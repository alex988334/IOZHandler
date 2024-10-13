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
    internal partial class IndexFilterControl : MyRootControl
    {
        public delegate void FindIndex(Object sender);
        public event FindIndex OnFindIndex;
                
        private Color color;

        public IndexFilterControl()
        {
            InitializeComponent();
            leftRadioButton.Checked = true;
        }

        public IndexFilterControl(bool leftSearch)
        {
            InitializeComponent();
            if (leftSearch)
            {
                leftRadioButton.Checked = true;
            }
            else
            {
                rightRadioButton.Checked = true;
            }
        }

        private void calculateIndex()
        {
            if (indexRichText.Text != null && indexRichText.Text.Length > 0)
            {
                String delim = delimeterRichText.Text != null ? delimeterRichText.Text : "";

                OnFindIndex(this);
            } else
            {
                messageC("Не указано название индекса!", new int[] { errCode() });
            }            
        }

       /* public void setParams(IndexParams parametrs)
        {
            this.parametrs = parametrs;
        }*/


        private void indexRichText_TextChanged(object sender, EventArgs e)
        {
            indexRichText.SelectionColor = color;
            calculateIndex();
        }

        private void delimeterRichText_TextChanged(object sender, EventArgs e)
        {
            calculateIndex();
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public void setIndex(String index)
        {
            indexRichText.Text = index;
        }

        public void setDelimeter(String delimeter)
        {
            delimeterRichText.Text = delimeter;
        }

        public void init(String index, String delimeter, Color color, bool leftSearch)
        {
            setIndex(index);
            setDelimeter(delimeter);
            this.color = color;
            if (leftSearch)
            {
                leftRadioButton.Checked = true;
            } else
            {
                rightRadioButton.Checked = true;
            }
        }
    }
}
