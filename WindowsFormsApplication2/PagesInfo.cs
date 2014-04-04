using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class PagesInfo : Form
    {
        public PagesInfo(string flag)
        {
            InitializeComponent();
            richTextBox1.Lines = LoadInfoAboutPages(flag);
            //LoadInfoAboutPages(flag);
        }

        private void PagesInfo_Load(object sender, EventArgs e)
        {

        }

        public string[] LoadInfoAboutPages(string filename)
        {
            filename = @"E:\ProjectRepo\TestFramework\ClassLibrary1\" + filename + ".cs";
            string line;
            int i = 0;
            int counter = 0;

            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                if ((counter > 4) && (line.Contains("public static WebItem")))
                    i++;
                counter++;
            }
            file.Close();

            string[] outputArray = new string[i];
            i = 0;
            counter = 0;

            StreamReader file1 = new StreamReader(filename);
            while ((line = file1.ReadLine()) != null)
            {
                if ((counter > 4) && (line.Contains("public static WebItem")))
                {
                    outputArray[i] = line;
                    i++;
                }
                counter++;
            }
            file1.Close();

            return outputArray;
        }
    }
}
