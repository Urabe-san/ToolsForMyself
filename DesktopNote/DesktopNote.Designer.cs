namespace DesktopNote
{
    partial class DesktopNote
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopNote));
            this.textboxNote = new System.Windows.Forms.TextBox();
            this.notifyIconDesktopNote = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextmenustripTaskTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextmenustripTaskTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // textboxNote
            // 
            this.textboxNote.Location = new System.Drawing.Point(0, 0);
            this.textboxNote.Multiline = true;
            this.textboxNote.Name = "textboxNote";
            this.textboxNote.Size = new System.Drawing.Size(298, 193);
            this.textboxNote.TabIndex = 0;
            // 
            // notifyIconDesktopNote
            // 
            this.notifyIconDesktopNote.ContextMenuStrip = this.contextmenustripTaskTray;
            this.notifyIconDesktopNote.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconDesktopNote.Icon")));
            this.notifyIconDesktopNote.Text = "notifyIconDesktopNote";
            this.notifyIconDesktopNote.Visible = true;
            // 
            // contextmenustripTaskTray
            // 
            this.contextmenustripTaskTray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextmenustripTaskTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextmenustripTaskTray.Name = "contextmenustripTaskTray";
            this.contextmenustripTaskTray.Size = new System.Drawing.Size(112, 76);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // DesktopNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 193);
            this.ControlBox = false;
            this.Controls.Add(this.textboxNote);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DesktopNote";
            this.ShowInTaskbar = false;
            this.Text = "Desktop Note";
            this.Load += new System.EventHandler(this.DesktopNote_Load);
            this.Resize += new System.EventHandler(this.DesktopNote_Resize);
            this.contextmenustripTaskTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxNote;
        private System.Windows.Forms.NotifyIcon notifyIconDesktopNote;
        private System.Windows.Forms.ContextMenuStrip contextmenustripTaskTray;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

