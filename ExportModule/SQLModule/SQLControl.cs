using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static System.Windows.Forms.LinkLabel;
using ZuluLib;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Example2.ExportModule.SQLModule
{
    public partial class SQLControl : MyRootControl
    {
        public const String STAGE_INDEX = "etap";
        public const String ALIAS_NAME = "alias_name";
        public const String DEMONT_INDEX = "demontaj";
        public const String LAST_LAYER = "last_layer";
        public const String LAYER = "layer_name";
        public const String LOGIC_OPERATOR = "logic_operat";
        public const String FIELD = "filed_name";
        public const String DICTION = "diction";
        public const String FIELD_VALUE = "field_value";
        public const String FILTERS_GROUP = "filters_group";

        private String confFile;
        private String pathConf = "O:\\tmp_zulu\\";
       // private Dictionary<String, Dictionary<String, String>> parametrs;
        private Dictionary<String, Group> parametrs;
        public const String TAG_UNIT_OPEN = "<unit>";
        public const String TAG_UNIT_CLOSE = "</unit>";
        public const String TAG_GROUP_FILTER_OPEN = "<group filter>";
        public const String TAG_GROUP_FILTER_CLOSE = "</group filter>";
        public const String TAG_FILTER_OPEN = "<filter>";
        public const String TAG_FILTER_CLOSE = "</filter>";  

        public SQLControl()
        {
            InitializeComponent();
            //   parametrs = new Dictionary<String, Dictionary<String, String>>();
            parametrs = new Dictionary<String, Group>();
        }

        public void setLayers(String[] layers)
        {     
            if (parametrs == null)
            {
                parametrs = new Dictionary<String, Group>();
            }
            for (int i = 0; i < layers.Length; i++)
            {
                if (!parametrs.ContainsKey(layers[i])) 
                {
                    parametrs[layers[i]] = null;
                }                
            }                
            
            initLayersComboBox();
            initLastLayerComboBox();
        }

        private void initLastLayerComboBox()
        {
            lastLayerComboBox.SelectedIndex = -1;
            lastLayerComboBox.Items.Clear();
            lastLayerComboBox.Items.AddRange(parametrs.Keys.ToArray());
        }

        private void initLayersComboBox()
        {
            layerComboBox.SelectedIndex = -1;
            layerComboBox.Items.Clear();
            layerComboBox.Items.AddRange(parametrs.Keys.ToArray());
        }

        private void initIndexSqlTreeView()
        {
            String[] keys = parametrs.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++) 
            {
                TreeNode layer = new TreeNode(keys[i]);

                layer.Nodes.Add(new TreeNode());


              /*  layer.Nodes.Add(new TreeNode(STAGE_INDEX + ": " + parametrs[keys[i]][STAGE_INDEX]));
                layer.Nodes.Add(new TreeNode(ALIAS_NAME + ": " + parametrs[keys[i]][ALIAS_NAME]));
                layer.Nodes.Add(new TreeNode(DEMONT_INDEX + ": " + parametrs[keys[i]][DEMONT_INDEX]));
                layer.Nodes.Add(new TreeNode(LAST_LAYER + ": " + parametrs[keys[i]][LAST_LAYER]));*/

                indexSqlTreeView.Nodes.Add(layer);
            }
        }

        public /*Dictionary<String, Dictionary<String, String>>*/Dictionary<String, Group> getParametrs()
        {
            return parametrs;
        }

        public void setParams(Dictionary<String, Group> parametrs)
        {
            this.parametrs = parametrs;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (layerComboBox.SelectedIndex != -1)
            {
                parametrs.Remove((String)layerComboBox.SelectedItem);

                sqlViewerRichText.Clear();
                String[] keys = parametrs.Keys.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    if (parametrs[keys[i]] != null)
                    {
                        sqlViewerRichText.AppendText(keys[i] + " => " + parametrs[keys[i]].ToString());
                    }
                    
                }
            }
        }

        private void removeLayerNode(int index)
        {
            indexSqlTreeView.Nodes[index].Remove();
        }

        private int findLayerNode(String layerName)
        {
            for (int i = 0; i < indexSqlTreeView.Nodes.Count; i++)
            {
                if (indexSqlTreeView.Nodes[i].Text.Equals(layerName))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool securityAdd()
        {
            if (layerComboBox.SelectedIndex == -1)
            {
                messageC("Не выбран слой!", new int[] { errCode() });
                return false;
            }

            if (etapDictionaryTextBox.Text == null || etapDictionaryTextBox.Text.Length == 0)
            {
                messageC("Не указана сопоставляемая запись этапа из словаря!", new int[] { errCode() });
                return false;
            }

            if (fileAliasTextBox.Text == null || fileAliasTextBox.Text.Length == 0)
            {
                messageC("Не указано название псевдонима файла!", new int[] { errCode() });
                return false;
            }

          /*  if (demontajTextBox.Text == null || demontajTextBox.Text.Length == 0)
            {
                messageC("Не указан индекс принадлежности к демонтажу!", new int[] { errCode() });
                return false;
            }*/

            if (lastLayerComboBox.SelectedIndex == -1)
            {
                messageC("Не выбран слой существующих!", new int[] { errCode() });
                return false;
            }

            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (!securityAdd())
            {
                return;
            }

            addCollection();
            addIndexSQLTree();
        }

        private void addCollection()
        {
            String layer = (String) layerComboBox.SelectedItem;
            if (parametrs.ContainsKey(layer))
            {
                parametrs.Remove(layer);
            }
            parametrs[layer] = new Group("L1");
            parametrs[layer].setLayerName(layer);
            parametrs[layer].setStage(etapDictionaryTextBox.Text);
            parametrs[layer].setLastLayer((String)lastLayerComboBox.SelectedItem);
            parametrs[layer].setAliasName(fileAliasTextBox.Text);

            Dictionary<String, List<Filter>> list = groupFiltersControl1.getFilters();
            parametrs[layer].setFilters(list);

            /*  String layer = (String)layerComboBox.SelectedItem;
              if (!parametrs.ContainsKey(layer) || parametrs[layer] == null)
              {
                  parametrs[layer] = new Dictionary<string, string>();
              }

              parametrs[layer][STAGE_INDEX] = etapDictionaryTextBox.Text;
              parametrs[layer][ALIAS_NAME] = fileAliasTextBox.Text;
           //   parametrs[layer][DEMONT_INDEX] = demontajTextBox.Text;
              parametrs[layer][LAST_LAYER] = (String)lastLayerComboBox.SelectedItem;*/
        }

        private void addIndexSQLTree()
        {
            String layer = (String)layerComboBox.SelectedItem;
            sqlViewerRichText.AppendText(layer + " => " + parametrs[layer].ToString());
            /*  int ind = findLayerNode((String)layerComboBox.SelectedItem);
              if (ind != -1)
              {
                  removeLayerNode(ind);
              }
              String layName = (String)layerComboBox.SelectedItem;
              TreeNode layer = new TreeNode(layName);
              // layer.Nodes.Add(new TreeNode(STAGE_INDEX + ": " + etapDictionaryTextBox.Text));
              //  layer.Nodes.Add(new TreeNode(ALIAS_NAME + ": " + fileAliasTextBox.Text));
              //   layer.Nodes.Add(new TreeNode(DEMONT_INDEX + ": " + demontajTextBox.Text));

              layer.Nodes.Add(new TreeNode(parametrs[layName].ToString()));
            //  layer.Nodes.Add(new TreeNode(LAST_LAYER + ": " + (String)lastLayerComboBox.SelectedItem));

              indexSqlTreeView.Nodes.Add(layer);*/
        }

        private void loadCfgFile()
        {
            if (!File.Exists(confFile))
            {
                return;
            }

            String[] lines = File.ReadAllLines(confFile);

            if (lines.Length == 0)
            {                
                return;
            }
       
            deserializeParamerts(lines);
            sqlViewerRichText.Clear();
            String[] keys = parametrs.Keys.ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                sqlViewerRichText.AppendText(keys[i] + " => {\n" + parametrs[keys[i]].ToString() + "\n}\n");
            }

            //initIndexSqlTreeView();
        }

        private String serializeParametrs()
        {
            String str = "";
            String[] keys = parametrs.Keys.ToArray();           
            for (int i = 0; i < keys.Length; i++)
            {
                Group gr = parametrs[keys[i]];
                if (gr == null)
                {
                    continue;
                }
                str = str + TAG_UNIT_OPEN + "\n"
                    + LAYER + "=" + keys[i] + "\n"
                    + STAGE_INDEX + "=" + gr.getStage() + "\n"
                    + LAST_LAYER + "=" + gr.getLastLayer() + "\n"
                    + ALIAS_NAME + "=" + gr.getAliasName() + "\n";
                
                Dictionary<String, List<Filter>> filt = gr.getFilters();
                String[] filtKeys = filt.Keys.ToArray();
                for (int j = 0; j < filtKeys.Length; j++)
                {
                    str = str + TAG_GROUP_FILTER_OPEN + "\n"
                        + FILTERS_GROUP + "=" + filtKeys[j] + "\n";

                    for (int k = 0; k < filt[filtKeys[j]].Count; k++)
                    {
                        str = str + TAG_FILTER_OPEN + "\n"
                            + LOGIC_OPERATOR + "=" + filt[filtKeys[j]][k].logicOperator + "\n"
                            + FIELD + "=" + filt[filtKeys[j]][k].field + "\n"
                            + FIELD_VALUE + "=" + filt[filtKeys[j]][k].value + "\n"
                            + DICTION + "=" + filt[filtKeys[j]][k].dictionField + "\n"
                            + TAG_FILTER_CLOSE + "\n";
                    }
                    str = str + TAG_GROUP_FILTER_CLOSE + "\n";
                }
                str = str + TAG_UNIT_CLOSE + "\n\n";
            }
            return str;
        }

        private void deserializeParamerts(String[] args)
        {
            var en = args.GetEnumerator();            
            parametrs = null;
            String currentLayer = null;
            String currentGroup = null;
            Dictionary<String, List<Filter>> filters = null;
            Group group = null;
            Filter filter = null;
            while (en.MoveNext()) {          
                
                 String line = (String) en.Current;

              //  messageC(line, new int[] { errCode() });
                 if (line == null || line.Length == 0 )
                 {
                     continue;
                 }
                 if (line.Equals(TAG_UNIT_OPEN))
                 {
                     if (parametrs == null)
                     {
                         parametrs = new Dictionary<String, Group>();                         
                     }
                     group = new Group("L1");
                     filters = new Dictionary<String, List<Filter>>();
                     group.setFilters(filters);
                    continue;
                }
                 if (line.Contains(LAYER))
                 {
                     String[] pairs = line.Split("=");
                     currentLayer = pairs[1];
                     group.setLayerName(currentLayer);
                     parametrs[currentLayer] = group;
                     continue;
                 }
                 if (line.Contains(STAGE_INDEX))
                 {
                     String[] pairs = line.Split("=");
                     group.setStage(pairs[1]);
                     continue;
                 }
                 if (line.Contains(LAST_LAYER))
                 {
                     String[] pairs = line.Split("=");
                     group.setLastLayer(pairs[1]);
                     continue;
                 }
                if (line.Contains(ALIAS_NAME))
                {
                    String[] pairs = line.Split("=");
                    group.setAliasName(pairs[1]);
                    continue;
                }
                if (line.Equals(TAG_GROUP_FILTER_OPEN))
                 {
                   /* if (filters == null)
                    {
                        filters = new Dictionary<String, List<Filter>>();
                        group.setFilters(filters);
                    }  */
                     continue;
                 }
                if (line.Contains(FILTERS_GROUP))
                {
                    String[] pairs = line.Split("=");
                    currentGroup = pairs[1];
                    continue;
                }
                if (line.Equals(TAG_FILTER_OPEN))
                {
                    filter = new Filter();
                    if (!filters.ContainsKey(currentGroup))
                    {
                        filters[currentGroup] = new List<Filter>();
                    }
                    filters[currentGroup].Add(filter);
                    continue;
                }
                if (line.Contains(LOGIC_OPERATOR))
                {
                    String[] pairs = line.Split("=");
                    filter.logicOperator = pairs[1];
                    continue;
                }
                if (line.Contains(FIELD))
                {
                    String[] pairs = line.Split("=");
                    filter.field = pairs[1];
                    continue;
                }
                if (line.Contains(FIELD_VALUE))
                {
                    String[] pairs = line.Split("=");
                    filter.value = pairs[1];
                    continue;
                }
                if (line.Contains(DICTION))
                {
                    String[] pairs = line.Split("=");
                    filter.dictionField = bool.Parse(pairs[1]);
                    continue;
                }
                if (line.Equals(TAG_FILTER_CLOSE))
                {
                    filter.nameGroup = currentGroup;
                    filter = null;
                    continue;
                }
                if (line.Equals(TAG_GROUP_FILTER_CLOSE))
                {
                    currentGroup = null;
                 //   filters = null;
                    continue;
                }
                if (line.Equals(TAG_UNIT_CLOSE))
                {
                    currentLayer = null;
                    
                    group = null;
                    continue;
                }

            }           
            
        }


        private void generateParams()
        {            
            groupFiltersControl1.getFilters();
        }


        private void saveButton_Click(object sender, EventArgs e)
        {            

          //  try
          //  {
                StreamWriter w = new StreamWriter(confFile, false);
                if (parametrs.Keys.Count > 0)
                {
                    w.WriteLine(serializeParametrs());

                   /* JsonSerializerOptions jso = new JsonSerializerOptions();
                    jso.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
                    w.WriteLine(JsonSerializer.Serialize(parametrs, jso));*/
                } else
                {
                    w.WriteLine();
                }
                w.Close();
          /*  }
            catch (Exception ex)
            {
                messageC("Записать конфигурацию в файл не удалось! Путь сохранения: " + confFile, new int[] { errCode() });
            }*/
        }

        public void setMap(String mapName)
        {
            if (!Directory.Exists(pathConf))
            {
                Directory.CreateDirectory(pathConf);
            }

            confFile = pathConf + mapName + ".sqlcfg";    
            
            loadCfgFile();
        }
    }
}
