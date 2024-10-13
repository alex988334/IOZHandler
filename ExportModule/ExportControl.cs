using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZuluLib;
using Example2.ExportModule;
using Example2.ExportModule.SQLModule;
using Example2.ExportModule.ThemeModule;
using Example2.ExportModule.TypeModule;
using System.Diagnostics;

namespace Example2.ExportModule
{
    public partial class ExportControl : MyRootControl
    {
        public delegate void ExportComplete();
        public event ExportComplete OnExportComplete;

        private Dictionary<String, MyLayer> layers;
        private String exportTheme = "";
        private OpenFileDialog openFileDialog;
        private String fileType;
        //   private MyLayer selectedLayer;
        private Exporter exporter;
        private String pptBorderlayer;
        private MapDoc map;
        private EditorConditionGroupForm editorConditionGroupForm;
        private TreeNode groupRules;
        private int stage;

        private IndexPalitre palitre;

        private String exportPath;
        private String borderLayer;
        private String theme;
        private String cfgFile;
        private String groupRulesFile;
        private String exportExtension;
        private int[] selectedPptObjects;
        private List<String> dictionaryFields;
        protected List<String> annotationExport;
        protected Dictionary<String, Dictionary<String, List<String>>> excludesTypes;
        

        //     private bool downRun = true;

        /*
         * Не реализовано RULES! 
         */

        public ExportControl()
        {
            InitializeComponent();

            expAllLayersCheckBox.Checked = true;
            expCfgButton.Enabled = false;
            expCfgFileTextBox.Enabled = false;
            expRunButton.Enabled = false;

            expFileExtComboBox.Enabled = false;
            exportPathTextBox.Text = "O:\\Export";

            expAllLayersCheckBox.Checked = false;
            expAllLayersCheckBox.Enabled = false;

            openFileDialog = new OpenFileDialog();
            editorConditionGroupForm = new EditorConditionGroupForm();

            exporter = new ThemeExporter();
            setFileTypes(exporter.getFileTypes());

            ToolStripMenuItem item = new ToolStripMenuItem("Удалить поле из списка");
            item.Click += deleteMenuItemClick;
            contextMenu.Items.Add(item);
        }

        public void deleteMenuItemClick(object sender, EventArgs e)
        {
            if (dictionFieldTreeView.SelectedNode != null)
            {
                String name = dictionFieldTreeView.SelectedNode.Text;
                dictionaryFields.Remove(name);
                dictionFieldTreeView.SelectedNode.Remove();
            }
        }

