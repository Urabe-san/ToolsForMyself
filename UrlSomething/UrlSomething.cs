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
using System.Xml.Linq;
using System.Linq.Expressions;

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
            ClearTextBoxes();
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

        private void buttonPaste_Click(object sender, EventArgs e)
        {
            PasteToOrigin();
        }

        private void buttonPastePlus_Click(object sender, EventArgs e)
        {
            PasteToOrigin(true);
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            if(0<textboxResult.Text.Length)
            {
                CopyToClipboard(textboxResult.Text);
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

        private void WriteEventLog(string expression, string source = "")
        {
            string sourcevalue = string.Empty;

            if(string.IsNullOrEmpty(source))
            {
                sourcevalue = System.AppDomain.CurrentDomain.FriendlyName;
                if (string.IsNullOrEmpty(sourcevalue))
                {
                    sourcevalue = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
                }
            }
            else
            {
                sourcevalue = source;
            }

            //Create source, when source is not exists.
            if (!System.Diagnostics.EventLog.SourceExists(sourcevalue))
            {

                System.Diagnostics.EventLog.CreateEventSource(sourcevalue, "");
            }
            try
            {
                System.Diagnostics.EventLog.WriteEntry(sourcevalue, expression, System.Diagnostics.EventLogEntryType.Error);
            }
            catch
            {
                //NOP
            }
        }

        private void ClearTextBoxes()
        {
            textboxOrigin.Text = string.Empty;
            textboxResult.Text = string.Empty;
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

            if (IsHttps)
            {
                result = HTTPS_STRING + result;
            }
            else if (IsHttp)
            {
                result = HTTP_STRING + result;
            }

            return result;
        }

        private void PasteToOrigin(bool WithDecode = false)
        {
            //textboxOrigin.Paste(); //perhaps, this one line will accomplish my goal.

            IDataObject iDataInstance = Clipboard.GetDataObject();

            // most of the "else" is unnecessary, when i clear the values ​​in the text boxes first.
            // although, this program also serves as a test.
            if (iDataInstance.GetDataPresent(DataFormats.Text))
            {
                string TextData = (String)iDataInstance.GetData(DataFormats.Text);

                if (!string.IsNullOrEmpty(TextData))
                {
                    textboxOrigin.Text = TextData;
                    if (WithDecode)
                    {
                        if (TextData.Length > 0)
                        {
                            textboxResult.Text = this.Decode(TextData);
                        }
                        else
                        {
                            textboxResult.Text = string.Empty;
                        }
                    }
                    else
                    {
                        textboxResult.Text = string.Empty;
                    }
                }
                else
                {
                    ClearTextBoxes();
                }
            }
        }

        private bool CopyToClipboard(string Value)
        {
            bool result = false;

            try
            {
                Clipboard.SetText(Value);
                result = true;
            }
            catch (Exception exc)
            {
                result = false;
                WriteEventLog(exc.Message);
            }

            return result;
        }
    }
}
