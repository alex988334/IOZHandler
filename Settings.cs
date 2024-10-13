using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Example2.ExportModule.TypeModule;
using System.Runtime.Serialization;

namespace Example2
{
    internal class Settings: RootClass
    {
        public String lastMapPath;
        public String sampleNets;
        public String exportPath;
        public String borderLayer;
        public String theme;
        public String cfgFile;        
        public String groupRules;
        public String exportExtension;
        public String selectedBorderObjects;
        public String dictionaryFields;
        public String annotationExport;
        public String excludesTypes;
        public String typeExportParams;

        private bool loaded;
        private String delimeter = "=";
        private String settingsFile = Application.StartupPath + "\\Settings.cfg";
        private String separator = ";";
        

        public Settings()
        {
            loadFromFile();
        }

        public void saveToFile()
        {
            try
            {
                StreamWriter w = new StreamWriter(settingsFile, false);
                w.WriteLine(this.ToString());
                w.Close();
            }
            catch (Exception e)
            {
                messageC("Записать настройки в файл не удалось! Путь сохранения: " + settingsFile, new int[] {errCode()});
            }
        }

        public override String ToString()
        {
            String line = nameof(lastMapPath) + delimeter + lastMapPath + "\n";
            if (sampleNets != null) line = line + nameof(sampleNets) + delimeter + sampleNets + "\n";
            if (exportPath != null) line = line + nameof(exportPath) + delimeter + exportPath + "\n";
            if (borderLayer != null) line = line + nameof(borderLayer) + delimeter + borderLayer + "\n";
            if (theme != null) line = line + nameof(theme) + delimeter + theme + "\n";
            if (cfgFile != null) line = line + nameof(cfgFile) + delimeter + cfgFile + "\n";
            if (groupRules != null) line = line + nameof(groupRules) + delimeter + groupRules + "\n";
            if (exportExtension != null) line = line + nameof(exportExtension) + delimeter + exportExtension + "\n";
            if (selectedBorderObjects != null && selectedBorderObjects.Length > 0) line = line + nameof(selectedBorderObjects) + delimeter + selectedBorderObjects + "\n";
            if (dictionaryFields != null && dictionaryFields.Length > 0) line = line + nameof(dictionaryFields) + delimeter + dictionaryFields + "\n";
            if (annotationExport != null && annotationExport.Length > 0) line = line + nameof(annotationExport) + delimeter + annotationExport + "\n";
            if (excludesTypes != null && excludesTypes.Length > 0) line = line + nameof(excludesTypes) + delimeter + excludesTypes + "\n";
         //   if (typeExportParams != null && typeExportParams.Length > 0) line = line + nameof(typeExportParams) + delimeter + typeExportParams + "\n";

            return line;
        }

        public void loadFromFile()
        {
            loadFromFile(settingsFile);
        }  

        public String arrToStr(int[] objects)
        {
            String st = "";
            
                for (int i = 0; i < objects.Length; i++) {
                    if (i == objects.Length - 1)
                    {
                        st = st + objects[i];
                    } else
                    {
                        st = st + objects[i] + separator;
                    }                    
                }
            return st;
        }

        public String arrToStr(List<String> objects)
        {
            String st = "";

            for (int i = 0; i < objects.Count; i++)
            {
                if (i == objects.Count - 1)
                {
                    st = st + objects[i];
                }
                else
                {
                    st = st + objects[i] + separator;
                }
            }
            return st;
        }

        public void setTypeExportParams(List<GroupFilter> list)
        {
            String jsonStr = "";
            for (int i = 0; i < list.Count; i++)
            {
                jsonStr += list[i].serializeJSON();
                if (i < list.Count - 1)
                {
                    jsonStr += ",";
                }
            }

            jsonStr = "[" + jsonStr + "]";

            this.typeExportParams = jsonStr;

           // this.typeExportParams = JsonSerializer.Serialize<List<GroupFilter>>(list);
        }

     /*   public List<GroupFilter> getTypeExportParams()
        {
            if (typeExportParams == null || typeExportParams.Length == 0)
            {
                return new List<GroupFilter>();
            }


            return deserializeTypeExportParams();
        }*/

