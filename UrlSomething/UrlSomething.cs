using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Web;

namespace UrlSomething
{
    public partial class UrlSomething : Form
    {
        private bool IsClose;

        public UrlSomething()
        {
            InitializeComponent();
        }

        private void UrlSomething_Load(object sender, EventArgs evt)
        {
            IsClose = false;
        }

        private void UrlSomething_FormClosing(object sender, FormClosingEventArgs evt)
        {
            if( !IsClose)
            {
                if (MessageBox.Show("Quit this application", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    evt.Cancel = true;
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs evt)
        {
            textboxOrigin.Text = string.Empty;
        }

        private void buttonDecode_Click(object sender, EventArgs evt)
        {
            string expression = string.Empty;

            if (!string.IsNullOrEmpty(textboxOrigin.Text))
            {
                expression = textboxOrigin.Text.Trim();
            }
            if(expression.Length > 0)
            {
                textboxResult.Text = this.Decode(expression);
            }
            else
            {
                textboxResult.Text = string.Empty;
            }
        }

        private void buttonQuit_Click(object sender, EventArgs evt)
        {
            if (MessageBox.Show("Quit this application", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IsClose = true;
                this.Close();
            }
        }

        private string Decode(string expression)
        {
            const string HTTP_STRING = "http://"; //Why do some people exclude the "https%3A%2F%2F" part when encoding?
            const string HTTPS_STRING = "https://";

            string origin = string.Empty;
            string result = string.Empty;

            bool IsHttp = false, IsHttps = false;

            if (expression.IndexOf(HTTPS_STRING) == 0)
            {
                IsHttps = true;
                origin = expression.Substring(HTTPS_STRING.Length);
            }
            else if (expression.IndexOf(HTTP_STRING) == 0)
            {
                IsHttp = true;
                origin = expression.Substring(HTTP_STRING.Length);
            }
            else
            { 
                origin = expression; 
            }

            result = HttpUtility.UrlDecode(origin);

            if(IsHttps)
            {
                result = HTTPS_STRING + result;
            }
            else if(IsHttp)
            {
                result = HTTP_STRING + result;
            }

            return result;
        }
    }
}
