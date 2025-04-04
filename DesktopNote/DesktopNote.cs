using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopNote
{
    public partial class DesktopNote : Form
    {

        private const string FILE_NAME = "DesktopNote.txt";

        public DesktopNote()
        {
            InitializeComponent();
        }

        private void DesktopNote_Load(object sender, EventArgs e)
        {
            NoteResize();
        }

        private void DesktopNote_Resize(object sender, EventArgs e)
        {
            NoteResize();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Value = string.Empty;
            try
            {
                Value = LoadFile(GetApplicationDirectoryPath() + "\\" + FILE_NAME);
                textboxNote.Text = Value;
            }
            catch {
                //nop
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile(GetApplicationDirectoryPath() + "\\" + FILE_NAME, textboxNote.Text);
            }
            catch
            {
                //nop
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static void SaveFile(string FileFullPath, string Value)
        {
            try
            {
                System.IO.File.WriteAllText(FileFullPath, Value, System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error in Write Process: {ex.Message}");
                throw new Exception("Error in Write Process: {ex.Message}", ex);
            }
        }
        private void NoteResize()
        {
            textboxNote.Size = this.ClientSize;
        }

        private static string LoadFile(string FileFullPath)
        {
            try
            {
                if (System.IO.File.Exists(FileFullPath))
                {
                    return System.IO.File.ReadAllText(FileFullPath, System.Text.Encoding.UTF8);
                }
                else
                {
                    //return string.Empty;
                    throw new System.Exception("LoadFile is not Exists.");
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error upon Load Process: {ex.Message}");
                //return string.Empty;
                throw new Exception("Error upon Load Process: {ex.Message}",ex);
            }
        }

        public static string GetApplicationDirectoryPath()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            return StripPath(Path.GetDirectoryName(assemblyPath));
        }

        private static string StripPath(string expression)
        {
            int ThisLength = expression.Trim().Length;

            if (0 == ThisLength)
            {
                return expression.Trim();
            }

            if (expression.Trim().Substring(ThisLength - 1, 1).Equals("\\"))
            {
                return expression.Trim().Substring(0, ThisLength - 1);
            }
            else
            {
                return expression.Trim();
            }
        }
    }

}
