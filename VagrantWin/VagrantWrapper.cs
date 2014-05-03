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

        private Process StartVagrantProcess(string vagrantFilePath, VagrantCommand command)
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec")  ?? "",
                    WorkingDirectory = Path.GetDirectoryName(vagrantFilePath) ?? "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = "/c vagrant " + ToCommandString(command),
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

        public async void StartVagrantProcessAsync(string vagrantFilePath, VagrantCommand command)
        {
            CurrentCommand = command;

            using (var process = StartVagrantProcess(vagrantFilePath, CurrentCommand))
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
    }

    public enum VagrantCommand
    {
        Empty,
        Status,
        Up,
        Provision,
        Halt,
        Destroy
    }
}