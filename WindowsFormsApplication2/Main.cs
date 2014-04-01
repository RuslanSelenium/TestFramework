using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary1;
using OpenQA.Selenium;
using System.Windows;

namespace WindowsFormsApplication2
{
    public partial class Main : Form
    {
        public static int total = 0;

        public static int count = 0;

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TestCases.Product_TC();
            WriteLog.WriteLogToFile("<-------------------------------Test Case starting ------------------------------->", true);
            PagesActions.OpenLoginPage();
            LoginAction.DoLogin();
            if (VerifyClass.VerifyLoginText(LoginWebItems.LoggedGreetings.TakeElementText()) == true)
            {
                count++;
                total++;
                WriteLog.WriteResult(total.ToString() + " : " + "Verification successful");
            }
            else
            {
                total++;
                WriteLog.WriteResult(total.ToString() + " : " + "Verification failed");
            }
            TestFramework.CloseBrowser();
            WriteLog.WriteLogToFile("<-------------------------------Test Case ending ------------------------------->", true);

        }

        private void testRunButton_Click(object sender, EventArgs e)
        {
            TestRunnerForm testRunner = new TestRunnerForm();
            testRunner.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void тестКейсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTestCaseForm f = new NewTestCaseForm();
            f.Show();
        }
    }
}
