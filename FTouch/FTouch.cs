using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FTouch
{
    internal class FTouch
    {
        private enum Types
        {
            None = 0,
            create = 1,
            modify = 2,
            access = 3
        }


        static void Main(string[] args)
        {
            Types opt = Types.None;
            DateTime stamp = DateTime.MinValue;
            string Filename = null;

            if (3 != args.Length)
            {
                usage();
                return;
            }

            opt = OptionDef(args[0]);
            stamp = StringToTime(args[1]);
            Filename = args[2];

            ChangeTimeStamp(opt, Filename, stamp);
        }

        /// <summary>
        ///   Usage
        /// </summary>
        static void usage()
        {
            Console.Write("FTouch by Urabe-san. Aug. 2024\n\n");
            Console.WriteLine("USAGE: ");
            Console.WriteLine(" FTouch [option] [timestamp] [filepath] \n");
            Console.WriteLine("  option");
            Console.WriteLine("   C or c: change create time");
            Console.WriteLine("   M or m: change modify time");
            Console.WriteLine("   A or a: change access time");
            Console.WriteLine("");
            Console.WriteLine("  timestamp");
            Console.WriteLine("   yyyy-MM-ddTHH:mm:ss");
            Console.WriteLine("");
        }

        static Types OptionDef(string args)
        {
            Types result =Types.None;
            if(1 == args.Length)
            {
                if (args.Equals("C") || args.Equals("c"))
                {
                    result = Types.create;
                }
                else if (args.Equals("M") || args.Equals("m"))
                {
                    result = Types.modify;
                }
                else if (args.Equals("A") || args.Equals("a"))
                {
                    result = Types.access;
                }
            }

            return result;
        }

        static DateTime StringToTime(string expression)
        {
            DateTime result;

            if(!DateTime.TryParse(expression.Replace('T', ' '), out result))
            {
                result= DateTime.MinValue;
            }
            return result;
        }

        static int ChangeTimeStamp(Types operation, string path, DateTime timestamp)
        {
            int result = 0;

            if (false == System.IO.File.Exists(path))
            {
                result = 1;
            }

            if (0 == result) {
                if (timestamp.Ticks <= 0)
                {
                    result = 2;
                }
            }

            if (0 == result)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (operation == Types.create)
                {
                    file.CreationTime = timestamp;
                }
                else if (operation == Types.modify)
                {
                    file.LastWriteTime = timestamp;
                }
                else if (operation == Types.access)
                {
                    file.LastAccessTime = timestamp;
                }
                else
                {
                    result = 3;
                }
                if (0 == result)
                {
                    file.Refresh();
                }
                file = null;
            }

            return result;
        }
    }
}
