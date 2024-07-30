using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

namespace GetFileList
{
    internal class GetFileList
    {
        /// <summary>
        ///   プログラムのエントリ
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //exit program when no command line parameter
            if (args.Length < 1)
            {
                return;
            }

            OutputFileList(args[0]);
        }

        /// <summary>
        ///   指定のパスのディレクトリーとファイルの一覧を出力する
        /// </summary>
        /// <param name="Pathname">出力パス</param>
        static void OutputFileList(string Pathname)
        {
            IEnumerable<string> files; // ディレクトリー／ファイルの一覧を格納する
            var DirNames = new List<string>(); // ディレクトリの一覧を格納する(サブディレクトリ出力呼び出しのため)

            try
            {
                // ディレクトリーの一覧を出力する
                files = Directory.EnumerateDirectories(
                    Pathname,
                    "*",
                    SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    DirNames.Add(file); //ディレクトリーの一覧は保存しておく
                    Console.WriteLine("<<DIR>>   " + file);
                }

                // ファイルの一覧を出力する
                files =
                    Directory.EnumerateFiles(
                      Pathname,
                      "*",
                      SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    Console.WriteLine("<<FILE>>  " + file);
                }

                // (再帰)サブディレクトリーの出力を行う
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
