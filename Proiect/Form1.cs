using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using FileManagement;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.Playlists;
using Windows.Storage;
using Common;
using Core;
using CustomExceptions;
using Playback.Playables;
using Exception = ABI.System.Exception;

namespace Proiect_Ip // NU SCHIMBATI NAMESPACE UL, se strica iar interfata
{
    public partial class Form1 : Form
    {
        private MediaPlayer _player = new MediaPlayer();
        private MediaManager _manager = new MediaManager();

        /// <summary>
        /// Initializes form components, hidden columns, event handlers, and default UI state.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            // Coloana ascunsa FileName
            var colFileName = new DataGridViewTextBoxColumn();
            colFileName.Name = "ColumnFileName";
            colFileName.Visible = false;
            dataGridViewLibrary.Columns.Add(colFileName);

            var colFileNamePlaylist = new DataGridViewTextBoxColumn();
            colFileNamePlaylist.Name = "ColumnFileName";
            colFileNamePlaylist.Visible = false;
            dataGridViewPlaylist.Columns.Add(colFileNamePlaylist);

            var colFileNameQueue = new DataGridViewTextBoxColumn();
            colFileNameQueue.Name = "ColumnFileName";
            colFileNameQueue.Visible = false;
            dataGridViewQueue.Columns.Add(colFileNameQueue);
            dataGridViewQueue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _manager.SongStartedEvent += Manager_SongStartedEvent;

            // Legam butoanele de jos
            btnPlay.Click += btnPlay_Click;
            btnPause.Click += btnPause_Click;
            btnMute.Click += btnMute_Click;
            btnNext.Click += btnNext_Click;

            // Setam volumul initial la maxim
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 50;
            _manager.AdjustVolume(0.5);

            // Legam slider-ul
            trackBarVolume.Scroll += trackBarVolume_Scroll;

            timer1.Interval = 1000;
            timer1.Start();

            trackBarSeek.Scroll += trackBarSeek_Scroll;
            //fix pentru radio buttons:
            TabControl.SelectedTab = tabPageLibrary;
            radioButtonLibrary.Checked = true;

            //textbox cu display de strategie
            _manager.ActivateSequential();
            textBoxStrategie.Text = "Sequential";

            _manager.SongFinishedEvent += SongFinishedHandler;
            _manager.PlaybackErrorOccurred += PlaybackErrorHandler;
            _manager.PlaybackDoneOcurred += PlaybackDoneHandler;
        }

