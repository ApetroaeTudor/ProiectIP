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
            timer1 = new System.Windows.Forms.Timer(components);
            TabControl = new TabControl();
            tabPageLibrary = new TabPage();
            dataGridViewLibrary = new DataGridView();
            ColumnTitle = new DataGridViewTextBoxColumn();
            ColumnArtist = new DataGridViewTextBoxColumn();
            ColumnDuration = new DataGridViewTextBoxColumn();
            textBoxSearchBar = new TextBox();
            lblSearchBar = new Label();
            btnAddFile = new Button();
            tabPlaylists = new TabPage();
            splitContainer1 = new SplitContainer();
            btnAddPlaylistToQueue = new Button();
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
            panelCentral = new Panel();
            trackBarSeek = new TrackBar();
            lblCurrentTime = new Label();
            lblTotalTime = new Label();
            btnPlay = new Button();
            btnNext = new Button();
            btnPause = new Button();
            btnMute = new Button();
            trackBarVolume = new TrackBar();
            lblMinVol = new Label();
            lblMaxVol = new Label();
            panelPlayback = new Panel();
            textBoxStrategie = new TextBox();
            btnSequential = new Button();
            btnRepeat = new Button();
            btnShuffle = new Button();
            label1 = new Label();
            panelNav.SuspendLayout();
            panelQueue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).BeginInit();
            contextMenuStripLibrary.SuspendLayout();
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
            panelCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).BeginInit();
            panelPlayback.SuspendLayout();
            SuspendLayout();
            // 
            // panelNav
            // 
            panelNav.BackColor = SystemColors.ControlDark;
            panelNav.Controls.Add(radioButtonStorage);
            panelNav.Controls.Add(radioButtonPlaylists);
            panelNav.Controls.Add(radioButtonLibrary);
            panelNav.Dock = DockStyle.Left;
            panelNav.Location = new Point(0, 0);
            panelNav.Margin = new Padding(2, 3, 2, 3);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(242, 693);
            panelNav.TabIndex = 1;
            // 
            // radioButtonStorage
            // 
            radioButtonStorage.AutoSize = true;
            radioButtonStorage.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonStorage.ForeColor = Color.Navy;
            radioButtonStorage.Location = new Point(27, 203);
            radioButtonStorage.Margin = new Padding(5, 4, 5, 4);
            radioButtonStorage.Name = "radioButtonStorage";
            radioButtonStorage.Size = new Size(116, 30);
            radioButtonStorage.TabIndex = 9;
            radioButtonStorage.Text = "Storage";
            radioButtonStorage.UseVisualStyleBackColor = true;
            radioButtonStorage.CheckedChanged += radioButtonStorage_CheckedChanged;
            // 
            // radioButtonPlaylists
            // 
            radioButtonPlaylists.AutoSize = true;
            radioButtonPlaylists.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonPlaylists.ForeColor = Color.Navy;
            radioButtonPlaylists.Location = new Point(27, 143);
            radioButtonPlaylists.Margin = new Padding(5, 4, 5, 4);
            radioButtonPlaylists.Name = "radioButtonPlaylists";
            radioButtonPlaylists.Size = new Size(123, 30);
            radioButtonPlaylists.TabIndex = 8;
            radioButtonPlaylists.Text = "Playlists";
            radioButtonPlaylists.UseVisualStyleBackColor = true;
            radioButtonPlaylists.CheckedChanged += radioButtonPlaylists_CheckedChanged;
            // 
            // radioButtonLibrary
            // 
            radioButtonLibrary.AutoSize = true;
            radioButtonLibrary.Checked = true;
            radioButtonLibrary.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            radioButtonLibrary.ForeColor = Color.Navy;
            radioButtonLibrary.Location = new Point(27, 79);
            radioButtonLibrary.Margin = new Padding(5, 4, 5, 4);
            radioButtonLibrary.Name = "radioButtonLibrary";
            radioButtonLibrary.Size = new Size(106, 30);
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
            panelQueue.Location = new Point(242, 0);
            panelQueue.Margin = new Padding(2, 3, 2, 3);
            panelQueue.Name = "panelQueue";
            panelQueue.Size = new Size(1427, 693);
            panelQueue.TabIndex = 2;
            // 
            // dataGridViewQueue
            // 
            dataGridViewQueue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQueue.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6 });
            dataGridViewQueue.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewQueue.Location = new Point(1018, 103);
            dataGridViewQueue.Margin = new Padding(5, 4, 5, 4);
            dataGridViewQueue.Name = "dataGridViewQueue";
            dataGridViewQueue.ReadOnly = true;
            dataGridViewQueue.RowHeadersWidth = 51;
            dataGridViewQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewQueue.Size = new Size(402, 464);
            dataGridViewQueue.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Title";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Artist";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Duration";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 125;
            // 
            // contextMenuStripLibrary
            // 
            contextMenuStripLibrary.ImageScalingSize = new Size(20, 20);
            contextMenuStripLibrary.Items.AddRange(new ToolStripItem[] { toolStripMenuItemPlay, toolStripMenuItemAddToQueue, toolStripMenuItemPlayNext, toolStripMenuItemAddToPlaylist, toolStripMenuItemRemoveFromLibrary });
            contextMenuStripLibrary.Name = "contextMenuStripLibrary";
            contextMenuStripLibrary.Size = new Size(234, 124);
            // 
            // toolStripMenuItemPlay
            // 
            toolStripMenuItemPlay.Name = "toolStripMenuItemPlay";
            toolStripMenuItemPlay.Size = new Size(233, 24);
            toolStripMenuItemPlay.Text = "->Play";
            toolStripMenuItemPlay.Click += toolStripMenuItemPlay_Click;
            // 
            // toolStripMenuItemAddToQueue
            // 
            toolStripMenuItemAddToQueue.Name = "toolStripMenuItemAddToQueue";
            toolStripMenuItemAddToQueue.Size = new Size(233, 24);
            toolStripMenuItemAddToQueue.Text = "->Add to Queue";
            toolStripMenuItemAddToQueue.Click += toolStripMenuItemAddToQueue_Click;
            // 
            // toolStripMenuItemPlayNext
            // 
            toolStripMenuItemPlayNext.Name = "toolStripMenuItemPlayNext";
            toolStripMenuItemPlayNext.Size = new Size(233, 24);
            toolStripMenuItemPlayNext.Text = "->PlayNext";
            toolStripMenuItemPlayNext.Click += toolStripMenuItemPlayNext_Click;
            // 
            // toolStripMenuItemAddToPlaylist
            // 
            toolStripMenuItemAddToPlaylist.Name = "toolStripMenuItemAddToPlaylist";
            toolStripMenuItemAddToPlaylist.Size = new Size(233, 24);
            toolStripMenuItemAddToPlaylist.Text = "->Add to Playlist";
            toolStripMenuItemAddToPlaylist.Click += toolStripMenuItemAddToPlaylist_Click;
            // 
            // toolStripMenuItemRemoveFromLibrary
            // 
            toolStripMenuItemRemoveFromLibrary.Name = "toolStripMenuItemRemoveFromLibrary";
            toolStripMenuItemRemoveFromLibrary.Size = new Size(233, 24);
            toolStripMenuItemRemoveFromLibrary.Text = "->Remove from Library";
            toolStripMenuItemRemoveFromLibrary.Click += toolStripMenuItemRemoveFromPlaylist_Click;
            // 
            // buttonClearQueue
            // 
            buttonClearQueue.Location = new Point(1024, 591);
            buttonClearQueue.Margin = new Padding(5, 4, 5, 4);
            buttonClearQueue.Name = "buttonClearQueue";
            buttonClearQueue.Size = new Size(128, 67);
            buttonClearQueue.TabIndex = 3;
            buttonClearQueue.Text = "Clear";
            buttonClearQueue.UseVisualStyleBackColor = true;
            buttonClearQueue.Click += buttonClearQueue_Click;
            // 
            // btnRemoveQueue
            // 
            btnRemoveQueue.Location = new Point(1189, 591);
            btnRemoveQueue.Margin = new Padding(5, 4, 5, 4);
            btnRemoveQueue.Name = "btnRemoveQueue";
            btnRemoveQueue.Size = new Size(128, 67);
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
            labelQueue.Location = new Point(1080, 28);
            labelQueue.Margin = new Padding(5, 0, 5, 0);
            labelQueue.Name = "labelQueue";
            labelQueue.Size = new Size(77, 25);
            labelQueue.TabIndex = 0;
            labelQueue.Text = "Queue";
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(tabPageLibrary);
            TabControl.Controls.Add(tabPlaylists);
            TabControl.Controls.Add(tabSettingsStorage);
            TabControl.Dock = DockStyle.Right;
            TabControl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0, true);
            TabControl.ItemSize = new Size(20, 20);
            TabControl.Location = new Point(19, 0);
            TabControl.Margin = new Padding(2, 3, 2, 3);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(998, 693);
            TabControl.SizeMode = TabSizeMode.Fixed;
            TabControl.TabIndex = 0;
            // 
            // tabPageLibrary
            // 
            tabPageLibrary.Controls.Add(dataGridViewLibrary);
            tabPageLibrary.Controls.Add(textBoxSearchBar);
            tabPageLibrary.Controls.Add(lblSearchBar);
            tabPageLibrary.Controls.Add(btnAddFile);
            tabPageLibrary.Location = new Point(4, 24);
            tabPageLibrary.Margin = new Padding(2, 3, 2, 3);
            tabPageLibrary.Name = "tabPageLibrary";
            tabPageLibrary.Padding = new Padding(2, 3, 2, 3);
            tabPageLibrary.Size = new Size(990, 665);
            tabPageLibrary.TabIndex = 0;
            tabPageLibrary.Text = "Library";
            tabPageLibrary.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLibrary
            // 
            dataGridViewLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLibrary.Columns.AddRange(new DataGridViewColumn[] { ColumnTitle, ColumnArtist, ColumnDuration });
            dataGridViewLibrary.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewLibrary.Location = new Point(25, 167);
            dataGridViewLibrary.Margin = new Padding(5, 4, 5, 4);
            dataGridViewLibrary.Name = "dataGridViewLibrary";
            dataGridViewLibrary.ReadOnly = true;
            dataGridViewLibrary.RowHeadersWidth = 51;
            dataGridViewLibrary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLibrary.Size = new Size(390, 483);
            dataGridViewLibrary.TabIndex = 6;
            // 
            // ColumnTitle
            // 
            ColumnTitle.HeaderText = "Title";
            ColumnTitle.MinimumWidth = 6;
            ColumnTitle.Name = "ColumnTitle";
            ColumnTitle.ReadOnly = true;
            ColumnTitle.Width = 125;
            // 
            // ColumnArtist
            // 
            ColumnArtist.HeaderText = "Artist";
            ColumnArtist.MinimumWidth = 6;
            ColumnArtist.Name = "ColumnArtist";
            ColumnArtist.ReadOnly = true;
            ColumnArtist.Width = 125;
            // 
            // ColumnDuration
            // 
            ColumnDuration.HeaderText = "Duration";
            ColumnDuration.MinimumWidth = 6;
            ColumnDuration.Name = "ColumnDuration";
            ColumnDuration.ReadOnly = true;
            ColumnDuration.Width = 125;
            // 
            // textBoxSearchBar
            // 
            textBoxSearchBar.Location = new Point(511, 59);
            textBoxSearchBar.Margin = new Padding(5, 4, 5, 4);
            textBoxSearchBar.Name = "textBoxSearchBar";
            textBoxSearchBar.Size = new Size(213, 30);
            textBoxSearchBar.TabIndex = 5;
            // 
            // lblSearchBar
            // 
            lblSearchBar.AutoSize = true;
            lblSearchBar.Location = new Point(395, 68);
            lblSearchBar.Margin = new Padding(5, 0, 5, 0);
            lblSearchBar.Name = "lblSearchBar";
            lblSearchBar.Size = new Size(81, 25);
            lblSearchBar.TabIndex = 4;
            lblSearchBar.Text = "Search";
            lblSearchBar.Click += lblSearchBar_Click;
            // 
            // btnAddFile
            // 
            btnAddFile.Location = new Point(25, 51);
            btnAddFile.Margin = new Padding(5, 4, 5, 4);
            btnAddFile.Name = "btnAddFile";
            btnAddFile.Size = new Size(127, 49);
            btnAddFile.TabIndex = 0;
            btnAddFile.Text = "+File";
            btnAddFile.UseVisualStyleBackColor = true;
            btnAddFile.Click += btnAddFile_Click;
            // 
            // tabPlaylists
            // 
            tabPlaylists.Controls.Add(splitContainer1);
            tabPlaylists.Location = new Point(4, 24);
            tabPlaylists.Margin = new Padding(2, 3, 2, 3);
            tabPlaylists.Name = "tabPlaylists";
            tabPlaylists.Padding = new Padding(2, 3, 2, 3);
            tabPlaylists.Size = new Size(990, 665);
            tabPlaylists.TabIndex = 1;
            tabPlaylists.Text = "Playlists";
            tabPlaylists.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(2, 3);
            splitContainer1.Margin = new Padding(5, 4, 5, 4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnAddPlaylistToQueue);
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
            splitContainer1.Size = new Size(986, 659);
            splitContainer1.SplitterDistance = 336;
            splitContainer1.SplitterWidth = 6;
            splitContainer1.TabIndex = 0;
            // 
            // btnAddPlaylistToQueue
            // 
            btnAddPlaylistToQueue.Location = new Point(163, 472);
            btnAddPlaylistToQueue.Margin = new Padding(3, 4, 3, 4);
            btnAddPlaylistToQueue.Name = "btnAddPlaylistToQueue";
            btnAddPlaylistToQueue.Size = new Size(146, 71);
            btnAddPlaylistToQueue.TabIndex = 5;
            btnAddPlaylistToQueue.Text = "AddPlaylistToQueue";
            btnAddPlaylistToQueue.UseVisualStyleBackColor = true;
            btnAddPlaylistToQueue.Click += btnAddPlaylistToQueue_Click;
            // 
            // lblPlaylists
            // 
            lblPlaylists.AutoSize = true;
            lblPlaylists.Location = new Point(131, 28);
            lblPlaylists.Margin = new Padding(5, 0, 5, 0);
            lblPlaylists.Name = "lblPlaylists";
            lblPlaylists.Size = new Size(151, 25);
            lblPlaylists.TabIndex = 4;
            lblPlaylists.Text = "Playlist names";
            // 
            // buttonDeletePlaylist
            // 
            buttonDeletePlaylist.Location = new Point(18, 561);
            buttonDeletePlaylist.Margin = new Padding(5, 4, 5, 4);
            buttonDeletePlaylist.Name = "buttonDeletePlaylist";
            buttonDeletePlaylist.Size = new Size(117, 51);
            buttonDeletePlaylist.TabIndex = 3;
            buttonDeletePlaylist.Text = "-";
            buttonDeletePlaylist.UseVisualStyleBackColor = true;
            buttonDeletePlaylist.Click += buttonDeletePlaylist_Click;
            // 
            // buttonRenamePlaylist
            // 
            buttonRenamePlaylist.Location = new Point(18, 481);
            buttonRenamePlaylist.Margin = new Padding(5, 4, 5, 4);
            buttonRenamePlaylist.Name = "buttonRenamePlaylist";
            buttonRenamePlaylist.Size = new Size(117, 51);
            buttonRenamePlaylist.TabIndex = 2;
            buttonRenamePlaylist.Text = "Rename";
            buttonRenamePlaylist.UseVisualStyleBackColor = true;
            buttonRenamePlaylist.Click += buttonRenamePlaylist_Click;
            // 
            // buttonNewPlaylist
            // 
            buttonNewPlaylist.Location = new Point(18, 409);
            buttonNewPlaylist.Margin = new Padding(5, 4, 5, 4);
            buttonNewPlaylist.Name = "buttonNewPlaylist";
            buttonNewPlaylist.Size = new Size(117, 51);
            buttonNewPlaylist.TabIndex = 1;
            buttonNewPlaylist.Text = "+";
            buttonNewPlaylist.UseVisualStyleBackColor = true;
            buttonNewPlaylist.Click += buttonNewPlaylist_Click;
            // 
            // listBoxPlaylists
            // 
            listBoxPlaylists.FormattingEnabled = true;
            listBoxPlaylists.Location = new Point(5, 77);
            listBoxPlaylists.Margin = new Padding(5, 4, 5, 4);
            listBoxPlaylists.Name = "listBoxPlaylists";
            listBoxPlaylists.Size = new Size(317, 284);
            listBoxPlaylists.TabIndex = 0;
            listBoxPlaylists.SelectedIndexChanged += listBoxPlaylists_SelectedIndexChanged;
            // 
            // dataGridViewPlaylist
            // 
            dataGridViewPlaylist.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPlaylist.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridViewPlaylist.ContextMenuStrip = contextMenuStripLibrary;
            dataGridViewPlaylist.Location = new Point(18, 77);
            dataGridViewPlaylist.Margin = new Padding(5, 4, 5, 4);
            dataGridViewPlaylist.Name = "dataGridViewPlaylist";
            dataGridViewPlaylist.ReadOnly = true;
            dataGridViewPlaylist.RowHeadersWidth = 51;
            dataGridViewPlaylist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPlaylist.Size = new Size(457, 435);
            dataGridViewPlaylist.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Title";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Artist";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Duration";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // buttonDeleteSongFromPlaylist
            // 
            buttonDeleteSongFromPlaylist.Location = new Point(402, 520);
            buttonDeleteSongFromPlaylist.Margin = new Padding(5, 4, 5, 4);
            buttonDeleteSongFromPlaylist.Name = "buttonDeleteSongFromPlaylist";
            buttonDeleteSongFromPlaylist.Size = new Size(111, 48);
            buttonDeleteSongFromPlaylist.TabIndex = 9;
            buttonDeleteSongFromPlaylist.Text = "Delete";
            buttonDeleteSongFromPlaylist.UseVisualStyleBackColor = true;
            buttonDeleteSongFromPlaylist.Click += buttonDeleteSongFromPlaylist_Click;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.Location = new Point(190, 520);
            buttonMoveDown.Margin = new Padding(5, 4, 5, 4);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(166, 48);
            buttonMoveDown.TabIndex = 8;
            buttonMoveDown.Text = "Move Down";
            buttonMoveDown.UseVisualStyleBackColor = true;
            buttonMoveDown.Click += buttonMoveDown_Click;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.Location = new Point(18, 520);
            buttonMoveUp.Margin = new Padding(5, 4, 5, 4);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(150, 48);
            buttonMoveUp.TabIndex = 7;
            buttonMoveUp.Text = "Move UP";
            buttonMoveUp.UseVisualStyleBackColor = true;
            buttonMoveUp.Click += buttonMoveUp_Click;
            // 
            // labelPlaylistSongs
            // 
            labelPlaylistSongs.AutoSize = true;
            labelPlaylistSongs.Location = new Point(251, 28);
            labelPlaylistSongs.Margin = new Padding(5, 0, 5, 0);
            labelPlaylistSongs.Name = "labelPlaylistSongs";
            labelPlaylistSongs.Size = new Size(145, 25);
            labelPlaylistSongs.TabIndex = 5;
            labelPlaylistSongs.Text = "Playlist songs";
            // 
            // tabSettingsStorage
            // 
            tabSettingsStorage.Controls.Add(labelStocare);
            tabSettingsStorage.Controls.Add(progressBarStorage);
            tabSettingsStorage.Controls.Add(labelSettingsStorage);
            tabSettingsStorage.Location = new Point(4, 24);
            tabSettingsStorage.Margin = new Padding(2, 3, 2, 3);
            tabSettingsStorage.Name = "tabSettingsStorage";
            tabSettingsStorage.Padding = new Padding(2, 3, 2, 3);
            tabSettingsStorage.Size = new Size(990, 665);
            tabSettingsStorage.TabIndex = 2;
            tabSettingsStorage.Text = "Storage";
            tabSettingsStorage.UseVisualStyleBackColor = true;
            // 
            // labelStocare
            // 
            labelStocare.AutoSize = true;
            labelStocare.Location = new Point(720, 99);
            labelStocare.Margin = new Padding(5, 0, 5, 0);
            labelStocare.Name = "labelStocare";
            labelStocare.Size = new Size(167, 25);
            labelStocare.TabIndex = 2;
            labelStocare.Text = "0Mb din 500Mb ";
            // 
            // progressBarStorage
            // 
            progressBarStorage.Location = new Point(80, 99);
            progressBarStorage.Margin = new Padding(5, 4, 5, 4);
            progressBarStorage.Name = "progressBarStorage";
            progressBarStorage.Size = new Size(576, 36);
            progressBarStorage.TabIndex = 1;
            // 
            // labelSettingsStorage
            // 
            labelSettingsStorage.AutoSize = true;
            labelSettingsStorage.Location = new Point(295, 37);
            labelSettingsStorage.Margin = new Padding(5, 0, 5, 0);
            labelSettingsStorage.Name = "labelSettingsStorage";
            labelSettingsStorage.Size = new Size(204, 25);
            labelSettingsStorage.TabIndex = 0;
            labelSettingsStorage.Text = "Gestionare Stocare ";
            // 
            // panelCentral
            // 
            panelCentral.BackColor = SystemColors.ActiveCaption;
            panelCentral.Controls.Add(TabControl);
            panelCentral.Dock = DockStyle.Left;
            panelCentral.Location = new Point(242, 0);
            panelCentral.Margin = new Padding(2, 3, 2, 3);
            panelCentral.Name = "panelCentral";
            panelCentral.Size = new Size(1017, 693);
            panelCentral.TabIndex = 3;
            // 
            // trackBarSeek
            // 
            trackBarSeek.Location = new Point(378, 11);
            trackBarSeek.Margin = new Padding(2, 3, 2, 3);
            trackBarSeek.Name = "trackBarSeek";
            trackBarSeek.Size = new Size(742, 56);
            trackBarSeek.TabIndex = 0;
            trackBarSeek.Value = 1;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Location = new Point(375, 49);
            lblCurrentTime.Margin = new Padding(2, 0, 2, 0);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(44, 20);
            lblCurrentTime.TabIndex = 1;
            lblCurrentTime.Text = "00:00";
            // 
            // lblTotalTime
            // 
            lblTotalTime.AutoSize = true;
            lblTotalTime.Location = new Point(1081, 49);
            lblTotalTime.Margin = new Padding(2, 0, 2, 0);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(44, 20);
            lblTotalTime.TabIndex = 2;
            lblTotalTime.Text = "00:00";
            // 
            // btnPlay
            // 
            btnPlay.Location = new Point(600, 89);
            btnPlay.Margin = new Padding(2, 3, 2, 3);
            btnPlay.Name = "btnPlay";
            btnPlay.Size = new Size(206, 44);
            btnPlay.TabIndex = 4;
            btnPlay.Text = "Play";
            btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(841, 89);
            btnNext.Margin = new Padding(2, 3, 2, 3);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(117, 44);
            btnNext.TabIndex = 5;
            btnNext.Text = ">>";
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(1008, 89);
            btnPause.Margin = new Padding(2, 3, 2, 3);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(135, 44);
            btnPause.TabIndex = 6;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnMute
            // 
            btnMute.Location = new Point(1278, 11);
            btnMute.Margin = new Padding(2, 3, 2, 3);
            btnMute.Name = "btnMute";
            btnMute.Size = new Size(122, 59);
            btnMute.TabIndex = 7;
            btnMute.Text = "Mute";
            btnMute.UseVisualStyleBackColor = true;
            // 
            // trackBarVolume
            // 
            trackBarVolume.Location = new Point(1249, 103);
            trackBarVolume.Margin = new Padding(2, 3, 2, 3);
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.Size = new Size(206, 56);
            trackBarVolume.TabIndex = 8;
            // 
            // lblMinVol
            // 
            lblMinVol.AutoSize = true;
            lblMinVol.Location = new Point(1246, 153);
            lblMinVol.Margin = new Padding(2, 0, 2, 0);
            lblMinVol.Name = "lblMinVol";
            lblMinVol.Size = new Size(17, 20);
            lblMinVol.TabIndex = 9;
            lblMinVol.Text = "0";
            // 
            // lblMaxVol
            // 
            lblMaxVol.AutoSize = true;
            lblMaxVol.Location = new Point(1426, 153);
            lblMaxVol.Margin = new Padding(2, 0, 2, 0);
            lblMaxVol.Name = "lblMaxVol";
            lblMaxVol.Size = new Size(33, 20);
            lblMaxVol.TabIndex = 10;
            lblMaxVol.Text = "100";
            // 
            // panelPlayback
            // 
            panelPlayback.BackColor = Color.LightSlateGray;
            panelPlayback.Controls.Add(label1);
            panelPlayback.Controls.Add(textBoxStrategie);
            panelPlayback.Controls.Add(btnSequential);
            panelPlayback.Controls.Add(btnRepeat);
            panelPlayback.Controls.Add(btnShuffle);
            panelPlayback.Controls.Add(lblMaxVol);
            panelPlayback.Controls.Add(lblMinVol);
            panelPlayback.Controls.Add(trackBarVolume);
            panelPlayback.Controls.Add(btnMute);
            panelPlayback.Controls.Add(btnPause);
            panelPlayback.Controls.Add(btnNext);
            panelPlayback.Controls.Add(btnPlay);
            panelPlayback.Controls.Add(lblTotalTime);
            panelPlayback.Controls.Add(lblCurrentTime);
            panelPlayback.Controls.Add(trackBarSeek);
            panelPlayback.Dock = DockStyle.Bottom;
            panelPlayback.Location = new Point(0, 693);
            panelPlayback.Margin = new Padding(2, 3, 2, 3);
            panelPlayback.Name = "panelPlayback";
            panelPlayback.Size = new Size(1669, 187);
            panelPlayback.TabIndex = 0;
            // 
            // textBoxStrategie
            // 
            textBoxStrategie.Location = new Point(163, 88);
            textBoxStrategie.Margin = new Padding(3, 4, 3, 4);
            textBoxStrategie.Name = "textBoxStrategie";
            textBoxStrategie.ReadOnly = true;
            textBoxStrategie.Size = new Size(97, 27);
            textBoxStrategie.TabIndex = 14;
            // 
            // btnSequential
            // 
            btnSequential.Location = new Point(27, 132);
            btnSequential.Margin = new Padding(3, 4, 3, 4);
            btnSequential.Name = "btnSequential";
            btnSequential.Size = new Size(103, 41);
            btnSequential.TabIndex = 13;
            btnSequential.Text = "Sequential";
            btnSequential.UseVisualStyleBackColor = true;
            btnSequential.Click += btnSequential_Click;
            // 
            // btnRepeat
            // 
            btnRepeat.Location = new Point(27, 80);
            btnRepeat.Margin = new Padding(3, 4, 3, 4);
            btnRepeat.Name = "btnRepeat";
            btnRepeat.Size = new Size(103, 44);
            btnRepeat.TabIndex = 12;
            btnRepeat.Text = "Repeat";
            btnRepeat.UseVisualStyleBackColor = true;
            btnRepeat.Click += btnRepeat_Click;
            // 
            // btnShuffle
            // 
            btnShuffle.Location = new Point(27, 17);
            btnShuffle.Margin = new Padding(3, 4, 3, 4);
            btnShuffle.Name = "btnShuffle";
            btnShuffle.Size = new Size(103, 47);
            btnShuffle.TabIndex = 11;
            btnShuffle.Text = "Shuffle";
            btnShuffle.UseVisualStyleBackColor = true;
            btnShuffle.Click += btnShuffle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(345, 122);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 4;
            label1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1669, 880);
            Controls.Add(panelCentral);
            Controls.Add(panelQueue);
            Controls.Add(panelNav);
            Controls.Add(panelPlayback);
            Margin = new Padding(2, 3, 2, 3);
            Name = "Form1";
            Text = "Form1";
            panelNav.ResumeLayout(false);
            panelNav.PerformLayout();
            panelQueue.ResumeLayout(false);
            panelQueue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQueue).EndInit();
            contextMenuStripLibrary.ResumeLayout(false);
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
            panelCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBarSeek).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarVolume).EndInit();
            panelPlayback.ResumeLayout(false);
            panelPlayback.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelNav;
        private System.Windows.Forms.Panel panelQueue;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLibrary;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToQueue;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlayNext;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddToPlaylist;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemoveFromLibrary;
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
        private TabControl TabControl;
        private TabPage tabPageLibrary;
        private DataGridView dataGridViewLibrary;
        private DataGridViewTextBoxColumn ColumnTitle;
        private DataGridViewTextBoxColumn ColumnArtist;
        private DataGridViewTextBoxColumn ColumnDuration;
        private TextBox textBoxSearchBar;
        private Label lblSearchBar;
        private Button btnAddFile;
        private TabPage tabPlaylists;
        private SplitContainer splitContainer1;
        private Label lblPlaylists;
        private Button buttonDeletePlaylist;
        private Button buttonRenamePlaylist;
        private Button buttonNewPlaylist;
        private ListBox listBoxPlaylists;
        private DataGridView dataGridViewPlaylist;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button buttonDeleteSongFromPlaylist;
        private Button buttonMoveDown;
        private Button buttonMoveUp;
        private Label labelPlaylistSongs;
        private TabPage tabSettingsStorage;
        private Label labelStocare;
        private ProgressBar progressBarStorage;
        private Label labelSettingsStorage;
        private Panel panelCentral;
        private TrackBar trackBarSeek;
        private Label lblCurrentTime;
        private Label lblTotalTime;
        private Button btnPlay;
        private Button btnNext;
        private Button btnPause;
        private Button btnMute;
        private TrackBar trackBarVolume;
        private Label lblMinVol;
        private Label lblMaxVol;
        private Panel panelPlayback;
        private Button btnAddPlaylistToQueue;
        private Button btnSequential;
        private Button btnRepeat;
        private Button btnShuffle;
        private TextBox textBoxStrategie;
        private Label label1;
    }
}

