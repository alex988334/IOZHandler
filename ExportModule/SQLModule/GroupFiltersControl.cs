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
    internal partial class GroupFiltersControl : MyRootControl
    {
        public GroupFiltersControl()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            FieldFilter filter = new FieldFilter();

            filterViewerFlowLayout.Controls.Add(filter);
        }

        public Dictionary<String, List<Filter>> getFilters() 
        { 
            Dictionary<String, List<Filter>> filters = new Dictionary<String, List<Filter>>();
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel) Controls[0];
            for (int i = 0; i < flowLayoutPanel.Controls.Count; i++)
            {
                FieldFilter contr = (FieldFilter) flowLayoutPanel.Controls[i];
                Filter fil = contr.getFilter();

                if (!filters.ContainsKey(fil.nameGroup))
                {
                    filters[fil.nameGroup] = new List<Filter>();
                }

                filters[fil.nameGroup].Add(contr.getFilter());
            }

            if (filters.Count == 0)
            {
                throw new ArgumentException("Фильтры не заданы!");
            }

            return filters;
        }
    }
}
