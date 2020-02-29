using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBulkRenamer
{
    class BulkRenamer
    {

        public static void CreateTempFile(string directoryPath, string tempFilePath)
        {
            string[] files_in_path = Directory.GetFiles(directoryPath);
            StringBuilder files_as_string = new StringBuilder();
            foreach (string file in files_in_path)
            {
                files_as_string.AppendLine(file);
            }

            //using (FileStream fs = File.Create("C:\\Users\\Shahr\\Desktop\\files.txt"))
            using (FileStream fs = File.Create(tempFilePath))
            {
                byte[] files_as_bytes = new UTF8Encoding(true).GetBytes(files_as_string.ToString());
                fs.Write(files_as_bytes, 0, files_as_bytes.Length);
            }
        }

        public static void BulkRename(string tempFile, string directoryPath)
        {
            using(StreamReader sr = File.OpenText(tempFile))
            {
                string[] files_in_path = Directory.GetFiles(directoryPath);
                for (int i = 0; i < files_in_path.Length; i++)
                {
                    string before = files_in_path[i];
                    string after = sr.ReadLine();
                    Console.WriteLine($"Moving {before} to {after}");
                    File.Move(before,after );
                }
            }
            

        }
    }
}
