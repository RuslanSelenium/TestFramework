using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class NewTestCaseForm : Form
    {
        public NewTestCaseForm()
        {
            InitializeComponent();
            comboBox1.Items.Add("dfsdf");
            comboBox1.Items.Add("hhhfh");
            comboBox1.Items.Add("234323");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("IExplore.exe");
            
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string PricePath = @"E:\ProjectRepo\TestFramework\ClassLibrary1\TestCases.cs";
            System.IO.StreamReader PriceFile = new System.IO.StreamReader(PricePath, true);
            int i = 0;
            string line;
            string[] lineArray = new string[10000];// = { "asd", "asdasd" };
            while ((line = PriceFile.ReadLine()) != null)
            {
                Console.WriteLine(line);
                lineArray[i] = line;
                i = i + 1;
            }
        }
    }
}
