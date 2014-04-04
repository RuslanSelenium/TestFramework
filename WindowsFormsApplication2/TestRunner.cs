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
            //Progress();
        }

        private void ProgressBarRunning()
        {
            // Display the ProgressBar control.
            progressBar1.Visible = true;
            // Set Minimum to 1 to represent the first file being copied.
            progressBar1.Minimum = 1;
            // Set Maximum to the total number of files to copy.
            progressBar1.Maximum = 100000;
            // Set the initial value of the ProgressBar.
            progressBar1.Value = 1;
            // Set the Step property to a value of 1 to represent each file being copied.
            progressBar1.Step = 1;

            // Loop through all files to copy.
            for (int x = 1; x <= 100000; x++)
            {
                    // Perform the increment on the ProgressBar.
                progressBar1.PerformStep();
            }
        }

        private void TestRunnerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
