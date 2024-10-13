using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example2.SupportClasses;
using Example2.MapModule;
using Example2.RuleModule;
using ZuluLib;


namespace Example2.ExportModule
{
    internal abstract class Exporter : RootClass
    {
        public const string DELIMETR = "\\";
        public const string FILE_DXF = ".dxf";

        protected MyLayer layer;
        protected string themeName;
        protected string exportType = "";
        protected MyLayer pptBorderLayer;
        protected int[] pptSelectedObjects;
        protected List<string> byRefFields;
        protected List<string> annotationExport;


        private IZSqlResult selectedPPT;
        protected MapDoc map;

        protected ISampleNets nets;
        protected Rules rules;
        protected ZB.ZbDatabase db;
        protected string net;
        protected string pathConfFile = "";
        protected string exportPath = "";

        protected TreeNode groupConditRules;
        protected BorderInterator ZoneInterator;
        protected Dictionary<string, List<string>> excludedTypes;


        protected int stage;
        public const int STAGE_SELECTION = 1;
        public const int STAGE_EXPORT = 2;

        protected const int MODE_NET = 1;
        protected const int MODE_TYPE = 2;
        protected const int MODE_MODE = 3;


        public abstract void run();

        public abstract string[] getFileTypes();

        public void setGroupConditionRules(TreeNode tree)
        {
            groupConditRules = tree;
        }

        /*   protected void moveFirstPPTBorder()
           {
               selectedPPT.DataSet.MoveFirst();
           }*/

        public void setAnnotationExport(List<string> anno)
        {
            annotationExport = anno;
        }

        public void setMap(MapDoc map)
        {
            this.map = map;
        }

        public void setStage(int stage)
        {
            this.stage = stage;
        }

        /*    protected void initPptObjects()
            {
                Layer l = pptBorderLayer.getZuluLayer();
                IZSqlResult result = l.ExecSQL("SELECT Sys FROM [" + l.UserName + "]");
                if (result != null && result.RetCode == 0 && result.DataSet.MoveFirst())
                {
                    selectedPPT = result;
                } else
                {
                    throw new Exception("Не существует слоя с границами зон, либо слой пустой!");
                }
            }*/

        /*   protected (String, bool) getCurrentPPTObject()
           {
               return (selectedPPT.DataSet.FieldValue[0], selectedPPT.DataSet.MoveNext());
           }*/

        public void setByRefFields(List<string> byRefFields)
        {
            this.byRefFields = byRefFields;
        }

        public void setNets(ISampleNets nets)
        {
            this.nets = nets;
        }

        public void setPptLayer(MyLayer layer)
        {
            pptBorderLayer = layer;
            //   initPptObjects();
            // ZoneInterator = new BorderInterator(layer.getZuluLayer());            
        }

        public void setPptInterator(BorderInterator interator)
        {
            ZoneInterator = interator;
        }

        public void setRules(Rules rules)
        {
            this.rules = rules;
        }

        public void setLayer(MyLayer layer)
        {
            this.layer = layer;
            db = layer.getDb();
            net = layer.getNetName();
        }

        public void setExportPath(string path)
        {
            exportPath = path;
        }

        public void setTypeFile(string typeFile)
        {
            exportType = typeFile;
        }

        public void setExportConfFile(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                pathConfFile = pathFile;
            }
            else
            {
                messageC("Файл конфигурации не существует! pathFile => " + pathFile, new int[] { errCode(), boldCode() });
            }
        }

        public void setThemeExport(string themeName)
        {
            this.themeName = themeName;
        }

        public void createDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        protected string cleanString(string str)
        {
            return str.Replace("\"", "").Trim();
        }

        public void setPptSelectedObjects(int[] sysId)
        {
            pptSelectedObjects = sysId;
        }

        public void setExcludedTypes(Dictionary<string, List<string>> excludedTypes)
        {
            this.excludedTypes = excludedTypes;
        }
    }
}
