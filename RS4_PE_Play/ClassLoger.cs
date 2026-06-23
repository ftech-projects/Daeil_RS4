using System;
using System.Windows.Forms;

namespace ResisterTest.Managers
{
    public static class Logger
    {
        private static TextBox _targetTextBox;

        public static void Initialize(TextBox targetTextBox)
        {
            _targetTextBox = targetTextBox;
        }

        public static void Log(string message)
        {
            if (_targetTextBox == null) return;

            if (_targetTextBox.InvokeRequired)
            {
                _targetTextBox.Invoke(new Action(() => AppendMessage(message)));
            }
            else
            {
                AppendMessage(message);
            }
        }

        public static void Error(string message)
        {
            Log("[ERROR] " + message);
        }

        private static void AppendMessage(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            _targetTextBox.AppendText($"[{time}] {message}{Environment.NewLine}");
            _targetTextBox.SelectionStart = _targetTextBox.Text.Length;
            _targetTextBox.ScrollToCaret();
        }
    }
}
