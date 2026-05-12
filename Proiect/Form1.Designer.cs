namespace Proiect
{
    partial class Form1
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
            TreeNode treeNode1 = new TreeNode("Library");
            TreeNode treeNode2 = new TreeNode("Playlists");
            TreeNode treeNode3 = new TreeNode("Settings&Storage");
            panelPlayback = new Panel();
            lblMaxVol = new Label();
            lblMinVol = new Label();
            trackBarVolume = new TrackBar();
            btnMute = new Button();
            btnPause = new Button();
            btnNext = new Button();
            btnPlay = new Button();
            btnPrev = new Button();
            lblTotalTime = new Label();
            lblCurrentTime = new Label();
            trackBarSeek = new TrackBar();
            panelNav = new Panel();
            treeViewNavigation = new TreeView();
            panelQueue = new Panel();
            panelCentral = new Panel();
            tabLibrary = new TabControl();
            tabPage1 = new TabPage();
            tabPlaylists = new TabPage();
            tabSettingsStorage = new TabPage();
            panelPlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            panelNav.SuspendLayout();
            panelCentral.SuspendLayout();
            tabLibrary.SuspendLayout();
            SuspendLayout();
            // 
            // panelPlayback
            // 
            panelPlayback.BackColor = Color.LightSlateGray;
            panelPlayback.Controls.Add(lblMaxVol);
            panelPlayback.Controls.Add(lblMinVol);
            panelPlayback.Controls.Add(trackBarVolume);
            panelPlayback.Controls.Add(btnMute);
            panelPlayback.Controls.Add(btnPause);
            panelPlayback.Controls.Add(btnNext);
            panelPlayback.Controls.Add(btnPlay);
            panelPlayback.Controls.Add(btnPrev);
            panelPlayback.Controls.Add(lblTotalTime);
            panelPlayback.Controls.Add(lblCurrentTime);
            panelPlayback.Controls.Add(trackBarSeek);
            panelPlayback.Dock = DockStyle.Bottom;
            panelPlayback.Location = new Point(0, 700);
            panelPlayback.Margin = new Padding(3, 4, 3, 4);
            panelPlayback.Name = "panelPlayback";
            panelPlayback.Size = new Size(1781, 186);
            panelPlayback.TabIndex = 0;
            // 
            // lblMaxVol
            // 
            lblMaxVol.AutoSize = true;
            lblMaxVol.Location = new Point(1426, 154);
            lblMaxVol.Name = "lblMaxVol";
            lblMaxVol.Size = new Size(33, 20);
            lblMaxVol.TabIndex = 10;
            lblMaxVol.Text = "100";
            // 
            // lblMinVol
            // 
            lblMinVol.AutoSize = true;
            lblMinVol.Location = new Point(1246, 154);
            lblMinVol.Name = "lblMinVol";
            lblMinVol.Size = new Size(17, 20);
            lblMinVol.TabIndex = 9;
            lblMinVol.Text = "0";
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(1249, 104);
            trackBarVolume.Margin = new Padding(3, 4, 3, 4);
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(205, 56);
            trackBarVolume.TabIndex = 8;
            // 
            // btnMute
            // 
            btnMute.Location = new Point(1278, 11);
            btnMute.Margin = new Padding(3, 4, 3, 4);
            btnMute.Name = "btnMute";
            btnMute.Size = new Size(123, 59);
            btnMute.TabIndex = 7;
            btnMute.Text = "Mute";
            btnMute.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(1008, 89);
            btnPause.Margin = new Padding(3, 4, 3, 4);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(135, 45);
            btnPause.TabIndex = 6;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(841, 89);
            btnNext.Margin = new Padding(3, 4, 3, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(116, 45);
            btnNext.TabIndex = 5;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(600, 89);
            btnPlay.Margin = new Padding(3, 4, 3, 4);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(205, 45);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            btnPlay.Click += btnPlay_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(451, 89);
            btnPrev.Margin = new Padding(3, 4, 3, 4);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(115, 45);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "<<";
            btnPrev.UseVisualStyleBackColor = true;
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(1081, 50);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(44, 20);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "00:00";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(375, 50);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(44, 20);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.Text = "00:00";
            // 
            // trackBarSeek
            // 
            trackBarSeek.Location = new Point(378, 11);
            trackBarSeek.Margin = new Padding(3, 4, 3, 4);
            trackBarSeek.Name = "trackBarSeek";
            trackBarSeek.Size = new Size(741, 56);
            trackBarSeek.TabIndex = 0;
            trackBarSeek.Value = 1;
            // 
            // panelNav
            // 
            panelNav.BackColor = SystemColors.ControlDark;
            panelNav.Controls.Add(treeViewNavigation);
            panelNav.Dock = DockStyle.Left;
            panelNav.Location = new Point(0, 0);
            panelNav.Margin = new Padding(3, 4, 3, 4);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(243, 700);
            panelNav.TabIndex = 1;
            // 
            // treeViewNavigation
            // 
            treeViewNavigation.BackColor = SystemColors.ScrollBar;
            treeViewNavigation.Dock = DockStyle.Right;
            treeViewNavigation.Font = new Font("Segoe Script", 11F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            treeViewNavigation.ForeColor = Color.MidnightBlue;
            treeViewNavigation.FullRowSelect = true;
            treeViewNavigation.Indent = 19;
            treeViewNavigation.ItemHeight = 50;
            treeViewNavigation.Location = new Point(30, 0);
            treeViewNavigation.Margin = new Padding(3, 4, 3, 4);
            treeViewNavigation.Name = "treeViewNavigation";
            treeNode1.Name = "NodeLibrary";
            treeNode1.Text = "Library";
            treeNode2.Name = "NodePlaylists";
            treeNode2.Text = "Playlists";
            treeNode3.Name = "NodeSettingsStorage";
            treeNode3.Text = "Settings&Storage";
            treeViewNavigation.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode2, treeNode3 });
            treeViewNavigation.Size = new Size(213, 700);
            treeViewNavigation.TabIndex = 0;
            // 
            // panelQueue
            // 
            panelQueue.BackColor = SystemColors.ControlDark;
            panelQueue.Dock = DockStyle.Fill;
            panelQueue.Location = new Point(243, 0);
            panelQueue.Margin = new Padding(3, 4, 3, 4);
            panelQueue.Name = "panelQueue";
            panelQueue.Size = new Size(1538, 700);
            panelQueue.TabIndex = 2;
            // 
            // panelCentral
            // 
            panelCentral.BackColor = SystemColors.ActiveCaption;
            panelCentral.Controls.Add(tabLibrary);
            panelCentral.Dock = DockStyle.Left;
            panelCentral.Location = new Point(243, 0);
            panelCentral.Margin = new Padding(3, 4, 3, 4);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(1017, 700);
            panelCentral.TabIndex = 3;
            // 
            // tabLibrary
            // 
            tabLibrary.Controls.Add(tabPage1);
            tabLibrary.Controls.Add(tabPlaylists);
            tabLibrary.Controls.Add(tabSettingsStorage);
            tabLibrary.Dock = DockStyle.Right;
            tabLibrary.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            tabLibrary.Location = new Point(19, 0);
            tabLibrary.Margin = new Padding(3, 4, 3, 4);
            tabLibrary.Name = "tabLibrary";
            tabLibrary.SelectedIndex = 0;
            tabLibrary.Size = new Size(998, 700);
            tabLibrary.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 37);
            tabPage1.Margin = new Padding(3, 4, 3, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3, 4, 3, 4);
            tabPage1.Size = new Size(990, 659);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Library";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPlaylists
            // 
            tabPlaylists.Location = new Point(4, 37);
            tabPlaylists.Margin = new Padding(3, 4, 3, 4);
            tabPlaylists.Name = "tabPlaylists";
            tabPlaylists.Padding = new Padding(3, 4, 3, 4);
            tabPlaylists.Size = new Size(990, 659);
            tabPlaylists.TabIndex = 1;
            tabPlaylists.Text = "Playlists";
            tabPlaylists.UseVisualStyleBackColor = true;
            // 
            // tabSettingsStorage
            // 
            tabSettingsStorage.Location = new Point(4, 37);
            tabSettingsStorage.Margin = new Padding(3, 4, 3, 4);
            tabSettingsStorage.Name = "tabSettingsStorage";
            tabSettingsStorage.Padding = new Padding(3, 4, 3, 4);
            tabSettingsStorage.Size = new Size(990, 659);
            tabSettingsStorage.TabIndex = 2;
            tabSettingsStorage.Text = "Settings&Storage";
            tabSettingsStorage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1781, 886);
            Controls.Add(panelCentral);
            Controls.Add(panelQueue);
            Controls.Add(panelNav);
            Controls.Add(panelPlayback);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            panelPlayback.ResumeLayout(false);
            panelPlayback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            panelNav.ResumeLayout(false);
            panelCentral.ResumeLayout(false);
            tabLibrary.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPlayback;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Button btnMute;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.TrackBar trackBarSeek;
        private System.Windows.Forms.Label lblMaxVol;
        private System.Windows.Forms.Label lblMinVol;
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.TreeView treeViewNavigation;
        private System.Windows.Forms.Panel panelQueue;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.TabControl tabLibrary;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPlaylists;
        private System.Windows.Forms.TabPage tabSettingsStorage;
    }
}
