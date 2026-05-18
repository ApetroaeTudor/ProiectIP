namespace Proiect_Ip
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
            components = new System.ComponentModel.Container();
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
            radioButtonStorage = new RadioButton();
            radioButtonPlaylists = new RadioButton();
            radioButtonLibrary = new RadioButton();
            panelQueue = new Panel();
            dataGridViewQueue = new DataGridView();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            contextMenuStripLibrary = new ContextMenuStrip(components);
            toolStripMenuItemPlay = new ToolStripMenuItem();
            toolStripMenuItemAddToQueue = new ToolStripMenuItem();
            toolStripMenuItemPlayNext = new ToolStripMenuItem();
            toolStripMenuItemAddToPlaylist = new ToolStripMenuItem();
            toolStripMenuItemRemoveFromLibrary = new ToolStripMenuItem();
            buttonClearQueue = new Button();
            btnRemoveQueue = new Button();
            labelQueue = new Label();
            panelCentral = new Panel();
            TabControl = new TabControl();
            tabPageLibrary = new TabPage();
            dataGridViewLibrary = new DataGridView();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnArtist = new DataGridViewTextBoxColumn();
            ColumnDuration = new DataGridViewTextBoxColumn();
            textBoxSearchBar = new TextBox();
            lblSearchBar = new Label();
            btnAddFolder = new Button();
            btnAddFile = new Button();
            tabPlaylists = new TabPage();
            splitContainer1 = new SplitContainer();
            lblPlaylists = new Label();
            buttonDeletePlaylist = new Button();
            buttonRenamePlaylist = new Button();
            buttonNewPlaylist = new Button();
            listBoxPlaylists = new ListBox();
            dataGridViewPlaylist = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            buttonDeleteSongFromPlaylist = new Button();
            buttonMoveDown = new Button();
            buttonMoveUp = new Button();
            labelPlaylistSongs = new Label();
            tabSettingsStorage = new TabPage();
            labelStocare = new Label();
            progressBarStorage = new ProgressBar();
            labelSettingsStorage = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            panelPlayback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            panelNav.SuspendLayout();
            panelQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).BeginInit();
            contextMenuStripLibrary.SuspendLayout();
            panelCentral.SuspendLayout();
            TabControl.SuspendLayout();
            tabPageLibrary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibrary).BeginInit();
            tabPlaylists.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlaylist).BeginInit();
            tabSettingsStorage.SuspendLayout();
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
            panelPlayback.Location = new Point(0, 520);
            panelPlayback.Margin = new Padding(2);
            panelPlayback.Name = "panelPlayback";
            panelPlayback.Size = new Size(1460, 140);
            panelPlayback.TabIndex = 0;
            // 
            // lblMaxVol
            // 
            lblMaxVol.AutoSize = true;
            lblMaxVol.Location = new Point(1248, 115);
            lblMaxVol.Margin = new Padding(2, 0, 2, 0);
            lblMaxVol.Name = "lblMaxVol";
            lblMaxVol.Size = new Size(25, 15);
            lblMaxVol.TabIndex = 10;
            lblMaxVol.Text = "100";
            // 
            // lblMinVol
            // 
            lblMinVol.AutoSize = true;
            lblMinVol.Location = new Point(1090, 115);
            lblMinVol.Margin = new Padding(2, 0, 2, 0);
            lblMinVol.Name = "lblMinVol";
            lblMinVol.Size = new Size(13, 15);
            lblMinVol.TabIndex = 9;
            lblMinVol.Text = "0";
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(1093, 77);
            trackBarVolume.Margin = new Padding(2);
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(180, 45);
            trackBarVolume.TabIndex = 8;
            // 
            // btnMute
            // 
            btnMute.Location = new Point(1118, 8);
            btnMute.Margin = new Padding(2);
            btnMute.Name = "btnMute";
            btnMute.Size = new Size(107, 44);
            btnMute.TabIndex = 7;
            btnMute.Text = "Mute";
            btnMute.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(882, 67);
            btnPause.Margin = new Padding(2);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(118, 33);
            btnPause.TabIndex = 6;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(736, 67);
            btnNext.Margin = new Padding(2);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(102, 33);
            btnNext.TabIndex = 5;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(525, 67);
            btnPlay.Margin = new Padding(2);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(180, 33);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(394, 67);
            btnPrev.Margin = new Padding(2);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(100, 33);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "<<";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(946, 37);
            lblTotalTime.Margin = new Padding(2, 0, 2, 0);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(34, 15);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "00:00";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(328, 37);
            lblCurrentTime.Margin = new Padding(2, 0, 2, 0);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(34, 15);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.Text = "00:00";
            // 
            // trackBarSeek
            // 
            trackBarSeek.Location = new Point(331, 8);
            trackBarSeek.Margin = new Padding(2);
            trackBarSeek.Name = "trackBarSeek";
            trackBarSeek.Size = new Size(649, 45);
            trackBarSeek.TabIndex = 0;
            trackBarSeek.Value = 1;
            // 
            // panelNav
            // 
            panelNav.BackColor = SystemColors.ControlDark;
            panelNav.Controls.Add(radioButtonStorage);
            panelNav.Controls.Add(radioButtonPlaylists);
            panelNav.Controls.Add(radioButtonLibrary);
            panelNav.Dock = DockStyle.Left;
            panelNav.Location = new Point(0, 0);
            panelNav.Margin = new Padding(2);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(212, 520);
            panelNav.TabIndex = 1;
            // 
            // radioButtonStorage
            // 
            radioButtonStorage.AutoSize = true;
            radioButtonStorage.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonStorage.ForeColor = Color.Navy;
            radioButtonStorage.Location = new Point(24, 152);
            radioButtonStorage.Margin = new Padding(4, 3, 4, 3);
            radioButtonStorage.Name = "radioButtonStorage";
            radioButtonStorage.Size = new Size(98, 26);
            radioButtonStorage.TabIndex = 9;
            radioButtonStorage.TabStop = true;
            radioButtonStorage.Text = "Storage";
            radioButtonStorage.UseVisualStyleBackColor = true;
            radioButtonStorage.CheckedChanged += radioButtonStorage_CheckedChanged;
            // 
            // radioButtonPlaylists
            // 
            radioButtonPlaylists.AutoSize = true;
            radioButtonPlaylists.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonPlaylists.ForeColor = Color.Navy;
            radioButtonPlaylists.Location = new Point(24, 107);
            radioButtonPlaylists.Margin = new Padding(4, 3, 4, 3);
            radioButtonPlaylists.Name = "radioButtonPlaylists";
            radioButtonPlaylists.Size = new Size(103, 26);
            radioButtonPlaylists.TabIndex = 8;
            radioButtonPlaylists.TabStop = true;
            radioButtonPlaylists.Text = "Playlists";
            radioButtonPlaylists.UseVisualStyleBackColor = true;
            radioButtonPlaylists.CheckedChanged += radioButtonPlaylists_CheckedChanged;
            // 
            // radioButtonLibrary
            // 
            radioButtonLibrary.AutoSize = true;
            radioButtonLibrary.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonLibrary.ForeColor = Color.Navy;
            radioButtonLibrary.Location = new Point(24, 59);
            radioButtonLibrary.Margin = new Padding(4, 3, 4, 3);
            radioButtonLibrary.Name = "radioButtonLibrary";
            radioButtonLibrary.Size = new Size(90, 26);
            radioButtonLibrary.TabIndex = 7;
            radioButtonLibrary.TabStop = true;
            radioButtonLibrary.Text = "Library";
            radioButtonLibrary.UseVisualStyleBackColor = true;
            radioButtonLibrary.CheckedChanged += radioButtonLibrary_CheckedChanged;
            // 
            // panelQueue
            // 
            panelQueue.BackColor = SystemColors.ControlDark;
            panelQueue.Controls.Add(dataGridViewQueue);
            panelQueue.Controls.Add(buttonClearQueue);
            panelQueue.Controls.Add(btnRemoveQueue);
            panelQueue.Controls.Add(labelQueue);
            panelQueue.Dock = DockStyle.Fill;
            panelQueue.Location = new Point(212, 0);
            panelQueue.Margin = new Padding(2);
            panelQueue.Name = "panelQueue";
            panelQueue.Size = new Size(1248, 520);
            panelQueue.TabIndex = 2;
            // 
            // dataGridViewQueue
            // 
            dataGridViewQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQueue.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridViewQueue.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewQueue.Location = new Point(891, 77);
            dataGridViewQueue.Margin = new Padding(4, 3, 4, 3);
            dataGridViewQueue.Name = "dataGridViewQueue";
            dataGridViewQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQueue.Size = new Size(352, 348);
            dataGridViewQueue.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Title";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Artist";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Duration";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // contextMenuStripLibrary
            // 
            contextMenuStripLibrary.Items.AddRange(new ToolStripItem[] { toolStripMenuItemPlay, toolStripMenuItemAddToQueue, toolStripMenuItemPlayNext, toolStripMenuItemAddToPlaylist, toolStripMenuItemRemoveFromLibrary });
            contextMenuStripLibrary.Name = "contextMenuStripLibrary";
            contextMenuStripLibrary.Size = new Size(199, 114);
            // 
            // toolStripMenuItemPlay
            // 
            toolStripMenuItemPlay.Name = "toolStripMenuItemPlay";
            toolStripMenuItemPlay.Size = new Size(198, 22);
            toolStripMenuItemPlay.Text = "->Play";
            toolStripMenuItemPlay.Click += toolStripMenuItemPlay_Click;
            // 
            // toolStripMenuItemAddToQueue
            // 
            toolStripMenuItemAddToQueue.Name = "toolStripMenuItemAddToQueue";
            toolStripMenuItemAddToQueue.Size = new Size(198, 22);
            toolStripMenuItemAddToQueue.Text = "->Add to Queue";
            toolStripMenuItemAddToQueue.Click += toolStripMenuItemAddToQueue_Click;
            // 
            // toolStripMenuItemPlayNext
            // 
            toolStripMenuItemPlayNext.Name = "toolStripMenuItemPlayNext";
            toolStripMenuItemPlayNext.Size = new Size(198, 22);
            toolStripMenuItemPlayNext.Text = "->PlayNext";
            toolStripMenuItemPlayNext.Click += toolStripMenuItemPlayNext_Click;
            // 
            // toolStripMenuItemAddToPlaylist
            // 
            toolStripMenuItemAddToPlaylist.Name = "toolStripMenuItemAddToPlaylist";
            toolStripMenuItemAddToPlaylist.Size = new Size(198, 22);
            toolStripMenuItemAddToPlaylist.Text = "->Add to Playlist";
            toolStripMenuItemAddToPlaylist.Click += toolStripMenuItemAddToPlaylist_Click;
            // 
            // toolStripMenuItemRemoveFromLibrary
            // 
            toolStripMenuItemRemoveFromLibrary.Name = "toolStripMenuItemRemoveFromLibrary";
            toolStripMenuItemRemoveFromLibrary.Size = new Size(198, 22);
            toolStripMenuItemRemoveFromLibrary.Text = "->Remove from Library";
            toolStripMenuItemRemoveFromLibrary.Click += toolStripMenuItemRemoveFromPlaylist_Click;
            // 
            // buttonClearQueue
            // 
            buttonClearQueue.Location = new Point(896, 443);
            buttonClearQueue.Margin = new Padding(4, 3, 4, 3);
            buttonClearQueue.Name = "buttonClearQueue";
            buttonClearQueue.Size = new Size(112, 50);
            buttonClearQueue.TabIndex = 3;
            buttonClearQueue.Text = "Clear";
            buttonClearQueue.UseVisualStyleBackColor = true;
            buttonClearQueue.Click += buttonClearQueue_Click;
            // 
            // btnRemoveQueue
            // 
            btnRemoveQueue.Location = new Point(1040, 443);
            btnRemoveQueue.Margin = new Padding(4, 3, 4, 3);
            btnRemoveQueue.Name = "btnRemoveQueue";
            btnRemoveQueue.Size = new Size(112, 50);
            btnRemoveQueue.TabIndex = 2;
            btnRemoveQueue.Text = "Remove";
            btnRemoveQueue.UseVisualStyleBackColor = true;
            btnRemoveQueue.Click += btnRemoveQueue_Click;
            // 
            // labelQueue
            // 
            labelQueue.AutoSize = true;
            labelQueue.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelQueue.ForeColor = Color.Navy;
            labelQueue.Location = new Point(945, 21);
            labelQueue.Margin = new Padding(4, 0, 4, 0);
            labelQueue.Name = "labelQueue";
            labelQueue.Size = new Size(62, 20);
            labelQueue.TabIndex = 0;
            labelQueue.Text = "Queue";
            // 
            // panelCentral
            // 
            panelCentral.BackColor = SystemColors.ActiveCaption;
            panelCentral.Controls.Add(TabControl);
            panelCentral.Dock = DockStyle.Left;
            panelCentral.Location = new Point(212, 0);
            panelCentral.Margin = new Padding(2);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(890, 520);
            panelCentral.TabIndex = 3;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabPageLibrary);
            TabControl.Controls.Add(tabPlaylists);
            TabControl.Controls.Add(tabSettingsStorage);
            TabControl.Dock = DockStyle.Right;
            TabControl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            TabControl.ItemSize = new Size(20, 20);
            TabControl.Location = new Point(17, 0);
            TabControl.Margin = new Padding(2);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(873, 520);
            TabControl.SizeMode = TabSizeMode.Fixed;
            TabControl.TabIndex = 0;
            // 
            // tabPageLibrary
            // 
            tabPageLibrary.Controls.Add(dataGridViewLibrary);
            tabPageLibrary.Controls.Add(textBoxSearchBar);
            tabPageLibrary.Controls.Add(lblSearchBar);
            tabPageLibrary.Controls.Add(btnAddFolder);
            tabPageLibrary.Controls.Add(btnAddFile);
            tabPageLibrary.Location = new Point(4, 24);
            tabPageLibrary.Margin = new Padding(2);
            tabPageLibrary.Name = "tabPageLibrary";
            tabPageLibrary.Padding = new Padding(2);
            tabPageLibrary.Size = new Size(865, 492);
            tabPageLibrary.TabIndex = 0;
            tabPageLibrary.Text = "Library";
            tabPageLibrary.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLibrary
            // 
            dataGridViewLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibrary.Columns.AddRange(new DataGridViewColumn[] { ColumnTitle, ColumnArtist, ColumnDuration });
            dataGridViewLibrary.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewLibrary.Location = new Point(22, 125);
            dataGridViewLibrary.Margin = new Padding(4, 3, 4, 3);
            dataGridViewLibrary.Name = "dataGridViewLibrary";
            dataGridViewLibrary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLibrary.Size = new Size(341, 362);
            dataGridViewLibrary.TabIndex = 6;
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "Title";
            ColumnTitle.Name = "ColumnTitle";
            // 
            // ColumnArtist
            // 
            ColumnArtist.HeaderText = "Artist";
            ColumnArtist.Name = "ColumnArtist";
            // 
            // ColumnDuration
            // 
            ColumnDuration.HeaderText = "Duration";
            ColumnDuration.Name = "ColumnDuration";
            // 
            // textBoxSearchBar
            // 
            textBoxSearchBar.Location = new Point(447, 44);
            textBoxSearchBar.Margin = new Padding(4, 3, 4, 3);
            textBoxSearchBar.Name = "textBoxSearchBar";
            textBoxSearchBar.Size = new Size(187, 26);
            textBoxSearchBar.TabIndex = 5;
            // 
            // lblSearchBar
            // 
            lblSearchBar.AutoSize = true;
            lblSearchBar.Location = new Point(346, 51);
            lblSearchBar.Margin = new Padding(4, 0, 4, 0);
            lblSearchBar.Name = "lblSearchBar";
            lblSearchBar.Size = new Size(66, 20);
            lblSearchBar.TabIndex = 4;
            lblSearchBar.Text = "Search";
            lblSearchBar.Click += lblSearchBar_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Location = new Point(173, 38);
            btnAddFolder.Margin = new Padding(4, 3, 4, 3);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(99, 37);
            btnAddFolder.TabIndex = 1;
            btnAddFolder.Text = "+Folder";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(22, 38);
            btnAddFile.Margin = new Padding(4, 3, 4, 3);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(111, 37);
            btnAddFile.TabIndex = 0;
            btnAddFile.Text = "+File";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // tabPlaylists
            // 
            tabPlaylists.Controls.Add(splitContainer1);
            tabPlaylists.Location = new Point(4, 24);
            tabPlaylists.Margin = new Padding(2);
            tabPlaylists.Name = "tabPlaylists";
            tabPlaylists.Padding = new Padding(2);
            tabPlaylists.Size = new Size(865, 492);
            tabPlaylists.TabIndex = 1;
            tabPlaylists.Text = "Playlists";
            tabPlaylists.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(2, 2);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(lblPlaylists);
            splitContainer1.Panel1.Controls.Add(buttonDeletePlaylist);
            splitContainer1.Panel1.Controls.Add(buttonRenamePlaylist);
            splitContainer1.Panel1.Controls.Add(buttonNewPlaylist);
            splitContainer1.Panel1.Controls.Add(listBoxPlaylists);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewPlaylist);
            splitContainer1.Panel2.Controls.Add(buttonDeleteSongFromPlaylist);
            splitContainer1.Panel2.Controls.Add(buttonMoveDown);
            splitContainer1.Panel2.Controls.Add(buttonMoveUp);
            splitContainer1.Panel2.Controls.Add(labelPlaylistSongs);
            splitContainer1.Size = new Size(861, 488);
            splitContainer1.SplitterDistance = 294;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.Location = new Point(115, 21);
            lblPlaylists.Margin = new Padding(4, 0, 4, 0);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(123, 20);
            lblPlaylists.TabIndex = 4;
            lblPlaylists.Text = "Playlist names";
            // 
            // buttonDeletePlaylist
            // 
            buttonDeletePlaylist.Location = new Point(70, 425);
            buttonDeletePlaylist.Margin = new Padding(4, 3, 4, 3);
            buttonDeletePlaylist.Name = "buttonDeletePlaylist";
            buttonDeletePlaylist.Size = new Size(102, 38);
            buttonDeletePlaylist.TabIndex = 3;
            buttonDeletePlaylist.Text = "-";
            buttonDeletePlaylist.UseVisualStyleBackColor = true;
            buttonDeletePlaylist.Click += buttonDeletePlaylist_Click;
            // 
            // buttonRenamePlaylist
            // 
            buttonRenamePlaylist.Location = new Point(70, 367);
            buttonRenamePlaylist.Margin = new Padding(4, 3, 4, 3);
            buttonRenamePlaylist.Name = "buttonRenamePlaylist";
            buttonRenamePlaylist.Size = new Size(102, 38);
            buttonRenamePlaylist.TabIndex = 2;
            buttonRenamePlaylist.Text = "Rename";
            buttonRenamePlaylist.UseVisualStyleBackColor = true;
            buttonRenamePlaylist.Click += buttonRenamePlaylist_Click;
            // 
            // buttonNewPlaylist
            // 
            buttonNewPlaylist.Location = new Point(70, 307);
            buttonNewPlaylist.Margin = new Padding(4, 3, 4, 3);
            buttonNewPlaylist.Name = "buttonNewPlaylist";
            buttonNewPlaylist.Size = new Size(102, 38);
            buttonNewPlaylist.TabIndex = 1;
            buttonNewPlaylist.Text = "+";
            buttonNewPlaylist.UseVisualStyleBackColor = true;
            buttonNewPlaylist.Click += buttonNewPlaylist_Click;
            // 
            // listBoxPlaylists
            // 
            listBoxPlaylists.FormattingEnabled = true;
            listBoxPlaylists.Location = new Point(4, 58);
            listBoxPlaylists.Margin = new Padding(4, 3, 4, 3);
            listBoxPlaylists.Name = "listBoxPlaylists";
            listBoxPlaylists.Size = new Size(278, 214);
            listBoxPlaylists.TabIndex = 0;
            listBoxPlaylists.SelectedIndexChanged += listBoxPlaylists_SelectedIndexChanged;
            // 
            // dataGridViewPlaylist
            // 
            dataGridViewPlaylist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlaylist.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewPlaylist.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewPlaylist.Location = new Point(16, 58);
            dataGridViewPlaylist.Margin = new Padding(4, 3, 4, 3);
            dataGridViewPlaylist.Name = "dataGridViewPlaylist";
            dataGridViewPlaylist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPlaylist.Size = new Size(400, 326);
            dataGridViewPlaylist.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Title";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Artist";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Duration";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // buttonDeleteSongFromPlaylist
            // 
            buttonDeleteSongFromPlaylist.Location = new Point(352, 390);
            buttonDeleteSongFromPlaylist.Margin = new Padding(4, 3, 4, 3);
            buttonDeleteSongFromPlaylist.Name = "buttonDeleteSongFromPlaylist";
            buttonDeleteSongFromPlaylist.Size = new Size(97, 36);
            buttonDeleteSongFromPlaylist.TabIndex = 9;
            buttonDeleteSongFromPlaylist.Text = "Delete";
            buttonDeleteSongFromPlaylist.UseVisualStyleBackColor = true;
            buttonDeleteSongFromPlaylist.Click += buttonDeleteSongFromPlaylist_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Location = new Point(166, 390);
            buttonMoveDown.Margin = new Padding(4, 3, 4, 3);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(145, 36);
            buttonMoveDown.TabIndex = 8;
            buttonMoveDown.Text = "Move Down";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Location = new Point(16, 390);
            buttonMoveUp.Margin = new Padding(4, 3, 4, 3);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(131, 36);
            buttonMoveUp.TabIndex = 7;
            buttonMoveUp.Text = "Move UP";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // labelPlaylistSongs
            // 
            labelPlaylistSongs.AutoSize = true;
            labelPlaylistSongs.Location = new Point(220, 21);
            labelPlaylistSongs.Margin = new Padding(4, 0, 4, 0);
            labelPlaylistSongs.Name = "labelPlaylistSongs";
            labelPlaylistSongs.Size = new Size(118, 20);
            labelPlaylistSongs.TabIndex = 5;
            labelPlaylistSongs.Text = "Playlist songs";
            // 
            // tabSettingsStorage
            // 
            tabSettingsStorage.Controls.Add(labelStocare);
            tabSettingsStorage.Controls.Add(progressBarStorage);
            tabSettingsStorage.Controls.Add(labelSettingsStorage);
            tabSettingsStorage.Location = new Point(4, 24);
            tabSettingsStorage.Margin = new Padding(2);
            tabSettingsStorage.Name = "tabSettingsStorage";
            tabSettingsStorage.Padding = new Padding(2);
            tabSettingsStorage.Size = new Size(865, 492);
            tabSettingsStorage.TabIndex = 2;
            tabSettingsStorage.Text = "Storage";
            tabSettingsStorage.UseVisualStyleBackColor = true;
            // 
            // labelStocare
            // 
            labelStocare.AutoSize = true;
            labelStocare.Location = new Point(630, 74);
            labelStocare.Margin = new Padding(4, 0, 4, 0);
            labelStocare.Name = "labelStocare";
            labelStocare.Size = new Size(136, 20);
            labelStocare.TabIndex = 2;
            labelStocare.Text = "0Mb din 500Mb ";
            // 
            // progressBarStorage
            // 
            progressBarStorage.Location = new Point(70, 74);
            progressBarStorage.Margin = new Padding(4, 3, 4, 3);
            progressBarStorage.Name = "progressBarStorage";
            progressBarStorage.Size = new Size(504, 27);
            progressBarStorage.TabIndex = 1;
            // 
            // labelSettingsStorage
            // 
            labelSettingsStorage.AutoSize = true;
            labelSettingsStorage.Location = new Point(258, 28);
            labelSettingsStorage.Margin = new Padding(4, 0, 4, 0);
            labelSettingsStorage.Name = "labelSettingsStorage";
            labelSettingsStorage.Size = new Size(171, 20);
            labelSettingsStorage.TabIndex = 0;
            labelSettingsStorage.Text = "Gestionare Stocare ";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1460, 660);
            Controls.Add(panelCentral);
            Controls.Add(panelQueue);
            Controls.Add(panelNav);
            Controls.Add(panelPlayback);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            panelPlayback.ResumeLayout(false);
            panelPlayback.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            panelNav.ResumeLayout(false);
            panelNav.PerformLayout();
            panelQueue.ResumeLayout(false);
            panelQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).EndInit();
            contextMenuStripLibrary.ResumeLayout(false);
            panelCentral.ResumeLayout(false);
            TabControl.ResumeLayout(false);
            tabPageLibrary.ResumeLayout(false);
            tabPageLibrary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLibrary).EndInit();
            tabPlaylists.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewPlaylist).EndInit();
            tabSettingsStorage.ResumeLayout(false);
            tabSettingsStorage.PerformLayout();
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
        private System.Windows.Forms.Panel panelQueue;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPageLibrary;
        private System.Windows.Forms.TabPage tabPlaylists;
        private System.Windows.Forms.TabPage tabSettingsStorage;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnAddFile;
        private System.Windows.Forms.DataGridView dataGridViewLibrary;
        private System.Windows.Forms.TextBox textBoxSearchBar;
        private System.Windows.Forms.Label lblSearchBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnArtist;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDuration;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLibrary;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToQueue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlayNext;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToPlaylist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveFromLibrary;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblPlaylists;
        private System.Windows.Forms.Button buttonDeletePlaylist;
        private System.Windows.Forms.Button buttonRenamePlaylist;
        private System.Windows.Forms.Button buttonNewPlaylist;
        private System.Windows.Forms.ListBox listBoxPlaylists;
        private System.Windows.Forms.Button buttonDeleteSongFromPlaylist;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Label labelPlaylistSongs;
        private System.Windows.Forms.DataGridView dataGridViewPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label labelStocare;
        private System.Windows.Forms.ProgressBar progressBarStorage;
        private System.Windows.Forms.Label labelSettingsStorage;
        private System.Windows.Forms.Label labelQueue;
        private System.Windows.Forms.Button buttonClearQueue;
        private System.Windows.Forms.Button btnRemoveQueue;
        private System.Windows.Forms.RadioButton radioButtonStorage;
        private System.Windows.Forms.RadioButton radioButtonPlaylists;
        private System.Windows.Forms.RadioButton radioButtonLibrary;
        private System.Windows.Forms.DataGridView dataGridViewQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Timer timer1;
    }
}

