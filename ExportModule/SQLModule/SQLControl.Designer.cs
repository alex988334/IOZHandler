namespace Example2.ExportModule.SQLModule
{
    partial class SQLControl
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
            components = new System.ComponentModel.Container();
            SQLPanel = new Panel();
            panel2 = new Panel();
            sqlViewerRichText = new RichTextBox();
            indexSqlTreeView = new TreeView();
            panel1 = new Panel();
            panel3 = new Panel();
            typeOfSQLGroupBox = new GroupBox();
            sqlRadioButton = new RadioButton();
            prepareQueryRadioButton = new RadioButton();
            layerComboBox = new ComboBox();
            saveButton = new Button();
            etapDictionaryTextBox = new TextBox();
            fileAliasTextBox = new TextBox();
            deleteButton = new Button();
            addButton = new Button();
            lastLayerComboBox = new ComboBox();
            groupFiltersControl1 = new GroupFiltersControl();
            toolTip1 = new ToolTip(components);
            SQLPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            typeOfSQLGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // SQLPanel
            // 
            SQLPanel.Controls.Add(panel2);
            SQLPanel.Controls.Add(panel1);
            SQLPanel.Dock = DockStyle.Fill;
            SQLPanel.Location = new Point(0, 0);
            SQLPanel.Name = "SQLPanel";
            SQLPanel.Size = new Size(1046, 266);
            SQLPanel.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.Controls.Add(sqlViewerRichText);
            panel2.Controls.Add(indexSqlTreeView);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(613, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(433, 266);
            panel2.TabIndex = 9;
            // 
            // sqlViewerRichText
            // 
            sqlViewerRichText.Dock = DockStyle.Fill;
            sqlViewerRichText.Location = new Point(0, 0);
            sqlViewerRichText.Name = "sqlViewerRichText";
            sqlViewerRichText.Size = new Size(358, 266);
            sqlViewerRichText.TabIndex = 9;
            sqlViewerRichText.Text = "";
            // 
            // indexSqlTreeView
            // 
            indexSqlTreeView.Dock = DockStyle.Right;
            indexSqlTreeView.Location = new Point(358, 0);
            indexSqlTreeView.Name = "indexSqlTreeView";
            indexSqlTreeView.Size = new Size(75, 266);
            indexSqlTreeView.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(groupFiltersControl1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(613, 266);
            panel1.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(typeOfSQLGroupBox);
            panel3.Controls.Add(layerComboBox);
            panel3.Controls.Add(saveButton);
            panel3.Controls.Add(etapDictionaryTextBox);
            panel3.Controls.Add(fileAliasTextBox);
            panel3.Controls.Add(deleteButton);
            panel3.Controls.Add(addButton);
            panel3.Controls.Add(lastLayerComboBox);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(3);
            panel3.Size = new Size(293, 266);
            panel3.TabIndex = 23;
            // 
            // typeOfSQLGroupBox
            // 
            typeOfSQLGroupBox.Controls.Add(sqlRadioButton);
            typeOfSQLGroupBox.Controls.Add(prepareQueryRadioButton);
            typeOfSQLGroupBox.Location = new Point(3, 3);
            typeOfSQLGroupBox.Name = "typeOfSQLGroupBox";
            typeOfSQLGroupBox.Size = new Size(281, 41);
            typeOfSQLGroupBox.TabIndex = 0;
            typeOfSQLGroupBox.TabStop = false;
            typeOfSQLGroupBox.Text = "Выриант SQL запроса";
            // 
            // sqlRadioButton
            // 
            sqlRadioButton.AutoSize = true;
            sqlRadioButton.Enabled = false;
            sqlRadioButton.Location = new Point(189, 17);
            sqlRadioButton.Name = "sqlRadioButton";
            sqlRadioButton.Size = new Size(90, 19);
            sqlRadioButton.TabIndex = 1;
            sqlRadioButton.Text = "чистый SQL";
            sqlRadioButton.UseVisualStyleBackColor = true;
            sqlRadioButton.Visible = false;
            // 
            // prepareQueryRadioButton
            // 
            prepareQueryRadioButton.AutoSize = true;
            prepareQueryRadioButton.Checked = true;
            prepareQueryRadioButton.Location = new Point(6, 18);
            prepareQueryRadioButton.Name = "prepareQueryRadioButton";
            prepareQueryRadioButton.Size = new Size(99, 19);
            prepareQueryRadioButton.TabIndex = 0;
            prepareQueryRadioButton.TabStop = true;
            prepareQueryRadioButton.Text = "упрощенный";
            prepareQueryRadioButton.UseVisualStyleBackColor = true;
            // 
            // layerComboBox
            // 
            layerComboBox.FormattingEnabled = true;
            layerComboBox.Location = new Point(3, 50);
            layerComboBox.Name = "layerComboBox";
            layerComboBox.Size = new Size(247, 23);
            layerComboBox.TabIndex = 6;
            layerComboBox.Text = "Слой";
            // 
            // saveButton
            // 
            saveButton.Dock = DockStyle.Bottom;
            saveButton.Location = new Point(3, 241);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(287, 22);
            saveButton.TabIndex = 14;
            saveButton.Text = "Сохранить изменения";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // etapDictionaryTextBox
            // 
            etapDictionaryTextBox.Location = new Point(3, 79);
            etapDictionaryTextBox.Name = "etapDictionaryTextBox";
            etapDictionaryTextBox.PlaceholderText = "Сопоставляемая запись этапа из словаря";
            etapDictionaryTextBox.Size = new Size(279, 23);
            etapDictionaryTextBox.TabIndex = 16;
            toolTip1.SetToolTip(etapDictionaryTextBox, "Сопоставляемая запись этапа из словаря");
            // 
            // fileAliasTextBox
            // 
            fileAliasTextBox.Location = new Point(3, 139);
            fileAliasTextBox.Name = "fileAliasTextBox";
            fileAliasTextBox.PlaceholderText = "Псевдоним в результирующем файле";
            fileAliasTextBox.Size = new Size(247, 23);
            fileAliasTextBox.TabIndex = 17;
            toolTip1.SetToolTip(fileAliasTextBox, "Псевдоним в результирующем файле");
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(254, 50);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(28, 23);
            deleteButton.TabIndex = 20;
            deleteButton.Text = "-";
            toolTip1.SetToolTip(deleteButton, "Удалить сопоставление для слоя");
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.Location = new Point(254, 139);
            addButton.Name = "addButton";
            addButton.Size = new Size(28, 23);
            addButton.TabIndex = 5;
            addButton.Text = "+";
            toolTip1.SetToolTip(addButton, "Добавить сопоставление для слоя");
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // lastLayerComboBox
            // 
            lastLayerComboBox.FormattingEnabled = true;
            lastLayerComboBox.Location = new Point(3, 108);
            lastLayerComboBox.Name = "lastLayerComboBox";
            lastLayerComboBox.Size = new Size(279, 23);
            lastLayerComboBox.TabIndex = 21;
            lastLayerComboBox.Text = "Слой извлечения существующих";
            toolTip1.SetToolTip(lastLayerComboBox, "Слой извлечения существующих");
            // 
            // groupFiltersControl1
            // 
            groupFiltersControl1.Dock = DockStyle.Right;
            groupFiltersControl1.Location = new Point(293, 0);
            groupFiltersControl1.Name = "groupFiltersControl1";
            groupFiltersControl1.Padding = new Padding(3);
            groupFiltersControl1.Size = new Size(320, 266);
            groupFiltersControl1.TabIndex = 22;
            // 
            // SQLControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SQLPanel);
            Name = "SQLControl";
            Size = new Size(1046, 266);
            SQLPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            typeOfSQLGroupBox.ResumeLayout(false);
            typeOfSQLGroupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel SQLPanel;
        private Panel panel2;
        private TreeView indexSqlTreeView;
        private Panel panel1;
        private RichTextBox sampleLayerNameichText;
        private TextBox textBox2;
        private CheckBox sqlAllLayersCheckBox;
        private ComboBox layerComboBox;
        private Button addButton;
        private Button saveButton;
        private TextBox etapDictionaryTextBox;
        private TextBox fileAliasTextBox;
        private Button deleteButton;
        private ComboBox lastLayerComboBox;
        private GroupBox typeOfSQLGroupBox;
        private RadioButton sqlRadioButton;
        private RadioButton prepareQueryRadioButton;
        private ToolTip toolTip1;
        private GroupFiltersControl groupFiltersControl1;
        private Panel panel3;
        private RichTextBox sqlViewerRichText;
    }
}
