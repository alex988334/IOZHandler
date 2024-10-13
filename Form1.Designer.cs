using Example2.CheckModule;
using Example2.RuleModule;
using Example2.MapModule;
using Example2.ExportModule;

namespace Example2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mapControl1 = new MapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkControl2 = new CheckControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ruleControl2 = new RuleControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.exportControl1 = new ExportControl();
            this.RulesPage = new System.Windows.Forms.TabPage();
            this.ExportPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogRichTextBox.HideSelection = false;
            this.LogRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.Size = new System.Drawing.Size(1093, 315);
            this.LogRichTextBox.TabIndex = 0;
            this.LogRichTextBox.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LogRichTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1093, 720);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(61, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1093, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1131, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Карта";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mapControl1
            // 
            this.mapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapControl1.Location = new System.Drawing.Point(3, 3);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Padding = new System.Windows.Forms.Padding(5);
            this.mapControl1.Size = new System.Drawing.Size(1125, 389);
            this.mapControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1131, 395);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Проверка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkControl2
            // 
            this.checkControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkControl2.Location = new System.Drawing.Point(3, 3);
            this.checkControl2.Name = "checkControl2";
            this.checkControl2.Size = new System.Drawing.Size(1125, 24);
            this.checkControl2.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ruleControl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1131, 395);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Правила";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ruleControl2
            // 
            this.ruleControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruleControl2.Location = new System.Drawing.Point(0, 0);
            this.ruleControl2.Name = "ruleControl2";
            this.ruleControl2.Size = new System.Drawing.Size(1131, 395);
            this.ruleControl2.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.exportControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1085, 363);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Экспорт";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // exportControl1
            // 
            this.exportControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exportControl1.Location = new System.Drawing.Point(0, 0);
            this.exportControl1.Name = "exportControl1";
            this.exportControl1.Padding = new System.Windows.Forms.Padding(5);
            this.exportControl1.Size = new System.Drawing.Size(1085, 363);
            this.exportControl1.TabIndex = 0;
            // 
            // RulesPage
            // 
            this.RulesPage.Location = new System.Drawing.Point(4, 4);
            this.RulesPage.Name = "RulesPage";
            this.RulesPage.Size = new System.Drawing.Size(919, 255);
            this.RulesPage.TabIndex = 2;
            this.RulesPage.Text = "Правила";
            this.RulesPage.UseVisualStyleBackColor = true;
            // 
            // ExportPage
            // 
            this.ExportPage.Location = new System.Drawing.Point(4, 4);
            this.ExportPage.Name = "ExportPage";
            this.ExportPage.Size = new System.Drawing.Size(919, 255);
            this.ExportPage.TabIndex = 3;
            this.ExportPage.Text = "Экспорт";
            this.ExportPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 720);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Экспорт в слои";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private RichTextBox LogRichTextBox;
        private ToolTip toolTip1;
        private SplitContainer splitContainer1;
        private CheckControl checkControl1;
        private RuleControl ruleControl1;
        private TabPage RulesPage;
        private TabPage ExportPage;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private MapControl mapControl1;
        private TabPage tabPage2;
        private CheckControl checkControl2;
        private TabPage tabPage3;
        private RuleControl ruleControl2;
        private TabPage tabPage4;
        private ExportControl exportControl1;
    }
}