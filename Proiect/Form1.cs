using FileManagement;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Media.Playlists;
using Windows.Storage;
using Common;
using Core;
using Playback.Playables;

namespace Proiect
{
    public partial class Form1 : Form
    {
        private MediaPlayer _player = new MediaPlayer();
        private MediaManager _manager = new MediaManager();
        public Form1()
        {
            InitializeComponent();
        }
        
        private async void btnPlay_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "AudioFile|*.wav;*.flac;*.mp3";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            string filePath = "";
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                filePath = choofdlog.FileName;
                MessageBox.Show(filePath);
            }
            
            // await _manager.AddSongToLibrary(filePath);
            // await _manager.AddSongToLibrary("02-fleetwood_mac-dont_stop.flac");

            _manager.AddSongToLibrary("01-fleetwood_mac-go_your_own_way.flac");
            _manager.AddSongToLibrary("02-fleetwood_mac-dont_stop.flac");
            _manager.AddSongToLibrary("03-fleetwood_mac-dreams.flac");
            _manager.AddSongToLibrary("testing.wav");

            
            var file1data = await FileReader.LoadSong("01-fleetwood_mac-go_your_own_way.flac");
            var file2data = await FileReader.LoadSong("02-fleetwood_mac-dont_stop.flac");
            var file3data = await FileReader.LoadSong("03-fleetwood_mac-dreams.flac");
            var file1Metadata = await FileProcessor.GetSongInfoAsync(file1data);
            var file2Metadata = await FileProcessor.GetSongInfoAsync(file2data);
            var file3Metadata = await FileProcessor.GetSongInfoAsync(file3data);

            var fileList = new List<SongInfo>();
            fileList.Add(file1Metadata);
            fileList.Add(file2Metadata);
            fileList.Add(file3Metadata);
            _manager.AddPlaylistToLibrary("Playlist2", fileList);
            _manager.AddPlaylistToQueue("Playlist1");
            
            _manager.AdjustVolume(100);
            _manager.PlayNextSong();
            _manager.ChangeSongPosition(200);
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
}