        public void dictionFieldTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenu.Show(Cursor.Position);
            }
        }

        public void setMap(MapDoc map)
        {
            this.map = map;
        }

        //   public void generateLayersList

        private void initEditorConditionGroupForm()
        {
            TreeNode tree = new TreeNode();
            String[] keys = layers.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                /*  if (expPptLayerComboBox.SelectedIndex != -1 && layers[keys[i]].getName().Equals(expPptLayerComboBox.SelectedItem))
                  {
                      continue;
                  }*/

                Layer l = layers[keys[i]].getZuluLayer();
                TreeNode lay = new TreeNode(l.UserName);
                lay.Name = l.UserName;

                for (int j = 1; j <= l.Themes.Count; j++)
                {
                    Theme t = l.Themes.GetTheme(j);
                    String tName = l.Themes.GetTheme(j).UserName;
                    int tFiltId = l.Themes.ThemeFilterId[j];

                    TreeNode tNode = new TreeNode(tName);
                    tNode.Name = tName;
                    ThemeFilterDesc filt = l.ThemeFilters.GetItemById(tFiltId);

                    for (int k = 0; k < filt.ConditionsCount; k++)
                    {
                        //   message("filt.ConditionName[k] => " + filt.ConditionName[k]);
                        TreeNode cond = new TreeNode(filt.ConditionName[k]);
                        cond.Name = filt.ConditionName[k];
                        cond.Tag = k;
                        tNode.Nodes.Add(cond);
                    }
                    lay.Nodes.Add(tNode);
                }
                tree.Nodes.Add(lay);
            }
            //    logprint(tree);
            editorConditionGroupForm.setDataTree(tree);
        }

        private void logprint(TreeNode tree)
        {
            for (int i = 0; i < tree.Nodes.Count; i++)
            {
                logprint(tree.Nodes[i]);
            }
            message("tree.Name => " + tree.Name);
        }

        public void setLayers(Dictionary<String, MyLayer> layers)
        {
            this.layers = layers;

            expPptLayerComboBox.Items.AddRange(layers.Keys.ToArray());
            for (int i = 0; i < expPptLayerComboBox.Items.Count; i++)
            {
                if (expPptLayerComboBox.Items[i].Equals(borderLayer))
                {
                    expPptLayerComboBox.SelectedIndex = i;
                    break;
                }
            }
            sqlControl1.setMap(map.Name);


            exporter = new ThemeExporter();
            setFileTypes(exporter.getFileTypes());
        }

       /* private void generateThemeTree()
        {
            themeTreeView.Nodes.Clear();
            themeTreeView.CheckBoxes = true;

            String[] keys = layers.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].Equals(pptBorderlayer))
                {
                    continue;
                }
                TreeNode l = new TreeNode(layers[keys[i]].getZuluLayer().UserName);

                Themes themes = layers[keys[i]].getZuluLayer().Themes;
                //    message("count => " + themes.Count);                
                for (int k = 1; k < themes.Count + 1; k++)
                {
                    TreeNode lt = new TreeNode(themes.GetTheme(k).UserName);
                    l.Nodes.Add(lt);
                }
                themeTreeView.Nodes.Add(l);
            }
            checkThemeTree(true);
            themeTreeView.ExpandAll();
        }*/

        private void generateLayersTree()
        {
            structCheckerTreeView.Nodes.Clear();
            structCheckerTreeView.CheckBoxes = true;

            String[] keys = layers.Keys.ToArray();
            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i].Equals(pptBorderlayer) || layers[keys[i]].getNetName() == null || layers[keys[i]].getNetName() == "")
                {
                    continue;
                }
                Layer layer = layers[keys[i]].getZuluLayer();
                TreeNode l = new TreeNode(layer.UserName);
                l.Checked = true;
                for (int j = 0; j < layer.ObjectTypes.Count; j++)
                {                   
                    ObjectType type = layer.ObjectTypes.GetItemByIndex(j);
                    TreeNode lt = new TreeNode(type.Name);

                    lt.Checked = inExcludesTypes(layer.UserName, type.Name, null);

                    for (int k = 1; k <= type.Modes.Count; k++)
                    {
                        TreeNode ltm = new TreeNode(type.Modes[k].Name);
                        ltm.Checked = inExcludesTypes(layer.UserName, type.Name, type.Modes[k].Name);
                        if (ltm.Checked)
                        {
                            lt.Checked = ltm.Checked;
                        }

                        lt.Nodes.Add(ltm);
                    }
                    l.Nodes.Add(lt);
                }
                structCheckerTreeView.Nodes.Add(l);
            }
            //   checkStructTree(true);

            structCheckerTreeView.ExpandAll();
        }

        private bool inExcludesTypes(String layerName, String typeName, String modeName)
        {
            if (modeName != null)
            {
                if (excludesTypes.ContainsKey(layerName) && excludesTypes[layerName].ContainsKey(typeName)
                        && (excludesTypes[layerName][typeName].Contains(modeName) || excludesTypes[layerName][typeName].Count == 0))
                {
                    return false;
                }
            }

            if (typeName != null && modeName == null)
            {
                if (excludesTypes.ContainsKey(layerName) && excludesTypes[layerName].ContainsKey(typeName))
                {
                    return false;
                }
            }

            return true;
        }

        private void checkThemeTree(bool check)
        {
            for (int i = 0; i < themeTreeView.Nodes.Count; i++)
            {
                checkTree(themeTreeView.Nodes[i], check);
            }
        }

        private void checkStructTree(bool check)
        {
            for (int i = 0; i < structCheckerTreeView.Nodes.Count; i++)
            {
                checkTree(structCheckerTreeView.Nodes[i], check);
            }
        }

        private void checkTree(TreeNode view, bool check)
        {
            for (int i = 0; i < view.Nodes.Count; i++)
            {
                checkTree(view.Nodes[i], check);
            }
            view.Checked = check;
        }

        private void setFileTypes(String[] fileTypes)
        {
            if (fileTypes.Length == 0)
            {
                throw new ArgumentNullException("Нет допустимых форматов расширений файлов!");
            }

            foreach (String fileType in fileTypes)
            {
                if (fileType == null || fileType.Length == 0)
                {
                    throw new ArgumentNullException("Формат файла не может быть пустой строкой!");
                }
            }
            expFileExtComboBox.Items.AddRange(fileTypes);
        }

        /* private void expThemeCheckBox_CheckedChanged(object sender, EventArgs e)
         {
             if (expThemeCheckBox.Checked)
             {
                 exporter = new ThemeExporter();
                 expThemeComboBox.Enabled = true;
             }
             else
             {
                 exporter = new TypeExporter();
                 expThemeComboBox.SelectedIndex = -1;
                 expThemeComboBox.Enabled = false;
             }

             setFileTypes(exporter.getFileTypes());
         }*/

        private void expThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expThemeComboBox.SelectedIndex != -1)
            {
                expFileExtComboBox.Enabled = true;
                for (int i = 0; i < expFileExtComboBox.Items.Count; i++)
                {
                    if (expFileExtComboBox.Items[i].Equals(exportExtension))
                    {
                        expFileExtComboBox.SelectedIndex = i;
                        break;
                    }
                }

                exportTheme = (String)expThemeComboBox.SelectedItem;
            }
            else
            {
                expFileExtComboBox.Enabled = false;
            }

        }

        private void expCfgButton_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Conf(*.cfg)|*.cfg";
            if (cfgFile != null && cfgFile.Length > 0)
            {
                openFileDialog.InitialDirectory = removeFileName(cfgFile, ".cfg");
            }
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cfgFile = openFileDialog.FileName;
                expCfgFileTextBox.Text = openFileDialog.FileName;
            }
        }

        private String removeFileName(String pathFile, String extansion)
        {
            if (pathFile.Contains(extansion))
            {
                String[] parts = pathFile.Split("\\");
                if (parts.Length == 1)
                {
                    parts = pathFile.Split("/");
                }
                pathFile = parts[0];
                for (int i = 1; i < parts.Length - 1; i++)
                {
                    pathFile = pathFile + "\\" + parts[i];
                }
            }
            return pathFile;
        }

        private void expRunButton_Click(object sender, EventArgs e)
        {
            try
            {
                checkState();

                if (sqlQueryRadioButton.Checked)
                {
                    SQLExporter exp = new SQLExporter();
                    Dictionary<String, Group> parametrs = sqlControl1.getParametrs();
                    String[] keys = parametrs.Keys.ToArray();
                    for (int i = 0; i < keys.Length; i++)
                    {
                        if (parametrs[keys[i]] == null)
                        {
                            parametrs.Remove(keys[i]);
                        }
                        parametrs[keys[i]].validate();
                        parametrs[keys[i]].generateWhere();
                  
                    }
                    exp.setParams(parametrs);
                    exporter = exp;
                }

            /*    if (typesRadioButton.Checked)
                {
                    TypeExporter exp = new TypeExporter();
                    List<GroupFilter> filters = typeControl1.getGroupFilter();                  
                    exp.setFilterList(filters);
                    exporter = exp;
                }*/
            }
            catch (Exception excep)
            {
                messageC(excep.Message, new int[] { errCode() });
                messageC("Экспорт отменен!", new int[] { errCode() });
                return;
            }
                     
            exporter.setAnnotationExport(getAnnotationExport());
           // exporter.setStage(stage);
            exporter.setThemeExport(exportTheme);
            exporter.setTypeFile(fileType);
            exporter.setExportPath(exportPathTextBox.Text);
            exporter.createDirectory(exportPathTextBox.Text);
            exporter.setMap(map);
            exporter.setExportConfFile(expCfgFileTextBox.Text);


            String key = expPptLayerComboBox.SelectedItem.ToString();
            exporter.setPptLayer(layers[key]);

            exporter.setPptSelectedObjects(collectSelectedPpt());
            exporter.setByRefFields(dictionaryFields);

            List<String> explayers = selectionLayers();
            if (explayers.Count == 0)
            {
                messageC("Слои не выбраны! Экспорт завершен", new int[] { errCode() });
                return;
            }

            for (int i = 0; i < explayers.Count; i++)
            {
                messageC("Экспорт слоя: " + layers[explayers[i]].getName(), new int[] { boldCode() });
                exporter.setLayer(layers[explayers[i]]);
                exporter.setExcludedTypes(generateExcludesTypes(explayers[i]));

               // exporter.setGroupConditionRules(groupRules);
                exporter.run();

              //  break;
            }

            messageC("Экспорт завершен", new int[] { boldCode() });

            OnExportComplete();
        }

        public void setExcludesTypes(Dictionary<String, Dictionary<String, List<String>>> excludesTypes)
        {
            this.excludesTypes = excludesTypes;
        }

        public Dictionary<String, Dictionary<String, List<String>>> getExcludesTypes()
        {
            Dictionary<String, Dictionary<String, List<String>>> excludesTypes =
                        new Dictionary<string, Dictionary<string, List<string>>>();

            List<String> explayers = selectionLayers();
            for (int i = 0; i < explayers.Count; i++)
            {
                excludesTypes[explayers[i]] = generateExcludesTypes(explayers[i]);
            }

            return excludesTypes;
        }

        private Dictionary<String, List<String>> generateExcludesTypes(String layerName)
        {
            Dictionary<String, List<String>> excludesTypes = new Dictionary<String, List<String>>();
            for (int i = 0; i < structCheckerTreeView.Nodes.Count; i++)
            {
                if (structCheckerTreeView.Nodes[i].Text.Equals(layerName))
                {
                    for (int k = 0; k < structCheckerTreeView.Nodes[i].Nodes.Count; k++)
                    {
                        if (!structCheckerTreeView.Nodes[i].Nodes[k].Checked)
                        {
                            excludesTypes[structCheckerTreeView.Nodes[i].Nodes[k].Text] = new List<String>();
                        }
                        else
                        {
                            for (int j = 0; j < structCheckerTreeView.Nodes[i].Nodes[k].Nodes.Count; j++)
                            {
                                if (!structCheckerTreeView.Nodes[i].Nodes[k].Nodes[j].Checked)
                                {
                                    if (!excludesTypes.ContainsKey(structCheckerTreeView.Nodes[i].Nodes[k].Text)
                                            || excludesTypes[structCheckerTreeView.Nodes[i].Nodes[k].Text] == null)
                                    {
                                        excludesTypes[structCheckerTreeView.Nodes[i].Nodes[k].Text] = new List<String>();
                                    }

                                    excludesTypes[structCheckerTreeView.Nodes[i].Nodes[k].Text]
                                            .Add(structCheckerTreeView.Nodes[i].Nodes[k].Nodes[j].Text);
                                }
                            }
                        }
                    }
                    break;
                }
            }

            return excludesTypes;
        }

        private int[] collectSelectedPpt()
        {
            List<int> sysId = new List<int>();
            for (int i = 0; i < borderTreeView.Nodes.Count; i++)
            {
                if (borderTreeView.Nodes[i].Checked == true)
                {
                    sysId.Add((int)borderTreeView.Nodes[i].Tag);
                }
            }

            return sysId.ToArray();
        }

        private List<string> selectionLayers()
        {
            List<string> layers = new List<string>();

            for (int i = 0; i < structCheckerTreeView.Nodes.Count; i++)
            {
                if (structCheckerTreeView.Nodes[i].Checked)
                {
                    layers.Add(structCheckerTreeView.Nodes[i].Text);
                }
            }

            return layers;
        }

        private void checkState()
        {
            if (expFileExtComboBox.Items.Count == 0)
            {
                throw new Exception("Не проинициализирован контрол выбора расширения файла!");
            }
        }

        private void expFileExtComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expFileExtComboBox.SelectedIndex != -1)
            {
                expRunButton.Enabled = true;
                fileType = (String)expFileExtComboBox.SelectedItem;
                if (fileType.Equals(Exporter.FILE_DXF))
                {
                    expCfgFileTextBox.Enabled = true;
                    expCfgButton.Enabled = true;
                }
                else
                {
                    expCfgFileTextBox.Enabled = false;
                    expCfgButton.Enabled = false;
                }
            }
            else
            {
                expRunButton.Enabled = false;
            }
        }

        /*     private void expSelectLayComboBox_SelectedIndexChanged(object sender, EventArgs e)
             {
                 if (expSelectLayComboBox.SelectedIndex != -1)
                 {
                     selectedLayer = layers[(String) expSelectLayComboBox.SelectedItem];

                 }            
             }*/

        private void expAllLayersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
          /*  if (expAllLayersCheckBox.Checked)
            {
                structCheckerTreeView.Enabled = false;
            }
            else
            {
                structCheckerTreeView.Enabled = true;
            }*/

            checkStructTree(expAllLayersCheckBox.Checked);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();

            d.InitialDirectory = exportPathTextBox.Text;
            if (d.ShowDialog() == DialogResult.OK)
            {
                exportPathTextBox.Text = d.SelectedPath;
            }
        }

        private void expPptLayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expPptLayerComboBox.SelectedIndex != -1)
            {
                pptBorderlayer = expPptLayerComboBox.SelectedItem.ToString();
                loadPptObjects();

                generateLayersTree();
           //     generateThemeTree();
                structCheckerTreeView.Enabled = true;

                initThemeComboBox();
                initAnnotationTreeView();
            }
        }

        private void initAnnotationTreeView()
        {
            annotationTreeView.Nodes.Clear();
            annotationTreeView.CheckBoxes = true;

            MyLayer lay = findFirstCheckedLayer();
            if (lay == null)
            {
                return;
            }
            List<String> anno = lay.getAnnotationList();
            if (anno.Count == 0)
            {
                return;
            }

            for (int i = 0; i < anno.Count; i++)
            {
                TreeNode node = new TreeNode(anno[i]);
                annotationTreeView.Nodes.Add(node);

                if (annotationExport != null && annotationExport.Contains(anno[i]))
                {
                    node.Checked = true;
                }
                else
                {
                    node.Checked = false;
                }

            }
        }

        private MyLayer findFirstCheckedLayer()
        {
            for (int i = 0; i < structCheckerTreeView.Nodes.Count; i++)
            {
                if (structCheckerTreeView.Nodes[i].Checked)
                {
                    return layers[structCheckerTreeView.Nodes[i].Text];
                }
            }

            return null;
        }

        private void initThemeComboBox()
        {
            expThemeComboBox.SelectedIndex = -1;
            expThemeComboBox.Items.Clear();

            MyLayer lay = findFirstCheckedLayer();
            if (lay == null)
            {
                return;
            }

            expThemeComboBox.Items.AddRange(lay.getThemes());
            for (int j = 0; j < expThemeComboBox.Items.Count; j++)
            {
                if (expThemeComboBox.Items[j].Equals(theme))
                {
                    expThemeComboBox.SelectedIndex = j;
                    break;
                }
            }
            expAllLayersCheckBox.Enabled = true;
        }

        private void expThemeComboBox_GotFocus(Object sender, EventArgs e)
        {
            initThemeComboBox();
        }

        private void structCheckerTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            /*   if (downRun)
               {*/
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                checkTree(e.Node.Nodes[i], e.Node.Checked);
                //    downRun = false;
            }
            /*    } else
                {
                    if (e.Node.Checked && e.Node.Parent != null && e.Node.Parent.GetType() == typeof(TreeNode))
                    {                    
                        e.Node.Parent.Checked = true;
                        downRun = true;
                    }
                }

               /* 
                *   Не придумал как реализовать включение флагов вверх по иерархии,
                *   пробег вверх включает пробег вниз, который активирует пробег вверх,
                *   зацикливание, события afterCheck множественные, предположение: нет, блокирующие флаги не пропускают часть нужных событий
                * 
                *       отсутствует возможность включать вехние узлы иерархии, если они отключены
                * */
        }

        private void themeTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            for (int i = 0; i < e.Node.Nodes.Count; i++)
            {
                checkTree(e.Node.Nodes[i], e.Node.Checked);
            }
        }


        private void editGroupButton_Click(object sender, EventArgs e)
        {
            editorConditionGroupForm.setMapPath(map.PathName);
            initEditorConditionGroupForm();

            editorConditionGroupForm.ShowDialog();
            groupRulesFile = editorConditionGroupForm.getPathGrpRuleFile();

            groupRules = editorConditionGroupForm.getGroupConditionTree();
            groupThemeTreeView.Nodes.Clear();
            groupThemeTreeView.Nodes.Add((TreeNode)groupRules.Clone());

            groupThemeTreeView.ExpandAll();
        }

        private void expCfgFileTextBox_TextChanged(object sender, EventArgs e)
        {
            exporter.setExportConfFile(expCfgFileTextBox.Text);
        }

        private void disablePages()
        {
            SQLPanel.Enabled = false;
            groupFiltersPanel.Enabled = false;
            themesPanel.Enabled = false;
            typesPanel.Enabled = false;
        }

        private void TypeOfExportRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            disablePages();

            if (themeRadioButton.Checked)
            {
                themesPanel.Enabled = true;
                return;
            }

            if (groupFiltresRadioButton.Checked)
            {
                groupFiltersPanel.Enabled = true;
                return;
            }

            if (sqlQueryRadioButton.Checked)
            {
                SQLPanel.Enabled = true;
                return;
            }

            if (typesRadioButton.Checked)
            {
                typesPanel.Enabled = true;
                return;
            }

            throw new Exception("Не реализованный код! RadioButton_CheckedChanged()");

        }

        public List<GroupFilter> getTypeExpGroupFilters()
        {
            return typeControl1.getGroupFilter();
        }
        public void setTypeExpGroupFilters(List<GroupFilter> filters)
        {
            typeControl1.setGroupFilters(filters);
        }
        public String getExportPath()
        {
            return exportPath;
        }
        public void setExportPath(String path)
        {
            this.exportPath = path;
        }
        public void setBorderLayer(String layerName)
        {
            borderLayer = layerName;
        }
        public String getBorderLayer()
        {
            borderLayer = (String)expPptLayerComboBox.SelectedItem;
            return borderLayer;
        }
        public void setTheme(String theme)
        {
            this.theme = theme;
        }
        public String getTheme()
        {
            theme = (String)expThemeComboBox.SelectedItem;
            return theme;
        }
        public void setCfgFile(String filePath)
        {
            cfgFile = filePath;
        }
        public String getCfgFile()
        {
            cfgFile = expCfgFileTextBox.Text;
            return cfgFile;
        }
        public void setGroupRulesFile(String pathFile)
        {
            groupRulesFile = pathFile;
        }
        public String getGroupRulesFile()
        {
            return groupRulesFile;
        }
        public void setExportExtension(String extension)
        {
            exportExtension = extension;
        }
        public String getExportExtension()
        {
            exportExtension = (String)expFileExtComboBox.SelectedItem;
            return exportExtension;
        }
        public int[] getSelectedPptObjects()
        {
            selectedPptObjects = collectSelectedPpt();
            return selectedPptObjects;
        }
        public void setSelectedPptObjects(int[] sysId)
        {
            selectedPptObjects = sysId;
        }
        public void setDictionaryFields(List<String> fields)
        {
            dictionaryFields = fields;
        }
        public List<String> getDictionaryFields()
        {
            return dictionaryFields;
        }
        public List<String> getAnnotationExport()
        {
            annotationExport = new List<string>();
            for (int i = 0; i < annotationTreeView.Nodes.Count; i++)
            {
                if (annotationTreeView.Nodes[i].Checked)
                {
                    annotationExport.Add(annotationTreeView.Nodes[i].Text);
                }
            }

            return annotationExport;
        }

        public void setAnnotationExport(List<String> annotationExport)
        {
            this.annotationExport = annotationExport;
        }

        private void loadPptObjects()
        {
            borderTreeView.Nodes.Clear();

            if (expPptLayerComboBox.SelectedIndex != -1)
            {
                allBoundCheckBox.Enabled = true;

             //   Debug.WriteLine("!!!!! SELECT [Sys], [Territory_list] FROM [" + expPptLayerComboBox.SelectedItem + "] ORDER BY [Territory_list]");

                IZSqlResult rez = map.ExecSQL("SELECT [Sys], [Territory_list] FROM [" + expPptLayerComboBox.SelectedItem + "] ORDER BY [Territory_list]");
                if (rez.RetCode == 0)
                {
                    if (rez.DataSet.MoveFirst())
                    {
                        borderTreeView.CheckBoxes = true;
                        do
                        {
                            TreeNode pptNode = new TreeNode(rez.DataSet.FieldValue[1]);
                            pptNode.Tag = int.Parse(rez.DataSet.FieldValue[0]);
                            if (selectedPptObjects != null)
                            {
                                if (selectedPptObjects.Contains((int)pptNode.Tag))
                                {
                                    pptNode.Checked = true;
                                }
                            }
                            else
                            {
                                pptNode.Checked = true;
                            }

                            borderTreeView.Nodes.Add(pptNode);

                        } while (rez.DataSet.MoveNext());

                        borderTreeView.ExpandAll();
                    }
                    else
                    {
                        messageC("ППТ слой пустой! Проверьте слой: " + expPptLayerComboBox.SelectedItem,
                                new int[] { errCode() });
                    }
                }
                else
                {
                    messageC("Не удалось загрузить список из слоя ППТ! Проверьте слой: " + expPptLayerComboBox.SelectedItem,
                            new int[] { errCode() });
                }
            }
        }

        private void ExportControl_Load(object sender, EventArgs e)
        {
            if (groupRulesFile != null && groupRulesFile.Length > 0 && File.Exists(groupRulesFile))
            {
                editorConditionGroupForm.loadFromFile(groupRulesFile);

                groupRules = editorConditionGroupForm.getGroupConditionTree();
                groupThemeTreeView.Nodes.Clear();
                groupThemeTreeView.Nodes.Add((TreeNode)groupRules.Clone());

                groupThemeTreeView.ExpandAll();
            }

            if (cfgFile != null && cfgFile.Length > 0 && File.Exists(cfgFile))
            {
                expCfgFileTextBox.Text = cfgFile;
            }

            if (dictionaryFields != null && dictionaryFields.Count > 0)
            {
                for (int i = 0; i < dictionaryFields.Count; i++)
                {
                    dictionFieldTreeView.Nodes.Add(new TreeNode(dictionaryFields[i]));
                }
            }

            themeRadioButton.Checked = true;
        }

        private void allBoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < borderTreeView.Nodes.Count; i++)
            {
                borderTreeView.Nodes[i].Checked = allBoundCheckBox.Checked;
            }
        }

        private void addDictionFieldButton_Click(object sender, EventArgs e)
        {
            if (dictionaryFieldTextBox.Text != null && dictionaryFieldTextBox.Text.Length > 0)
            {
                dictionaryFields.Add(dictionaryFieldTextBox.Text);
                dictionFieldTreeView.Nodes.Add(new TreeNode(dictionaryFieldTextBox.Text));
                dictionaryFieldTextBox.Text = null;
            }
        }

        private void TabControl1_SelectedIndexChanged(Object sender, EventArgs e)
        {           
            TabPage tabPage = ((TabControl) sender).SelectedTab;
            if (tabPage.Name.Equals("SQLPage"))
            {
                List<String> explayers = selectionLayers();
                String[] li = explayers.ToArray();
                sqlControl1.setLayers(li);                
            }
            
        }
    }
}
