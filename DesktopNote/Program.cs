using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopNote
{
    internal static class Program
    {
        private const string PROGRAM_NAME = "DesktopNoteAlpha"; // for Mutex

        private static Mutex PrivateMutex;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool CreatedNew;
            PrivateMutex = new Mutex(true, PROGRAM_NAME, out CreatedNew);

            try
            {
                // Preventing multiple instances
                if (!CreatedNew)
                {
                    //Console.WriteLine("This application is already run.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new DesktopNote());
            }
            finally
            {
                // ミューテックスが取得されている場合にのみリリース
                if (CreatedNew)
                {
                    PrivateMutex.ReleaseMutex();
                }
            }
        }
    }
}
