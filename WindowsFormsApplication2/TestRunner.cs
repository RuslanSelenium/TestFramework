using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class TestRunnerForm : Form
    {
        public TestRunnerForm()
        {
            InitializeComponent();
            LoadListOfTestSuitesExe();
        }

        public void LoadListOfTestSuitesExe()
        {
            string[] listOfTestSuites = ReturnListOfTestSuitesExe();
            int i = 0;
            foreach (string line in listOfTestSuites)
            {
                if ((line != "WindowsFormsApplication2") && (line != "WindowsFormsApplication2.vshost"))
                {
                    checklistTestSuites.Items.Insert(i, line);
                    i++;
                }
            }
        }

        public string[] ReturnListOfTestSuitesExe()
        {
            string[] fileNames = Directory.GetFiles(@"E:\ProjectRepo\TestFramework\WindowsFormsApplication2\bin\Debug", "*.exe");
            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
            }

            return fileNames;
        }

        public string[] GetListOfCheckedTestSuites()
        {
            string[] outputArray = new string[checklistTestSuites.CheckedItems.Count];
            int i = 0;
            foreach (object checkedItems in checklistTestSuites.CheckedItems)
            {
                outputArray[i] = checkedItems.ToString();
                i++;
            }
            return outputArray;
        }

        public void RunTheCheckedTestSuites(string[] listOfTestSuites)
        {
            foreach (string testSuite in listOfTestSuites)
            {
                Process.Start(@"E:\ProjectRepo\TestFramework\WindowsFormsApplication2\bin\Debug\" + testSuite + ".exe");
            }
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            RunTheCheckedTestSuites(GetListOfCheckedTestSuites());
        }
    }
}
