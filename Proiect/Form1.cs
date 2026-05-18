using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Bibliotecile colegilor tăi (Backend-ul audio/file management)
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


            // Legam butoanele de jos
            btnPlay.Click += btnPlay_Click;
            btnPause.Click += btnPause_Click;
            btnMute.Click += btnMute_Click;
            btnNext.Click += btnNext_Click;
            // btnPrev.Click += btnPrev_Click;

            // Setam volumul initial la maxim
            trackBarVolume.Minimum = 0;
            trackBarVolume.Maximum = 100;
            trackBarVolume.Value = 100;
            _manager.AdjustVolume(100);

            // Legam slider-ul
            trackBarVolume.Scroll += trackBarVolume_Scroll;

            timer1.Interval = 1000;
            timer1.Start();

            trackBarSeek.Scroll += trackBarSeek_Scroll;

            _manager.SongFinishedEvent += SongFinishedHandler;
            _manager.PlaybackErrorOccurred += PlaybackErrorHandler;
            _manager.PlaybackDoneOcurred += PlaybackDoneHandler;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Aici poți inițializa tabelele la pornirea aplicației dacă e nevoie

        }

        #region CALLBACK-URI NAVIGARE (Schimbarea paginilor din meniul stânga)

        private void radioButtonLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonLibrary.Checked)
            {
                TabControl.SelectedTab = tabPageLibrary;
            }
        }

        private void radioButtonPlaylists_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlaylists.Checked)
            {
                TabControl.SelectedTab = tabPlaylists;
            }
        }

        private void radioButtonStorage_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonStorage.Checked)
            {
                TabControl.SelectedTab = tabSettingsStorage;
            }
        }

        #endregion

        #region CALLBACK-URI CONTROALE AUDIO

        private async void btnPlay_Click(object sender, EventArgs e)
        {
             // Asta e codul pe care o sa l foloseasca callback-ul nu testul de mai jos , trebuie implementat hascurrentsong,resume, iar playnextsong exista deja
             if (_manager.HasCurrentSong()) //TREBUIE IMPLEMENTAT
             {
                 _manager.Resume();
             }
             else
             {
                 _manager.PlayNextSong(); 
             }
             
            //partea de mai jos e tinuta momentan doar pentru verificarea celorlalte callback uri
            // OpenFileDialog choofdlog = new OpenFileDialog();
            // choofdlog.Filter = "AudioFile|*.wav;*.flac;*.mp3";
            // choofdlog.FilterIndex = 1;
            // choofdlog.Multiselect = false;
            //
            // string filePath = "";
            // if (choofdlog.ShowDialog() == DialogResult.OK)
            // {
            //     filePath = choofdlog.FileName;
            //     MessageBox.Show("Fișier selectat: " + filePath);
            // }
            //
            // // Logica lor de simulare / testare piese
            // _manager.AddSongToLibrary("01-fleetwood_mac-go_your_own_way.flac");
            //
            // var file1data = await FileReader.LoadSong("01-fleetwood_mac-go_your_own_way.flac");
            // var file1Metadata = await FileProcessor.GetSongInfoAsync(file1data);
            //
            // var fileList = new List<SongInfo>();
            // fileList.Add(file1Metadata);
            //
            // _manager.AddPlaylistToLibrary("Playlist2", fileList);
            // _manager.AddPlaylistToLibrary("Playlist1", fileList);
            // _manager.AddPlaylistToQueue("Playlist2");
            //
            // _manager.AdjustVolume(100);
            // _manager.PlayNextSong();
            // _manager.ChangeSongPosition(208);

        }



        private void btnMute_Click(object sender, EventArgs e)
        {
            _manager.AdjustVolume(0);
            trackBarVolume.Value = 0;
        }

        #endregion

        #region HANDLERE EVENIMENTE BACKEND (Mesaje de eroare / info)

        private void PlaybackErrorHandler(object? obj, PlaybackFailedException playbackException)
        {
            MessageBox.Show(playbackException.Message, "Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PlaybackDoneHandler(object? obj, PlaybackDoneException playbackException)
        {
            MessageBox.Show(playbackException.Message, "Playback Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SongFinishedHandler(object? obj, bool success)
        {
            // PLACEHOLDER
        }

        #endregion



        private void btnPause_Click(object sender, EventArgs e)
        {
            _manager.Pause();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            await _manager.SkipSong();
        }

        // private void btnPrev_Click(object sender, EventArgs e)
        // {
        //     // _manager.PlayPreviousSong(); //TREBUIE IMPLEMENTAT (daca se vrea daca nu scoatem butonul de previous)
        // }

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
                if (!File.Exists(mediaFilePath))
                {
                    await _manager.AddSongToLibrary(filePath);
                }

                dataGridViewLibrary.Rows.Add(songInfo.SongTitle, songInfo.Artist,
                    TimeSpan.FromSeconds(songInfo.DurationSecs).ToString(@"mm\:ss"), songInfo.FileName);
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

        // private void btnAddFolder_Click(object sender, EventArgs e)
        // {// nu e necesar
        //
        // }

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
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewLibrary.SelectedRows)
            {
                if (!row.IsNewRow)
                    dataGridViewLibrary.Rows.Remove(row);
            }

        }

        //callback uri pentru stripmenuitem uri
        private void toolStripMenuItemPlay_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;

            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells["ColumnTitle"].Value?.ToString() ?? "";
            string artist = selected.Cells["ColumnArtist"].Value?.ToString() ?? "";
            string duration = selected.Cells["ColumnDuration"].Value?.ToString() ?? "";

            _manager.AddSongToQueue(fileName);
            dataGridViewQueue.Rows.Add(title, artist, duration);

            _manager.PlayNextSong();
        }

        private void toolStripMenuItemAddToQueue_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;

            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells["ColumnTitle"].Value?.ToString() ?? "";
            string artist = selected.Cells["ColumnArtist"].Value?.ToString() ?? "";
            string duration = selected.Cells["ColumnDuration"].Value?.ToString() ?? "";

            _manager.AddSongToQueue(fileName);
            dataGridViewQueue.Rows.Add(title, artist, duration);
        }

        private void toolStripMenuItemPlayNext_Click(object sender, EventArgs e)
        {
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;

            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells["ColumnTitle"].Value?.ToString() ?? "";
            string artist = selected.Cells["ColumnArtist"].Value?.ToString() ?? "";
            string duration = selected.Cells["ColumnDuration"].Value?.ToString() ?? "";

            _manager.AddSongToQueue(fileName);
            dataGridViewQueue.Rows.Add(title, artist, duration);
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            // Impartim la 100 ca sa normalizam pentru MediaPlayer (0.0 - 1.0)
            _manager.AdjustVolume((double)trackBarVolume.Value / 100.0);
        }

        private async void toolStripMenuItemAddToPlaylist_Click(object sender, EventArgs e)
        {
           
            if (dataGridViewLibrary.SelectedRows.Count == 0) return;
            if (listBoxPlaylists.Items.Count == 0)
            {
                MessageBox.Show("Nu exista niciun playlist. Creaza unul mai intai.",
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Afisam un dialog cu lista de playlists disponibile
            string[] playlists = listBoxPlaylists.Items
                .Cast<string>()
                .ToArray();

            string selectedPlaylist = Microsoft.VisualBasic.Interaction.InputBox(
                "Numele playlistului in care adaugi:\n" + string.Join(", ", playlists),
                "Add to Playlist", playlists[0]);

            if (string.IsNullOrWhiteSpace(selectedPlaylist)) return;
            if (!listBoxPlaylists.Items.Contains(selectedPlaylist))
            {
                MessageBox.Show("Playlist negasit.", "Eroare",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridViewRow selected = dataGridViewLibrary.SelectedRows[0];
            string fileName = selected.Cells["ColumnFileName"].Value?.ToString() ?? "";
            string title = selected.Cells["ColumnTitle"].Value?.ToString() ?? "";
            string artist = selected.Cells["ColumnArtist"].Value?.ToString() ?? "";
            string duration = selected.Cells["ColumnDuration"].Value?.ToString() ?? "";

            await _manager.AddSongToPlaylist(selectedPlaylist, fileName);

            // Daca playlistul selectat e deschis in tabel, adaugam si vizual
            if (listBoxPlaylists.SelectedItem?.ToString() == selectedPlaylist)
            {
                dataGridViewPlaylist.Rows.Add(title, artist, duration, fileName);
            }
        }


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
            catch (LibraryManagementException ex)
            {
                MessageBox.Show(ex.Message, "Eroare la stergere",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClearQueue_Click(object sender, EventArgs e)
        {
            _manager.ClearQueue();
            dataGridViewQueue.Rows.Clear();
        }

        private void btnRemoveQueue_Click(object sender, EventArgs e)
        {
            if (dataGridViewQueue.SelectedRows.Count == 0) return;

            int index = dataGridViewQueue.SelectedRows[0].Index;
            // _manager.RemoveSongFromQueue(index);
            dataGridViewQueue.Rows.RemoveAt(index);
        }

        private async void buttonNewPlaylist_Click(object sender, EventArgs e)
        {
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Numele noului playlist:", "Playlist nou", "");

            if (string.IsNullOrWhiteSpace(name)) return;

            await _manager.AddPlaylistToLibrary(name, new List<SongInfo>());
            listBoxPlaylists.Items.Add(name);
        }

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

        private async void buttonDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedItem == null) return;

            string name = listBoxPlaylists.SelectedItem.ToString() ?? "";

            await _manager.DeletePlaylist(name);
            listBoxPlaylists.Items.Remove(name);
            dataGridViewPlaylist.Rows.Clear();
        }

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

        private void listBoxPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxPlaylists.SelectedItem == null) return;

            string playlistName = listBoxPlaylists.SelectedItem.ToString() ?? "";

            dataGridViewPlaylist.Rows.Clear();

            
            var playlist = _manager.GetPlaylistSongs(playlistName); // TREBUIE IMPLEMENTAT
            foreach (var song in playlist)
            {
                dataGridViewPlaylist.Rows.Add(song.SongTitle, song.Artist,
                    TimeSpan.FromSeconds(song.DurationSecs).ToString(@"mm\:ss"), song.FileName);
            }
            

        }

        private void timer1_Tick(object sender, EventArgs e)
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

        private void trackBarSeek_Scroll(object sender, EventArgs e)
        {  
            TimeSpan current = _manager.GetCurrentSongPosition();
            double diff = trackBarSeek.Value - current.TotalSeconds;
            _manager.ChangeSongPosition(diff);
        }


    }
}