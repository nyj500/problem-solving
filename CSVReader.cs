using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using static Constants;

class CSVReader
{
    public static List<string[]> ReadCSV(string path)
    {
        try
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8, false))
                {
                    List<string[]> result = new List<string[]>();
                    string lines = null;
                    string[] keys = null;
                    string[] values = null;
                    int colNum = 0;

                    if ((lines = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(lines)) return result;
                        keys = lines.Split(',');
                        colNum = keys.Length;
                    }

                    while ((lines = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrEmpty(lines)) return result;

                        values = lines.Split(','); 
                        if (values.Length != colNum)
                        {
                            throw new ArgumentNullException("행에 빈 칸이 존재합니다.");
                        }
                        result.Add(values);
                    }

                    return result;
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
}