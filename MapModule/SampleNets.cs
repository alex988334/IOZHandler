using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Example2.MapModule
{
    internal class SampleNets : RootClass, ISampleNets
    {
        public const short MODE_CSV = 1;

        private Dictionary<string, Dictionary<string, List<string>>>? elements;

        public SampleNets(string pathFile, short mode)
        {
            if (mode == MODE_CSV)
            {
                SampleLayerStructFactory fact = new SampleLayerStructFactory();
                elements = fact.createLayerStruct(pathFile);
                return;
            }

            throw new Exception("Режим создания шаблона в классе SampleNets не найден! код режима " + mode.ToString());
        }


        public string[] getNetsKeys()
        {
            return elements.Keys.ToArray();
        }

        public override string ToString()
        {
            string str = "Загруженные параметры шаблона: {\n";

            foreach (string net in elements.Keys)
            {
                str = str + "\t" + net + " => {\n";
                foreach (string type in elements[net].Keys)
                {
                    str = str + "\t\t" + type + " => {\n" + "\t\t\t";
                    List<string> values = elements[net][type];
                    for (int i = 0; i < values.Count; i++)
                    {
                        str = str + /*"\t\t\t" +*/ values[i] + ", "/*",\n"*/;
                    }
                    str = str + "\t\t}\n";
                }
                str = str + "\t}\n";
            }
            str = str + "}\n";
            return str;
        }



        public string findNet(string layerName)
        {
            string[] keys = elements.Keys.ToArray();

            foreach (string net in keys)
            {
                if (layerName.Contains(net))
                {
                    return net;
                }
            }

            messageC("Тип сети не найден, слой: " + layerName, new int[] { warnCode() });
            return "";
        }

        public bool findType(string netName, string typeName)
        {
            if (elements[netName].ContainsKey(typeName))
            {
                return true;
            }
            return false;
        }


        public Dictionary<string, Dictionary<string, List<string>>> getNets()
        {
            return elements;
        }

        public Dictionary<string, List<string>> getNet(string netName)
        {
            return elements[netName];
        }

        public List<string> getAttrsforType(string netName, string typeName)
        {
            return elements[netName][typeName];
        }

        public string[] getTypesNames(string netName)
        {
            return elements[netName].Keys.ToArray();
        }
    }
}
