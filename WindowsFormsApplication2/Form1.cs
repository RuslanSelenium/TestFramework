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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassLibrary1.TestCases.Product_TC();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Width = 520;
            dataGridView1.Columns[0].Name = "Message";
            ClassLibrary1.TestCases.Login_TC();
            string[] endPoint = WriteLog.ReadResult();
            for (int i = 0; i < endPoint.Length; i++)
                dataGridView1.Rows.Add(endPoint[i]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassLibrary1.TestCases.TestForNewFunctions();


            string[] endPoint = WriteLog.ReadResult();
            //var result = MessageBox.Show(endPoint);
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Width = 520;
            dataGridView1.Columns[0].Name = "Message";
            for (int i = 0; i < endPoint.Length; i++ )
                dataGridView1.Rows.Add(endPoint[i]);
        }
    }
}
