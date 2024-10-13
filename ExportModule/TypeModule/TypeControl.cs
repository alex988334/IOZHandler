using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2.ExportModule.TypeModule
{
    public partial class TypeControl : MyRootControl
    {
        private List<GroupFilter> filterList = new List<GroupFilter>();
        public String defaultTableAlias = "L1";
        public const String DELIMITER = ";";

        public TypeControl()
        {
            InitializeComponent();
        }

        private void AddFieldButton_Click(object sender, EventArgs e)
        {
            fieldsListBox.SelectedIndex = -1;
            if (newFieldTextBox.Text.Length == 0)
            {
                messageC("Не заполнено название нового поля", new int[] { errCode() });
                return;
            }

            if (fieldsListBox.Items.Contains(newFieldTextBox.Text))
            {
                messageC("Поле с таким именем уже есть в списке", new int[] { errCode() });
                return;
            }

            
            String[] lines = newFieldTextBox.Text.Split(DELIMITER);
            List<String> aliases = new List<String>();
            String name = "";
            
            for (int i = 0; i < lines.Length; i++)
            {
                String line = lines[i].Trim();
                if (i == 0)
                {
                    name = line;
                } else
                {
                    aliases.Add(line);
                }
            }

            if (name.Length == 0)
            {
                messageC("Не заполнено название нового поля", new int[] { errCode() });
                return;
            }

            String alias = newFieldTextBox.Text.Substring(newFieldTextBox.Text.IndexOf(DELIMITER) + 1).Trim();
            int ind = fieldsListBox.Items.Add(name + " (" + alias + ")");

            GroupFilter f = new GroupFilter(name, defaultTableAlias);
            f.setAliases(aliases);
            filterList.Add(f);
            fieldsListBox.SelectedIndex = ind;

            allValuesCheckBox.Checked = f.isAllValues();
            exceptionValuesCheckBox.Checked = f.isExceptionValues();
            newFieldTextBox.Text = "";
        }
              

        private void fieldsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            valuesListBox.Items.Clear();
            int ind = ((ListBox)sender).SelectedIndex;
            if (ind == - 1)
            {
                return;
            }

            GroupFilter f = filterList[ind];
            if (f.getValues().Count > 0)
            {
                List<String> v = f.getValues();
                for (int i = 0; i < v.Count; i++)
                {
                    valuesListBox.Items.Add(v[i]);
                }
            }

            allValuesCheckBox.Checked = f.isAllValues();
            exceptionValuesCheckBox.Checked = f.isExceptionValues();
        }

        private void allValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int ind = fieldsListBox.SelectedIndex;
            if (ind > -1)
            {
                filterList[ind].setAllValues(allValuesCheckBox.Checked);
                blockControls(!allValuesCheckBox.Checked);
            }
        }

        private void blockControls(bool enable)
        {
            valuesListBox.Enabled = enable;
            newValueTextBox.Enabled = enable;
            addValueButton.Enabled = enable;
            if (!enable)
            {
                filterList[fieldsListBox.SelectedIndex].removeAllValues();
                valuesListBox.Items.Clear();
                newValueTextBox.Text = "";
            }
        }

        private void exceptionValuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int ind = fieldsListBox.SelectedIndex;
            if (ind > -1)
            {
                filterList[ind].setExceptionValues(exceptionValuesCheckBox.Checked);
            }            
        }

        private void addValueButton_Click(object sender, EventArgs e)
        {
            if (fieldsListBox.SelectedIndex == -1)
            {
                messageC("Не выбрано поле!", new int[] { errCode() });
                return;
            }
            if (newValueTextBox.Text.Length == 0)
            {
                messageC("Не указано добавляемое значение поля!", new int[] { errCode() });
                return;
            }

            if (valuesListBox.Items.Contains(newValueTextBox.Text))
            {
                messageC("Такое значение уже есть в списке!", new int[] { errCode() });
                return;
            }

            valuesListBox.Items.Add(newValueTextBox.Text);
            filterList[fieldsListBox.SelectedIndex].addValue(newValueTextBox.Text);
            newValueTextBox.Text = "";
        }

        private void fieldsListBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Items.Clear();                                          
               
                ListBox b = (ListBox) sender;
                if (b.Name.CompareTo("fieldsListBox") == 0)
                {
                    ToolStripMenuItem del = new ToolStripMenuItem("Удалить поле");
                    del.Click += deleteItemFromFieldListBox;
                    contextMenuStrip1.Items.Add(del);
                }
                if (b.Name.CompareTo("valuesListBox") == 0)
                {
                    ToolStripMenuItem del = new ToolStripMenuItem("Удалить значение");
                    del.Click += deleteItemFromValueListBox;
                    contextMenuStrip1.Items.Add(del);
                }

                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void deleteItemFromFieldListBox(object sender, EventArgs e)
        {
            int ind = fieldsListBox.SelectedIndex;
            if (ind > -1)
            {
                filterList.RemoveAt(ind);
                fieldsListBox.Items.RemoveAt(ind);
                fieldsListBox.SelectedIndex = -1;
                valuesListBox.Items.Clear();
            }
        }
        private void deleteItemFromValueListBox(object sender, EventArgs e)
        {
            int ind = valuesListBox.SelectedIndex;
            if (ind > -1)
            {
                filterList[fieldsListBox.SelectedIndex].removeValue(ind);
                valuesListBox.Items.RemoveAt(ind);
            }
        }

        public List<GroupFilter> getGroupFilter()
        {
            return filterList;
        }
        public void setGroupFilters(List<GroupFilter> filters)
        {
            this.filterList = filters;
            fieldsListBox.Items.Clear();
            for (int i = 0; i < filters.Count; i++) 
            {
                String name = filterList[i].getFieldName() + " (" +filterList[i].getAliasesStr() + ")";
                fieldsListBox.Items.Add(name);
            }

            if (fieldsListBox.Items.Count > 0)
            {
                fieldsListBox.SelectedIndex = 0;
            }
        }       
    }
}
