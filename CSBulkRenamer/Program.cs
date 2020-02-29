using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBulkRenamer;
using CommandLine;

namespace CSBulkRenamer
{
    class Program
    {
        public class Options
        {
            [Option('c', "command", Required = false, HelpText = "Which Command you want to run [createTempFile | rename]", Default = "createTempFile")]
            public string Command { get; set; }

            [Option('t', "tempFile", Required = false, HelpText = "Path to where your files.txt file is", Default = "files.txt")]
            public string TempFile { get; set; }

            [Option('d', "directoryPath", Required = false, 
                HelpText = "Path to the directory that contains all the files you want to rename", 
                Default = ".")]
            public string DirectoryPath { get; set; }
        }
        static void Main(string [] args)
        {

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    if (o.Command.Equals("createTempFile"))
                    {
                        BulkRenamer.CreateTempFile(o.TempFile, o.DirectoryPath);
                    }
                    else if (o.Command.Equals("rename"))
                    {
                        BulkRenamer.BulkRename(o.TempFile, o.DirectoryPath);
                    }
                    else
                    {
                        Console.WriteLine("Invalid options or option combinations");
                    }

                });

        }

        
    }
}
