using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace VagrantWin
{
    internal class VagratWrapper
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

        public string CurrentCommand { get; private set; }

        private Process StartVagrantProcess(string vagrantFilePath, string command)
        {
            var workDirectory = "";
            if (File.Exists(vagrantFilePath))
            {
                workDirectory = Path.GetDirectoryName(vagrantFilePath);
            }
            else if (Directory.Exists(vagrantFilePath))
            {
                workDirectory = vagrantFilePath;
            }

            var process = new Process
            {


                StartInfo =
                {
                    FileName = Environment.GetEnvironmentVariable("ComSpec")  ?? "",
                    WorkingDirectory = workDirectory ?? "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    Arguments = "/c vagrant " + command,
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

        public async void StartVagrantProcessAsync(string vagrantFilePath, string command)
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
                OnVagrantProcessCompleted();
            }   
        }
    }
}