namespace Example2.ExportModule.TypeModule
{
    partial class TypeControl
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
            panel1 = new Panel();
            panel2 = new Panel();
            addValueButton = new Button();
            newValueTextBox = new TextBox();
            AddFieldButton = new Button();
            newFieldTextBox = new TextBox();
            exceptionValuesCheckBox = new CheckBox();
            allValuesCheckBox = new CheckBox();
            valuesListBox = new ListBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            fieldsListBox = new ListBox();
            toolTip1 = new ToolTip(components);
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1272, 312);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(addValueButton);
            panel2.Controls.Add(newValueTextBox);
            panel2.Controls.Add(AddFieldButton);
            panel2.Controls.Add(newFieldTextBox);
            panel2.Controls.Add(exceptionValuesCheckBox);
            panel2.Controls.Add(allValuesCheckBox);
            panel2.Controls.Add(valuesListBox);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(fieldsListBox);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(553, 312);
            panel2.TabIndex = 9;
            // 
            // addValueButton
            // 
            addValueButton.Location = new Point(508, 36);
            addValueButton.Name = "addValueButton";
            addValueButton.Size = new Size(35, 26);
            addValueButton.TabIndex = 10;
            addValueButton.Text = "+";
            addValueButton.UseVisualStyleBackColor = true;
            addValueButton.Click += addValueButton_Click;
            // 
            // newValueTextBox
            // 
            newValueTextBox.Location = new Point(262, 36);
            newValueTextBox.Name = "newValueTextBox";
            newValueTextBox.PlaceholderText = "Новое значение";
            newValueTextBox.Size = new Size(240, 23);
            newValueTextBox.TabIndex = 9;
            toolTip1.SetToolTip(newValueTextBox, "Значения вводить по одному. Если поле из словаря, то вводить значения из словаря, коды словаря не использовать!");
            // 
            // AddFieldButton
            // 
            AddFieldButton.Location = new Point(221, 35);
            AddFieldButton.Name = "AddFieldButton";
            AddFieldButton.Size = new Size(35, 26);
            AddFieldButton.TabIndex = 8;
            AddFieldButton.Text = "+";
            AddFieldButton.UseVisualStyleBackColor = true;
            AddFieldButton.Click += AddFieldButton_Click;
            // 
            // newFieldTextBox
            // 
            newFieldTextBox.Location = new Point(2, 36);
            newFieldTextBox.Name = "newFieldTextBox";
            newFieldTextBox.PlaceholderText = "Новое поле";
            newFieldTextBox.Size = new Size(213, 23);
            newFieldTextBox.TabIndex = 7;
            toolTip1.SetToolTip(newFieldTextBox, "Использовать только латинские названия полей, все возможные названия полей указываются через точку с запятой");
            // 
            // exceptionValuesCheckBox
            // 
            exceptionValuesCheckBox.AutoSize = true;
            exceptionValuesCheckBox.Location = new Point(369, 288);
            exceptionValuesCheckBox.Name = "exceptionValuesCheckBox";
            exceptionValuesCheckBox.Size = new Size(174, 19);
            exceptionValuesCheckBox.TabIndex = 6;
            exceptionValuesCheckBox.Text = "Исключаемые из выборки";
            exceptionValuesCheckBox.UseVisualStyleBackColor = true;
            exceptionValuesCheckBox.CheckedChanged += exceptionValuesCheckBox_CheckedChanged;
            // 
            // allValuesCheckBox
            // 
            allValuesCheckBox.AutoSize = true;
            allValuesCheckBox.Location = new Point(262, 288);
            allValuesCheckBox.Name = "allValuesCheckBox";
            allValuesCheckBox.Size = new Size(99, 19);
            allValuesCheckBox.TabIndex = 5;
            allValuesCheckBox.Text = "Все значения";
            allValuesCheckBox.UseVisualStyleBackColor = true;
            allValuesCheckBox.CheckedChanged += allValuesCheckBox_CheckedChanged;
            // 
            // valuesListBox
            // 
            valuesListBox.FormattingEnabled = true;
            valuesListBox.ItemHeight = 15;
            valuesListBox.Location = new Point(262, 65);
            valuesListBox.Name = "valuesListBox";
            valuesListBox.Size = new Size(281, 214);
            valuesListBox.TabIndex = 4;
            valuesListBox.MouseUp += fieldsListBox_MouseUp;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(351, 17);
            label3.Name = "label3";
            label3.Size = new Size(103, 15);
            label3.TabIndex = 3;
            label3.Text = "Список значений";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 17);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 2;
            label2.Text = "Список полей";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(2, 2);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 1;
            label1.Text = "Выборка по полям бд";
            // 
            // fieldsListBox
            // 
            fieldsListBox.FormattingEnabled = true;
            fieldsListBox.ItemHeight = 15;
            fieldsListBox.Location = new Point(2, 64);
            fieldsListBox.Name = "fieldsListBox";
            fieldsListBox.Size = new Size(254, 244);
            fieldsListBox.TabIndex = 0;
            fieldsListBox.SelectedIndexChanged += fieldsListBox_SelectedIndexChanged;
            fieldsListBox.MouseUp += fieldsListBox_MouseUp;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // TypeControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "TypeControl";
            Size = new Size(1272, 312);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ListBox fieldsListBox;
        private ListBox valuesListBox;
        private Label label3;
        private Label label2;
        private CheckBox exceptionValuesCheckBox;
        private CheckBox allValuesCheckBox;
        private Panel panel2;
        private Button AddFieldButton;
        private TextBox newFieldTextBox;
        private Button addValueButton;
        private TextBox newValueTextBox;
        private ToolTip toolTip1;
        private ContextMenuStrip contextMenuStrip1;
    }
}
