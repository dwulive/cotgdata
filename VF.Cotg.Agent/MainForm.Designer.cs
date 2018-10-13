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
            this.webServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartWebServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StopWebServerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.WebServerStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EffectiveDatePicker = new System.Windows.Forms.DateTimePicker();
            this.PlayerNameTextbox = new System.Windows.Forms.TextBox();
            this.ScoreTextBox = new System.Windows.Forms.TextBox();
            this.RankTextBox = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.RankingsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
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
            // webServerToolStripMenuItem
            // 
            this.webServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartWebServerMenuItem,
            this.StopWebServerMenuItem});
            this.webServerToolStripMenuItem.Name = "webServerToolStripMenuItem";
            this.webServerToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.webServerToolStripMenuItem.Text = "Web Server";
            // 
            // StartWebServerMenuItem
            // 
            this.StartWebServerMenuItem.Name = "StartWebServerMenuItem";
            this.StartWebServerMenuItem.Size = new System.Drawing.Size(98, 22);
            this.StartWebServerMenuItem.Text = "Start";
            this.StartWebServerMenuItem.Click += new System.EventHandler(this.HandleStartWebServerMenuItemClick);
            // 
            // StopWebServerMenuItem
            // 
            this.StopWebServerMenuItem.Enabled = false;
            this.StopWebServerMenuItem.Name = "StopWebServerMenuItem";
            this.StopWebServerMenuItem.Size = new System.Drawing.Size(98, 22);
            this.StopWebServerMenuItem.Text = "Stop";
            this.StopWebServerMenuItem.Click += new System.EventHandler(this.HandleStopWebServerMenuItemClick);
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
            // WebServerStatusLabel
            // 
            this.WebServerStatusLabel.Name = "WebServerStatusLabel";
            this.WebServerStatusLabel.Size = new System.Drawing.Size(149, 17);
            this.WebServerStatusLabel.Text = "WebServer is NOT Running";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Player Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Effective Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Score:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rank:";
            // 
            // EffectiveDatePicker
            // 
            this.EffectiveDatePicker.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.EffectiveDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EffectiveDatePicker.Location = new System.Drawing.Point(96, 42);
            this.EffectiveDatePicker.Name = "EffectiveDatePicker";
            this.EffectiveDatePicker.Size = new System.Drawing.Size(197, 20);
            this.EffectiveDatePicker.TabIndex = 6;
            // 
            // PlayerNameTextbox
            // 
            this.PlayerNameTextbox.Location = new System.Drawing.Point(96, 75);
            this.PlayerNameTextbox.Name = "PlayerNameTextbox";
            this.PlayerNameTextbox.Size = new System.Drawing.Size(135, 20);
            this.PlayerNameTextbox.TabIndex = 7;
            // 
            // ScoreTextBox
            // 
            this.ScoreTextBox.Location = new System.Drawing.Point(96, 103);
            this.ScoreTextBox.Name = "ScoreTextBox";
            this.ScoreTextBox.Size = new System.Drawing.Size(135, 20);
            this.ScoreTextBox.TabIndex = 8;
            // 
            // RankTextBox
            // 
            this.RankTextBox.Location = new System.Drawing.Point(96, 132);
            this.RankTextBox.Name = "RankTextBox";
            this.RankTextBox.Size = new System.Drawing.Size(135, 20);
            this.RankTextBox.TabIndex = 9;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(156, 158);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 10;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.HandleImportSingleRecordClick);
            // 
            // RankingsListView
            // 
            this.RankingsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.RankingsListView.Location = new System.Drawing.Point(315, 42);
            this.RankingsListView.Name = "RankingsListView";
            this.RankingsListView.Size = new System.Drawing.Size(445, 148);
            this.RankingsListView.TabIndex = 11;
            this.RankingsListView.UseCompatibleStateImageBehavior = false;
            this.RankingsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "EffectiveDate";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Score";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Rank";
            this.columnHeader4.Width = 120;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(685, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HandleRefreshRankingsClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RankingsListView);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.RankTextBox);
            this.Controls.Add(this.ScoreTextBox);
            this.Controls.Add(this.PlayerNameTextbox);
            this.Controls.Add(this.EffectiveDatePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker EffectiveDatePicker;
        private System.Windows.Forms.TextBox PlayerNameTextbox;
        private System.Windows.Forms.TextBox ScoreTextBox;
        private System.Windows.Forms.TextBox RankTextBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.ListView RankingsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button1;
    }
}

