namespace WindowsFormsApplication2
{
    partial class NewTestCaseForm
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
            this.saveTestCase = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.testCaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.help = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.страницыИЭлементыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.главнаяСтраницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.авторизацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.страницаСПродуктомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.наВсехСтраницахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.help.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveTestCase
            // 
            this.saveTestCase.Location = new System.Drawing.Point(489, 436);
            this.saveTestCase.Name = "saveTestCase";
            this.saveTestCase.Size = new System.Drawing.Size(75, 23);
            this.saveTestCase.TabIndex = 0;
            this.saveTestCase.Text = "Save";
            this.saveTestCase.UseVisualStyleBackColor = true;
            this.saveTestCase.Click += new System.EventHandler(this.saveTestCase_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(12, 436);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 85);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(551, 345);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // testCaseName
            // 
            this.testCaseName.Location = new System.Drawing.Point(13, 44);
            this.testCaseName.Name = "testCaseName";
            this.testCaseName.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.testCaseName.Size = new System.Drawing.Size(217, 20);
            this.testCaseName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите название тестового сценария";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(370, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(135, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // help
            // 
            this.help.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справкаToolStripMenuItem});
            this.help.Location = new System.Drawing.Point(0, 0);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(576, 24);
            this.help.TabIndex = 6;
            this.help.Text = "Справка";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.страницыИЭлементыToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // страницыИЭлементыToolStripMenuItem
            // 
            this.страницыИЭлементыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.наВсехСтраницахToolStripMenuItem,
            this.главнаяСтраницаToolStripMenuItem,
            this.авторизацияToolStripMenuItem,
            this.страницаСПродуктомToolStripMenuItem});
            this.страницыИЭлементыToolStripMenuItem.Name = "страницыИЭлементыToolStripMenuItem";
            this.страницыИЭлементыToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.страницыИЭлементыToolStripMenuItem.Text = "Страницы и элементы";
            // 
            // главнаяСтраницаToolStripMenuItem
            // 
            this.главнаяСтраницаToolStripMenuItem.Name = "главнаяСтраницаToolStripMenuItem";
            this.главнаяСтраницаToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.главнаяСтраницаToolStripMenuItem.Text = "Главная страница";
            // 
            // авторизацияToolStripMenuItem
            // 
            this.авторизацияToolStripMenuItem.Name = "авторизацияToolStripMenuItem";
            this.авторизацияToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.авторизацияToolStripMenuItem.Text = "Авторизация";
            this.авторизацияToolStripMenuItem.Click += new System.EventHandler(this.авторизацияToolStripMenuItem_Click);
            // 
            // страницаСПродуктомToolStripMenuItem
            // 
            this.страницаСПродуктомToolStripMenuItem.Name = "страницаСПродуктомToolStripMenuItem";
            this.страницаСПродуктомToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.страницаСПродуктомToolStripMenuItem.Text = "Страница с продуктом";
            // 
            // наВсехСтраницахToolStripMenuItem
            // 
            this.наВсехСтраницахToolStripMenuItem.Name = "наВсехСтраницахToolStripMenuItem";
            this.наВсехСтраницахToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.наВсехСтраницахToolStripMenuItem.Text = "На всех страницах";
            this.наВсехСтраницахToolStripMenuItem.Click += new System.EventHandler(this.наВсехСтраницахToolStripMenuItem_Click);
            // 
            // NewTestCaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 471);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.testCaseName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveTestCase);
            this.Controls.Add(this.help);
            this.MainMenuStrip = this.help;
            this.Name = "NewTestCaseForm";
            this.Text = "New Test Case";
            this.Load += new System.EventHandler(this.NewTestCaseForm_Load);
            this.help.ResumeLayout(false);
            this.help.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveTestCase;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox testCaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.MenuStrip help;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem страницыИЭлементыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem главнаяСтраницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem авторизацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem страницаСПродуктомToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem наВсехСтраницахToolStripMenuItem;
    }
}