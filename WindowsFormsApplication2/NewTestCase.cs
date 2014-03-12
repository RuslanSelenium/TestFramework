using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

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

        public static bool CompileExecutable(String sourceName)
        {
            FileInfo sourceFile = new FileInfo(sourceName);
            CodeDomProvider provider = null;
            bool compileOk = false;

            // Select the code provider based on the input file extension.
            if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".CS")
            {
                provider = CodeDomProvider.CreateProvider("CSharp");
            }
            else if (sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) == ".VB")
            {
                provider = CodeDomProvider.CreateProvider("VisualBasic");
            }
            else 
            {
                Console.WriteLine("Source file must have a .cs or .vb extension");
            }

            if (provider != null)
            {

                // Format the executable file name.
                // Build the output assembly path using the current directory
                // and <source>_cs.exe or <source>_vb.exe.

                String exeName = String.Format(@"{0}\{1}.exe",
                   System.Environment.CurrentDirectory,
                    sourceFile.Name.Replace(".", "_"));

                CompilerParameters cp = new CompilerParameters();

                // Generate an executable instead of 
                // a class library.
                cp.GenerateExecutable = true;

                // Specify the assembly file name to generate.
                cp.OutputAssembly = exeName;

                // Add an assembly reference.
                cp.ReferencedAssemblies.Add("System.dll");
                cp.ReferencedAssemblies.Add("System.Core.dll");
                cp.ReferencedAssemblies.Add("ClassLibrary1.dll");

                // Save the assembly as a physical file.
                cp.GenerateInMemory = false;

                // Set whether to treat all warnings as errors.
                cp.TreatWarningsAsErrors = false;

                // Invoke compilation of the source file.
                CompilerResults cr = provider.CompileAssemblyFromFile(cp, 
                    sourceName);

                if(cr.Errors.Count > 0)
                {
                    // Display compilation errors.
                    MessageBox.Show("Errors building " + sourceName +  " into " + cr.PathToAssembly, "Compile Error!");
                    string errorList = null;
                    foreach(CompilerError ce in cr.Errors)
                    {
                        string errorNew = ce.ToString();
                        errorList = errorList + errorNew + "\n";
                    }
                    MessageBox.Show(errorList, "Compile Error");
                }
                else
                {
                    // Display a successful compilation message.
                    MessageBox.Show("Source " + sourceName + " built into " + cr.PathToAssembly + " successfully.", "Compiled successfully!");
                }

                // Return the results of the compilation.
                if (cr.Errors.Count > 0)
                {
                    compileOk = false;
                }
                else 
                {
                    compileOk = true;
                }
            }
            return compileOk;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string TestCasePath = @"E:\job\TestCase.cs";
                if (File.Exists(TestCasePath))
                {
                    CompileExecutable(TestCasePath);
                }
                else
                {
                    Console.WriteLine("Input source file not found - {0}",
                        TestCasePath);
                }
            }
            catch(Exception anError)
            {
                MessageBox.Show(anError.Source);
                MessageBox.Show("eeee!!!");
            }
        }
    }
}
