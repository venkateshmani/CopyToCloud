namespace C2CWindowsDesktopClient
{
    partial class Notifier
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notifier));
            this.c2cNotifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifierContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.copiedText = new System.Windows.Forms.Label();
            this.clipboardMonitor = new C2CWindowsDesktopClient.ClipboardMonitor();
            this.notifierContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2cNotifier
            // 
            this.c2cNotifier.ContextMenuStrip = this.notifierContextMenu;
            this.c2cNotifier.Icon = ((System.Drawing.Icon)(resources.GetObject("c2cNotifier.Icon")));
            this.c2cNotifier.Text = "Copy To Cloud";
            this.c2cNotifier.Visible = true;
            this.c2cNotifier.Click += new System.EventHandler(this.c2cNotifier_Click);
            this.c2cNotifier.DoubleClick += new System.EventHandler(this.c2cNotifier_DoubleClick);
            // 
            // notifierContextMenu
            // 
            this.notifierContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.testToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.notifierContextMenu.Name = "notifierContextMenu";
            this.notifierContextMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.testToolStripMenuItem.Text = "Exit";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.CheckOnClick = true;
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clipboard Text";
            // 
            // copiedText
            // 
            this.copiedText.AutoSize = true;
            this.copiedText.Location = new System.Drawing.Point(34, 131);
            this.copiedText.Name = "copiedText";
            this.copiedText.Size = new System.Drawing.Size(35, 13);
            this.copiedText.TabIndex = 2;
            this.copiedText.Text = "label2";
            // 
            // clipboardMonitor
            // 
            this.clipboardMonitor.BackColor = System.Drawing.Color.Red;
            this.clipboardMonitor.Location = new System.Drawing.Point(25, 300);
            this.clipboardMonitor.Name = "clipboardMonitor";
            this.clipboardMonitor.Size = new System.Drawing.Size(84, 25);
            this.clipboardMonitor.TabIndex = 3;
            this.clipboardMonitor.Text = "clipboardMonitor1";
            this.clipboardMonitor.Visible = false;
            // 
            // Notifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 347);
            this.Controls.Add(this.clipboardMonitor);
            this.Controls.Add(this.copiedText);
            this.Controls.Add(this.label1);
            this.Name = "Notifier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Notifier_FormClosed);
            this.notifierContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon c2cNotifier;
        private System.Windows.Forms.ContextMenuStrip notifierContextMenu;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label copiedText;
        private ClipboardMonitor clipboardMonitor;
    }
}

