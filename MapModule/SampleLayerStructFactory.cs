using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.SupportClasses;

namespace Example2.MapModule
{
    internal class SampleLayerStructFactory : RootClass, ISampleLayerStructFactory
    {
        private Dictionary<string, Dictionary<string, List<string>>> rezult;
        public const string DELIMETER_STR = ";";

        public SampleLayerStructFactory()
        {
            rezult = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        private Dictionary<string, Dictionary<string, List<string>>> GetStructFromCSV(string pathFile)
        {
            string[]? mass = readSampleFile(pathFile);
            if (mass == null)
            {
                throw new Exception("Файл шаблона слоя пустой: " + pathFile);
            }

            setNetsKeys(mass);
            setNetTypesKeys(mass);
            setTypesAttr(mass);

            return rezult;
        }

        private void setTypesAttr(string[] args)
        {
            foreach (string netKey in rezult.Keys)
            {
                foreach (string typeKey in rezult[netKey].Keys)
                {
                    string k = netKey + DELIMETER_STR + typeKey;

                    for (int i = 0; i < args.Length; i++)
                    {
                        if (args[i].CompareTo(k) == 0)
                        {
                            string[] attr = args[i + 1].Split(DELIMETER_STR);
                            for (int j = 0; j < attr.Length; j++)
                            {
                                rezult[netKey][typeKey].Add(attr[j]);
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void setNetTypesKeys(string[] args)
        {
            foreach (string key in rezult.Keys)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].CompareTo(key) == 0)
                    {
                        string[] types = args[i + 1].Split(DELIMETER_STR);
                        foreach (string type in types)
                        {
                            rezult[key][type] = new List<string>();
                        }
                        break;
                    }
                }
            }
        }


        private void setNetsKeys(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].CompareTo(EnumNetKeys.NETS) == 0)
                {
                    string[] nets = args[i + 1].Split(DELIMETER_STR);
                    foreach (string elem in nets)
                    {
                        rezult[elem] = new Dictionary<string, List<string>>();
                    }
                    return;
                }
            }
        }


        private string[]? readSampleFile(string path)
        {
            string[] res = null;
            try
            {
                res = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось прочесть файл шаблона слоя: " + path + "\n" + e.Message);
            }
            return res;
        }

        public Dictionary<string, Dictionary<string, List<string>>> createLayerStruct(string pathFile)
        {

            GetStructFromCSV(pathFile);
            return rezult;
        }
    }
}
