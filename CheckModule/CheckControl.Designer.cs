using Example2.MapModule;

namespace Example2.CheckModule
{
    partial class CheckControl
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
            this.CheckButton = new System.Windows.Forms.Button();
            this.structCheckBox = new System.Windows.Forms.CheckBox();
            this.dataCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CheckButton
            // 
            this.CheckButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.CheckButton.Location = new System.Drawing.Point(0, 0);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(150, 24);
            this.CheckButton.TabIndex = 4;
            this.CheckButton.Text = "Запустить";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // structCheckBox
            // 
            this.structCheckBox.AutoSize = true;
            this.structCheckBox.Checked = true;
            this.structCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.structCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.structCheckBox.Location = new System.Drawing.Point(150, 0);
            this.structCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.structCheckBox.Name = "structCheckBox";
            this.structCheckBox.Size = new System.Drawing.Size(82, 24);
            this.structCheckBox.TabIndex = 8;
            this.structCheckBox.Text = "Структура";
            this.structCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataCheckBox
            // 
            this.dataCheckBox.AutoSize = true;
            this.dataCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataCheckBox.Location = new System.Drawing.Point(232, 0);
            this.dataCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataCheckBox.Name = "dataCheckBox";
            this.dataCheckBox.Size = new System.Drawing.Size(69, 24);
            this.dataCheckBox.TabIndex = 9;
            this.dataCheckBox.Text = "Данные";
            this.dataCheckBox.UseVisualStyleBackColor = true;
            // 
            // CheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataCheckBox);
            this.Controls.Add(this.structCheckBox);
            this.Controls.Add(this.CheckButton);
            this.Name = "CheckControl";
            this.Size = new System.Drawing.Size(525, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CheckButton;
        private CheckBox structCheckBox;
        private CheckBox dataCheckBox;
    }
}
