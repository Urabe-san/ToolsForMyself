namespace DesktopNote
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFormWidth = new System.Windows.Forms.Label();
            this.textboxFormWidth = new System.Windows.Forms.TextBox();
            this.labelFormHeight = new System.Windows.Forms.Label();
            this.textboxFormHeight = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelPixel1 = new System.Windows.Forms.Label();
            this.labelPixel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFormWidth
            // 
            this.labelFormWidth.AutoSize = true;
            this.labelFormWidth.Location = new System.Drawing.Point(12, 9);
            this.labelFormWidth.Name = "labelFormWidth";
            this.labelFormWidth.Size = new System.Drawing.Size(75, 12);
            this.labelFormWidth.TabIndex = 0;
            this.labelFormWidth.Text = "Window Width";
            // 
            // textboxFormWidth
            // 
            this.textboxFormWidth.Location = new System.Drawing.Point(98, 6);
            this.textboxFormWidth.MaxLength = 4;
            this.textboxFormWidth.Name = "textboxFormWidth";
            this.textboxFormWidth.Size = new System.Drawing.Size(46, 19);
            this.textboxFormWidth.TabIndex = 1;
            this.textboxFormWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelFormHeight
            // 
            this.labelFormHeight.AutoSize = true;
            this.labelFormHeight.Location = new System.Drawing.Point(12, 34);
            this.labelFormHeight.Name = "labelFormHeight";
            this.labelFormHeight.Size = new System.Drawing.Size(80, 12);
            this.labelFormHeight.TabIndex = 2;
            this.labelFormHeight.Text = "Window Height";
            // 
            // textboxFormHeight
            // 
            this.textboxFormHeight.Location = new System.Drawing.Point(98, 31);
            this.textboxFormHeight.MaxLength = 4;
            this.textboxFormHeight.Name = "textboxFormHeight";
            this.textboxFormHeight.Size = new System.Drawing.Size(46, 19);
            this.textboxFormHeight.TabIndex = 3;
            this.textboxFormHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(96, 65);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(48, 23);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(150, 65);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(48, 23);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(32, 94);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(112, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "Clear Registory";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(150, 94);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(48, 23);
            this.buttonQuit.TabIndex = 7;
            this.buttonQuit.Text = "QUIT";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelPixel1
            // 
            this.labelPixel1.AutoSize = true;
            this.labelPixel1.Location = new System.Drawing.Point(150, 9);
            this.labelPixel1.Name = "labelPixel1";
            this.labelPixel1.Size = new System.Drawing.Size(29, 12);
            this.labelPixel1.TabIndex = 8;
            this.labelPixel1.Text = "pixel";
            // 
            // labelPixel2
            // 
            this.labelPixel2.AutoSize = true;
            this.labelPixel2.Location = new System.Drawing.Point(150, 34);
            this.labelPixel2.Name = "labelPixel2";
            this.labelPixel2.Size = new System.Drawing.Size(29, 12);
            this.labelPixel2.TabIndex = 9;
            this.labelPixel2.Text = "pixel";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 129);
            this.ControlBox = false;
            this.Controls.Add(this.labelPixel2);
            this.Controls.Add(this.labelPixel1);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textboxFormHeight);
            this.Controls.Add(this.labelFormHeight);
            this.Controls.Add(this.textboxFormWidth);
            this.Controls.Add(this.labelFormWidth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFormWidth;
        private System.Windows.Forms.TextBox textboxFormWidth;
        private System.Windows.Forms.Label labelFormHeight;
        private System.Windows.Forms.TextBox textboxFormHeight;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelPixel1;
        private System.Windows.Forms.Label labelPixel2;
    }
}