using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Example2.MapModule;

namespace Example2.RuleModule
{
    internal partial class RuleControl : MyRootControl
    {
        private Rules rules;
        private Dictionary<String, MyLayer> layers;
        private ISampleNets nets;
        private String mapPath;
        private String[] excludedLayers;

        public RuleControl()
        {
            InitializeComponent();
        }

        public void setMapPath(String mapPath)
        {
            if (File.Exists(mapPath))
            {
                rules = new Rules(mapPath);

                appendRulesComboBox();
                message(rules.ToString());
            }
        }

        public void setLayers(Dictionary<String, MyLayer> layers)
        {            
            this.layers = layers;
            ruleLayersComboBox.Items.AddRange(layers.Keys.ToArray());
            initRules();
        }

        public void setSampleNets(ISampleNets sampleNets)
        {
            this.nets = sampleNets;            
        }

        private void saveRule_Click(object sender, EventArgs e)
        {
            if (ruleValueTextBox.Text.Equals(""))
            {
                message("Не установлено новое значение!");
                return;
            }

            if (ruleLayersComboBox.SelectedIndex > -1 & ruleTypesComboBox.SelectedIndex == -1
                    & ruleKeysComboBox.SelectedIndex == -1)
            {
                rules.createRule((String)ruleLayersComboBox.SelectedItem, ruleValueTextBox.Text);
            }

            if (ruleLayersComboBox.SelectedIndex > -1 & ruleTypesComboBox.SelectedIndex > -1
                    & ruleKeysComboBox.SelectedIndex == -1)
            {
                rules.createRule((String)ruleLayersComboBox.SelectedItem, (String)ruleTypesComboBox.SelectedItem,
                           ruleValueTextBox.Text);
            }

            if (ruleLayersComboBox.SelectedIndex > -1 & ruleTypesComboBox.SelectedIndex > -1
                    & ruleKeysComboBox.SelectedIndex > -1)
            {
                rules.createRule((String)ruleLayersComboBox.SelectedItem, (String)ruleTypesComboBox.SelectedItem,
                        (String)ruleKeysComboBox.SelectedItem, ruleValueTextBox.Text);
            }

            rules.readRules();
            appendRulesComboBox();
        }

        private void initRules()
        {
            if (File.Exists(mapPath))
            {
                message(mapPath);

                rules = new Rules(mapPath);
                
                appendRulesComboBox();
                message(rules.ToString());
            }           
        }

        private void clearRulesComboBox()
        {
            ruleKeysComboBox.SelectedIndex = -1;
            ruleKeysComboBox.Items.Clear();

            ruleTypesComboBox.SelectedIndex = -1;
            ruleTypesComboBox.Items.Clear();

            ruleLayersComboBox.SelectedIndex = -1;
            ruleLayersComboBox.Items.Clear();
        }

        private void ruleLayersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ruleTypesComboBox.SelectedIndex = -1;
            ruleTypesComboBox.Items.Clear();

            if (ruleLayersComboBox.SelectedIndex != -1)
            {
                String n = layers[(String)ruleLayersComboBox.SelectedItem].getNetName();

                ruleTypesComboBox.Items.AddRange(nets.getTypesNames(n));
            }
        }

        private void ruleTypesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ruleKeysComboBox.SelectedIndex = -1;
            ruleKeysComboBox.Items.Clear();

            if (ruleTypesComboBox.SelectedIndex != -1)
            {
                String n = layers[(String)ruleLayersComboBox.SelectedItem].getNetName();
                String type = (String)ruleTypesComboBox.SelectedItem;
                String[] sr = nets.getAttrsforType(n, type).ToArray();
                ruleKeysComboBox.Items.AddRange(sr);
            }
        }

        private void appendRulesComboBox()
        {
            ruleSelectComboBox.SelectedIndex = -1;
            ruleSelectComboBox.Items.Clear();
            ruleSelectComboBox.Items.AddRange(rules.getKeys());
        }

        private void deleteRuleButton_Click(object sender, EventArgs e)
        {
            if (ruleSelectComboBox.SelectedIndex > -1)
            {
                rules.deleteRule((String)ruleSelectComboBox.SelectedItem);
                rules.readRules();
                appendRulesComboBox();
            }
        }

        private void printRulesButton_Click(object sender, EventArgs e)
        {
            message(rules.ToString());
            rules.readRules();
        }

        private void ruleKeysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  ruleKeysComboBox.SelectedIndex = -1;
            ruleKeysComboBox.Items.Clear();*/

            if (ruleTypesComboBox.SelectedIndex != -1)
            {
                String n = layers[(String)ruleLayersComboBox.SelectedItem].getNetName();
                String type = (String)ruleTypesComboBox.SelectedItem;

                ruleKeysComboBox.Items.AddRange(nets.getAttrsforType(n, type).ToArray());
            }
        }

    }
}
