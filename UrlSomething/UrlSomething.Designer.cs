namespace UrlSomething
{
    partial class UrlSomething
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UrlSomething));
            this.textboxOrigin = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.textboxResult = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonPaste = new System.Windows.Forms.Button();
            this.buttonPastePlus = new System.Windows.Forms.Button();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxOrigin
            // 
            this.textboxOrigin.Location = new System.Drawing.Point(16, 15);
            this.textboxOrigin.Margin = new System.Windows.Forms.Padding(4);
            this.textboxOrigin.Multiline = true;
            this.textboxOrigin.Name = "textboxOrigin";
            this.textboxOrigin.Size = new System.Drawing.Size(624, 84);
            this.textboxOrigin.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(649, 15);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(69, 29);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(541, 108);
            this.buttonDecode.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(100, 29);
            this.buttonDecode.TabIndex = 5;
            this.buttonDecode.Text = "DECODE";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // textboxResult
            // 
            this.textboxResult.Location = new System.Drawing.Point(16, 144);
            this.textboxResult.Margin = new System.Windows.Forms.Padding(4);
            this.textboxResult.Multiline = true;
            this.textboxResult.Name = "textboxResult";
            this.textboxResult.Size = new System.Drawing.Size(624, 84);
            this.textboxResult.TabIndex = 6;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(541, 236);
            this.buttonQuit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(100, 29);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // buttonPaste
            // 
            this.buttonPaste.Location = new System.Drawing.Point(649, 51);
            this.buttonPaste.Name = "buttonPaste";
            this.buttonPaste.Size = new System.Drawing.Size(24, 24);
            this.buttonPaste.TabIndex = 3;
            this.buttonPaste.Text = "P";
            this.buttonPaste.UseVisualStyleBackColor = true;
            this.buttonPaste.Click += new System.EventHandler(this.buttonPaste_Click);
            // 
            // buttonPastePlus
            // 
            this.buttonPastePlus.Location = new System.Drawing.Point(679, 51);
            this.buttonPastePlus.Name = "buttonPastePlus";
            this.buttonPastePlus.Size = new System.Drawing.Size(39, 24);
            this.buttonPastePlus.TabIndex = 4;
            this.buttonPastePlus.Text = "P+";
            this.buttonPastePlus.UseVisualStyleBackColor = true;
            this.buttonPastePlus.Click += new System.EventHandler(this.buttonPastePlus_Click);
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(649, 144);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(24, 24);
            this.buttonCopyToClipboard.TabIndex = 7;
            this.buttonCopyToClipboard.Text = "C";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // UrlSomething
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 276);
            this.Controls.Add(this.buttonCopyToClipboard);
            this.Controls.Add(this.buttonPastePlus);
            this.Controls.Add(this.buttonPaste);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.textboxResult);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textboxOrigin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlSomething";
            this.Text = "UrlSomething";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UrlSomething_FormClosing);
            this.Load += new System.EventHandler(this.UrlSomething_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxOrigin;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.TextBox textboxResult;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonPaste;
        private System.Windows.Forms.Button buttonPastePlus;
        private System.Windows.Forms.Button buttonCopyToClipboard;
    }
}

