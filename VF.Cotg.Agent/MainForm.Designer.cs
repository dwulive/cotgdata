namespace VF.Cotg.Agent
{
    partial class MainForm
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
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.webServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartWebServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopWebServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WebServerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.Text = "notifyIcon1";
            this.NotifyIcon.Visible = true;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(800, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.webServerToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WebServerStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 428);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(800, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // webServerToolStripMenuItem
            // 
            this.webServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartWebServerMenuItem,
            this.StopWebServerMenuItem});
            this.webServerToolStripMenuItem.Name = "webServerToolStripMenuItem";
            this.webServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.webServerToolStripMenuItem.Text = "Web Server";
            // 
            // StartWebServerMenuItem
            // 
            this.StartWebServerMenuItem.Name = "StartWebServerMenuItem";
            this.StartWebServerMenuItem.Size = new System.Drawing.Size(180, 22);
            this.StartWebServerMenuItem.Text = "Start";
            this.StartWebServerMenuItem.Click += new System.EventHandler(this.HandleStartWebServerMenuItemClick);
            // 
            // StopWebServerMenuItem
            // 
            this.StopWebServerMenuItem.Enabled = false;
            this.StopWebServerMenuItem.Name = "StopWebServerMenuItem";
            this.StopWebServerMenuItem.Size = new System.Drawing.Size(180, 22);
            this.StopWebServerMenuItem.Text = "Stop";
            this.StopWebServerMenuItem.Click += new System.EventHandler(this.HandleStopWebServerMenuItemClick);
            // 
            // WebServerStatusLabel
            // 
            this.WebServerStatusLabel.Name = "WebServerStatusLabel";
            this.WebServerStatusLabel.Size = new System.Drawing.Size(149, 17);
            this.WebServerStatusLabel.Text = "WebServer is NOT Running";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainForm";
            this.Text = "Crown of the Gods - Data Collection Agent";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartWebServerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StopWebServerMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel WebServerStatusLabel;
    }
}

