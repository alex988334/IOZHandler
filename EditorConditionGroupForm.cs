using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class EditorConditionGroupForm : Form
    {
     //   private Dictionary<String, Dictionary<String, Dictionary<String, Object>>> dataTree;
        private TreeNode dataTree;
        private TreeNode groupConditionTree;

        private TreeNode currentLayer;
        private TreeNode currentTheme;
        private TreeNode currentCondLayer;
        private TreeNode currentCondTheme;
        private TreeNode currentCond;
        private const String EXTANSION = ".grprule";
        private String pathGrpRuleFile;

        private String pathMap;        

        public EditorConditionGroupForm()
        {
            InitializeComponent();
        }

        public void setDataTree(TreeNode dataTree)
        {            
            init(dataTree);
        }

        public String getPathGrpRuleFile()
        {
            return pathGrpRuleFile;
        }

        public TreeNode getGroupConditionTree()
        {
            return (TreeNode) groupConditionTree.Clone();
        }

        private void initLayerComboBox()
        {
            selectorLayerComboBox.SelectedIndex = -1;
            selectorLayerComboBox.Items.Clear();            
          //  selectorLayerComboBox.Items.AddRange(dataTree.Keys.ToArray());

            for (int i = 0; i < dataTree.Nodes.Count; i++)
            {
                selectorLayerComboBox.Items.Add(dataTree.Nodes[i].Name);
            }
        }

        public void setMapPath(String path)
        {
            if (path.Contains(".zmp"))
            {
                path = path.Replace(".zmp", EXTANSION);
            }
            else
            {
                path = path + EXTANSION;
            }
            pathMap = path;
        }

        private void initSelectorGroupComboBox()
        {
            
            selectorGroupComboBox.SelectedIndex = -1;
            selectorGroupComboBox.Items.Clear();
            if (currentCondLayer == null || currentCondTheme == null)
            {
                return;
            }

            for (int i = 0; i < currentCondTheme.Nodes.Count; i++)
            {
                selectorGroupComboBox.Items.Add(currentCondTheme.Nodes[i].Name);
            }
        }

        private void initThemeComboBox()
        {           
            selectorThemeComboBox.SelectedIndex = -1;
            selectorThemeComboBox.Items.Clear();
            if (currentLayer == null)
            {
                return;
            }

            for (int i = 0; i < currentLayer.Nodes.Count; i++)
            {
                selectorThemeComboBox.Items.Add(currentLayer.Nodes[i].Name);
            }           
           // selectorThemeComboBox.Items.AddRange(dataTree[currentLayer.Name].Keys.ToArray());
        }

        private void initConditionsListBox()
        {
            conditionListBox.Items.Clear();
            if (currentLayer == null || currentTheme == null)
            {
                return;
            }

            for(int i = 0; i < currentTheme.Nodes.Count; i++)
            {
                conditionListBox.Items.Add(currentTheme.Nodes[i].Name);
            }
           // conditionListBox.Items.AddRange(dataTree[layer][theme].Keys.ToArray());
        }

        private void init(TreeNode data)
        {

            dataTree = data;
            

     /*       dataTree = new Dictionary<String, Dictionary<String, Dictionary<String, Object>>>();
            for (int i = 0; i < data.Nodes.Count; i++)
            {
                TreeNode layers = data.Nodes[i];
                Dictionary<String, Dictionary<String, Object>> t = new Dictionary<string, Dictionary<string, object>>();
                for (int j = 0; j < layers.Nodes.Count; j++)
                {
                    TreeNode themeNode = layers.Nodes[j];
                    Dictionary<String, Object> tc = new Dictionary<string, object>();
                    for (int k = 0; k < themeNode.Nodes.Count; k++)
                    {
                        tc[themeNode.Nodes[k].Name] = themeNode.Nodes[k].Name;
                    }
                    t[themeNode.Name] = tc;
                }
                dataTree[layers.Name] = t;
            }*/
        }

        private void selectorLayerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectorLayerComboBox.SelectedIndex != -1)
            {
                currentTheme = null;
                currentLayer = getLayerNodeFromData(selectorLayerComboBox.SelectedItem.ToString());
                currentCondLayer = getLayerNodeFromCond(selectorLayerComboBox.SelectedItem.ToString());
                
            } else
            {
                currentLayer = null;                                
            }

            initThemeComboBox();
        }

        private void initConditionListBox()
        {

        }

        private void selectorThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectorThemeComboBox.SelectedIndex != -1)
            {
                currentTheme = getThemeNodeFromData(selectorThemeComboBox.SelectedItem.ToString());
                currentCondTheme = getThemeNodeFromCond(currentCondLayer, selectorThemeComboBox.SelectedItem.ToString());
            } else
            {
                currentTheme = null;
            }

            initConditionsListBox();
            initSelectorGroupComboBox();
            initNameGroupTextBox();
        }

        private void initNameGroupTextBox()
        {
            nameGroupTextBox.Clear();
        }

        private TreeNode getThemeNodeFromData(String theme)
        {
            for (int i = 0; i < currentLayer.Nodes.Count; i++)
            {
                if (currentLayer.Nodes[i].Name.Equals(theme))
                {                    
                    return currentLayer.Nodes[i];
                }
            }
            throw new Exception("Не найдена тема в исходных данных! имя: " + theme);
        }


        private TreeNode getLayerNodeFromData(String layer)
        {
            for (int i = 0; i < dataTree.Nodes.Count; i++)
            {
                if (dataTree.Nodes[i].Name.Equals(layer))
                {                    
                    return dataTree.Nodes[i];
                }
            }
            throw new Exception("Не найден слой в исходных данных! имя: " + layer);
        }


        private TreeNode getLayerNodeFromCond(String layer)
        {
            for(int i = 0; i < groupConditionTree.Nodes.Count; i++)
            {
                if (groupConditionTree.Nodes[i].Name.Equals(layer))
                {
                    return groupConditionTree.Nodes[i];
                }
            }

            TreeNode tree = new TreeNode(layer);
            tree.Name = layer;
            groupConditionTree.Nodes.Add(tree);            
            return tree;
        }

        private TreeNode getThemeNodeFromCond(TreeNode layer, String theme)
        {
            for (int i = 0; i < layer.Nodes.Count; i++)
            {
                if (layer.Nodes[i].Name.Equals(theme))
                {                    
                    return layer.Nodes[i];
                }
            }

            TreeNode tree = new TreeNode(theme);
            tree.Name = theme;
            layer.Nodes.Add(tree);             
            return tree;
        }


        private void EditorConditionGroupForm_Load(object sender, EventArgs e)
        {            
            if (groupConditionTree == null)
            {
                groupConditionTree = new TreeNode("Правила");
            }
            viewerTreeView.Nodes.Clear();
            viewerTreeView.Nodes.Add(groupConditionTree);
            viewerTreeView.ExpandAll();
            initLayerComboBox();
        }

        private void saveRuleGroup()
        {            
            String rules = groupRulesToStr();
            try
            {
                StreamWriter w = new StreamWriter(pathMap, false);
                w.WriteLine(rules);
                w.Close();               
            }
            catch (Exception e)
            {
                nameGroupTextBox.Text = "Записать правило в файл не удалось! Правило: " + rules + ", файл: " + pathMap
                        + "\ne.message => " + e.Message;                
            }
        }


        private String groupRulesToStr()
        {
            String result = "";
            
            for(int i = 0; i < groupConditionTree.Nodes.Count; i++)
            {                
                TreeNode layer = groupConditionTree.Nodes[i]; 

                for (int j = 0; j < layer.Nodes.Count; j++)
                {
                    TreeNode theme = layer.Nodes[j];                    

                    for(int k = 0; k < theme.Nodes.Count; k++)
                    {
                        TreeNode rule = theme.Nodes[k]; 
                        
                        String line = "";
                        for (int l = 0; l < rule.Nodes.Count; l++)
                        {
                            line = line + rule.Nodes[l].Name + ((l + 1 < rule.Nodes.Count) ? ";" : "");                            
                        }
                        result = result + layer.Name + ";" + theme.Name + ";" + rule.Name + "=>" 
                                + line + ((k + 1 < theme.Nodes.Count) ? "\n" : "");
                    }
                }
            }

            return result;
        }


        private void createButton_Click(object sender, EventArgs e)
        {
            saveRuleGroup();            
        }

        private void findCurrentCondition(String condName)
        {
            for(int i = 0; i < currentCondTheme.Nodes.Count; i++)
            {
                if (currentCondTheme.Nodes[i].Name.Equals(condName))
                {
                    currentCond = currentCondTheme.Nodes[i];
                }
            }
        }


        private void selectorGroupComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (selectorGroupComboBox.SelectedIndex != -1)
            {
                findCurrentCondition(selectorGroupComboBox.SelectedItem.ToString());

                for (int i = 0; i < conditionListBox.Items.Count; i++)
                {
                    conditionListBox.SetItemCheckState(i, CheckState.Unchecked);                   
                }

                for (int i = 0; i < conditionListBox.Items.Count; i++)
                {
                    for(int k = 0; k < currentCond.Nodes.Count; k++)
                    {
                        if (conditionListBox.Items[i].ToString().Equals(currentCond.Nodes[k].Name))
                        {
                            nameGroupTextBox.Text = currentCond.Name;
                            conditionListBox.SetItemCheckState(i, CheckState.Checked);
                        }                        
                    }
                }            
            }
        }


        private void addRuleButton_Click(object sender, EventArgs e)
        {
            if (nameGroupTextBox.Text == null || nameGroupTextBox.Text.Length == 0 || conditionListBox.CheckedItems.Count == 0)
            {
                return;
            }
            
            if (groupConditionTree == null)
            {
                groupConditionTree = new TreeNode("Правила");
            }

            TreeNode condtree = new TreeNode(nameGroupTextBox.Text.Trim());
            condtree.Name = nameGroupTextBox.Text.Trim();
            currentCondTheme.Nodes.Add(condtree);

            for (int i = 0; i < conditionListBox.CheckedItems.Count; i++)
            {
                TreeNode cond = new TreeNode(conditionListBox.CheckedItems[i].ToString());
                cond.Name = conditionListBox.CheckedItems[i].ToString();
                condtree.Nodes.Add(cond);
            }

            selectorGroupComboBox.Items.Add(condtree.Name);
            updateViewerGroup();
        }

        private void updateViewerGroup()
        {
            viewerTreeView.Nodes.Clear();
            viewerTreeView.Nodes.Add(groupConditionTree);
            viewerTreeView.ExpandAll();
        }

        public void loadFromFile(String filePath)
        {
            
            String[] res = null;
            try
            {
                res = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось прочесть файл шаблона слоя: " + filePath + "\n" + e.Message);
            }

            if (res.Length == 0)
            {
                return;
            }

            if (groupConditionTree == null)
            {
                groupConditionTree = new TreeNode("Правила");
            }
            
            for (int i = 0; i < res.Length; i++)
            {
                String line = res[i];
                String[] modules = line.Split("=>");
                String[] mod1 = modules[0].Split(";");
                String[] mod2 = modules[1].Split(";");

                TreeNode layer = getLayerNodeFromCond(mod1[0]);               

                TreeNode theme = getThemeNodeFromCond(layer, mod1[1]);                

                TreeNode rule = getThemeNodeFromCond(theme, mod1[2]);

                rule.Nodes.Clear();
                for(int j = 0; j < mod2.Length; j++)
                {
                    TreeNode cond = new TreeNode(mod2[j]);
                    cond.Name = mod2[j];
                    rule.Nodes.Add(cond);
                }
            }

            initSelectorGroupComboBox();
        }


        private void loadRuleGroupButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "GrpRule files(*.grprule)|*.grprule";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathGrpRuleFile = openFileDialog1.FileName;
                loadFromFile(pathGrpRuleFile);
                updateViewerGroup();
            }            
        }

        private void deleteGroupCondButton_Click(object sender, EventArgs e)
        {
            String name = currentCond.Name;
            for (int i = 0; i < currentCondTheme.Nodes.Count; i++)
            {
                if (currentCondTheme.Nodes[i].Name.Equals(name))
                {
                    currentCondTheme.Nodes.RemoveAt(i);
                    break;
                }
            }
            if (currentCondTheme.Nodes.Count == 0)
            {
                name = currentCondTheme.Name;
                for (int i = 0; i < currentCondLayer.Nodes.Count; i++)
                {
                    if (currentCondLayer.Nodes[i].Name.Equals(name))
                    {
                        currentCondLayer.Nodes.RemoveAt(i);
                        break;
                    }
                }
            }

            if (currentCondLayer.Nodes.Count == 0)
            {
                name = currentCondLayer.Name;
                for (int i = 0; i < groupConditionTree.Nodes.Count; i++)
                {
                    if (groupConditionTree.Nodes[i].Name.Equals(name))
                    {
                        groupConditionTree.Nodes.RemoveAt(i);
                        break;
                    }
                }
            }
            if (selectorGroupComboBox.SelectedIndex > -1 && selectorGroupComboBox.SelectedIndex < selectorGroupComboBox.Items.Count)
            selectorGroupComboBox.Items.RemoveAt(selectorGroupComboBox.SelectedIndex);

            updateViewerGroup();
        }
    }
}
