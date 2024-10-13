using ZuluLib;
using ZB;
using System.Collections.Generic;
using Example2.LogModule;
using Example2.MapModule;
using Example2.RuleModule;
using Example2.ExportModule.TypeModule;

namespace Example2
{
    public partial class Form1 : Form
    {
        private ILog log;

        private ISampleNets nets;
        private Dictionary<String, MyLayer> layers;
       
        private MapDoc map;
        private Rules rules;
        private bool mapExist;
        private bool samplNetExist;
        private String rootPath;
        private String themeName;

        private Settings settings;

        public Form1()
        {
            InitializeComponent();
            
            log = new LogClass(LogRichTextBox);
            layers = new Dictionary<string, MyLayer>();
            map = new MapDoc();

            RootClass.OnLogMessage += OnLogMessage;
            MyRootControl.OnLogMessage += OnLogMessage;

            settings = new Settings();
            if (settings.lastMapPath != null) {
                mapControl1.setLastMap(settings.lastMapPath); 
            }

            if (settings.sampleNets != null) {
                mapControl1.setSampleNets(settings.sampleNets);
            }

            mapControl1.OnOpenMap += OnOpenMap;
            mapControl1.OnOpenSampleNets += OnOpenSampleNets;
            mapControl1.OnInitLayers += OnInitLayers;

            exportControl1.OnExportComplete += OnExportComplete;
        }

        private void OnOpenMap(MapDoc map)
        {
            this.map = map;
            checkControl2.setMap(map);
            exportControl1.setMap(map);

            settings.lastMapPath = mapControl1.getLastMap();
            settings.sampleNets = mapControl1.getSampleNets();
            settings.saveToFile();

            log.mess("ÊÀÐÒÀ => " + map.Name);
        }

        private void OnOpenSampleNets(ISampleNets nets)
        {
            this.nets = nets;
            checkControl2.setSampleNets(this.nets);
            ruleControl2.setSampleNets(this.nets);
            ruleControl2.setMapPath(map.PathName);
        }

        private void OnInitLayers(Dictionary<String, MyLayer> layers)
        {
            this.layers = layers;
            String[] keys = layers.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                log.mess(layers[keys[i]].getZuluLayer().Name);
            }

            checkControl2.setLayers(layers);
            ruleControl2.setLayers(layers);

            exportControl1.setBorderLayer(settings.borderLayer);
            exportControl1.setCfgFile(settings.cfgFile);
            exportControl1.setExportPath(settings.exportPath);
            exportControl1.setGroupRulesFile(settings.groupRules);
            exportControl1.setTheme(settings.theme);
            exportControl1.setExportExtension(settings.exportExtension);
            exportControl1.setSelectedPptObjects(settings.strToArr(settings.selectedBorderObjects));
            exportControl1.setDictionaryFields(settings.strToArrStr(settings.dictionaryFields));
            exportControl1.setAnnotationExport(settings.strToArrStr(settings.annotationExport));
       //     List<GroupFilter> wer = settings.getTypeExportParams();
      //      exportControl1.setTypeExpGroupFilters(wer);
            
            Dictionary<String, Dictionary<String, List<String>>> l = settings.getExcludesTypes();
            String[] k1 = l.Keys.ToArray();
            for (int i = 0; i < k1.Length; i++)
            {
                log.mess(k1[i]); 
                Dictionary<String, List<String>> t = l[k1[i]];
                String[] k2 = t.Keys.ToArray();
                for (int j = 0; j < k2.Length; j++)
                {
                    log.mess(k2[j]);
                    List<String> list = t[k2[j]];
                    for (int m = 0; m < list.Count; m++)
                    {
                        log.mess(list[m]);
                    }
                }
            }

            exportControl1.setExcludesTypes(l);

            exportControl1.setLayers(layers);
        }

        private void saveSettings()
        {
            settings.cfgFile = exportControl1.getCfgFile();
            settings.borderLayer = exportControl1.getBorderLayer();
            settings.exportExtension = exportControl1.getExportExtension();
            settings.theme = exportControl1.getTheme();
            settings.exportPath = exportControl1.getExportPath();
            settings.groupRules = exportControl1.getGroupRulesFile();
            settings.selectedBorderObjects = settings.arrToStr(exportControl1.getSelectedPptObjects());
            settings.dictionaryFields = settings.arrToStr(exportControl1.getDictionaryFields());
            settings.annotationExport = settings.arrToStr(exportControl1.getAnnotationExport());
       //     List<GroupFilter> filters =  exportControl1.getTypeExpGroupFilters();
       //     settings.setTypeExportParams(filters);

            Dictionary<String, Dictionary<String, List<String>>> l = exportControl1.getExcludesTypes();
            String[] k1 = l.Keys.ToArray();
            for (int i = 0; i < k1.Length; i++)
            {
                log.mess(k1[i]);
                Dictionary<String, List<String>> t = l[k1[i]];
                String[] k2 = t.Keys.ToArray();
                for (int j = 0; j < k2.Length; j++)
                {
                    log.mess(k2[j]);
                    List<String> list = t[k2[j]];
                    for (int m = 0; m < list.Count; m++)
                    {
                        log.mess(list[m]);
                    }
                }
            }
            settings.setExcludesTypes(l);

            settings.saveToFile();
        }

        private void OnExportComplete()
        {
            saveSettings();
        }


        private void OnLogMessage(String message, int[] code)
        {
            log.mess(message, code);
        }    
        
    }
}