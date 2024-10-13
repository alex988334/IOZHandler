namespace Example2.RuleModule
{
    partial class RuleControl: MyRootControl
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
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.printRulesButton = new System.Windows.Forms.Button();
            this.deleteRuleButton = new System.Windows.Forms.Button();
            this.ruleSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.saveRule = new System.Windows.Forms.Button();
            this.ruleValueTextBox = new System.Windows.Forms.TextBox();
            this.ruleKeysComboBox = new System.Windows.Forms.ComboBox();
            this.ruleTypesComboBox = new System.Windows.Forms.ComboBox();
            this.ruleLayersComboBox = new System.Windows.Forms.ComboBox();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.printRulesButton);
            this.panel9.Controls.Add(this.deleteRuleButton);
            this.panel9.Controls.Add(this.ruleSelectComboBox);
            this.panel9.Controls.Add(this.label3);
            this.panel9.Controls.Add(this.label9);
            this.panel9.Controls.Add(this.saveRule);
            this.panel9.Controls.Add(this.ruleValueTextBox);
            this.panel9.Controls.Add(this.ruleKeysComboBox);
            this.panel9.Controls.Add(this.ruleTypesComboBox);
            this.panel9.Controls.Add(this.ruleLayersComboBox);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(10);
            this.panel9.Size = new System.Drawing.Size(953, 150);
            this.panel9.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(421, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "Замена";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(421, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 21;
            this.label6.Text = "Тип";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 15);
            this.label5.TabIndex = 20;
            this.label5.Text = "Слой";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 19;
            this.label4.Text = "Поле типа";
            // 
            // printRulesButton
            // 
            this.printRulesButton.Location = new System.Drawing.Point(820, 83);
            this.printRulesButton.Name = "printRulesButton";
            this.printRulesButton.Size = new System.Drawing.Size(85, 23);
            this.printRulesButton.TabIndex = 18;
            this.printRulesButton.Text = "Вывести все";
            this.printRulesButton.UseVisualStyleBackColor = true;
            this.printRulesButton.Click += new System.EventHandler(this.printRulesButton_Click);
            // 
            // deleteRuleButton
            // 
            this.deleteRuleButton.Location = new System.Drawing.Point(753, 83);
            this.deleteRuleButton.Name = "deleteRuleButton";
            this.deleteRuleButton.Size = new System.Drawing.Size(61, 23);
            this.deleteRuleButton.TabIndex = 17;
            this.deleteRuleButton.Text = "Удалить";
            this.deleteRuleButton.UseVisualStyleBackColor = true;
            this.deleteRuleButton.Click += new System.EventHandler(this.deleteRuleButton_Click);
            // 
            // ruleSelectComboBox
            // 
            this.ruleSelectComboBox.FormattingEnabled = true;
            this.ruleSelectComboBox.Location = new System.Drawing.Point(6, 84);
            this.ruleSelectComboBox.Name = "ruleSelectComboBox";
            this.ruleSelectComboBox.Size = new System.Drawing.Size(741, 23);
            this.ruleSelectComboBox.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Правило";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 15);
            this.label9.TabIndex = 12;
            // 
            // saveRule
            // 
            this.saveRule.Location = new System.Drawing.Point(820, 5);
            this.saveRule.Name = "saveRule";
            this.saveRule.Size = new System.Drawing.Size(85, 50);
            this.saveRule.TabIndex = 11;
            this.saveRule.Text = "Создать правило";
            this.saveRule.UseVisualStyleBackColor = true;
            this.saveRule.Click += new System.EventHandler(this.saveRule_Click);
            // 
            // ruleValueTextBox
            // 
            this.ruleValueTextBox.Location = new System.Drawing.Point(475, 32);
            this.ruleValueTextBox.Name = "ruleValueTextBox";
            this.ruleValueTextBox.PlaceholderText = "Новое значение";
            this.ruleValueTextBox.Size = new System.Drawing.Size(337, 23);
            this.ruleValueTextBox.TabIndex = 10;
            // 
            // ruleKeysComboBox
            // 
            this.ruleKeysComboBox.FormattingEnabled = true;
            this.ruleKeysComboBox.Location = new System.Drawing.Point(76, 33);
            this.ruleKeysComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ruleKeysComboBox.Name = "ruleKeysComboBox";
            this.ruleKeysComboBox.Size = new System.Drawing.Size(331, 23);
            this.ruleKeysComboBox.TabIndex = 8;
            this.ruleKeysComboBox.SelectedIndexChanged += new System.EventHandler(this.ruleKeysComboBox_SelectedIndexChanged);
            // 
            // ruleTypesComboBox
            // 
            this.ruleTypesComboBox.FormattingEnabled = true;
            this.ruleTypesComboBox.Location = new System.Drawing.Point(475, 4);
            this.ruleTypesComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ruleTypesComboBox.Name = "ruleTypesComboBox";
            this.ruleTypesComboBox.Size = new System.Drawing.Size(337, 23);
            this.ruleTypesComboBox.TabIndex = 3;
            this.ruleTypesComboBox.SelectedIndexChanged += new System.EventHandler(this.ruleTypesComboBox_SelectedIndexChanged);
            // 
            // ruleLayersComboBox
            // 
            this.ruleLayersComboBox.FormattingEnabled = true;
            this.ruleLayersComboBox.Location = new System.Drawing.Point(76, 5);
            this.ruleLayersComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ruleLayersComboBox.Name = "ruleLayersComboBox";
            this.ruleLayersComboBox.Size = new System.Drawing.Size(331, 23);
            this.ruleLayersComboBox.TabIndex = 1;
            this.ruleLayersComboBox.SelectedIndexChanged += new System.EventHandler(this.ruleLayersComboBox_SelectedIndexChanged);
            // 
            // RuleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel9);
            this.Name = "RuleControl";
            this.Size = new System.Drawing.Size(953, 150);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button printRulesButton;
        private Button deleteRuleButton;
        private ComboBox ruleSelectComboBox;
        private Label label3;
        private Label label9;
        private Button saveRule;
        private TextBox ruleValueTextBox;
        private ComboBox ruleKeysComboBox;
        private ComboBox ruleTypesComboBox;
        private ComboBox ruleLayersComboBox;
    }
}
