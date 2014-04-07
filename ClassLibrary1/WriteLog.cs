using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary1;

public class WriteLog : TestFramework // This class was created for write some records in Log file (24.06. 17:30)
{
    public static string ResultPath = @"E:\logs\Result.txt";

    public static void ClearLog(string filename)
    {
        filename = @"E:\logs\" + filename;
        System.IO.StreamWriter file = new System.IO.StreamWriter(filename, false);
        file.Write("");
        file.Close();

    }

    public static void WriteLogToFile(string line, Boolean flag)
    {
        string TClog = @"E:\logs\TC_Logs.txt";
        string Errlog = @"E:\logs\Error_Logs.txt";
        DateTime date = DateTime.UtcNow;
        DateTime dateOnly = date;
        string dateString = dateOnly.ToString("MM/dd/yyyy HH:mm");
        System.IO.StreamWriter fileError = new System.IO.StreamWriter(Errlog, true);
        System.IO.StreamWriter fileTC = new System.IO.StreamWriter(TClog, true);
        if (flag == true)
            fileTC.WriteLine(dateString + ": " + line);
        else
            fileError.WriteLine(dateString + ": " + line);
        fileError.Close();
        fileTC.Close();
    }

    public static void WriteResult(string line) // This function was created for result logs (20:52 25.06)
    {
        DateTime date = DateTime.UtcNow;
        string dateString = date.ToString("MM/dd/yyyy HH:mm");
        System.IO.StreamWriter ResultFile = new System.IO.StreamWriter(ResultPath, true);
        ResultFile.WriteLine(dateString + ": " + line);
        ResultFile.Close();
    }

    public static string[] ReadResult()
    {
        System.IO.StreamReader ResultFile = new System.IO.StreamReader(ResultPath, true);
        int i = 0;
        string line;
        string[] lineArray = new string[50];// = { "asd", "asdasd" };
        while ((line = ResultFile.ReadLine()) != null)
        {
            lineArray[i] = line;
            i = i + 1;
        }
        return lineArray;
    }
}
