using Example2.ExportModule.SQLModule;

namespace Example2.ExportModule
{
    partial class ExportControl : MyRootControl
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
            expThemeComboBox = new ComboBox();
            expFileExtComboBox = new ComboBox();
            expRunButton = new Button();
            expCfgFileTextBox = new TextBox();
            expCfgButton = new Button();
            expAllLayersCheckBox = new CheckBox();
            exportPathTextBox = new TextBox();
            button1 = new Button();
            expAllThemesCheckBox = new CheckBox();
            structCheckerTreeView = new TreeView();
            expPptLayerComboBox = new ComboBox();
            themeTreeView = new TreeView();
            groupThemeTreeView = new TreeView();
            borderTreeView = new TreeView();
            allBoundCheckBox = new CheckBox();
            allGroupConditionCheckBox = new CheckBox();
            contextMenu = new ContextMenuStrip(components);
            editGroupButton = new Button();
            dictionaryFieldTextBox = new TextBox();
            addDictionFieldButton = new Button();
            label1 = new Label();
            dictionFieldTreeView = new TreeView();
            annotationTreeView = new TreeView();
            label2 = new Label();
            groupFiltresRadioButton = new RadioButton();
            themeRadioButton = new RadioButton();
            typesOfExportGroupBox = new GroupBox();
            typesRadioButton = new RadioButton();
            sqlQueryRadioButton = new RadioButton();
            expDirEtapCheckBox = new CheckBox();
            saveEtapNameCheckBox = new CheckBox();
            tabControl1 = new TabControl();
            generalTabPage = new TabPage();
            SQLPage = new TabPage();
            sqlControl1 = new SQLControl();
            typesTabPage = new TabPage();
            typeControl1 = new TypeModule.TypeControl();
            typesPanel = new Panel();
            SQLTabPage = new TabPage();
            SQLPanel = new Panel();
            panel2 = new Panel();
            indexCollectionFlowLayout = new FlowLayoutPanel();
            indexSqlTreeView = new TreeView();
            panel3 = new Panel();
            richTextBox1 = new RichTextBox();
            panel1 = new Panel();
            sampleLayerNameRichText = new RichTextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label6 = new Label();
            sqlAllLayersCheckBox = new CheckBox();
            layerSQLComboBox = new ComboBox();
            addIndexButton = new Button();
            typeOfSQLGroupBox = new GroupBox();
            sqlRadioButton = new RadioButton();
            prepareQueryRadioButton = new RadioButton();
            label5 = new Label();
            textBox1 = new TextBox();
            label4 = new Label();
            groupFiltersTabPage = new TabPage();
            groupFiltersPanel = new Panel();
            themesTabPage = new TabPage();
            themesPanel = new Panel();
            toolTip1 = new ToolTip(components);
            typesOfExportGroupBox.SuspendLayout();
            tabControl1.SuspendLayout();
            generalTabPage.SuspendLayout();
            SQLPage.SuspendLayout();
            typesTabPage.SuspendLayout();
            typesPanel.SuspendLayout();
            SQLTabPage.SuspendLayout();
            SQLPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            typeOfSQLGroupBox.SuspendLayout();
            groupFiltersTabPage.SuspendLayout();
            groupFiltersPanel.SuspendLayout();
            themesTabPage.SuspendLayout();
            themesPanel.SuspendLayout();
            SuspendLayout();
            // 
            // expThemeComboBox
            // 
            expThemeComboBox.FormattingEnabled = true;
            expThemeComboBox.Location = new Point(547, 3);
            expThemeComboBox.Name = "expThemeComboBox";
            expThemeComboBox.Size = new Size(258, 23);
            expThemeComboBox.TabIndex = 0;
            expThemeComboBox.Text = "Тема для экспорта";
            expThemeComboBox.SelectedIndexChanged += expThemeComboBox_SelectedIndexChanged;
            expThemeComboBox.GotFocus += expThemeComboBox_GotFocus;
            // 
            // expFileExtComboBox
            // 
            expFileExtComboBox.FormattingEnabled = true;
            expFileExtComboBox.Location = new Point(547, 273);
            expFileExtComboBox.Name = "expFileExtComboBox";
            expFileExtComboBox.Size = new Size(183, 23);
            expFileExtComboBox.TabIndex = 0;
            expFileExtComboBox.Text = "Формат выходного файла";
            expFileExtComboBox.SelectedIndexChanged += expFileExtComboBox_SelectedIndexChanged;
            // 
            // expRunButton
            // 
            expRunButton.Location = new Point(811, 272);
            expRunButton.Name = "expRunButton";
            expRunButton.Size = new Size(241, 31);
            expRunButton.TabIndex = 2;
            expRunButton.Text = "Старт";
            expRunButton.UseVisualStyleBackColor = true;
            expRunButton.Click += expRunButton_Click;
            // 
            // expCfgFileTextBox
            // 
            expCfgFileTextBox.Location = new Point(547, 215);
            expCfgFileTextBox.Name = "expCfgFileTextBox";
            expCfgFileTextBox.PlaceholderText = "Файл конфигурации";
            expCfgFileTextBox.Size = new Size(183, 23);
            expCfgFileTextBox.TabIndex = 3;
            expCfgFileTextBox.TextChanged += expCfgFileTextBox_TextChanged;
            // 
            // expCfgButton
            // 
            expCfgButton.Location = new Point(736, 214);
            expCfgButton.Name = "expCfgButton";
            expCfgButton.Size = new Size(69, 23);
            expCfgButton.TabIndex = 4;
            expCfgButton.Text = "Открыть";
            expCfgButton.UseVisualStyleBackColor = true;
            expCfgButton.Click += expCfgButton_Click;
            // 
            // expAllLayersCheckBox
            // 
            expAllLayersCheckBox.AutoSize = true;
            expAllLayersCheckBox.Location = new Point(226, 284);
            expAllLayersCheckBox.Name = "expAllLayersCheckBox";
            expAllLayersCheckBox.Size = new Size(164, 19);
            expAllLayersCheckBox.TabIndex = 6;
            expAllLayersCheckBox.Text = "Вся структура всех слоев";
            expAllLayersCheckBox.UseVisualStyleBackColor = true;
            expAllLayersCheckBox.CheckedChanged += expAllLayersCheckBox_CheckedChanged;
            // 
            // exportPathTextBox
            // 
            exportPathTextBox.Location = new Point(547, 244);
            exportPathTextBox.Name = "exportPathTextBox";
            exportPathTextBox.PlaceholderText = "Путь экспорта";
            exportPathTextBox.Size = new Size(183, 23);
            exportPathTextBox.TabIndex = 8;
            exportPathTextBox.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(736, 243);
            button1.Name = "button1";
            button1.Size = new Size(69, 23);
            button1.TabIndex = 9;
            button1.Text = "Выбрать";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // expAllThemesCheckBox
            // 
            expAllThemesCheckBox.AutoSize = true;
            expAllThemesCheckBox.Enabled = false;
            expAllThemesCheckBox.Location = new Point(3, 274);
            expAllThemesCheckBox.Name = "expAllThemesCheckBox";
            expAllThemesCheckBox.Size = new Size(77, 19);
            expAllThemesCheckBox.TabIndex = 10;
            expAllThemesCheckBox.Text = "Все темы";
            expAllThemesCheckBox.UseVisualStyleBackColor = true;
            // 
            // structCheckerTreeView
            // 
            structCheckerTreeView.Location = new Point(226, 3);
            structCheckerTreeView.Name = "structCheckerTreeView";
            structCheckerTreeView.Size = new Size(315, 275);
            structCheckerTreeView.TabIndex = 13;
            structCheckerTreeView.AfterCheck += structCheckerTreeView_AfterCheck;
            // 
            // expPptLayerComboBox
            // 
            expPptLayerComboBox.FormattingEnabled = true;
            expPptLayerComboBox.Location = new Point(3, 3);
            expPptLayerComboBox.Name = "expPptLayerComboBox";
            expPptLayerComboBox.Size = new Size(217, 23);
            expPptLayerComboBox.TabIndex = 14;
            expPptLayerComboBox.Text = "Слой с границами ППТ";
            expPptLayerComboBox.SelectedIndexChanged += expPptLayerComboBox_SelectedIndexChanged;
            // 
            // themeTreeView
            // 
            themeTreeView.Location = new Point(3, 3);
            themeTreeView.Name = "themeTreeView";
            themeTreeView.Size = new Size(293, 265);
            themeTreeView.TabIndex = 16;
            themeTreeView.AfterCheck += themeTreeView_AfterCheck;
            // 
            // groupThemeTreeView
            // 
            groupThemeTreeView.Dock = DockStyle.Right;
            groupThemeTreeView.Location = new Point(491, 0);
            groupThemeTreeView.Name = "groupThemeTreeView";
            groupThemeTreeView.Size = new Size(566, 306);
            groupThemeTreeView.TabIndex = 17;
            // 
            // borderTreeView
            // 
            borderTreeView.Location = new Point(3, 32);
            borderTreeView.Name = "borderTreeView";
            borderTreeView.Size = new Size(217, 246);
            borderTreeView.TabIndex = 18;
            // 
            // allBoundCheckBox
            // 
            allBoundCheckBox.AutoSize = true;
            allBoundCheckBox.Checked = true;
            allBoundCheckBox.CheckState = CheckState.Checked;
            allBoundCheckBox.Enabled = false;
            allBoundCheckBox.Location = new Point(3, 284);
            allBoundCheckBox.Name = "allBoundCheckBox";
            allBoundCheckBox.Size = new Size(160, 19);
            allBoundCheckBox.TabIndex = 21;
            allBoundCheckBox.Text = "Все объекты в слое ППТ";
            allBoundCheckBox.UseVisualStyleBackColor = true;
            allBoundCheckBox.CheckedChanged += allBoundCheckBox_CheckedChanged;
            // 
            // allGroupConditionCheckBox
            // 
            allGroupConditionCheckBox.AutoSize = true;
            allGroupConditionCheckBox.Location = new Point(3, 3);
            allGroupConditionCheckBox.Name = "allGroupConditionCheckBox";
            allGroupConditionCheckBox.Size = new Size(138, 19);
            allGroupConditionCheckBox.TabIndex = 20;
            allGroupConditionCheckBox.Text = "Все группы условий";
            allGroupConditionCheckBox.UseVisualStyleBackColor = true;
            // 
            // contextMenu
            // 
            contextMenu.Name = "contextMenu";
            contextMenu.Size = new Size(61, 4);
            // 
            // editGroupButton
            // 
            editGroupButton.Location = new Point(3, 28);
            editGroupButton.Name = "editGroupButton";
            editGroupButton.Size = new Size(139, 25);
            editGroupButton.TabIndex = 22;
            editGroupButton.Text = "Редактировать группы фильтров";
            editGroupButton.UseVisualStyleBackColor = true;
            editGroupButton.Click += editGroupButton_Click;
            // 
            // dictionaryFieldTextBox
            // 
            dictionaryFieldTextBox.Location = new Point(547, 50);
            dictionaryFieldTextBox.Name = "dictionaryFieldTextBox";
            dictionaryFieldTextBox.PlaceholderText = "Новое поле";
            dictionaryFieldTextBox.Size = new Size(220, 23);
            dictionaryFieldTextBox.TabIndex = 26;
            // 
            // addDictionFieldButton
            // 
            addDictionFieldButton.Location = new Point(773, 49);
            addDictionFieldButton.Name = "addDictionFieldButton";
            addDictionFieldButton.Size = new Size(32, 24);
            addDictionFieldButton.TabIndex = 27;
            addDictionFieldButton.Text = "+";
            addDictionFieldButton.UseVisualStyleBackColor = true;
            addDictionFieldButton.Click += addDictionFieldButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(547, 29);
            label1.Name = "label1";
            label1.Size = new Size(174, 15);
            label1.TabIndex = 28;
            label1.Text = "Поля словари из базы данных";
            // 
            // dictionFieldTreeView
            // 
            dictionFieldTreeView.Location = new Point(547, 79);
            dictionFieldTreeView.Name = "dictionFieldTreeView";
            dictionFieldTreeView.Size = new Size(258, 130);
            dictionFieldTreeView.TabIndex = 29;
            dictionFieldTreeView.MouseDown += dictionFieldTreeView_MouseDown;
            // 
            // annotationTreeView
            // 
            annotationTreeView.Location = new Point(811, 24);
            annotationTreeView.Name = "annotationTreeView";
            annotationTreeView.Size = new Size(241, 132);
            annotationTreeView.TabIndex = 30;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(811, 6);
            label2.Name = "label2";
            label2.Size = new Size(164, 15);
            label2.TabIndex = 31;
            label2.Text = "Экспортируемые аннотации";
            // 
            // groupFiltresRadioButton
            // 
            groupFiltresRadioButton.AutoSize = true;
            groupFiltresRadioButton.Location = new Point(6, 40);
            groupFiltresRadioButton.Name = "groupFiltresRadioButton";
            groupFiltresRadioButton.Size = new Size(129, 19);
            groupFiltresRadioButton.TabIndex = 24;
            groupFiltresRadioButton.Text = "группам фильтров";
            groupFiltresRadioButton.UseVisualStyleBackColor = true;
            groupFiltresRadioButton.CheckedChanged += TypeOfExportRadioButton_CheckedChanged;
            // 
            // themeRadioButton
            // 
            themeRadioButton.AutoSize = true;
            themeRadioButton.Checked = true;
            themeRadioButton.Location = new Point(6, 20);
            themeRadioButton.Name = "themeRadioButton";
            themeRadioButton.Size = new Size(60, 19);
            themeRadioButton.TabIndex = 23;
            themeRadioButton.TabStop = true;
            themeRadioButton.Text = "темам";
            themeRadioButton.UseVisualStyleBackColor = true;
            themeRadioButton.CheckedChanged += TypeOfExportRadioButton_CheckedChanged;
            // 
            // typesOfExportGroupBox
            // 
            typesOfExportGroupBox.Controls.Add(typesRadioButton);
            typesOfExportGroupBox.Controls.Add(sqlQueryRadioButton);
            typesOfExportGroupBox.Controls.Add(themeRadioButton);
            typesOfExportGroupBox.Controls.Add(groupFiltresRadioButton);
            typesOfExportGroupBox.Location = new Point(811, 162);
            typesOfExportGroupBox.Name = "typesOfExportGroupBox";
            typesOfExportGroupBox.Size = new Size(241, 104);
            typesOfExportGroupBox.TabIndex = 25;
            typesOfExportGroupBox.TabStop = false;
            typesOfExportGroupBox.Text = "Экспорт по:";
            // 
            // typesRadioButton
            // 
            typesRadioButton.AutoSize = true;
            typesRadioButton.Location = new Point(6, 80);
            typesRadioButton.Name = "typesRadioButton";
            typesRadioButton.Size = new Size(59, 19);
            typesRadioButton.TabIndex = 26;
            typesRadioButton.Text = "типам";
            typesRadioButton.UseVisualStyleBackColor = true;
            typesRadioButton.CheckedChanged += TypeOfExportRadioButton_CheckedChanged;
            // 
            // sqlQueryRadioButton
            // 
            sqlQueryRadioButton.AutoSize = true;
            sqlQueryRadioButton.Location = new Point(6, 60);
            sqlQueryRadioButton.Name = "sqlQueryRadioButton";
            sqlQueryRadioButton.Size = new Size(93, 19);
            sqlQueryRadioButton.TabIndex = 25;
            sqlQueryRadioButton.Text = "SQL запросу";
            sqlQueryRadioButton.UseVisualStyleBackColor = true;
            sqlQueryRadioButton.CheckedChanged += TypeOfExportRadioButton_CheckedChanged;
            // 
            // expDirEtapCheckBox
            // 
            expDirEtapCheckBox.AutoSize = true;
            expDirEtapCheckBox.Location = new Point(3, 6);
            expDirEtapCheckBox.Name = "expDirEtapCheckBox";
            expDirEtapCheckBox.Size = new Size(137, 19);
            expDirEtapCheckBox.TabIndex = 1;
            expDirEtapCheckBox.Text = "Создать папку этапа";
            expDirEtapCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveEtapNameCheckBox
            // 
            saveEtapNameCheckBox.AutoSize = true;
            saveEtapNameCheckBox.Location = new Point(3, 26);
            saveEtapNameCheckBox.Name = "saveEtapNameCheckBox";
            saveEtapNameCheckBox.Size = new Size(175, 19);
            saveEtapNameCheckBox.TabIndex = 0;
            saveEtapNameCheckBox.Text = "Сохранить этап в названии";
            saveEtapNameCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(generalTabPage);
            tabControl1.Controls.Add(SQLPage);
            tabControl1.Controls.Add(typesTabPage);
            tabControl1.Controls.Add(SQLTabPage);
            tabControl1.Controls.Add(groupFiltersTabPage);
            tabControl1.Controls.Add(themesTabPage);
            tabControl1.Location = new Point(11, 10);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1071, 340);
            tabControl1.TabIndex = 33;
            tabControl1.Click += TabControl1_SelectedIndexChanged;
            // 
            // generalTabPage
            // 
            generalTabPage.Controls.Add(expPptLayerComboBox);
            generalTabPage.Controls.Add(borderTreeView);
            generalTabPage.Controls.Add(typesOfExportGroupBox);
            generalTabPage.Controls.Add(expRunButton);
            generalTabPage.Controls.Add(allBoundCheckBox);
            generalTabPage.Controls.Add(label2);
            generalTabPage.Controls.Add(button1);
            generalTabPage.Controls.Add(annotationTreeView);
            generalTabPage.Controls.Add(exportPathTextBox);
            generalTabPage.Controls.Add(structCheckerTreeView);
            generalTabPage.Controls.Add(expCfgFileTextBox);
            generalTabPage.Controls.Add(expCfgButton);
            generalTabPage.Controls.Add(expAllLayersCheckBox);
            generalTabPage.Controls.Add(expFileExtComboBox);
            generalTabPage.Controls.Add(expThemeComboBox);
            generalTabPage.Controls.Add(dictionFieldTreeView);
            generalTabPage.Controls.Add(label1);
            generalTabPage.Controls.Add(dictionaryFieldTextBox);
            generalTabPage.Controls.Add(addDictionFieldButton);
            generalTabPage.Location = new Point(4, 24);
            generalTabPage.Name = "generalTabPage";
            generalTabPage.Size = new Size(1063, 312);
            generalTabPage.TabIndex = 4;
            generalTabPage.Text = "Общие настройки";
            generalTabPage.UseVisualStyleBackColor = true;
            // 
            // SQLPage
            // 
            SQLPage.Controls.Add(sqlControl1);
            SQLPage.Location = new Point(4, 24);
            SQLPage.Name = "SQLPage";
            SQLPage.Size = new Size(1063, 312);
            SQLPage.TabIndex = 5;
            SQLPage.Text = "SQL запрос";
            SQLPage.UseVisualStyleBackColor = true;
            // 
            // sqlControl1
            // 
            sqlControl1.Location = new Point(3, 3);
            sqlControl1.Name = "sqlControl1";
            sqlControl1.Size = new Size(1057, 306);
            sqlControl1.TabIndex = 0;
            // 
            // typesTabPage
            // 
            typesTabPage.Controls.Add(typeControl1);
            typesTabPage.Controls.Add(typesPanel);
            typesTabPage.Location = new Point(4, 24);
            typesTabPage.Name = "typesTabPage";
            typesTabPage.Size = new Size(1063, 312);
            typesTabPage.TabIndex = 3;
            typesTabPage.Text = "Типы";
            typesTabPage.UseVisualStyleBackColor = true;
            // 
            // typeControl1
            // 
            typeControl1.Dock = DockStyle.Fill;
            typeControl1.Location = new Point(0, 0);
            typeControl1.Name = "typeControl1";
            typeControl1.Size = new Size(777, 312);
            typeControl1.TabIndex = 3;
            // 
            // typesPanel
            // 
            typesPanel.Controls.Add(saveEtapNameCheckBox);
            typesPanel.Controls.Add(expDirEtapCheckBox);
            typesPanel.Dock = DockStyle.Right;
            typesPanel.Location = new Point(777, 0);
            typesPanel.Name = "typesPanel";
            typesPanel.Size = new Size(286, 312);
            typesPanel.TabIndex = 2;
            // 
            // SQLTabPage
            // 
            SQLTabPage.Controls.Add(SQLPanel);
            SQLTabPage.Location = new Point(4, 24);
            SQLTabPage.Name = "SQLTabPage";
            SQLTabPage.Size = new Size(1063, 312);
            SQLTabPage.TabIndex = 2;
            SQLTabPage.Text = "не раб";
            SQLTabPage.UseVisualStyleBackColor = true;
            // 
            // SQLPanel
            // 
            SQLPanel.Controls.Add(panel2);
            SQLPanel.Controls.Add(panel3);
            SQLPanel.Controls.Add(panel1);
            SQLPanel.Dock = DockStyle.Fill;
            SQLPanel.Location = new Point(0, 0);
            SQLPanel.Name = "SQLPanel";
            SQLPanel.Size = new Size(1063, 312);
            SQLPanel.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Controls.Add(indexCollectionFlowLayout);
            panel2.Controls.Add(indexSqlTreeView);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(299, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(764, 312);
            panel2.TabIndex = 9;
            // 
            // indexCollectionFlowLayout
            // 
            indexCollectionFlowLayout.Dock = DockStyle.Left;
            indexCollectionFlowLayout.FlowDirection = FlowDirection.TopDown;
            indexCollectionFlowLayout.Location = new Point(0, 0);
            indexCollectionFlowLayout.Name = "indexCollectionFlowLayout";
            indexCollectionFlowLayout.Size = new Size(361, 312);
            indexCollectionFlowLayout.TabIndex = 9;
            // 
            // indexSqlTreeView
            // 
            indexSqlTreeView.Dock = DockStyle.Right;
            indexSqlTreeView.Location = new Point(358, 0);
            indexSqlTreeView.Name = "indexSqlTreeView";
            indexSqlTreeView.Size = new Size(406, 312);
            indexSqlTreeView.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(richTextBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Enabled = false;
            panel3.Location = new Point(299, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(764, 312);
            panel3.TabIndex = 8;
            panel3.Visible = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Top;
            richTextBox1.Location = new Point(0, 0);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(764, 263);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(sampleLayerNameRichText);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(sqlAllLayersCheckBox);
            panel1.Controls.Add(layerSQLComboBox);
            panel1.Controls.Add(addIndexButton);
            panel1.Controls.Add(typeOfSQLGroupBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(299, 312);
            panel1.TabIndex = 8;
            // 
            // sampleLayerNameRichText
            // 
            sampleLayerNameRichText.Enabled = false;
            sampleLayerNameRichText.Location = new Point(3, 100);
            sampleLayerNameRichText.Name = "sampleLayerNameRichText";
            sampleLayerNameRichText.Size = new Size(288, 24);
            sampleLayerNameRichText.TabIndex = 11;
            sampleLayerNameRichText.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 248);
            label3.Name = "label3";
            label3.Size = new Size(223, 15);
            label3.TabIndex = 10;
            label3.Text = "Значение принадлежости к демонтажу";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 266);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(288, 23);
            textBox2.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 230);
            label6.Name = "label6";
            label6.Size = new Size(180, 15);
            label6.TabIndex = 8;
            label6.Text = "Разбивка на стройку/демонтаж";
            // 
            // sqlAllLayersCheckBox
            // 
            sqlAllLayersCheckBox.AutoSize = true;
            sqlAllLayersCheckBox.Location = new Point(3, 76);
            sqlAllLayersCheckBox.Name = "sqlAllLayersCheckBox";
            sqlAllLayersCheckBox.Size = new Size(74, 19);
            sqlAllLayersCheckBox.TabIndex = 7;
            sqlAllLayersCheckBox.Text = "все слои";
            sqlAllLayersCheckBox.UseVisualStyleBackColor = true;
            // 
            // layerSQLComboBox
            // 
            layerSQLComboBox.FormattingEnabled = true;
            layerSQLComboBox.Location = new Point(3, 50);
            layerSQLComboBox.Name = "layerSQLComboBox";
            layerSQLComboBox.Size = new Size(289, 23);
            layerSQLComboBox.TabIndex = 6;
            // 
            // addIndexButton
            // 
            addIndexButton.Location = new Point(3, 176);
            addIndexButton.Name = "addIndexButton";
            addIndexButton.Size = new Size(289, 23);
            addIndexButton.TabIndex = 5;
            addIndexButton.Text = "Добавить индекс поиска";
            addIndexButton.UseVisualStyleBackColor = true;
            // 
            // typeOfSQLGroupBox
            // 
            typeOfSQLGroupBox.Controls.Add(sqlRadioButton);
            typeOfSQLGroupBox.Controls.Add(prepareQueryRadioButton);
            typeOfSQLGroupBox.Location = new Point(3, 3);
            typeOfSQLGroupBox.Name = "typeOfSQLGroupBox";
            typeOfSQLGroupBox.Size = new Size(289, 41);
            typeOfSQLGroupBox.TabIndex = 0;
            typeOfSQLGroupBox.TabStop = false;
            typeOfSQLGroupBox.Text = "Выриант SQL запроса";
            // 
            // sqlRadioButton
            // 
            sqlRadioButton.AutoSize = true;
            sqlRadioButton.Location = new Point(189, 17);
            sqlRadioButton.Name = "sqlRadioButton";
            sqlRadioButton.Size = new Size(90, 19);
            sqlRadioButton.TabIndex = 1;
            sqlRadioButton.TabStop = true;
            sqlRadioButton.Text = "чистый SQL";
            sqlRadioButton.UseVisualStyleBackColor = true;
            // 
            // prepareQueryRadioButton
            // 
            prepareQueryRadioButton.AutoSize = true;
            prepareQueryRadioButton.Location = new Point(6, 18);
            prepareQueryRadioButton.Name = "prepareQueryRadioButton";
            prepareQueryRadioButton.Size = new Size(99, 19);
            prepareQueryRadioButton.TabIndex = 0;
            prepareQueryRadioButton.TabStop = true;
            prepareQueryRadioButton.Text = "упрощенный";
            prepareQueryRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 148);
            label5.Name = "label5";
            label5.Size = new Size(170, 15);
            label5.TabIndex = 4;
            label5.Text = "строка разделитель значений";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(179, 145);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(113, 23);
            textBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 127);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 3;
            label4.Text = "Извлечение этапа";
            // 
            // groupFiltersTabPage
            // 
            groupFiltersTabPage.Controls.Add(groupFiltersPanel);
            groupFiltersTabPage.Location = new Point(4, 24);
            groupFiltersTabPage.Name = "groupFiltersTabPage";
            groupFiltersTabPage.Padding = new Padding(3);
            groupFiltersTabPage.Size = new Size(1063, 312);
            groupFiltersTabPage.TabIndex = 0;
            groupFiltersTabPage.Text = "не раб";
            groupFiltersTabPage.UseVisualStyleBackColor = true;
            // 
            // groupFiltersPanel
            // 
            groupFiltersPanel.Controls.Add(editGroupButton);
            groupFiltersPanel.Controls.Add(allGroupConditionCheckBox);
            groupFiltersPanel.Controls.Add(groupThemeTreeView);
            groupFiltersPanel.Dock = DockStyle.Fill;
            groupFiltersPanel.Location = new Point(3, 3);
            groupFiltersPanel.Name = "groupFiltersPanel";
            groupFiltersPanel.Size = new Size(1057, 306);
            groupFiltersPanel.TabIndex = 23;
            // 
            // themesTabPage
            // 
            themesTabPage.Controls.Add(themesPanel);
            themesTabPage.Location = new Point(4, 24);
            themesTabPage.Name = "themesTabPage";
            themesTabPage.Padding = new Padding(3);
            themesTabPage.Size = new Size(1063, 312);
            themesTabPage.TabIndex = 1;
            themesTabPage.Text = "не раб";
            themesTabPage.UseVisualStyleBackColor = true;
            // 
            // themesPanel
            // 
            themesPanel.Controls.Add(expAllThemesCheckBox);
            themesPanel.Controls.Add(themeTreeView);
            themesPanel.Dock = DockStyle.Fill;
            themesPanel.Location = new Point(3, 3);
            themesPanel.Name = "themesPanel";
            themesPanel.Size = new Size(1057, 306);
            themesPanel.TabIndex = 17;
            // 
            // ExportControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabControl1);
            Name = "ExportControl";
            Padding = new Padding(2);
            Size = new Size(1087, 355);
            Load += ExportControl_Load;
            typesOfExportGroupBox.ResumeLayout(false);
            typesOfExportGroupBox.PerformLayout();
            tabControl1.ResumeLayout(false);
            generalTabPage.ResumeLayout(false);
            generalTabPage.PerformLayout();
            SQLPage.ResumeLayout(false);
            typesTabPage.ResumeLayout(false);
            typesPanel.ResumeLayout(false);
            typesPanel.PerformLayout();
            SQLTabPage.ResumeLayout(false);
            SQLPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            typeOfSQLGroupBox.ResumeLayout(false);
            typeOfSQLGroupBox.PerformLayout();
            groupFiltersTabPage.ResumeLayout(false);
            groupFiltersPanel.ResumeLayout(false);
            groupFiltersPanel.PerformLayout();
            themesTabPage.ResumeLayout(false);
            themesPanel.ResumeLayout(false);
            themesPanel.PerformLayout();
            ResumeLayout(false);
        }

        private void ExpThemeComboBox_GotFocus(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private ComboBox expThemeComboBox;
        private ComboBox expFileExtComboBox;
        private Button expRunButton;
        private TextBox expCfgFileTextBox;
        private Button expCfgButton;
        private CheckBox expAllLayersCheckBox;
        private TextBox exportPathTextBox;
        private Button button1;
        private CheckBox expAllThemesCheckBox;
        private TreeView structCheckerTreeView;
        private ComboBox expPptLayerComboBox;
        private TreeView themeTreeView;
        private TreeView groupThemeTreeView;
        private TreeView borderTreeView;
        private CheckBox allBoundCheckBox;
        private CheckBox allGroupConditionCheckBox;
        private ContextMenuStrip contextMenu;
        private Button editGroupButton;
        private TextBox dictionaryFieldTextBox;
        private Button addDictionFieldButton;
        private Label label1;
        private TreeView dictionFieldTreeView;
        private TreeView annotationTreeView;
        private Label label2;
        private RadioButton groupFiltresRadioButton;
        private RadioButton themeRadioButton;
        private GroupBox typesOfExportGroupBox;
        private CheckBox expDirEtapCheckBox;
        private CheckBox saveEtapNameCheckBox;
        private TabControl tabControl1;
        private TabPage groupFiltersTabPage;
        private TabPage themesTabPage;
        private TabPage SQLTabPage;
        private TabPage typesTabPage;
        private RadioButton typesRadioButton;
        private RadioButton sqlQueryRadioButton;
        private GroupBox typeOfSQLGroupBox;
        private RadioButton sqlRadioButton;
        private RadioButton prepareQueryRadioButton;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private TabPage generalTabPage;
        private Panel panel3;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private Panel panel1;
        private TreeView indexSqlTreeView;
        private ComboBox layerSQLComboBox;
        private Button addIndexButton;
        private Label label6;
        private CheckBox sqlAllLayersCheckBox;
        private Label label3;
        private TextBox textBox2;
        private Panel SQLPanel;
        private Panel groupFiltersPanel;
        private Panel themesPanel;
        private Panel typesPanel;
        private FlowLayoutPanel indexCollectionFlowLayout;
        private RichTextBox sampleLayerNameRichText;
        private ToolTip toolTip1;
        private TabPage SQLPage;
        private SQLControl sqlControl1;
        private TypeModule.TypeControl typeControl1;
    }
}
