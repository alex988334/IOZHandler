namespace Example2
{
    partial class EditorConditionGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.selectorLayerComboBox = new System.Windows.Forms.ComboBox();
            this.selectorThemeComboBox = new System.Windows.Forms.ComboBox();
            this.conditionListBox = new System.Windows.Forms.CheckedListBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.nameGroupTextBox = new System.Windows.Forms.TextBox();
            this.selectorGroupComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.deleteGroupCondButton = new System.Windows.Forms.Button();
            this.loadRuleGroupButton = new System.Windows.Forms.Button();
            this.addRuleButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.viewerTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // selectorLayerComboBox
            // 
            this.selectorLayerComboBox.FormattingEnabled = true;
            this.selectorLayerComboBox.Location = new System.Drawing.Point(12, 28);
            this.selectorLayerComboBox.Name = "selectorLayerComboBox";
            this.selectorLayerComboBox.Size = new System.Drawing.Size(227, 23);
            this.selectorLayerComboBox.TabIndex = 0;
            this.selectorLayerComboBox.SelectedIndexChanged += new System.EventHandler(this.selectorLayerComboBox_SelectedIndexChanged);
            // 
            // selectorThemeComboBox
            // 
            this.selectorThemeComboBox.FormattingEnabled = true;
            this.selectorThemeComboBox.Location = new System.Drawing.Point(12, 81);
            this.selectorThemeComboBox.Name = "selectorThemeComboBox";
            this.selectorThemeComboBox.Size = new System.Drawing.Size(227, 23);
            this.selectorThemeComboBox.TabIndex = 1;
            this.selectorThemeComboBox.SelectedIndexChanged += new System.EventHandler(this.selectorThemeComboBox_SelectedIndexChanged);
            // 
            // conditionListBox
            // 
            this.conditionListBox.FormattingEnabled = true;
            this.conditionListBox.Location = new System.Drawing.Point(245, 12);
            this.conditionListBox.Name = "conditionListBox";
            this.conditionListBox.Size = new System.Drawing.Size(277, 310);
            this.conditionListBox.TabIndex = 2;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(110, 163);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(129, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Сохранить в файл";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // nameGroupTextBox
            // 
            this.nameGroupTextBox.Location = new System.Drawing.Point(12, 134);
            this.nameGroupTextBox.Name = "nameGroupTextBox";
            this.nameGroupTextBox.Size = new System.Drawing.Size(227, 23);
            this.nameGroupTextBox.TabIndex = 4;
            // 
            // selectorGroupComboBox
            // 
            this.selectorGroupComboBox.FormattingEnabled = true;
            this.selectorGroupComboBox.Location = new System.Drawing.Point(12, 270);
            this.selectorGroupComboBox.Name = "selectorGroupComboBox";
            this.selectorGroupComboBox.Size = new System.Drawing.Size(227, 23);
            this.selectorGroupComboBox.TabIndex = 5;
            this.selectorGroupComboBox.DropDownClosed += new System.EventHandler(this.selectorGroupComboBox_DropDownClosed);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Список существующих групп";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Название группы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Тема";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Слой";
            // 
            // deleteGroupCondButton
            // 
            this.deleteGroupCondButton.Location = new System.Drawing.Point(12, 299);
            this.deleteGroupCondButton.Name = "deleteGroupCondButton";
            this.deleteGroupCondButton.Size = new System.Drawing.Size(75, 23);
            this.deleteGroupCondButton.TabIndex = 10;
            this.deleteGroupCondButton.Text = "Удалить";
            this.deleteGroupCondButton.UseVisualStyleBackColor = true;
            this.deleteGroupCondButton.Click += new System.EventHandler(this.deleteGroupCondButton_Click);
            // 
            // loadRuleGroupButton
            // 
            this.loadRuleGroupButton.Location = new System.Drawing.Point(104, 299);
            this.loadRuleGroupButton.Name = "loadRuleGroupButton";
            this.loadRuleGroupButton.Size = new System.Drawing.Size(135, 23);
            this.loadRuleGroupButton.TabIndex = 11;
            this.loadRuleGroupButton.Text = "Загрузить из файла";
            this.loadRuleGroupButton.UseVisualStyleBackColor = true;
            this.loadRuleGroupButton.Click += new System.EventHandler(this.loadRuleGroupButton_Click);
            // 
            // addRuleButton
            // 
            this.addRuleButton.Location = new System.Drawing.Point(12, 163);
            this.addRuleButton.Name = "addRuleButton";
            this.addRuleButton.Size = new System.Drawing.Size(92, 23);
            this.addRuleButton.TabIndex = 12;
            this.addRuleButton.Text = "Добавить";
            this.addRuleButton.UseVisualStyleBackColor = true;
            this.addRuleButton.Click += new System.EventHandler(this.addRuleButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // viewerTreeView
            // 
            this.viewerTreeView.Location = new System.Drawing.Point(528, 12);
            this.viewerTreeView.Name = "viewerTreeView";
            this.viewerTreeView.Size = new System.Drawing.Size(388, 310);
            this.viewerTreeView.TabIndex = 13;
            // 
            // EditorConditionGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 336);
            this.Controls.Add(this.viewerTreeView);
            this.Controls.Add(this.addRuleButton);
            this.Controls.Add(this.loadRuleGroupButton);
            this.Controls.Add(this.deleteGroupCondButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectorGroupComboBox);
            this.Controls.Add(this.nameGroupTextBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.conditionListBox);
            this.Controls.Add(this.selectorThemeComboBox);
            this.Controls.Add(this.selectorLayerComboBox);
            this.Name = "EditorConditionGroupForm";
            this.Text = "Группировка условий выборки";
            this.Load += new System.EventHandler(this.EditorConditionGroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox selectorLayerComboBox;
        private ComboBox selectorThemeComboBox;
        private CheckedListBox conditionListBox;
        private Button saveButton;
        private TextBox nameGroupTextBox;
        private ComboBox selectorGroupComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button deleteGroupCondButton;
        private Button loadRuleGroupButton;
        private Button addRuleButton;
        private OpenFileDialog openFileDialog1;
        private TreeView viewerTreeView;
    }
}