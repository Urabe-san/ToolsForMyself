using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace URLEncDec
{
    public partial class URLEncDec : Form
    {
        public URLEncDec()
        {
            InitializeComponent();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            if (0 < textboxExpression.Text.Length)
            {
                textboxResult.Text = System.Web.HttpUtility.UrlEncode(textboxExpression.Text);
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            if (0 < textboxExpression.Text.Length)
            {
                textboxResult.Text = System.Web.HttpUtility.UrlDecode(textboxExpression.Text);
            }
        }
    }
}
