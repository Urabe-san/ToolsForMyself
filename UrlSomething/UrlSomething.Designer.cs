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
            this.textboxOrigin = new System.Windows.Forms.TextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.textboxResult = new System.Windows.Forms.TextBox();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textboxOrigin
            // 
            this.textboxOrigin.Location = new System.Drawing.Point(12, 12);
            this.textboxOrigin.Multiline = true;
            this.textboxOrigin.Name = "textboxOrigin";
            this.textboxOrigin.Size = new System.Drawing.Size(469, 68);
            this.textboxOrigin.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(487, 12);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(52, 23);
            this.buttonClear.TabIndex = 2;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(406, 86);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(75, 23);
            this.buttonDecode.TabIndex = 3;
            this.buttonDecode.Text = "DECODE";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // textboxResult
            // 
            this.textboxResult.Location = new System.Drawing.Point(12, 115);
            this.textboxResult.Multiline = true;
            this.textboxResult.Name = "textboxResult";
            this.textboxResult.Size = new System.Drawing.Size(469, 68);
            this.textboxResult.TabIndex = 4;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(406, 189);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 0;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // UrlSomething
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 221);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.textboxResult);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textboxOrigin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UrlSomething";
            this.ShowIcon = false;
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
    }
}

