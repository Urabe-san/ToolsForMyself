using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;

namespace GetFileList
{
    internal class GetFileList
    {
        /// <summary>
        ///   Entrance to this program
        /// </summary>
        /// <param name="args">parameters</param>
        static void Main(string[] args)
        {
            //exit program when no command line parameter
            if (args.Length < 1)
            {
                Console.Error.WriteLine("Error: No Parameter.");
                return;
            }

            OutputFileList(args[0]);
        }

        /// <summary>
        ///   Output directories/files listing
        /// </summary>
        /// <param name="Pathname">target path</param>
        static void OutputFileList(string Pathname)
        {
            IEnumerable<string> files; // strage directories / files listing
            var DirNames = new List<string>(); // strage list of directories. for call to recursive output.

            try
            {
                // output directory list
                files = Directory.EnumerateDirectories(
                    Pathname,
                    "*",
                    SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    DirNames.Add(file); // memory to directories.
                    Console.WriteLine("<<DIR>>\t\t" + file);
                }

                // output file list.
                files =
                    Directory.EnumerateFiles(
                      Pathname,
                      "*",
                      SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    string FileLength;
                    FileInfo info = new FileInfo(file);
                    try
                    {
                        FileLength = info.Length.ToString();
                    }
                    catch
                    {
                        FileLength = "";
                    }

                    Console.WriteLine("<<FILE>>\t" + FileLength + "\t" + file);
                }

                // (recurcive) output sub directory information.
                foreach (string dir in DirNames)
                {
                    OutputFileList(dir);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            DirNames.Clear();
            files = null;
        }
    }
}