   /*     private List<GroupFilter> deserializeTypeExportParams()
        {
            List<GroupFilter> filters = new List<GroupFilter>();
            

            if (typeExportParams.Length == 2)
            {
                return filters;
            }

            if (typeExportParams[0].CompareTo("[".ToCharArray()[0]) != 0 
                    || typeExportParams[typeExportParams.Length - 1].CompareTo("]".ToCharArray()[0]) != 0)
            {
                throw new JsonException("Невозможно преобразовать JSON строку в коллекцию объектов, строка: "
                        + typeExportParams);
            }

            String jsonStr = typeExportParams.Substring(1, typeExportParams.Length - 2);

            List<String> objs = new List<String>();
            bool findedStart = false;
            bool findedEnd = false;
            do
            {

            } while (findedEnd);
        }*/

      /*  private T deserializeObject<T>(String typeName, String json) where T : GroupFilter
        {            
            switch (typeName)
            {
                case "GroupFilter":
                    GroupFilter filter = new GroupFilter();


                    break;
                default:
                    throw new JsonException("В конвертере не реализовано преобразование в тип " + typeName);
                    break;
            }
        }*/




        public Dictionary<String, Dictionary<String, List<String>>> getExcludesTypes()
        {
            if (excludesTypes == null || excludesTypes.Length == 0)
            {
                return new Dictionary<String, Dictionary<String, List<String>>>();
            }

            return JsonSerializer.Deserialize<Dictionary<String, Dictionary<String, List<String>>>>(excludesTypes);
        }


        public void setExcludesTypes(Dictionary<String, Dictionary<String, List<String>>> excludesTypes)
        {
            if (excludesTypes == null)
            {
                this.excludesTypes = JsonSerializer.Serialize(new Dictionary<String, Dictionary<String, List<String>>>());               
            } else
            {
                this.excludesTypes = JsonSerializer.Serialize(excludesTypes);
            }
        }


        public List<String> strToArrStr(String arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return new List<String>();
            }
            List<String> rez = new List<String>(arr.Split(separator));

            return rez;
        }

        public int[] strToArr(String arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return new int[] { };
            }

            String[] separated = arr.Split(separator);
            int[] result = new int[separated.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = int.Parse(separated[i]);
            }
            return result;
        }

        public void loadFromFile(String confFile)
        {
            if (!File.Exists(confFile))
            {
                loaded = false;
                File.Create(confFile);
                return;
            }

            String[] lines = null;
            lines = File.ReadAllLines(confFile);           

            if (lines.Length == 0)
            {
                loaded = false;
                return;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length == 0)
                {
                    continue;
                }
                String[] pairs = lines[i].Split(delimeter);
                
                if (pairs.Length != 2)
                {
                    messageC("В файле настроек обнаружен неверный параметр: " + lines[i] 
                            + ", в строке " + (i + 1), new int[] { errCode() });
                    continue;
                }
                pairs[0] = pairs[0].Trim();
                pairs[1] = pairs[1].Trim();

                if (pairs[0].Length == 0 || pairs[1].Length == 0)
                {
                    messageC("В файле настроек обнаружен неверный параметр: " + lines[i]
                            + ", в строке " + (i + 1), new int[] { errCode() });
                    continue;
                }

                if (nameof(this.lastMapPath).Equals(pairs[0]))
                {
                    lastMapPath = pairs[1];
                }
                if (nameof(this.exportPath).Equals(pairs[0]))
                {
                    exportPath = pairs[1];
                }
                if (nameof(this.borderLayer).Equals(pairs[0]))
                {
                    borderLayer = pairs[1];
                }
                if (nameof(this.theme).Equals(pairs[0]))
                {
                    theme = pairs[1];
                }
                if (nameof(this.cfgFile).Equals(pairs[0]))
                {
                    cfgFile = pairs[1];  
                }
                if (nameof(this.sampleNets).Equals(pairs[0]))
                {
                    sampleNets = pairs[1];
                }
                if (nameof(this.groupRules).Equals(pairs[0]))
                {
                    groupRules = pairs[1];
                }
                if (nameof(this.exportExtension).Equals(pairs[0]))
                {
                    exportExtension = pairs[1];
                }
                if (nameof(this.selectedBorderObjects).Equals(pairs[0]))
                {
                    selectedBorderObjects = pairs[1];
                }
                if (nameof(this.dictionaryFields).Equals(pairs[0]))
                {
                    dictionaryFields = pairs[1];
                }
                if (nameof(this.annotationExport).Equals(pairs[0]))
                {
                    annotationExport = pairs[1];
                }
                if (nameof(this.excludesTypes).Equals(pairs[0]))
                {
                    excludesTypes = pairs[1];
                }
                if (nameof(this.typeExportParams).Equals(pairs[0]))
                {
                    typeExportParams = pairs[1];
                }
            }

            loaded = true;
        }

        public bool isLoaded()
        {
            return loaded;
        }

    }
}
