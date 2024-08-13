using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace FTouchGUI
{
    enum TargetTimeType
    {
        CreateTime = 1,
        ModifyTime = 2,
        AccessTime = 4
    }

    enum DateTimeType
    {
        Year = 1,
        Month = 2,
        Day = 3,
        Hour = 4,
        Minute = 5,
        Second = 6,
        DateString = 7,
        TimeString = 8,
        DateTimeString = 9
    }

    public partial class FTouchGUI : Form
    {
        Boolean IsEventQuitButton = false;

        public FTouchGUI()
        {
            InitializeComponent();
        }

        private void FTouchGUI_Load(object sender, EventArgs e)
        {
            checkboxCreateTime.Checked = false;
            checkboxModifyTime.Checked = false;
            checkboxAccessTime.Checked = false;

            SetDateTimeControlReadOnly(TargetTimeType.CreateTime, true);
            SetDateTimeControlReadOnly(TargetTimeType.ModifyTime, true);
            SetDateTimeControlReadOnly(TargetTimeType.AccessTime, true);

            buttonSaveChange.Enabled = false;
        }

        private void FTouchGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult.Cancel == MessageBox.Show("Quit Program.", this.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                e.Cancel = true;
            }
        }

        private void buttonOpenfile_Click(object sender, EventArgs e)
        {
            string CurrentPath;
            string CurrentFileName;
            string TargetFullpath = string.Empty;

            if (true == System.IO.File.Exists(textboxFilepath.Text))
            {
                CurrentPath = System.IO.Path.GetFullPath(textboxFilepath.Text);
                CurrentFileName = System.IO.Path.GetFileName(textboxFilepath.Text);
            }
            else
            {
                CurrentPath = string.Empty;
                CurrentFileName = string.Empty;
            }

            TargetFullpath = this.ShowFileOpenDialog(CurrentPath, CurrentFileName);

            if(true==System.IO.File.Exists(TargetFullpath))
            {
                //Create Object FileInfo
                System.IO.FileInfo FileInformation = new System.IO.FileInfo(TargetFullpath);

                DateTime CreateTime = FileInformation.CreationTime;
                DateTime ModifyTime = FileInformation.LastWriteTime;
                DateTime　AccessTime = FileInformation.LastAccessTime;

                checkboxCreateTime.Checked = false;
                checkboxModifyTime.Checked = false;
                checkboxAccessTime.Checked = false;

                SetDateTimeControlReadOnly(TargetTimeType.CreateTime, true);
                SetDateTimeControlReadOnly(TargetTimeType.ModifyTime, true);
                SetDateTimeControlReadOnly(TargetTimeType.AccessTime, true);

                textboxFilepath.Text = TargetFullpath;

                SetDatetimeValue(TargetTimeType.CreateTime, CreateTime);
                SetDatetimeValue(TargetTimeType.ModifyTime, ModifyTime);
                SetDatetimeValue(TargetTimeType.AccessTime, AccessTime);

                buttonSaveChange.Enabled = true;
            }
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkboxCreateTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDateTimeControlReadOnly(TargetTimeType.CreateTime, !checkboxCreateTime.Checked);
        }

        private void checkboxModifyTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDateTimeControlReadOnly(TargetTimeType.ModifyTime, !checkboxModifyTime.Checked);
        }

        private void checkboxAccessTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDateTimeControlReadOnly(TargetTimeType.AccessTime, !checkboxAccessTime.Checked);
        }

        private string ShowFileOpenDialog(string CurrentPath, string CurrentFilename)
        {
            string result = string.Empty;
            string DefaultPath;
            string DefaultFileName;

            if (string.IsNullOrEmpty(CurrentPath))
            {
                DefaultPath = Application.ExecutablePath;
            }
            else
            {
                if (true == System.IO.Directory.Exists(CurrentPath))
                {
                    DefaultPath = CurrentPath;
                }
                else
                {
                    DefaultPath=string.Empty;
                }
            }

            if (string.IsNullOrEmpty(CurrentFilename))
            {
                DefaultFileName = string.Empty;
            }
            else
            {
                DefaultFileName = CurrentFilename;
            }

            //Create Object FileOpenDialog
            OpenFileDialog DialogFileOpen = new OpenFileDialog();
            DialogFileOpen.Title = "Open File";  //Dialog Caption
            DialogFileOpen.InitialDirectory = DefaultPath;  //Default Path
            DialogFileOpen.FileName = DefaultFileName;  //Default Filename
            DialogFileOpen.Filter = "All Files (*.*)|*.*";  //Selectable Extention
            DialogFileOpen.FilterIndex = 0;  //Default Extention (*.*)

            // Display File open dialog
            DialogResult DialogResultInstance = DialogFileOpen.ShowDialog();

            if (DialogResult.OK== DialogResultInstance)
            {
                result = DialogFileOpen.FileName;
            }
            else
            {
                result = string.Empty;
            }

            return result;
        }

        private void buttonSaveChange_Click(object sender, EventArgs e)
        {
            DateTime CreateDatetimeValue = DateTime.MinValue;
            DateTime ModifyDatetimeValue = DateTime.MinValue;
            DateTime AccessDatetimeValue = DateTime.MinValue;


            if (checkboxCreateTime.Checked && false == CheckInputError(TargetTimeType.CreateTime))
            {
                MessageBox.Show("Create Time Input Error.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (checkboxModifyTime.Checked && false == CheckInputError(TargetTimeType.CreateTime))
            {
                MessageBox.Show("Modyfy Time Input Error.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (checkboxAccessTime.Checked && false == CheckInputError(TargetTimeType.CreateTime))
            {
                MessageBox.Show("Access Time Input Error.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            if (checkboxCreateTime.Checked)
            {
                CreateDatetimeValue = StringToDatetime(textboxCreateYear.Text, textboxCreateMonth.Text, textboxCreateDay.Text, textboxCreateHour.Text, textboxCreateMinute.Text, textboxCreateSecond.Text);
            }
            if (checkboxModifyTime.Checked)
            {
                ModifyDatetimeValue = StringToDatetime(textboxModifyYear.Text, textboxModifyMonth.Text, textboxModifyDay.Text, textboxModifyHour.Text, textboxModifyMinute.Text, textboxModifySecond.Text);
            }
            if (checkboxAccessTime.Checked)
            {
                AccessDatetimeValue = StringToDatetime(textboxAccessYear.Text, textboxAccessMonth.Text, textboxAccessDay.Text, textboxAccessHour.Text, textboxAccessMinute.Text, textboxAccessSecond.Text);
            }

            if (false == SetTimestamp(textboxFilepath.Text.Trim(), CreateDatetimeValue, ModifyDatetimeValue, AccessDatetimeValue))
            {
                MessageBox.Show("Cannot set timestamp to file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SetDateTimeControlReadOnly(TargetTimeType Target, Boolean Value)
        {
            if (TargetTimeType.CreateTime == Target)
            {
                textboxCreateYear.ReadOnly = !checkboxCreateTime.Checked;
                textboxCreateMonth.ReadOnly = !checkboxCreateTime.Checked;
                textboxCreateDay.ReadOnly = !checkboxCreateTime.Checked;
                textboxCreateHour.ReadOnly = !checkboxCreateTime.Checked;
                textboxCreateMinute.ReadOnly = !checkboxCreateTime.Checked;
                textboxCreateSecond.ReadOnly = !checkboxCreateTime.Checked;
            }
            else if (TargetTimeType.ModifyTime == Target)
            {
                textboxModifyYear.ReadOnly = !checkboxModifyTime.Checked;
                textboxModifyMonth.ReadOnly = !checkboxModifyTime.Checked;
                textboxModifyDay.ReadOnly = !checkboxModifyTime.Checked;
                textboxModifyHour.ReadOnly = !checkboxModifyTime.Checked;
                textboxModifyMinute.ReadOnly = !checkboxModifyTime.Checked;
                textboxModifySecond.ReadOnly = !checkboxModifyTime.Checked;
            }
            else if (TargetTimeType.AccessTime == Target)
            {
                textboxAccessYear.ReadOnly = !checkboxAccessTime.Checked;
                textboxAccessMonth.ReadOnly = !checkboxAccessTime.Checked;
                textboxAccessDay.ReadOnly = !checkboxAccessTime.Checked;
                textboxAccessHour.ReadOnly = !checkboxAccessTime.Checked;
                textboxAccessMinute.ReadOnly = !checkboxAccessTime.Checked;
                textboxAccessSecond.ReadOnly = !checkboxAccessTime.Checked;
            }
        }

        private void SetDatetimeValue(TargetTimeType Target, DateTime Value)
        {
            if (TargetTimeType.CreateTime == Target)
            {
                textboxCreateYear.Text = Value.Year.ToString("0000");
                textboxCreateMonth.Text = Value.Month.ToString("00");
                textboxCreateDay.Text = Value.Day.ToString("00");
                textboxCreateHour.Text = Value.Hour.ToString("00");
                textboxCreateMinute.Text = Value.Minute.ToString("00");
                textboxCreateSecond.Text = Value.Second.ToString("00");
            }
            else if (TargetTimeType.ModifyTime == Target)
            {
                textboxModifyYear.Text = Value.Year.ToString("0000");
                textboxModifyMonth.Text = Value.Month.ToString("00");
                textboxModifyDay.Text = Value.Day.ToString("00");
                textboxModifyHour.Text = Value.Hour.ToString("00");
                textboxModifyMinute.Text = Value.Minute.ToString("00");
                textboxModifySecond.Text = Value.Second.ToString("00");
            }
            else if (TargetTimeType.AccessTime == Target)
            {
                textboxAccessYear.Text = Value.Year.ToString("0000");
                textboxAccessMonth.Text = Value.Month.ToString("00");
                textboxAccessDay.Text = Value.Day.ToString("00");
                textboxAccessHour.Text = Value.Hour.ToString("00");
                textboxAccessMinute.Text = Value.Minute.ToString("00");
                textboxAccessSecond.Text = Value.Second.ToString("00");
            }
        }

        Boolean CheckInputError(TargetTimeType Target)
        {
            Boolean result = true;

            if (TargetTimeType.CreateTime == Target)
            {
                result &= CheckDateTimeValue(textboxCreateYear.Text, DateTimeType.Year);
                result &= CheckDateTimeValue(textboxCreateMonth.Text, DateTimeType.Month);
                result &= CheckDateTimeValue(textboxCreateDay.Text, DateTimeType.Day);
                result &= CheckDateTimeValue(textboxCreateHour.Text, DateTimeType.Hour);
                result &= CheckDateTimeValue(textboxCreateMinute.Text, DateTimeType.Minute);
                result &= CheckDateTimeValue(textboxCreateSecond.Text, DateTimeType.Second);
            }
            else if (TargetTimeType.ModifyTime == Target)
            {
                result &= CheckDateTimeValue(textboxModifyYear.Text, DateTimeType.Year);
                result &= CheckDateTimeValue(textboxModifyMonth.Text, DateTimeType.Month);
                result &= CheckDateTimeValue(textboxModifyDay.Text, DateTimeType.Day);
                result &= CheckDateTimeValue(textboxModifyHour.Text, DateTimeType.Hour);
                result &= CheckDateTimeValue(textboxModifyMinute.Text, DateTimeType.Minute);
                result &= CheckDateTimeValue(textboxModifySecond.Text, DateTimeType.Second);
            }
            else if (TargetTimeType.AccessTime == Target)
            {
                result &= CheckDateTimeValue(textboxAccessYear.Text, DateTimeType.Year);
                result &= CheckDateTimeValue(textboxAccessMonth.Text, DateTimeType.Month);
                result &= CheckDateTimeValue(textboxAccessDay.Text, DateTimeType.Day);
                result &= CheckDateTimeValue(textboxAccessHour.Text, DateTimeType.Hour);
                result &= CheckDateTimeValue(textboxAccessMinute.Text, DateTimeType.Minute);
                result &= CheckDateTimeValue(textboxAccessSecond.Text, DateTimeType.Second);
            }

            return result;
        }

        private Boolean CheckDateTimeValue(string Expression, DateTimeType type)
        {
            Boolean result = false;

            if (DateTimeType.DateString == type || DateTimeType.TimeString == type || DateTimeType.DateTimeString == type)
            {
                DateTime temporary;
                result = DateTime.TryParse(Expression, out temporary);
            }
            else
            {
                try
                {
                    if (DateTimeType.Year == type)
                    {
                        int YearValue = Convert.ToInt32(Expression);
                        if (-1999 <= YearValue && YearValue <= 2999)
                        {
                            result = true;
                        }
                    }
                    else if (DateTimeType.Month == type)
                    {
                        int MonthValue = Convert.ToInt32(Expression);
                        if (1 <= MonthValue && MonthValue <= 12)
                        {
                            result = true;
                        }
                    }
                    else if (DateTimeType.Day == type)
                    {
                        int DayValue = Convert.ToInt32(Expression);
                        if (1 <= DayValue && DayValue <= 31)
                        {
                            result = true;
                        }
                    }
                    else if (DateTimeType.Hour == type)
                    {
                        int HourValue = Convert.ToInt32(Expression);
                        if (0 <= HourValue && HourValue < 24)
                        {
                            result = true;
                        }
                    }
                    else if (DateTimeType.Minute == type || DateTimeType.Second == type)
                    {
                        int MinuteSeccondValue = Convert.ToInt32(Expression);
                        if (0 <= MinuteSeccondValue && MinuteSeccondValue < 60)
                        {
                            result = true;
                        }
                    }
                }
                catch (OverflowException)
                {
                    MessageBox.Show("Input value is Over Flow.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    result = false;
                }
                catch (FormatException)
                {
                    result = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    result = false;
                }
            }
            return result;
        }

        private Boolean SetTimestamp(string filename, DateTime CreateTime, DateTime ModifyTIme, DateTime AccessTime)
        {
            Boolean result = false;
            FileInfo FileInformation;

            if (false == System.IO.File.Exists(filename))
            {
                return result;
            }

            try
            {
                FileInformation = new System.IO.FileInfo(filename);

                if(DateTime.MinValue != CreateTime)
                { 
                    FileInformation.CreationTime = CreateTime;
                }
                if (DateTime.MinValue != ModifyTIme)
                {
                    FileInformation.LastWriteTime = ModifyTIme;
                }
                if (DateTime.MinValue != AccessTime)
                {
                    FileInformation.LastAccessTime = AccessTime;
                }

                FileInformation.Refresh();

                FileInformation = null;

                result = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                result = false;
                MessageBox.Show("File is not found.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.IO.PathTooLongException)
            {
                result = false;
                MessageBox.Show("FilePath is loo long.", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

        private DateTime StringToDatetime(string YearValue, string MonthValue, string DayValue, string HourValue, string MinuteValue, string SeccondValue)
        {
            DateTime result;
            string DateTimeValue = string.Empty;

            try
            {
                DateTimeValue = YearValue + "/" + MonthValue + "/" + DayValue + " " + HourValue + ":" + MinuteValue + ":" + SeccondValue;
                if (false == DateTime.TryParse(DateTimeValue, out result))
                {
                    result = DateTime.MinValue;
                }
            }
            catch (Exception ex)
            {
                result = DateTime.MinValue;
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return result;
        }

    }
}
