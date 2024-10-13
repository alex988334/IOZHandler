using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.SupportClasses
{
    internal class ExceptionSQL : Exception
    {
        public ExceptionSQL(string msg) : base(msg) { }
    }
}
