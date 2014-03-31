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
            LoadListOfTestSuites();
        }
       
        public void LoadListOfTestSuites()
        {
            string[] listOfTestSuites = ReturnListOfTestSuites();
            foreach (string line in listOfTestSuites)
            {
                comboBox1.Items.Add(line);
            }
        }

        public string[] ReturnListOfTestSuites()
        {
            string[] fileNames = Directory.GetFiles(@"E:\ProjectRepo\TestFramework\WindowsFormsApplication2\bin\Debug", "*.cs");
            for (int i = 0; i < fileNames.Length; i++ )
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
            }

            return fileNames;
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

        public static bool IsFileEmpty(string filename)
        {
            try
            {
                string[] strok = File.ReadAllLines(filename);

                if (strok.Length == 0)
                {
                    return true;
                }
                return false;
            }
            catch (FileNotFoundException e)
            {
                return true;
            }

        }

        public void SaveToFile(string filename)
        {
            filename = @"E:\ProjectRepo\TestFramework\WindowsFormsApplication2\bin\Debug\" + filename + ".cs"; // need to remove
            
            string[] lines1 = { "using System;", "using System.Collections.Generic;", "using System.Linq;", "using System.Text;", "using ClassLibrary1;", " " };
            string[] lines2 = { "namespace Test", "{", "class Program", "{", "static void Main(string[] args)", "{", testCaseName.Text + "();", "}" };
            string[] testCaseBodyBegin = { "public static void " + testCaseName.Text + "()", "{", " " };
            string[] testCaseBodyBeginEnd = { " ", "}", "}", "}" };
            string code = richTextBox1.Text;

            if (IsFileEmpty(filename))
            {
                StreamWriter newFile = new StreamWriter(filename, true);
                //prepare new test suite 
                foreach (string line in lines1)
                {
                    Console.WriteLine(line);
                    newFile.WriteLine(line);
                }
                foreach (string line in lines2)
                {
                    newFile.WriteLine(line);
                }
                foreach (string line in testCaseBodyBegin)
                {
                    newFile.WriteLine(line);
                }
                newFile.WriteLine(code);        // write code from text box
                foreach (string line in testCaseBodyBeginEnd)
                {
                    newFile.WriteLine(line);
                }
                newFile.Close();
                MessageBox.Show("New Test Suite was Created", "Programm Messages");
            }
            else
            {
                string[] newLines = GetNewArrayFromFile(filename);
                StreamWriter newFileRewrite = new StreamWriter(filename, false);

                foreach (string line in newLines)
                {
                    newFileRewrite.WriteLine(line);
                }
                newFileRewrite.Close();
                MessageBox.Show("Changes Accepted", "Programm Messages");
            }

        }

        public string[] GetNewArrayFromFile(string filename)
        {
            string line;
            int counter = 0;

            StreamReader file = new StreamReader(filename);
            while ((line = file.ReadLine()) != null)
            {
                counter++;
            }
            file.Close();
            
            string[] lines = new string[counter+1];
            counter = 0;
            StreamReader file1 = new StreamReader(filename);
           
            while ((lines[counter] = file1.ReadLine()) != null)
            {
                counter++;
            }
            file1.Close();

            for (counter = 0; counter < lines.Length; counter++)
            {
                Console.WriteLine(lines[counter]);
            }
            Console.WriteLine(lines[12]);

            return ReplaceArray(lines, lines.Length);
        }

        public string[] ReplaceArray(string[] inputArray, int count)
        {
            string[] newArray = new string[count+4];
            int i = 0;

            for (i = 0; i < 13; i++)
            {
                newArray[i] = inputArray[i];
            }
            newArray[13] = testCaseName.Text + "();";
            
            for (i = 14; i < inputArray.Length-3; i++)
            {
                newArray[i] = inputArray[i-1];
            }
            newArray[inputArray.Length - 3] = inputArray[inputArray.Length - 4];
            newArray[i + 1] = "public static void " + testCaseName.Text + "()";
            newArray[i + 2] = "{";
            newArray[i + 3] = richTextBox1.Text;
            newArray[i + 4] = "}";
            newArray[i + 5] = "}";
            newArray[i + 6] = "}";

            for (i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine(newArray[i]);
            }
            return newArray;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text;
            
            this.Close();
        }

        private void saveTestCase_Click(object sender, EventArgs e)
        {
            SaveToFile(comboBox1.Text);
            
        }
    }
}
