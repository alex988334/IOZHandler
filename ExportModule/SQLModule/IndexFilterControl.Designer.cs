namespace Example2
{
    partial class IndexFilterControl
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
            groupBox1 = new GroupBox();
            rightRadioButton = new RadioButton();
            leftRadioButton = new RadioButton();
            indexRichText = new RichTextBox();
            delimeterRichText = new RichTextBox();
            toolTip1 = new ToolTip(components);
            compositeValueCheckBox = new CheckBox();
            indexAliasTextBox = new TextBox();
            aliasDelimetrTextBox = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rightRadioButton);
            groupBox1.Controls.Add(leftRadioButton);
            groupBox1.Location = new Point(155, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(148, 51);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Направление поиска";
            // 
            // rightRadioButton
            // 
            rightRadioButton.AutoSize = true;
            rightRadioButton.Location = new Point(68, 22);
            rightRadioButton.Name = "rightRadioButton";
            rightRadioButton.Size = new Size(63, 19);
            rightRadioButton.TabIndex = 1;
            rightRadioButton.TabStop = true;
            rightRadioButton.Text = "справа";
            toolTip1.SetToolTip(rightRadioButton, "Поиск значения справа от индекса");
            rightRadioButton.UseVisualStyleBackColor = true;
            // 
            // leftRadioButton
            // 
            leftRadioButton.AutoSize = true;
            leftRadioButton.Location = new Point(6, 22);
            leftRadioButton.Name = "leftRadioButton";
            leftRadioButton.Size = new Size(56, 19);
            leftRadioButton.TabIndex = 0;
            leftRadioButton.TabStop = true;
            leftRadioButton.Text = "слева";
            toolTip1.SetToolTip(leftRadioButton, "Поиск значения слева от индекса");
            leftRadioButton.UseVisualStyleBackColor = true;
            // 
            // indexRichText
            // 
            indexRichText.Location = new Point(3, 4);
            indexRichText.Name = "indexRichText";
            indexRichText.Size = new Size(146, 22);
            indexRichText.TabIndex = 3;
            indexRichText.Text = "";
            toolTip1.SetToolTip(indexRichText, "Поисковый индекс");
            indexRichText.TextChanged += indexRichText_TextChanged;
            // 
            // delimeterRichText
            // 
            delimeterRichText.Location = new Point(3, 60);
            delimeterRichText.Name = "delimeterRichText";
            delimeterRichText.Size = new Size(69, 22);
            delimeterRichText.TabIndex = 4;
            delimeterRichText.Text = "";
            toolTip1.SetToolTip(delimeterRichText, "Разделитель между поисковым индексом и его значением");
            delimeterRichText.TextChanged += delimeterRichText_TextChanged;
            // 
            // compositeValueCheckBox
            // 
            compositeValueCheckBox.AutoSize = true;
            compositeValueCheckBox.Location = new Point(161, 60);
            compositeValueCheckBox.Name = "compositeValueCheckBox";
            compositeValueCheckBox.Size = new Size(138, 19);
            compositeValueCheckBox.TabIndex = 5;
            compositeValueCheckBox.Text = "Составное значение";
            toolTip1.SetToolTip(compositeValueCheckBox, "Подразбивает составное числовое значение ииндекса на составляющие");
            compositeValueCheckBox.UseVisualStyleBackColor = true;
            // 
            // indexAliasTextBox
            // 
            indexAliasTextBox.Location = new Point(3, 31);
            indexAliasTextBox.Name = "indexAliasTextBox";
            indexAliasTextBox.Size = new Size(146, 23);
            indexAliasTextBox.TabIndex = 6;
            toolTip1.SetToolTip(indexAliasTextBox, "Псевдоним индекса из словаря");
            // 
            // aliasDelimetrTextBox
            // 
            aliasDelimetrTextBox.Location = new Point(78, 59);
            aliasDelimetrTextBox.Name = "aliasDelimetrTextBox";
            aliasDelimetrTextBox.Size = new Size(71, 23);
            aliasDelimetrTextBox.TabIndex = 7;
            toolTip1.SetToolTip(aliasDelimetrTextBox, "Псевдоним в словаре");
            // 
            // IndexFilterControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(aliasDelimetrTextBox);
            Controls.Add(indexAliasTextBox);
            Controls.Add(compositeValueCheckBox);
            Controls.Add(delimeterRichText);
            Controls.Add(indexRichText);
            Controls.Add(groupBox1);
            Name = "IndexFilterControl";
            Size = new Size(309, 88);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private GroupBox groupBox1;
        private RadioButton leftRadioButton;
        private RadioButton rightRadioButton;
        private RichTextBox indexRichText;
        private ToolTip toolTip1;
        private RichTextBox delimeterRichText;
        private CheckBox compositeValueCheckBox;
        private TextBox indexAliasTextBox;
        private TextBox aliasDelimetrTextBox;
    }
}
