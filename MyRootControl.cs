using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Example2.LogModule;

namespace Example2
{
    public partial class MyRootControl : UserControl, ILogEnums
    {
        public delegate void LogMessage(String message, int[] codes);
        public static event LogMessage OnLogMessage;

        public delegate void Message(String message);
        protected Message message;

        public delegate void MessageCode(String message, int[] codes);
        protected MessageCode messageC;     

        public MyRootControl()
        {
            InitializeComponent();
            message = msg;
            messageC = msg;           
        }
     
        public void msg(String message)
        {
            OnLogMessage(message, new int[] { ILogEnums.normalCode() });
        }

        public void msg(String message, int[] codes)
        {
            OnLogMessage(message, codes);
        }

        public int errCode()
        {
            return ILogEnums.errCode();
        }
        public int warnCode()
        {
            return ILogEnums.warnCode();
        }
        public int boldCode()
        {
            return ILogEnums.boldCode();
        }
        public int italCode()
        {
            return ILogEnums.italicCode();
        }

        public bool isErr(int code) 
        {
            return ILogEnums.isError(code);
        }

        public bool isWarn(int code)
        {
            return ILogEnums.isWarning(code);
        }

        
    }
}
