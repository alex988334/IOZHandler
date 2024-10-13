using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZuluLib;
using ZB;
using Example2.MapModule;


namespace Example2
{
    public class MyLayer: RootClass
    {
        private Layer layer;
        private ZbDatabase db;
        private ISampleNets sampleNets;
        private String name;
        private String netName;
        private int etap;

        public MyLayer(Layer layer, ISampleNets sample)
        {
            this.sampleNets = sample;
            
            this.layer = layer;
            db = new ZbDatabase();
            name = preparelayerName();
            messageC("Обработка слоя: " + name, new int[] {boldCode()});
            findEtapName();
            if (etap == 0)
            {
                messageC("Не найден этап в названии слоя!", new int[] {warnCode()});
            } else
            {
                message("Этап из названия слоя: " + etap.ToString());
            }
            
            prepareNetName();
        }

        public String[] getThemes()
        {
            List<String> result = new List<String>();
            for (int i = 0; i < layer.Themes.Count; i++)
            {
                result.Add(layer.Themes.ThemeUserName[i]);
            }
            
            return result.ToArray();
        }

        private String preparelayerName()
        {
            String[] args = layer.Name.Split("\\");
            if (args.Length == 1)
            {
                args = layer.Name.Split("/");
            }
            args = args[args.Length - 1].Split(".");            
            return args[0];
        }

        private void prepareNetName()
        {
            netName = sampleNets.findNet(name);
        }
        

        public ZbDatabase getDb()
        {            
            return db;
        }

        public IBaseInfo getBase(String typeName)
        {
            for (int i = 0; i < layer.Bases.Count; i++)
            {
                int k = String.Compare(layer.Bases[i].UserName, typeName, StringComparison.OrdinalIgnoreCase);
                if (k == 0)
                {
                    return layer.Bases[i];
                }
            }

            throw new Exception("Не найдена база данных!!!");
        }

        public Layer getZuluLayer()
        {
            return layer;
        }


        private void findEtapName()
        {
            String[] findKeys = { "Этап", "этап", "Etap", "etap", "Et", "et", "Эт", "эт" };
            for (int i = 0; i < findKeys.Length; i++)
            {
                int ind = name.IndexOf(findKeys[i]);
                if (ind > -1)
                {
                    etap = extractEtap(findKeys[i], ind);                    
                    
                    break;
                }
            }
                      
        }

        private int extractEtap(String key, int findedIndex)
        {
            int sI = findedIndex;
            int stInd = -1, enInd = -1;

            while (sI > 0)
            {
                sI = sI - 1;                
                double d = Char.GetNumericValue(name[sI]);
                
                if (d >= 0.0 && enInd < 0)
                {
                    enInd = sI;
                } 
                if (d < 0.0 && enInd > 0)
                {
                    stInd = sI + 1;
                    break;
                }
            }

            if (stInd >= 0 && enInd >= 0)
            {
                return Int32.Parse(name.Substring(stInd, enInd - stInd + 1));
            }

            stInd = -1;
            enInd = -1;
            sI = findedIndex + key.Length - 1;
            while (sI > 0 && sI < name.Length - 1)
            {
                ++sI;
                double d = Char.GetNumericValue(name[sI]);
                if (d >= 0.0 && stInd < 0)
                {
                    stInd = sI;
                }
                if (d < 0.0 && stInd > 0)
                {
                    enInd = sI - 1;
                    break;
                }
            }

            if (stInd >= 0 && enInd >= 0)
            {
                return Int32.Parse(name.Substring(stInd, enInd - stInd + 1));
            }

            return 0;
        }

        public void checkLayer(bool checkStruct, bool checkData)
        {            
            if (checkStruct)
            {
                checkStructLayer();
            }
            
            if (checkData)
            {
                checkSamleData();
            }      
        }

        private void checkSamleData()
        {
            throw new NotImplementedException("Не реализовано! checkSamleData");
        }

        public String getNetName()
        {
            return netName;
        }

        public String getName()
        {
            return name;
        }

        private void checkStructLayer()
        {
            String[] nameTypes = sampleNets.getTypesNames(netName);
            bool printDBName = false;

            foreach (String typeName in nameTypes)
            {
                bool findFlag = false;
                for (int i = 0; i < layer.Bases.Count; i++)
                {
                    BaseInfo b = layer.Bases[i];
                    if (typeName.Equals(b.UserName, StringComparison.OrdinalIgnoreCase))
                    {
                        findFlag = true;

                        if (db.Open(b.Name))
                        {
                            existAttrs(i);
                        }
                        else
                        {
                            messageC("Не удалось открыть базу данных для типа: '" + b.UserName + "'", 
                                    new int[] {errCode()});
                        }
                    }
                }
                if (!findFlag)
                {
                    messageC("Не найден тип : '" + typeName + "' в слое " + name, 
                            new int[] { errCode() });
                    printDBName = true;
                }
            }
            if (printDBName)
            {
                messageC("Список бд в слое: ", new int[] { boldCode() });
                messageC(getNamesDB(), new int[] { formatStrCode() });
            }            
        }

        private String getNamesDB()
        {
            String bases = "";
            for (int i = 0; i < layer.Bases.Count; i++)
            {
                bases = bases + "\"" +  layer.Bases[i].UserName + "\", ";
            }
            return bases;
        }

        public ObjectTypes getTypes()
        {
            return layer.ObjectTypes;
        }

        public List<String> getAnnotationList()
        {
            List<String> list = new List<String>();

            for (int i = 0; i < layer.LabelLayers.Count; i++)
            {
                list.Add(layer.LabelLayers[i].UserName);
            }

            return list;
        }


        private void existAttrs(int indexDb)
        {
            BaseInfo b = layer.Bases[indexDb];
            List<String> attr = sampleNets.getAttrsforType(netName, b.UserName);

            int fieldCount = db.ActiveQuery.VisualQuery.Fields.Count;
            IZbFields fields = db.ActiveQuery.VisualQuery.Fields;
            bool printAttrs = false;
            for (int i = 0; i < attr.Count; i++)
            {
                bool findField = false;
                for (int j = 0; j < fieldCount; j++)
                {
                    if ((db.ActiveQuery.VisualQuery.Fields[j].Name).Equals(attr[i].ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        findField = true;
                    }
                }
                if (!findField)
                {
                    messageC("Не найдено поле: \"" + attr[i].ToString() + "\" в базе данных: " + b.UserName, 
                            new int[] { errCode() });
                    printAttrs = true;
                }
            }

            if (printAttrs)
            {
                String msg = "";
                for (int i = 0; i < db.ActiveQuery.VisualQuery.Fields.Count; i++)
                {
                    msg = msg + "\"" + db.ActiveQuery.VisualQuery.Fields[i].Name + "\", ";
                }

                messageC("Список полей в базе данных для типа \"" + b.UserName + "\":", new int[] {boldCode()});
                messageC(msg, new int[] {formatStrCode()});
            }            
        }        
    }
}
