namespace Example2.ExportModule.SQLModule
{
    partial class GroupFiltersControl
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
            addButton = new Button();
            filterViewerFlowLayout = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Bottom;
            addButton.Location = new Point(3, 233);
            addButton.Name = "addButton";
            addButton.Size = new Size(305, 23);
            addButton.TabIndex = 0;
            addButton.Text = "Добавить";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // filterViewerFlowLayout
            // 
            filterViewerFlowLayout.AutoScroll = true;
            filterViewerFlowLayout.Dock = DockStyle.Fill;
            filterViewerFlowLayout.Location = new Point(3, 3);
            filterViewerFlowLayout.Name = "filterViewerFlowLayout";
            filterViewerFlowLayout.Size = new Size(305, 230);
            filterViewerFlowLayout.TabIndex = 2;
            // 
            // GroupFiltersControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(filterViewerFlowLayout);
            Controls.Add(addButton);
            Name = "GroupFiltersControl";
            Padding = new Padding(3);
            Size = new Size(311, 259);
            ResumeLayout(false);
        }

        #endregion

        private Button addButton;
        private Button deleteButton;
        private FlowLayoutPanel filterViewerFlowLayout;
    }
}
