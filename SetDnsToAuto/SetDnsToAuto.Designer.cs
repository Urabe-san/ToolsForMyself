namespace SetDnsToAuto
{
    partial class SetDnsToAuto
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
            this.labelWarning = new System.Windows.Forms.Label();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.comboboxTargetAdapter = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Location = new System.Drawing.Point(12, 15);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(101, 15);
            this.labelWarning.TabIndex = 0;
            this.labelWarning.Text = "Reset for DNS";
            // 
            // buttonExecute
            // 
            this.buttonExecute.Location = new System.Drawing.Point(281, 40);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(75, 23);
            this.buttonExecute.TabIndex = 2;
            this.buttonExecute.Text = "Execute";
            this.buttonExecute.UseVisualStyleBackColor = true;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // comboboxTargetAdapter
            // 
            this.comboboxTargetAdapter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxTargetAdapter.FormattingEnabled = true;
            this.comboboxTargetAdapter.Location = new System.Drawing.Point(119, 12);
            this.comboboxTargetAdapter.Name = "comboboxTargetAdapter";
            this.comboboxTargetAdapter.Size = new System.Drawing.Size(237, 23);
            this.comboboxTargetAdapter.TabIndex = 1;
            // 
            // SetDnsToAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 76);
            this.Controls.Add(this.buttonExecute);
            this.Controls.Add(this.comboboxTargetAdapter);
            this.Controls.Add(this.labelWarning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetDnsToAuto";
            this.Text = "DNS Reset";
            this.Load += new System.EventHandler(this.SetDnsToAuto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.ComboBox comboboxTargetAdapter;
    }
}

