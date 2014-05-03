namespace VagrantWin
{
    public class VagrantMessageEventHandler
    {
        public VagrantMessageEventHandler(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}