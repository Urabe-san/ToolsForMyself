using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopNote
{
    public partial class ConfigForm : Form
    {
        uint? FormSizeWidth = 0;
        uint? FormSizeHeight = 0;

        public uint? WindowWidth { get; set; } = 0;
        public uint? WindowHeight { get; set; } = 0;

        public ConfigForm()
        {
            InitializeComponent();
        }
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            WindowWidth = FormSizeWidth;
            WindowHeight = FormSizeHeight;
            this.Close();
        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {
            FormSizeWidth = WindowWidth;
            FormSizeHeight = WindowHeight;

            textboxFormWidth.Text = FormSizeWidth.ToString();
            textboxFormHeight.Text = FormSizeHeight.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (IsInteger(textboxFormWidth.Text) && IsInteger(textboxFormHeight.Text))
            {
                FormSizeWidth = uint.Parse(textboxFormWidth.Text);
                FormSizeHeight = uint.Parse(textboxFormHeight.Text);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {

        }

        private bool IsInteger(string Value)
        {
            uint dummy = 1;
            if (uint.TryParse(Value, out dummy))
            {
                return true;
            } 
            else
            {  
                return false; 
            }
        }
    }
}