        /// <summary>
        /// Handles form load event. Reserved for future initialization logic.
        /// </summary>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Aici poți inițializa tabelele la pornirea aplicației dacă e nevoie

        }

        #region CALLBACK-URI NAVIGARE (Schimbarea paginilor din meniul stânga)

        /// <summary>
        /// Navigates to the Library tab when the Library radio button is selected.
        /// </summary>
        private void radioButtonLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLibrary.Checked)
            {
                TabControl.SelectedTab = tabPageLibrary;
            }
        }

        /// <summary>
        /// Navigates to the Playlists tab when the Playlists radio button is selected.
        /// </summary>
        private void radioButtonPlaylists_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlaylists.Checked)
            {
                TabControl.SelectedTab = tabPlaylists;
            }
        }



        #endregion

        #region CALLBACK-URI CONTROALE AUDIO

        /// <summary>
        /// Highlights the currently playing song row in the queue grid when a new song starts.
        /// </summary>
        private void Manager_SongStartedEvent(object? sender, SongInfo song)
        {
            //varianta fara label 
            /*
            if (dataGridViewQueue.InvokeRequired)
            {
                dataGridViewQueue.Invoke(() => Manager_SongStartedEvent(sender, song));
                return;
            }

            try
            {
                if (!dataGridViewQueue.Columns.Contains("ColumnFileName")) return;

                dataGridViewQueue.ClearSelection();
        
                foreach (DataGridViewRow row in dataGridViewQueue.Rows)
                {
                    if (row.IsNewRow) continue;
            
                    if (row.Cells["ColumnFileName"].Value?.ToString() == song.FileName)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch 
            {
            }
            */
            if (dataGridViewQueue.InvokeRequired)
            {
                dataGridViewQueue.Invoke(() => Manager_SongStartedEvent(sender, song));
                return;
            }

            lblPlayingNow.Text = $"Now Playing: {song.SongTitle} - {song.Artist}";

            try
            {
                if (!dataGridViewQueue.Columns.Contains("ColumnFileName")) return;

                dataGridViewQueue.ClearSelection();

                foreach (DataGridViewRow row in dataGridViewQueue.Rows)
                {
                    if (row.IsNewRow) continue;

                    if (row.Cells["ColumnFileName"].Value?.ToString() == song.FileName)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// Resumes playback if a song is loaded, otherwise plays the next song in the queue.
        /// </summary>
        private async void btnPlay_Click(object sender, EventArgs e)
        {
            if (_manager.HasCurrentSong())
            {
                _manager.Resume();
            }
            else
            {
                _manager.PlayNextSong();
            }
        }

        /// <summary>
        /// Mutes the audio and resets the volume slider to zero.
        /// </summary>
        private void btnMute_Click(object sender, EventArgs e)
        {
            _manager.AdjustVolume(0);
            trackBarVolume.Value = 0;
        }

        #endregion

        #region HANDLERE EVENIMENTE BACKEND (Mesaje de eroare / info)

        /// <summary>
        /// Displays a playback error message received from the backend.
        /// </summary>
        private void PlaybackErrorHandler(object? obj, PlaybackFailedException playbackException)
        {
            MessageBox.Show(playbackException.Message, "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Displays an informational message when all songs in the queue have finished playing.
        /// </summary>
        private void PlaybackDoneHandler(object? obj, PlaybackDoneException playbackException)
        {
            MessageBox.Show(playbackException.Message, "Playback Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Removes the finished song from the queue grid. Skipped if Repeat strategy is active.
        /// </summary>
        private void SongFinishedHandler(object? obj, bool success)
        {
            if (dataGridViewQueue.InvokeRequired)
            {
                dataGridViewQueue.Invoke(() => SongFinishedHandler(obj, success));
                return;
            }

            if (textBoxStrategie.Text == "Repeat") return;

            if (dataGridViewQueue.SelectedRows.Count > 0)
            {
                var row = dataGridViewQueue.SelectedRows[0];
                if (!row.IsNewRow)
                {
                    dataGridViewQueue.Rows.Remove(row);
                }
            }
            else if (dataGridViewQueue.Rows.Count > 0 && !dataGridViewQueue.Rows[0].IsNewRow)
            {
                dataGridViewQueue.Rows.RemoveAt(0);
            }
        }

        #endregion

        /// <summary>
        /// Pauses the current playback.
        /// </summary>
        private void btnPause_Click(object sender, EventArgs e)
        {
            _manager.Pause();
        }

        /// <summary>
        /// Skips the current song and plays the next one in the queue.
        /// </summary>
        private async void btnNext_Click(object sender, EventArgs e)
        {
            await _manager.SkipSong();
        }

        /// <summary>
        /// Opens a file dialog, loads the selected audio file into the library and displays it in the grid.
        /// </summary>
        private async void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "AudioFile|*.wav;*.flac;*.mp3";
            dialog.Multiselect = false;

            if (dialog.ShowDialog() != DialogResult.OK) return;

            string filePath = dialog.FileName;
            try
            {
                var storageFile = await StorageFile.GetFileFromPathAsync(filePath);
                var songInfo = await FileProcessor.GetSongInfoAsync(storageFile);

                // Verificam daca fisierul NU e deja in Media inainte sa copiem
                string mediaFilePath = FileReader.GetSpecifiedDirPath(Path.GetFileName(filePath), "Media");
                await _manager.AddSongToLibrary(filePath);

                // Adaugam randul si setam explicit ColumnFileName
                int rowIndex = dataGridViewLibrary.Rows.Add(songInfo.SongTitle, songInfo.Artist,
                    TimeSpan.FromSeconds(songInfo.DurationSecs).ToString(@"mm\:ss"));
                dataGridViewLibrary.Rows[rowIndex].Cells["ColumnFileName"].Value = songInfo.FileName;

                // Adaugam automat in queue
                _manager.AddSongToQueue(songInfo.FileName);
                int queueRowIndex = dataGridViewQueue.Rows.Add(songInfo.SongTitle, songInfo.Artist,
                    TimeSpan.FromSeconds(songInfo.DurationSecs).ToString(@"mm\:ss"));
                dataGridViewQueue.Rows[queueRowIndex].Cells["ColumnFileName"].Value = songInfo.FileName;
            }
            catch (LibraryManagementException ex)
            {
                string fullError = ex.Message;
                if (ex.InnerException != null)
                    fullError += "\n\nCauza: " + ex.InnerException.Message;
                if (ex.InnerException?.InnerException != null)
                    fullError += "\n\nCauza 2: " + ex.InnerException.InnerException.Message;

                MessageBox.Show(fullError, "Eroare la adaugare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Filters the library grid based on the text entered in the search bar.
        /// </summary>
        private void lblSearchBar_Click(object sender, EventArgs e)
        {
            string query = textBoxSearchBar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dataGridViewLibrary.Rows)
            {
                if (row.IsNewRow) continue;

                string title = row.Cells["ColumnTitle"].Value?.ToString()?.ToLower() ?? "";
                string artist = row.Cells["ColumnArtist"].Value?.ToString()?.ToLower() ?? "";

                row.Visible = string.IsNullOrEmpty(query) || title.Contains(query) || artist.Contains(query);
            }

        }

        /// <summary>
        /// Removes the selected song from the library grid.
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewLibrary.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridViewLibrary.Rows.Remove(row);
            }

        }

        //callback uri pentru stripmenuitem uri

        /// <summary>
        /// Adds the selected song to the queue and begins immediate playback.
        /// </summary>
        private void toolStripMenuItemPlay_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells[0].Value?.ToString() ?? "";
            string artist = selected.Cells[1].Value?.ToString() ?? "";
            string duration = selected.Cells[2].Value?.ToString() ?? "";

            _manager.AddSongToQueue(fileName);

            int rowIndex = dataGridViewQueue.Rows.Add(title, artist, duration);
            dataGridViewQueue.Rows[rowIndex].Cells["ColumnFileName"].Value = fileName;

            _manager.PlayNextSong();
        }

        /// <summary>
        /// Adds the selected song to the end of the playback queue.
        /// </summary>
        private void toolStripMenuItemAddToQueue_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells[0].Value?.ToString() ?? "";
            string artist = selected.Cells[1].Value?.ToString() ?? "";
            string duration = selected.Cells[2].Value?.ToString() ?? "";

            _manager.AddSongToQueue(fileName);

            int rowIndex = dataGridViewQueue.Rows.Add(title, artist, duration);
            dataGridViewQueue.Rows[rowIndex].Cells["ColumnFileName"].Value = fileName;
        }

        /// <summary>
        /// Adds the selected song to the playback queue to be played next.
        /// </summary>
        private void toolStripMenuItemPlayNext_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells[0].Value?.ToString() ?? "";
            string artist = selected.Cells[1].Value?.ToString() ?? "";
            string duration = selected.Cells[2].Value?.ToString() ?? "";
            _manager.AddSongToQueue(fileName);
            int rowIndex = dataGridViewQueue.Rows.Add(title, artist, duration);
            dataGridViewQueue.Rows[rowIndex].Cells["ColumnFileName"].Value = fileName;
        }

        /// <summary>
        /// Adjusts the playback volume based on the volume slider position.
        /// </summary>
        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            // Impartim la 100 ca sa normalizam pentru MediaPlayer (0.0 - 1.0)
            _manager.AdjustVolume((double)trackBarVolume.Value / 100.0);
        }

        /// <summary>
        /// Adds the selected song to a user-specified playlist chosen via an input dialog.
        /// </summary>
        private async void toolStripMenuItemAddToPlaylist_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            if (listBoxPlaylists.Items.Count == 0)
            {
                MessageBox.Show("Nu exista niciun playlist. Creaza unul mai intai.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string[] playlists = listBoxPlaylists.Items.Cast<string>().ToArray();
            string selectedPlaylist = Microsoft.VisualBasic.Interaction.InputBox(
                "Numele playlistului in care adaugi:\n" + string.Join(", ", playlists),
                "Add to Playlist", playlists[0]);
            if (string.IsNullOrWhiteSpace(selectedPlaylist)) return;
            if (!listBoxPlaylists.Items.Contains(selectedPlaylist))
            {
                MessageBox.Show("Playlist negasit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells[0].Value?.ToString() ?? "";
            string artist = selected.Cells[1].Value?.ToString() ?? "";
            string duration = selected.Cells[2].Value?.ToString() ?? "";
            await _manager.AddSongToPlaylist(selectedPlaylist, fileName);
            if (listBoxPlaylists.SelectedItem?.ToString() == selectedPlaylist)
            {
                dataGridViewPlaylist.Rows.Add(title, artist, duration, fileName);
            }
        }

        /// <summary>
        /// Removes the selected song from the library, both in the UI and the database.
        /// </summary>
        private void toolStripMenuItemRemoveFromPlaylist_Click(object sender, EventArgs e)//defapt e from library a fost un name gresit
        {

            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            try
            {
                _manager.RemoveSongFromLibrary(fileName);
                dataGridViewLibrary.Rows.Remove(selected);
            }
            catch (MediaManagementException ex)
            {
                MessageBox.Show(ex.Message, "Eroare la stergere", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clears all songs from the playback queue in both the backend and the UI.
        /// </summary>
        private void buttonClearQueue_Click(object sender, EventArgs e)
        {
            _manager.ClearQueue();
            dataGridViewQueue.Rows.Clear();
        }

        /// <summary>
        /// Removes the selected song from the playback queue grid.
        /// </summary>
        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            if (dataGridViewQueue.SelectedRows.Count == 0) return;

            int index = dataGridViewQueue.SelectedRows[0].Index;
            // _manager.RemoveSongFromQueue(index);
            dataGridViewQueue.Rows.RemoveAt(index);
        }

        /// <summary>
        /// Creates a new playlist with the name provided by the user via an input dialog.
        /// </summary>
        private async void buttonNewPlaylist_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Numele noului playlist:", "Playlist nou", "");

            if (string.IsNullOrWhiteSpace(name)) return;

            await _manager.AddPlaylistToLibrary(name, new List<SongInfo>());
            listBoxPlaylists.Items.Add(name);
        }

        /// <summary>
        /// Renames the selected playlist using a new name provided by the user via an input dialog.
        /// </summary>
        private async void buttonRenamePlaylist_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedItem == null) return;

            string oldName = listBoxPlaylists.SelectedItem.ToString() ?? "";
            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Noul nume:", "Redenumire playlist", oldName);

            if (string.IsNullOrWhiteSpace(newName) || newName == oldName) return;

            await _manager.RenamePlaylist(oldName, newName);
            listBoxPlaylists.Items[listBoxPlaylists.SelectedIndex] = newName;
        }

        /// <summary>
        /// Deletes the selected playlist from the database and removes it from the UI.
        /// </summary>
        private async void buttonDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedItem == null) return;

            string name = listBoxPlaylists.SelectedItem.ToString() ?? "";

            await _manager.DeletePlaylist(name);
            listBoxPlaylists.Items.Remove(name);
            dataGridViewPlaylist.Rows.Clear();
        }

        /// <summary>
        /// Moves the selected song one position up in the playlist grid.
        /// </summary>
        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlaylist.SelectedRows.Count == 0) return;

            int index = dataGridViewPlaylist.SelectedRows[0].Index;
            if (index == 0) return;

            // Facem swap intre randul selectat si cel de deasupra
            for (int i = 0; i < dataGridViewPlaylist.Columns.Count; i++)
            {
                object temp = dataGridViewPlaylist.Rows[index].Cells[i].Value;
                dataGridViewPlaylist.Rows[index].Cells[i].Value =
                    dataGridViewPlaylist.Rows[index - 1].Cells[i].Value;
                dataGridViewPlaylist.Rows[index - 1].Cells[i].Value = temp;
            }
            dataGridViewPlaylist.Rows[index - 1].Selected = true;
            dataGridViewPlaylist.Rows[index].Selected = false;
        }


        /// <summary>
        /// Moves the selected song one position down in the playlist grid.
        /// </summary>
        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlaylist.SelectedRows.Count == 0) return;

            int index = dataGridViewPlaylist.SelectedRows[0].Index;
            if (index >= dataGridViewPlaylist.Rows.Count - 2) return;

            for (int i = 0; i < dataGridViewPlaylist.Columns.Count; i++)
            {
                object temp = dataGridViewPlaylist.Rows[index].Cells[i].Value;
                dataGridViewPlaylist.Rows[index].Cells[i].Value =
                    dataGridViewPlaylist.Rows[index + 1].Cells[i].Value;
                dataGridViewPlaylist.Rows[index + 1].Cells[i].Value = temp;
            }
            dataGridViewPlaylist.Rows[index + 1].Selected = true;
            dataGridViewPlaylist.Rows[index].Selected = false;
        }

        /// <summary>
        /// Removes the selected song from the current playlist in both the database and the UI.
        /// </summary>
        private async void buttonDeleteSongFromPlaylist_Click(object sender, EventArgs e)
        {
            if (dataGridViewPlaylist.SelectedRows.Count == 0) return;
            if (listBoxPlaylists.SelectedItem == null) return;

            string playlistName = listBoxPlaylists.SelectedItem.ToString() ?? "";
            DataGridViewRow selected = dataGridViewPlaylist.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";

            await _manager.RemoveSongFromPlaylist(playlistName, fileName);
            dataGridViewPlaylist.Rows.Remove(selected);
        }

        /// <summary>
        /// Loads and displays the songs of the selected playlist in the playlist grid.
        /// </summary>
        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxPlaylists.SelectedItem == null) return;

            string playlistName = listBoxPlaylists.SelectedItem.ToString() ?? "";

            dataGridViewPlaylist.Rows.Clear();

            try
            {
                var playlist = _manager.GetPlaylistSongs(playlistName);
                foreach (var song in playlist)
                {
                    int rowIndex = dataGridViewPlaylist.Rows.Add(song.SongTitle, song.Artist,
                        TimeSpan.FromSeconds(song.DurationSecs).ToString(@"mm\:ss"));
                    dataGridViewPlaylist.Rows[rowIndex].Cells["ColumnFileName"].Value = song.FileName;
                }
            }
            catch (MediaManagementException ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        /// <summary>
        /// Updates the seek bar and time labels every second based on the current playback position.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeSpan current = _manager.GetCurrentSongPosition();
                TimeSpan total = _manager.GetCurrentSongDuration();
                lblCurrentTime.Text = current.ToString(@"mm\:ss");
                lblTotalTime.Text = total.ToString(@"mm\:ss");
                if (total.TotalSeconds > 0)
                {
                    trackBarSeek.Maximum = (int)total.TotalSeconds;
                    trackBarSeek.Value = Math.Min((int)current.TotalSeconds, trackBarSeek.Maximum);
                }
            }
            catch { }

        }

        /// <summary>
        /// Seeks to the position indicated by the seek bar when the user drags it.
        /// </summary>
        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {
            TimeSpan current = _manager.GetCurrentSongPosition();
            double diff = trackBarSeek.Value - current.TotalSeconds;
            _manager.ChangeSongPosition(diff);
        }

        /// <summary>
        /// Adds all songs from the selected playlist to the playback queue.
        /// </summary>
        private void btnAddPlaylistToQueue_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedItem == null) return;
            string playlistName = listBoxPlaylists.SelectedItem.ToString() ?? "";

            try
            {
                _manager.AddPlaylistToQueue(playlistName);
                var songs = _manager.GetPlaylistSongs(playlistName);

                foreach (var song in songs)
                {
                    int rowIndex = dataGridViewQueue.Rows.Add(song.SongTitle, song.Artist, TimeSpan.FromSeconds(song.DurationSecs).ToString(@"mm\:ss"));
                    dataGridViewQueue.Rows[rowIndex].Cells["ColumnFileName"].Value = song.FileName;
                }
            }
            catch (MediaManagementException ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Activates shuffle playback strategy and updates the strategy display.
        /// </summary>
        private void btnShuffle_Click(object sender, EventArgs e)
        {
            _manager.ActivateShuffle();
            textBoxStrategie.Text = "Shuffle";

        }

        /// <summary>
        /// Activates repeat playback strategy and updates the strategy display.
        /// </summary>
        private void btnRepeat_Click(object sender, EventArgs e)
        {
            _manager.ActivateRepeat();
            textBoxStrategie.Text = "Repeat";

        }

        /// <summary>
        /// Activates sequential playback strategy and updates the strategy display.
        /// </summary>
        private void btnSequential_Click(object sender, EventArgs e)
        {
            _manager.ActivateSequential();
            textBoxStrategie.Text = "Sequential";

        }

        /// <summary>
        /// Display help menu.
        /// </summary>
        private void btnHelp_Click(object sender, EventArgs e)
        {
            string helpPath = FileReader.GetSpecifiedDirPath("MusicPlayerUserHelp.chm", "Help");
            Help.ShowHelp(this, helpPath);

        }
    }
}