using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace VagrantWin
{
    public class VagrantWrapper
    {
        private Process _currentProcess;

        public event EventHandler<VagrantMessageEventHandler> OutputMessageReceived;

        protected virtual void OnOutputMessageReceived(string message)
        {
            var handler = OutputMessageReceived;
            if (handler != null) handler(this, new VagrantMessageEventHandler(message));
        }

        public event EventHandler<VagrantMessageEventHandler> ErrorMessageReceived;

        protected virtual void OnErrorMessageReceived(string message)
        {
            var handler = ErrorMessageReceived;
            if (handler != null) handler(this, new VagrantMessageEventHandler(message));
        }

        public event EventHandler VagrantProcessStarted;

        protected virtual void OnVagrantProcessStarted()
        {
            var handler = VagrantProcessStarted;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public event EventHandler VagrantProcessCompleted;

        protected virtual void OnVagrantProcessCompleted()
        {
            var handler = VagrantProcessCompleted;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public VagrantCommand CurrentCommand { get; private set; }

        private Process StartVagrantProcess(string vagrantFilePath, string commandString)
        {
            var workDirectory = File.Exists(vagrantFilePath)
                ? Path.GetDirectoryName(vagrantFilePath)
                : Directory.Exists(vagrantFilePath) ? vagrantFilePath 
                : "";

            var process = new Process
            {
                StartInfo =
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec") ?? "",
                    WorkingDirectory = workDirectory ?? "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = "/c vagrant " + commandString,
                }
            };
            process.OutputDataReceived += (_, e) =>
            {
                if (e.Data == null) return;
                OnOutputMessageReceived(e.Data);
            };
            process.ErrorDataReceived += (s, e) =>
            {
                if (e.Data == null) return;
                OnErrorMessageReceived(e.Data);
            };
            //ŽÀs
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return process;
        }

        public static string ToCommandString(VagrantCommand command)
        {
            return command.ToString().ToLower() + (command == VagrantCommand.Destroy ? " -f" : "");
        }

        public async void ExecuteVagrantCommandAsync(string vagrantFilePath, VagrantCommand command)
        {
            CurrentCommand = command;

            await StartVagrantProcessAsync(vagrantFilePath, ToCommandString(command));
        }

        private async Task StartVagrantProcessAsync(string vagrantFilePath, string commandStr)
        {
            using (var process = StartVagrantProcess(vagrantFilePath, commandStr))
            {
                OnVagrantProcessStarted();
                _currentProcess = process;
                await Task.Run(() => process.WaitForExit());
                _currentProcess = null;
                OnVagrantProcessCompleted();
            }
        }

        public void CancelCurrentVagrantProcess()
        {
            if (_currentProcess != null)
            {
                _currentProcess.CancelErrorRead();
                _currentProcess.CancelOutputRead();
                _currentProcess.Close();

                _currentProcess = null;
                OnVagrantProcessCompleted();
            }   
        }

        public static VagrantCommand ToCommand(string commandName)
        {
            VagrantCommand ret;
            if (Enum.TryParse(commandName,true, out ret))
            {
                return ret;
            }

            return VagrantCommand.Empty;
        }

        public async void AddBoxAsync(string vagrantFilePath, string boxName, string boxUri)
        {
            CurrentCommand = VagrantCommand.Box;
            await StartVagrantProcessAsync(vagrantFilePath, string.Format("box add {0} {1}", boxName, boxUri));
        }

        public async void ListBoxAsync(string vagrantFilePath)
        {
            CurrentCommand = VagrantCommand.Box;
            await StartVagrantProcessAsync(vagrantFilePath, string.Format("box list"));
        }

        public async void RemoveBoxAsync(string vagrantFilePath, string boxName)
        {
            CurrentCommand = VagrantCommand.Box;
            await StartVagrantProcessAsync(vagrantFilePath, string.Format("box remove {0}",boxName));
        }

        public async void InitWithBoxNameAsync(string vagrantFilePath, string boxName)
        {
            CurrentCommand = VagrantCommand.Init;
            await StartVagrantProcessAsync(vagrantFilePath, string.Format("init {0}", boxName));
        }
    }
}