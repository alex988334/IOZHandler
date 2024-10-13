using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.LogModule
{
    internal class LogClass : ILog
    {
        private RichTextBox textBox;

        public LogClass(RichTextBox textBox)
        {
            this.textBox = textBox;
        }

        public string formatStr(string msg)
        {
            return formatStr(msg, ILog.DEFAULT_MESS_LENGTH);
        }

        public string formatStr(string msg, short lenStr)
        {
            int r = msg.Length / lenStr;

            for (int j = 0; j < r; j++)
            {
                int posit = msg.IndexOf(ILog.DELIMETR_SPACE, lenStr * (j + 1));
                msg.Insert(posit, "/n");
            }
            return msg;
        }

        public void mess(string msg)
        {
            textBox.SelectionColor = Color.Black;
            textBox.SelectionFont = new Font(textBox.Font, FontStyle.Regular);
            textBox.AppendText(msg + "\n");
        }

        public void mess(string msg, short code)
        {
            if (code == ILog.ERROR_MESSAGE)
            {
                textBox.SelectionColor = Color.Red;
            }
            if (code == ILog.WARNING_MESSAGE)
            {
                textBox.SelectionColor = Color.Orange;
            }
            if (code == ILog.BOLT_MESSAGE)
            {
                textBox.SelectionFont = new Font(textBox.Font, FontStyle.Bold);
            }

            textBox.AppendText(msg + "\n");
            //textBox.Scro
        }

        public void mess(string msg, int[] codes)
        {
            foreach (int code in codes)
            {
                if (ILogEnums.isError(code))
                {
                    textBox.SelectionColor = Color.Red;
                }
                if (ILogEnums.isWarning(code))
                {
                    textBox.SelectionColor = Color.Orange;
                }
                if (code == ILogEnums.boldCode())
                {
                    textBox.SelectionFont = new Font(textBox.Font, FontStyle.Bold);
                }
                if (code == ILogEnums.italicCode())
                {
                    textBox.SelectionFont = new Font(textBox.Font, FontStyle.Italic);
                }

                if (code == ILogEnums.formatStrCode())
                {
                    msg = formatStr(msg);
                }

            }
            textBox.AppendText(msg + "\n");
        }
    }
}
