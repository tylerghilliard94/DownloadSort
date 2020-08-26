using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DownloadSort
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            string newPath = "";
            if (args.Length == 0)
            {
                newPath = $@"{path}\Downloads";
            }
            else
            {
                newPath = args[1];
            }

            Console.WriteLine(newPath);


            var files = new DirectoryInfo(newPath).GetFiles().OrderByDescending(f => f.LastWriteTime);

            List<string> tenFiles = new List<string>();
            List<DateTime> tenFilestime = new List<DateTime>();
            List<string> tenFilesSize = new List<string>();

            // for (int i = 0; i < 10; i++)
            // {
            string maxCounter = "";
            if (args.Length < 3)
            {
                maxCounter = "10";
            }
            else
            {
                maxCounter = args[3];
            }




            int counter = 0;
            foreach (var file in files)
            {

                if (counter < int.Parse(maxCounter))
                {
                    tenFiles.Add(Path.GetFileName(file.ToString()));
                    tenFilestime.Add(File.GetLastAccessTime(file.ToString()));
                    tenFilesSize.Add(file.ToString());
                    counter++;
                }
                else
                {
                    counter++;
                }
            }

            for (int i = 0; i < int.Parse(maxCounter); i++)
            {
                FileInfo length = new FileInfo($"{tenFilesSize[i]}");
                Console.Write(tenFiles[i] + ", ");
                Console.Write(tenFilestime[i] + ", ");
                Console.WriteLine(length.Length + " bytes.");
            }




            // }


        }
    }
}
