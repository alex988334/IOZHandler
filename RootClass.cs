using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.LogModule;

namespace Example2
{
    public class RootClass : ILogEnums
    {
        public delegate void LogMessage(String message, int[] codes);
        public static event LogMessage OnLogMessage;

        public delegate void Message(String message);
        protected Message message;

        public delegate void MessageCode(String message, int[] codes);
        protected MessageCode messageC;

        public RootClass()
        {            
            message = msg;
            messageC = msg;
        //    addChildren = addChild;

        }

      /*  public void addChild(RootClass obj)
        {
            OnLogListenerAdd(obj);
        }*/

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

        public int formatStrCode()
        {
            return ILogEnums.formatStrCode();
        }
    }
}
