using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2.MapModule
{
    public interface ISampleNets
    {
        public Dictionary<string, Dictionary<string, List<string>>> getNets();
        public string[] getTypesNames(string netName);
        public Dictionary<string, List<string>> getNet(string netName);
        public List<string> getAttrsforType(string netName, string typeName);
        public string ToString();

        public string findNet(string netName);
        public bool findType(string netName, string typeName);
    }
}
