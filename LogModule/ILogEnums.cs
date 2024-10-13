using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.LogModule
{
    public interface ILogEnums
    {
        private const int MSG_NORMAL = 0;
        private const int MSG_ERROR = 1;
        private const int MSG_WARNING = 2;
        private const int FONT_BOLD = 3;
        private const int FONT_ITALIC = 4;

        private const int FORMAT_STR = 5;

        public static int normalCode() => MSG_NORMAL;
        public static int errCode() => MSG_ERROR;
        public static int warnCode() => MSG_WARNING;
        public static int boldCode() => FONT_BOLD;
        public static int italicCode() => FONT_ITALIC;
        public static int formatStrCode() => FORMAT_STR;

        public static bool isError(int code)
        {
            return code == MSG_ERROR;
        }

        public static bool isWarning(int code)
        {
            return code == MSG_WARNING;
        }
    }
}
