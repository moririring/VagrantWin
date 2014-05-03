using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagrantWin
{
    public class MessageBoxReplacer
    {
        private readonly IWindowMessageHook _hook;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll", EntryPoint = "PostMessageA")]
        static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"), DllImport("user32.dll")]
        static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass"),
         DllImport("user32.dll")]
        private static extern int MoveWindow(IntPtr hWnd, int x, int y, int w, int h, int repaint);
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }
        const int WM_APP = 0x8000;
        const int WM_APP_CENTERMSG = WM_APP;

        public MessageBoxReplacer(IWindowMessageHook hook)
        {
            _hook = hook;

            _hook.WindowMessageReceived += (sender, args) =>
            {
                var senderForm = args.SrcForm;
                if (senderForm == null)
                {
                    return;
                }
                if (args.Message.Msg != WM_APP_CENTERMSG)
                {
                    return;
                }

                var hWnd = GetForegroundWindow();
                if (hWnd == senderForm.Handle)
                {
                    return;
                }

                var r = new RECT();
                GetWindowRect(hWnd, ref r);
                var w = r.right - r.left;
                var h = r.bottom - r.top;
                var x = senderForm.Left + (senderForm.Width - w)/2;
                var y = senderForm.Top + (senderForm.Height - h)/2;
                MoveWindow(hWnd, x, y, w, h, 0);
            };
        }

        public void ReplaceNextMessageBoxPosition()
        {
            PostMessage(_hook.Handle, WM_APP_CENTERMSG, 0, IntPtr.Zero);
        }
    }

    public interface IWindowMessageHook
    {
        event EventHandler<WindowMessageEventArgs> WindowMessageReceived;

        IntPtr Handle { get; }
    }

    public class WindowMessageEventArgs
    {
        private readonly Message _message;

        private readonly Form _srcForm;

        public WindowMessageEventArgs(Message message, Form srcForm)
        {
            _message = message;
            _srcForm = srcForm;
        }

        public Message Message
        {
            get { return _message; }
        }

        public Form SrcForm
        {
            get { return _srcForm; }
        }
    }
}
