namespace Example2.MapModule
{
    partial class MapControl: MyRootControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            mapPathTextBox = new TextBox();
            pathSampleTextBox = new TextBox();
            loadMapButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            onlyVisibleLayers = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 8);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "Карта";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 37);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 1;
            label2.Text = "Шаблон";
            // 
            // mapPathTextBox
            // 
            mapPathTextBox.Location = new Point(63, 5);
            mapPathTextBox.Name = "mapPathTextBox";
            mapPathTextBox.Size = new Size(633, 23);
            mapPathTextBox.TabIndex = 2;
            mapPathTextBox.DoubleClick += mapPathTextBox_DoubleClick;
            // 
            // pathSampleTextBox
            // 
            pathSampleTextBox.Location = new Point(63, 34);
            pathSampleTextBox.Name = "pathSampleTextBox";
            pathSampleTextBox.Size = new Size(633, 23);
            pathSampleTextBox.TabIndex = 3;
            pathSampleTextBox.DoubleClick += pathSampleTextBox_DoubleClick;
            // 
            // loadMapButton
            // 
            loadMapButton.Location = new Point(702, 4);
            loadMapButton.Name = "loadMapButton";
            loadMapButton.Size = new Size(75, 53);
            loadMapButton.TabIndex = 4;
            loadMapButton.Text = "Загрузить карту";
            loadMapButton.UseVisualStyleBackColor = true;
            loadMapButton.Click += loadMapButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // onlyVisibleLayers
            // 
            onlyVisibleLayers.AutoSize = true;
            onlyVisibleLayers.Checked = true;
            onlyVisibleLayers.CheckState = CheckState.Checked;
            onlyVisibleLayers.Location = new Point(63, 69);
            onlyVisibleLayers.Name = "onlyVisibleLayers";
            onlyVisibleLayers.Size = new Size(229, 19);
            onlyVisibleLayers.TabIndex = 5;
            onlyVisibleLayers.Text = "Обрабатывать только видимые слои";
            onlyVisibleLayers.UseVisualStyleBackColor = true;
            // 
            // MapControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            Controls.Add(onlyVisibleLayers);
            Controls.Add(loadMapButton);
            Controls.Add(pathSampleTextBox);
            Controls.Add(mapPathTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MapControl";
            Padding = new Padding(5);
            Size = new Size(785, 96);
            Load += MapControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private TextBox mapPathTextBox;
        private TextBox pathSampleTextBox;
        private Button loadMapButton;
        private OpenFileDialog openFileDialog1;
        private CheckBox onlyVisibleLayers;
    }
}
