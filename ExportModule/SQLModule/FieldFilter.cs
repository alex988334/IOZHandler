using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2.ExportModule.SQLModule
{
    internal partial class FieldFilter : MyRootControl
    {
        public FieldFilter()
        {
            InitializeComponent();

            logicOperatorComboBox.SelectedIndex = 0;
        }

        public String getAliasGroup()
        {
            return nameGroupTextBox.Text;
        }

        public String getLogicOperator()
        {
            return (String) logicOperatorComboBox.SelectedItem;
        }

        public String getField()
        {
            return fieldTextBox.Text;
        }

        public bool isDictionaryField()
        {
            return dictionaryCheckBox.Checked;
        }

        public String getValueField()
        {
            return valueFieldTextBox.Text;
        }

        public void validate()
        {
            if (logicOperatorComboBox.SelectedIndex == -1 || nameGroupTextBox.Text == null 
                || fieldTextBox.Text == null || valueFieldTextBox.Text == null)
            {
                throw new ArgumentException("Не заполнены поля в фильтре! Выполнение прервано.");
            }
        }

        public Filter getFilter()
        {
            return new Filter()
            {
                dictionField = dictionaryCheckBox.Checked,
                field = fieldTextBox.Text,
                logicOperator = (String) logicOperatorComboBox.SelectedItem,
                value = valueFieldTextBox.Text,
                nameGroup = nameGroupTextBox.Text,
            };
        }
    }
}
