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
            Console.Error.WriteLine("Finished.");
        }

        /// <summary>
        ///   Output directories/files listing
        /// </summary>
        /// <param name="Pathname">target path</param>
        static void OutputFileList(string Pathname)
        {
            IEnumerable<string> files; // storage directories / files listing
            var DirNames = new List<string>(); // storage list of directories. for call to recursive output.

            try
            {
                // output directory list
                try
                {
                    files = Directory.GetDirectories(Pathname);
                    foreach (string file in files)
                    {
                        // memory to directories.
                        DirNames.Add(file);

                        string TimeStamp;
                        FileInfo info = new FileInfo(file);

                        try
                        {
                            TimeStamp = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        catch (Exception ex)
                        {
                            TimeStamp = "";
                            Console.Error.WriteLine("[ERROR_PATH] " + file);
                            Console.Error.WriteLine(ex.ToString());
                        }

                        Console.WriteLine("<<DIR>>\t" + TimeStamp + "\t\t" + file);
                    }
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine("[ERROR_PATH] " + Pathname);
                    Console.Error.WriteLine(ex.ToString());
                }

                // output file list.
                try
                {
                    files =
                        Directory.EnumerateFiles(
                          Pathname,
                          "*",
                          SearchOption.TopDirectoryOnly);

                    foreach (string file in files)
                    {
                        string FileLength;
                        string TimeStamp;
                        FileInfo info;

                        try
                        {
                            info = new FileInfo(file);
                            FileLength = info.Length.ToString();
                            TimeStamp = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        catch (Exception ex)
                        {
                            FileLength = "";
                            TimeStamp = "";
                            Console.Error.WriteLine("[ERROR_FILE] " + file);
                            Console.Error.WriteLine(ex.ToString());
                        }

                        Console.WriteLine("<<FILE>>\t" + TimeStamp + "\t" + FileLength + "\t" + file);
                    }
                }
                catch(Exception ex)
                {
                    Console.Error.WriteLine("[ERROR_PATH] " + Pathname);
                    Console.Error.WriteLine(ex.ToString());
                }

                // (recursive) output sub directory information.
                foreach (string dir in DirNames)
                {
                    OutputFileList(dir);
                }
            }
            catch (Exception ex)
            {
				Console.Error.WriteLine(ex.ToString());
            }

            //dispose
            DirNames.Clear();
            files = null;
        }
    }
}
