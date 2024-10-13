using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.LogModule
{
    internal interface ILog : ILogEnums
    {
        public const short ERROR_MESSAGE = 1;
        public const short WARNING_MESSAGE = 2;
        public const short BOLT_MESSAGE = 3;
        public const short DEFAULT_MESS_LENGTH = 100;
        public const string DELIMETR_SPACE = " ";
        public void mess(string msg);
        public void mess(string msg, short code);
        public void mess(string msg, int[] codes);
        public string formatStr(string msg);
        public string formatStr(string msg, short lenStr);
    }
}
