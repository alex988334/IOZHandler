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
using ZuluOcx;

namespace Example2.MapModule
{
    internal partial class MapControl : MyRootControl
    {
        private ISampleNets nets;
        private Dictionary<String, MyLayer> layers;
        private MapDoc map;

        public delegate void OpenMap(MapDoc map);
        public event OpenMap OnOpenMap;

        public delegate void OpenSampleNets(ISampleNets nets);
        public event OpenSampleNets OnOpenSampleNets;

        public delegate void InitLayers(Dictionary<String, MyLayer> layers);
        public event InitLayers OnInitLayers;

        private String lastMapPath;
        private String sampleNetPath;

        public MapControl()
        {
            InitializeComponent();

            map = new MapDoc();
            layers = new Dictionary<String, MyLayer>();
        }

        private void initMap(String mapName)
        {
            if (String.Compare(mapName, "") != 0 && map.Open(mapName))
            {
                pathSampleTextBox.Enabled = true;
                message("Название карты: " + map.Name);
                OnOpenMap(map);
            }
            else
            {
                pathSampleTextBox.Enabled = false;
                messageC("Не удалось открыть файл карты: " + mapPathTextBox.Text, new int[] { errCode() });
            }
        }

        private void pathSampleTextBox_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV files(*.csv)|*.csv|Text files(*.txt)|*.txt";
            if (sampleNetPath != null)
            {
                openFileDialog1.InitialDirectory = removeFileName(sampleNetPath, ".csv");
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathSampleTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void mapPathTextBox_DoubleClick(object sender, EventArgs e)
        {        
          /*  ZuluCommDlg dlg = new ZuluCommDlg();
            dlg.DialogTitle = "Пример выбора папки";

            if (dlg.ShowOpen(1) != null) 
            {
                mapPathTextBox.Text = dlg.FileName;
            }  */ 

            openFileDialog1.Filter = "Zulu map files(*.zmp)|*.zmp";
            openFileDialog1.InitialDirectory = lastMapPath;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mapPathTextBox.Text = openFileDialog1.FileName;
            }
        }

        private void initSampleNets(String path)
        {
            if (!File.Exists(path))
            {
                messageC("Не удалось открыть файл шаблона: " + path, new int[] { errCode() });
                return;
            }

            String[] args = path.Split(".");

            if (String.Compare(args[args.Length - 1], "csv", StringComparison.OrdinalIgnoreCase) == 0)
            {
                try
                {
                    nets = new SampleNets(pathSampleTextBox.Text, SampleNets.MODE_CSV);

                    messageC("Загруженный шаблон: ", new int[] { boldCode() });
                    message(nets.ToString());
                    OnOpenSampleNets(nets);
                    initLayers();
                }
                catch (Exception e)
                {
                    messageC(e.Message, new int[] { errCode(), boldCode() });
                }
            }
        }

        private void initLayers()
        {
            for (short i = 1; i <= map.Layers.Count; i++)
            {
               /* if (onlyVisibleLayers.Checked && map.Layers[(short)i].Visible == false)
                {
                    continue;
                }
               */
                MyLayer l = new MyLayer(map.Layers[(short)i], nets);
                // if (l.getNetName() != null && l.getNetName().Length != 0)
                //  {
                layers[l.getName()] = l;
                message("Слой: " + l.getName());
                message("Тип сети: " + l.getNetName());
                //   }                
            }
            OnInitLayers(layers);
        }

        private void loadMapButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(mapPathTextBox.Text) && File.Exists(pathSampleTextBox.Text))
            {
                lastMapPath = mapPathTextBox.Text;
                sampleNetPath = pathSampleTextBox.Text;
                initMap(mapPathTextBox.Text);
                initSampleNets(pathSampleTextBox.Text);
            }
            else
            {
                messageC("Один из указанных путей не существует!", new int[] { errCode() });
            }
        }

        public String getLastMap()
        {
            return lastMapPath;
        }

        public String getSampleNets()
        {
            return sampleNetPath;
        }
        public void setSampleNets(String pathFile)
        {
            sampleNetPath = pathFile;
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

        public void setLastMap(String pathFile)
        {
            lastMapPath = removeFileName(pathFile, ".zmp");
        }

        private void MapControl_Load(object sender, EventArgs e)
        {
            if (sampleNetPath != null && sampleNetPath.Length > 0)
            {
                pathSampleTextBox.Text = sampleNetPath;
            }
        }

        
    }
}
