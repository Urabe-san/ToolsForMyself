namespace FTouchGUI
{
    partial class FTouchGUI
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.textboxFilepath = new System.Windows.Forms.TextBox();
            this.buttonOpenfile = new System.Windows.Forms.Button();
            this.textboxCreateYear = new System.Windows.Forms.TextBox();
            this.labelCreateSlash1 = new System.Windows.Forms.Label();
            this.textboxCreateMonth = new System.Windows.Forms.TextBox();
            this.labelCreateSlash2 = new System.Windows.Forms.Label();
            this.textboxCreateDay = new System.Windows.Forms.TextBox();
            this.textboxCreateHour = new System.Windows.Forms.TextBox();
            this.labelCreateCoron1 = new System.Windows.Forms.Label();
            this.labelCreateCoron2 = new System.Windows.Forms.Label();
            this.textboxCreateMinute = new System.Windows.Forms.TextBox();
            this.textboxCreateSecond = new System.Windows.Forms.TextBox();
            this.checkboxCreateTime = new System.Windows.Forms.CheckBox();
            this.checkboxModifyTime = new System.Windows.Forms.CheckBox();
            this.textboxModifySecond = new System.Windows.Forms.TextBox();
            this.labelModifyCoron2 = new System.Windows.Forms.Label();
            this.textboxModifyMinute = new System.Windows.Forms.TextBox();
            this.labelModifyCoron1 = new System.Windows.Forms.Label();
            this.textboxModifyHour = new System.Windows.Forms.TextBox();
            this.textboxModifyDay = new System.Windows.Forms.TextBox();
            this.labelModifySlash2 = new System.Windows.Forms.Label();
            this.textboxModifyMonth = new System.Windows.Forms.TextBox();
            this.labelModifySlash1 = new System.Windows.Forms.Label();
            this.textboxModifyYear = new System.Windows.Forms.TextBox();
            this.checkboxAccessTime = new System.Windows.Forms.CheckBox();
            this.textboxAccessSecond = new System.Windows.Forms.TextBox();
            this.labelAccessCoron2 = new System.Windows.Forms.Label();
            this.textboxAccessMinute = new System.Windows.Forms.TextBox();
            this.labelAccessCoron1 = new System.Windows.Forms.Label();
            this.textboxAccessHour = new System.Windows.Forms.TextBox();
            this.textboxAccessDay = new System.Windows.Forms.TextBox();
            this.labelAccessSlash2 = new System.Windows.Forms.Label();
            this.textboxAccessMonth = new System.Windows.Forms.TextBox();
            this.labelAccessSlash1 = new System.Windows.Forms.Label();
            this.textboxAccessYear = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonSaveChange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxFilepath
            // 
            this.textboxFilepath.Location = new System.Drawing.Point(12, 12);
            this.textboxFilepath.Name = "textboxFilepath";
            this.textboxFilepath.Size = new System.Drawing.Size(382, 25);
            this.textboxFilepath.TabIndex = 1;
            // 
            // buttonOpenfile
            // 
            this.buttonOpenfile.Location = new System.Drawing.Point(400, 14);
            this.buttonOpenfile.Name = "buttonOpenfile";
            this.buttonOpenfile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenfile.TabIndex = 2;
            this.buttonOpenfile.Text = "Open";
            this.buttonOpenfile.UseVisualStyleBackColor = true;
            this.buttonOpenfile.Click += new System.EventHandler(this.buttonOpenfile_Click);
            // 
            // textboxCreateYear
            // 
            this.textboxCreateYear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateYear.Location = new System.Drawing.Point(127, 43);
            this.textboxCreateYear.MaxLength = 4;
            this.textboxCreateYear.Name = "textboxCreateYear";
            this.textboxCreateYear.Size = new System.Drawing.Size(40, 25);
            this.textboxCreateYear.TabIndex = 4;
            this.textboxCreateYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCreateSlash1
            // 
            this.labelCreateSlash1.AutoSize = true;
            this.labelCreateSlash1.Location = new System.Drawing.Point(168, 48);
            this.labelCreateSlash1.Name = "labelCreateSlash1";
            this.labelCreateSlash1.Size = new System.Drawing.Size(15, 15);
            this.labelCreateSlash1.TabIndex = 5;
            this.labelCreateSlash1.Text = "-";
            this.labelCreateSlash1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxCreateMonth
            // 
            this.textboxCreateMonth.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateMonth.Location = new System.Drawing.Point(184, 43);
            this.textboxCreateMonth.MaxLength = 2;
            this.textboxCreateMonth.Name = "textboxCreateMonth";
            this.textboxCreateMonth.Size = new System.Drawing.Size(26, 25);
            this.textboxCreateMonth.TabIndex = 6;
            this.textboxCreateMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCreateSlash2
            // 
            this.labelCreateSlash2.AutoSize = true;
            this.labelCreateSlash2.Location = new System.Drawing.Point(211, 48);
            this.labelCreateSlash2.Name = "labelCreateSlash2";
            this.labelCreateSlash2.Size = new System.Drawing.Size(15, 15);
            this.labelCreateSlash2.TabIndex = 7;
            this.labelCreateSlash2.Text = "-";
            this.labelCreateSlash2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxCreateDay
            // 
            this.textboxCreateDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateDay.Location = new System.Drawing.Point(227, 43);
            this.textboxCreateDay.MaxLength = 2;
            this.textboxCreateDay.Name = "textboxCreateDay";
            this.textboxCreateDay.Size = new System.Drawing.Size(26, 25);
            this.textboxCreateDay.TabIndex = 8;
            this.textboxCreateDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textboxCreateHour
            // 
            this.textboxCreateHour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateHour.Location = new System.Drawing.Point(259, 43);
            this.textboxCreateHour.MaxLength = 2;
            this.textboxCreateHour.Name = "textboxCreateHour";
            this.textboxCreateHour.Size = new System.Drawing.Size(26, 25);
            this.textboxCreateHour.TabIndex = 9;
            this.textboxCreateHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelCreateCoron1
            // 
            this.labelCreateCoron1.AutoSize = true;
            this.labelCreateCoron1.Location = new System.Drawing.Point(286, 48);
            this.labelCreateCoron1.Name = "labelCreateCoron1";
            this.labelCreateCoron1.Size = new System.Drawing.Size(10, 15);
            this.labelCreateCoron1.TabIndex = 10;
            this.labelCreateCoron1.Text = ":";
            this.labelCreateCoron1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCreateCoron2
            // 
            this.labelCreateCoron2.AutoSize = true;
            this.labelCreateCoron2.Location = new System.Drawing.Point(324, 48);
            this.labelCreateCoron2.Name = "labelCreateCoron2";
            this.labelCreateCoron2.Size = new System.Drawing.Size(10, 15);
            this.labelCreateCoron2.TabIndex = 12;
            this.labelCreateCoron2.Text = ":";
            this.labelCreateCoron2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxCreateMinute
            // 
            this.textboxCreateMinute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateMinute.Location = new System.Drawing.Point(297, 43);
            this.textboxCreateMinute.MaxLength = 2;
            this.textboxCreateMinute.Name = "textboxCreateMinute";
            this.textboxCreateMinute.Size = new System.Drawing.Size(26, 25);
            this.textboxCreateMinute.TabIndex = 11;
            this.textboxCreateMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textboxCreateSecond
            // 
            this.textboxCreateSecond.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxCreateSecond.Location = new System.Drawing.Point(335, 43);
            this.textboxCreateSecond.MaxLength = 2;
            this.textboxCreateSecond.Name = "textboxCreateSecond";
            this.textboxCreateSecond.Size = new System.Drawing.Size(26, 25);
            this.textboxCreateSecond.TabIndex = 13;
            this.textboxCreateSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkboxCreateTime
            // 
            this.checkboxCreateTime.AutoSize = true;
            this.checkboxCreateTime.Location = new System.Drawing.Point(14, 46);
            this.checkboxCreateTime.Name = "checkboxCreateTime";
            this.checkboxCreateTime.Size = new System.Drawing.Size(103, 19);
            this.checkboxCreateTime.TabIndex = 3;
            this.checkboxCreateTime.Text = "CreateTime";
            this.checkboxCreateTime.UseVisualStyleBackColor = true;
            this.checkboxCreateTime.CheckedChanged += new System.EventHandler(this.checkboxCreateTime_CheckedChanged);
            // 
            // checkboxModifyTime
            // 
            this.checkboxModifyTime.AutoSize = true;
            this.checkboxModifyTime.Location = new System.Drawing.Point(14, 75);
            this.checkboxModifyTime.Name = "checkboxModifyTime";
            this.checkboxModifyTime.Size = new System.Drawing.Size(101, 19);
            this.checkboxModifyTime.TabIndex = 14;
            this.checkboxModifyTime.Text = "ModifyTime";
            this.checkboxModifyTime.UseVisualStyleBackColor = true;
            this.checkboxModifyTime.CheckedChanged += new System.EventHandler(this.checkboxModifyTime_CheckedChanged);
            // 
            // textboxModifySecond
            // 
            this.textboxModifySecond.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifySecond.Location = new System.Drawing.Point(335, 72);
            this.textboxModifySecond.MaxLength = 2;
            this.textboxModifySecond.Name = "textboxModifySecond";
            this.textboxModifySecond.Size = new System.Drawing.Size(26, 25);
            this.textboxModifySecond.TabIndex = 24;
            this.textboxModifySecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelModifyCoron2
            // 
            this.labelModifyCoron2.AutoSize = true;
            this.labelModifyCoron2.Location = new System.Drawing.Point(324, 77);
            this.labelModifyCoron2.Name = "labelModifyCoron2";
            this.labelModifyCoron2.Size = new System.Drawing.Size(10, 15);
            this.labelModifyCoron2.TabIndex = 23;
            this.labelModifyCoron2.Text = ":";
            this.labelModifyCoron2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxModifyMinute
            // 
            this.textboxModifyMinute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifyMinute.Location = new System.Drawing.Point(297, 72);
            this.textboxModifyMinute.MaxLength = 2;
            this.textboxModifyMinute.Name = "textboxModifyMinute";
            this.textboxModifyMinute.Size = new System.Drawing.Size(26, 25);
            this.textboxModifyMinute.TabIndex = 22;
            this.textboxModifyMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelModifyCoron1
            // 
            this.labelModifyCoron1.AutoSize = true;
            this.labelModifyCoron1.Location = new System.Drawing.Point(286, 77);
            this.labelModifyCoron1.Name = "labelModifyCoron1";
            this.labelModifyCoron1.Size = new System.Drawing.Size(10, 15);
            this.labelModifyCoron1.TabIndex = 21;
            this.labelModifyCoron1.Text = ":";
            this.labelModifyCoron1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxModifyHour
            // 
            this.textboxModifyHour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifyHour.Location = new System.Drawing.Point(259, 72);
            this.textboxModifyHour.MaxLength = 2;
            this.textboxModifyHour.Name = "textboxModifyHour";
            this.textboxModifyHour.Size = new System.Drawing.Size(26, 25);
            this.textboxModifyHour.TabIndex = 20;
            this.textboxModifyHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textboxModifyDay
            // 
            this.textboxModifyDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifyDay.Location = new System.Drawing.Point(227, 72);
            this.textboxModifyDay.MaxLength = 2;
            this.textboxModifyDay.Name = "textboxModifyDay";
            this.textboxModifyDay.Size = new System.Drawing.Size(26, 25);
            this.textboxModifyDay.TabIndex = 19;
            this.textboxModifyDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelModifySlash2
            // 
            this.labelModifySlash2.AutoSize = true;
            this.labelModifySlash2.Location = new System.Drawing.Point(211, 77);
            this.labelModifySlash2.Name = "labelModifySlash2";
            this.labelModifySlash2.Size = new System.Drawing.Size(15, 15);
            this.labelModifySlash2.TabIndex = 18;
            this.labelModifySlash2.Text = "-";
            this.labelModifySlash2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxModifyMonth
            // 
            this.textboxModifyMonth.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifyMonth.Location = new System.Drawing.Point(184, 72);
            this.textboxModifyMonth.MaxLength = 2;
            this.textboxModifyMonth.Name = "textboxModifyMonth";
            this.textboxModifyMonth.Size = new System.Drawing.Size(26, 25);
            this.textboxModifyMonth.TabIndex = 17;
            this.textboxModifyMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelModifySlash1
            // 
            this.labelModifySlash1.AutoSize = true;
            this.labelModifySlash1.Location = new System.Drawing.Point(168, 77);
            this.labelModifySlash1.Name = "labelModifySlash1";
            this.labelModifySlash1.Size = new System.Drawing.Size(15, 15);
            this.labelModifySlash1.TabIndex = 16;
            this.labelModifySlash1.Text = "-";
            this.labelModifySlash1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxModifyYear
            // 
            this.textboxModifyYear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxModifyYear.Location = new System.Drawing.Point(127, 72);
            this.textboxModifyYear.MaxLength = 4;
            this.textboxModifyYear.Name = "textboxModifyYear";
            this.textboxModifyYear.Size = new System.Drawing.Size(40, 25);
            this.textboxModifyYear.TabIndex = 15;
            this.textboxModifyYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkboxAccessTime
            // 
            this.checkboxAccessTime.AutoSize = true;
            this.checkboxAccessTime.Location = new System.Drawing.Point(14, 104);
            this.checkboxAccessTime.Name = "checkboxAccessTime";
            this.checkboxAccessTime.Size = new System.Drawing.Size(107, 19);
            this.checkboxAccessTime.TabIndex = 25;
            this.checkboxAccessTime.Text = "AccessTime";
            this.checkboxAccessTime.UseVisualStyleBackColor = true;
            this.checkboxAccessTime.CheckedChanged += new System.EventHandler(this.checkboxAccessTime_CheckedChanged);
            // 
            // textboxAccessSecond
            // 
            this.textboxAccessSecond.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessSecond.Location = new System.Drawing.Point(335, 101);
            this.textboxAccessSecond.MaxLength = 2;
            this.textboxAccessSecond.Name = "textboxAccessSecond";
            this.textboxAccessSecond.Size = new System.Drawing.Size(26, 25);
            this.textboxAccessSecond.TabIndex = 35;
            this.textboxAccessSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccessCoron2
            // 
            this.labelAccessCoron2.AutoSize = true;
            this.labelAccessCoron2.Location = new System.Drawing.Point(324, 106);
            this.labelAccessCoron2.Name = "labelAccessCoron2";
            this.labelAccessCoron2.Size = new System.Drawing.Size(10, 15);
            this.labelAccessCoron2.TabIndex = 34;
            this.labelAccessCoron2.Text = ":";
            this.labelAccessCoron2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxAccessMinute
            // 
            this.textboxAccessMinute.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessMinute.Location = new System.Drawing.Point(297, 101);
            this.textboxAccessMinute.MaxLength = 2;
            this.textboxAccessMinute.Name = "textboxAccessMinute";
            this.textboxAccessMinute.Size = new System.Drawing.Size(26, 25);
            this.textboxAccessMinute.TabIndex = 33;
            this.textboxAccessMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccessCoron1
            // 
            this.labelAccessCoron1.AutoSize = true;
            this.labelAccessCoron1.Location = new System.Drawing.Point(286, 106);
            this.labelAccessCoron1.Name = "labelAccessCoron1";
            this.labelAccessCoron1.Size = new System.Drawing.Size(10, 15);
            this.labelAccessCoron1.TabIndex = 32;
            this.labelAccessCoron1.Text = ":";
            this.labelAccessCoron1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxAccessHour
            // 
            this.textboxAccessHour.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessHour.Location = new System.Drawing.Point(259, 101);
            this.textboxAccessHour.MaxLength = 2;
            this.textboxAccessHour.Name = "textboxAccessHour";
            this.textboxAccessHour.Size = new System.Drawing.Size(26, 25);
            this.textboxAccessHour.TabIndex = 31;
            this.textboxAccessHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textboxAccessDay
            // 
            this.textboxAccessDay.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessDay.Location = new System.Drawing.Point(227, 101);
            this.textboxAccessDay.MaxLength = 2;
            this.textboxAccessDay.Name = "textboxAccessDay";
            this.textboxAccessDay.Size = new System.Drawing.Size(26, 25);
            this.textboxAccessDay.TabIndex = 30;
            this.textboxAccessDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccessSlash2
            // 
            this.labelAccessSlash2.AutoSize = true;
            this.labelAccessSlash2.Location = new System.Drawing.Point(211, 106);
            this.labelAccessSlash2.Name = "labelAccessSlash2";
            this.labelAccessSlash2.Size = new System.Drawing.Size(15, 15);
            this.labelAccessSlash2.TabIndex = 29;
            this.labelAccessSlash2.Text = "-";
            this.labelAccessSlash2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxAccessMonth
            // 
            this.textboxAccessMonth.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessMonth.Location = new System.Drawing.Point(184, 101);
            this.textboxAccessMonth.MaxLength = 2;
            this.textboxAccessMonth.Name = "textboxAccessMonth";
            this.textboxAccessMonth.Size = new System.Drawing.Size(26, 25);
            this.textboxAccessMonth.TabIndex = 28;
            this.textboxAccessMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccessSlash1
            // 
            this.labelAccessSlash1.AutoSize = true;
            this.labelAccessSlash1.Location = new System.Drawing.Point(168, 106);
            this.labelAccessSlash1.Name = "labelAccessSlash1";
            this.labelAccessSlash1.Size = new System.Drawing.Size(15, 15);
            this.labelAccessSlash1.TabIndex = 27;
            this.labelAccessSlash1.Text = "-";
            this.labelAccessSlash1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textboxAccessYear
            // 
            this.textboxAccessYear.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textboxAccessYear.Location = new System.Drawing.Point(127, 101);
            this.textboxAccessYear.MaxLength = 4;
            this.textboxAccessYear.Name = "textboxAccessYear";
            this.textboxAccessYear.Size = new System.Drawing.Size(40, 25);
            this.textboxAccessYear.TabIndex = 26;
            this.textboxAccessYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(400, 103);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "QUIT";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonSaveChange
            // 
            this.buttonSaveChange.Location = new System.Drawing.Point(400, 42);
            this.buttonSaveChange.Name = "buttonSaveChange";
            this.buttonSaveChange.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveChange.TabIndex = 36;
            this.buttonSaveChange.Text = "Set Time";
            this.buttonSaveChange.UseVisualStyleBackColor = true;
            this.buttonSaveChange.Click += new System.EventHandler(this.buttonSaveChange_Click);
            // 
            // FTouchGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 140);
            this.Controls.Add(this.buttonSaveChange);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.checkboxAccessTime);
            this.Controls.Add(this.textboxAccessSecond);
            this.Controls.Add(this.labelAccessCoron2);
            this.Controls.Add(this.textboxAccessMinute);
            this.Controls.Add(this.labelAccessCoron1);
            this.Controls.Add(this.textboxAccessHour);
            this.Controls.Add(this.textboxAccessDay);
            this.Controls.Add(this.labelAccessSlash2);
            this.Controls.Add(this.textboxAccessMonth);
            this.Controls.Add(this.labelAccessSlash1);
            this.Controls.Add(this.textboxAccessYear);
            this.Controls.Add(this.checkboxModifyTime);
            this.Controls.Add(this.textboxModifySecond);
            this.Controls.Add(this.labelModifyCoron2);
            this.Controls.Add(this.textboxModifyMinute);
            this.Controls.Add(this.labelModifyCoron1);
            this.Controls.Add(this.textboxModifyHour);
            this.Controls.Add(this.textboxModifyDay);
            this.Controls.Add(this.labelModifySlash2);
            this.Controls.Add(this.textboxModifyMonth);
            this.Controls.Add(this.labelModifySlash1);
            this.Controls.Add(this.textboxModifyYear);
            this.Controls.Add(this.checkboxCreateTime);
            this.Controls.Add(this.textboxCreateSecond);
            this.Controls.Add(this.labelCreateCoron2);
            this.Controls.Add(this.textboxCreateMinute);
            this.Controls.Add(this.labelCreateCoron1);
            this.Controls.Add(this.textboxCreateHour);
            this.Controls.Add(this.textboxCreateDay);
            this.Controls.Add(this.labelCreateSlash2);
            this.Controls.Add(this.textboxCreateMonth);
            this.Controls.Add(this.labelCreateSlash1);
            this.Controls.Add(this.textboxCreateYear);
            this.Controls.Add(this.buttonOpenfile);
            this.Controls.Add(this.textboxFilepath);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTouchGUI";
            this.ShowIcon = false;
            this.Text = "FTouchGUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTouchGUI_FormClosing);
            this.Load += new System.EventHandler(this.FTouchGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxFilepath;
        private System.Windows.Forms.Button buttonOpenfile;
        private System.Windows.Forms.TextBox textboxCreateYear;
        private System.Windows.Forms.Label labelCreateSlash1;
        private System.Windows.Forms.TextBox textboxCreateMonth;
        private System.Windows.Forms.Label labelCreateSlash2;
        private System.Windows.Forms.TextBox textboxCreateDay;
        private System.Windows.Forms.TextBox textboxCreateHour;
        private System.Windows.Forms.Label labelCreateCoron1;
        private System.Windows.Forms.Label labelCreateCoron2;
        private System.Windows.Forms.TextBox textboxCreateMinute;
        private System.Windows.Forms.TextBox textboxCreateSecond;
        private System.Windows.Forms.CheckBox checkboxCreateTime;
        private System.Windows.Forms.CheckBox checkboxModifyTime;
        private System.Windows.Forms.TextBox textboxModifySecond;
        private System.Windows.Forms.Label labelModifyCoron2;
        private System.Windows.Forms.TextBox textboxModifyMinute;
        private System.Windows.Forms.Label labelModifyCoron1;
        private System.Windows.Forms.TextBox textboxModifyHour;
        private System.Windows.Forms.TextBox textboxModifyDay;
        private System.Windows.Forms.Label labelModifySlash2;
        private System.Windows.Forms.TextBox textboxModifyMonth;
        private System.Windows.Forms.Label labelModifySlash1;
        private System.Windows.Forms.TextBox textboxModifyYear;
        private System.Windows.Forms.CheckBox checkboxAccessTime;
        private System.Windows.Forms.TextBox textboxAccessSecond;
        private System.Windows.Forms.Label labelAccessCoron2;
        private System.Windows.Forms.TextBox textboxAccessMinute;
        private System.Windows.Forms.Label labelAccessCoron1;
        private System.Windows.Forms.TextBox textboxAccessHour;
        private System.Windows.Forms.TextBox textboxAccessDay;
        private System.Windows.Forms.Label labelAccessSlash2;
        private System.Windows.Forms.TextBox textboxAccessMonth;
        private System.Windows.Forms.Label labelAccessSlash1;
        private System.Windows.Forms.TextBox textboxAccessYear;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSaveChange;
    }
}

