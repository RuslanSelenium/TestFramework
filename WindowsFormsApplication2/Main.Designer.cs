namespace WindowsFormsApplication2
{
    partial class Main
    {
        /// <summary>
        /// Требуется переменная конструктора.
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.testRunButton = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестКейсToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тестСьютToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNewFrame = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(71, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Graphics";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testRunButton
            // 
            this.testRunButton.Location = new System.Drawing.Point(246, 83);
            this.testRunButton.Name = "testRunButton";
            this.testRunButton.Size = new System.Drawing.Size(135, 60);
            this.testRunButton.TabIndex = 1;
            this.testRunButton.Text = "Test Running";
            this.testRunButton.UseVisualStyleBackColor = true;
            this.testRunButton.Click += new System.EventHandler(this.testRunButton_Click);
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(560, 395);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(117, 44);
            this.exit.TabIndex = 2;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестКейсToolStripMenuItem,
            this.тестСьютToolStripMenuItem});
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            this.создатьToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.создатьToolStripMenuItem.Text = "Создать";
            // 
            // тестКейсToolStripMenuItem
            // 
            this.тестКейсToolStripMenuItem.Name = "тестКейсToolStripMenuItem";
            this.тестКейсToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.тестКейсToolStripMenuItem.Text = "Тест кейс";
            this.тестКейсToolStripMenuItem.Click += new System.EventHandler(this.тестКейсToolStripMenuItem_Click);
            // 
            // тестСьютToolStripMenuItem
            // 
            this.тестСьютToolStripMenuItem.Name = "тестСьютToolStripMenuItem";
            this.тестСьютToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.тестСьютToolStripMenuItem.Text = "Тест сьют";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fAQToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.справкаToolStripMenuItem.Text = "Справка ";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.fAQToolStripMenuItem.Text = "F A Q ";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // testNewFrame
            // 
            this.testNewFrame.Location = new System.Drawing.Point(119, 250);
            this.testNewFrame.Name = "testNewFrame";
            this.testNewFrame.Size = new System.Drawing.Size(185, 60);
            this.testNewFrame.TabIndex = 5;
            this.testNewFrame.Text = "Test fo new funcs";
            this.testNewFrame.UseVisualStyleBackColor = true;
            this.testNewFrame.Click += new System.EventHandler(this.testNewFrame_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 451);
            this.Controls.Add(this.testNewFrame);
            this.Controls.Add(this.testRunButton);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Test Runner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button testRunButton;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестКейсToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тестСьютToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.Button testNewFrame;
    }
}

