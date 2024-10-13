using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZuluLib;
using Example2.MapModule;

namespace Example2.CheckModule
{
    internal partial class CheckControl : MyRootControl
    {
        private MapDoc map;
        private ISampleNets nets;
        private Dictionary<String, MyLayer> layers;

        public CheckControl()
        {
            InitializeComponent();
        }

        public void setMap(MapDoc map)
        {
            this.map = map;
        }

        public void setSampleNets(ISampleNets nets)
        {
            this.nets = nets;
        }

        public void setLayers(Dictionary<String, MyLayer> layers)
        {
            this.layers = layers;
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (map == null)
            {
                messageC("Не выбран файл карты!", new int[] { errCode() });
                return;
            }
            if (nets == null)
            {
                messageC("Не выбран файл шаблона слоев!", new int[] { errCode() });
                return;
            }
            
            String[] keys = layers.Keys.ToArray();
            for (short i = 0; i < keys.Length; i++)
            {
                if (layers[keys[i]].getNetName().Equals(""))
                {
                    continue;
                }
                message("");
                layers[keys[i]].checkLayer(structCheckBox.Checked, dataCheckBox.Checked);
            }
            message("Проверка завершена!");
        }
    }
}
