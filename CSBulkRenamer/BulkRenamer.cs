using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSBulkRenamer
{
    /// <summary>
    /// Allows You to bulk rename files using a temporary txt file
    /// </summary>
    class BulkRenamer
    {
        /// <summary>
        /// Creates a temporary <c>files.txt</c> file
        /// </summary>
        /// <param name="tempFilePath">String of the path where you want to create temp file</param>
        /// <param name="directoryPath">String of the directory where you are reading in filenames from</param>
        public static void CreateTempFile(string tempFilePath, string directoryPath)
        {
            string[] files_in_path = Directory.GetFiles(directoryPath);
            StringBuilder files_as_string = new StringBuilder();
            foreach (string file in files_in_path)
            {
                files_as_string.AppendLine(file);
            }


            using (FileStream fs = File.Create(tempFilePath))
            {
                byte[] files_as_bytes = new UTF8Encoding(true).GetBytes(files_as_string.ToString());
                fs.Write(files_as_bytes, 0, files_as_bytes.Length);
            }
        }
        /// <summary>
        /// Renames files in <c>directoryPath</c> with the file names is <c>tempFilePath</c> 
        /// </summary>
        /// <param name="tempFilePath">String of the path where created temp file</param>
        /// <param name="directoryPath">String of the directory where you are reading in filenames from</param>
        public static void BulkRename(string tempFilePath, string directoryPath)
        {
            using(StreamReader sr = File.OpenText(tempFilePath))
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
