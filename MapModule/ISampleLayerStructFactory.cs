using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.MapModule
{
    internal interface ISampleLayerStructFactory
    {

        public Dictionary<string, Dictionary<string, List<string>>> createLayerStruct(string pathFile);
    }
}
