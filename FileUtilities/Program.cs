using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int FileCount = 0;
            string path = @"C:\Program Files\IIS\Microsoft Web Deploy";
            Console.WriteLine("DIRECTORY {0}", path);
            Console.WriteLine("-----------------------------------------------------------");
            var files = Directory.EnumerateFiles(path, "*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    if (Path.GetExtension(file) == ".dll")
                    {
                        var version = FileVersionInfo.GetVersionInfo(file).ProductVersion;
                        Console.WriteLine("{0} uses .NET version {1}", Path.GetFileName(file), version);
                        FileCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error reading {0}: {1}", file, e.Message);
                }
            }
            Console.WriteLine();
            Console.WriteLine("File Count = {0}", FileCount);
            Console.Read();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
    }
}
