namespace Example2.ExportModule.SQLModule
{
    partial class FieldFilter
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
            fieldTextBox = new TextBox();
            nameGroupTextBox = new TextBox();
            dictionaryCheckBox = new CheckBox();
            toolTip1 = new ToolTip(components);
            valueFieldTextBox = new TextBox();
            logicOperatorComboBox = new ComboBox();
            SuspendLayout();
            // 
            // fieldTextBox
            // 
            fieldTextBox.Location = new Point(3, 33);
            fieldTextBox.Name = "fieldTextBox";
            fieldTextBox.PlaceholderText = "Поле в бд";
            fieldTextBox.Size = new Size(187, 23);
            fieldTextBox.TabIndex = 0;
            // 
            // nameGroupTextBox
            // 
            nameGroupTextBox.Location = new Point(3, 4);
            nameGroupTextBox.Name = "nameGroupTextBox";
            nameGroupTextBox.PlaceholderText = "Название группы";
            nameGroupTextBox.Size = new Size(212, 23);
            nameGroupTextBox.TabIndex = 1;
            toolTip1.SetToolTip(nameGroupTextBox, "Название группы в имени результирующего файла");
            // 
            // dictionaryCheckBox
            // 
            dictionaryCheckBox.AutoSize = true;
            dictionaryCheckBox.Checked = true;
            dictionaryCheckBox.CheckState = CheckState.Checked;
            dictionaryCheckBox.Location = new Point(196, 35);
            dictionaryCheckBox.Name = "dictionaryCheckBox";
            dictionaryCheckBox.Size = new Size(86, 19);
            dictionaryCheckBox.TabIndex = 2;
            dictionaryCheckBox.Text = "из словаря";
            dictionaryCheckBox.UseVisualStyleBackColor = true;
            // 
            // valueFieldTextBox
            // 
            valueFieldTextBox.Location = new Point(3, 62);
            valueFieldTextBox.Name = "valueFieldTextBox";
            valueFieldTextBox.PlaceholderText = "Значение поля";
            valueFieldTextBox.Size = new Size(279, 23);
            valueFieldTextBox.TabIndex = 3;
            toolTip1.SetToolTip(valueFieldTextBox, "Значение поля");
            // 
            // logicOperatorComboBox
            // 
            logicOperatorComboBox.FormattingEnabled = true;
            logicOperatorComboBox.Items.AddRange(new object[] { "AND", "OR" });
            logicOperatorComboBox.Location = new Point(221, 4);
            logicOperatorComboBox.Name = "logicOperatorComboBox";
            logicOperatorComboBox.Size = new Size(61, 23);
            logicOperatorComboBox.TabIndex = 4;
            toolTip1.SetToolTip(logicOperatorComboBox, "Оператор");
            // 
            // FieldFilter
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(logicOperatorComboBox);
            Controls.Add(valueFieldTextBox);
            Controls.Add(dictionaryCheckBox);
            Controls.Add(nameGroupTextBox);
            Controls.Add(fieldTextBox);
            Name = "FieldFilter";
            Size = new Size(285, 90);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox fieldTextBox;
        private TextBox nameGroupTextBox;
        private ToolTip toolTip1;
        private CheckBox dictionaryCheckBox;
        private TextBox valueFieldTextBox;
        private ComboBox logicOperatorComboBox;
    }
}
