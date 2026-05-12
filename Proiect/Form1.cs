using FileManagement;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;

namespace Proiect
{
    public partial class Form1 : Form
    {
        private MediaPlayer _player = new MediaPlayer();
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

            var storageFile = await FileReader.LoadNewSongAsync(filePath);
            var playbackItem = FileProcessor.GetMediaSource(storageFile);
            var songInfo = await FileProcessor.GetSongInfoAsync(storageFile);

            MessageBox.Show(songInfo.ToString());
            
            _player.Source = playbackItem;
            _player.Volume = 100;
            _player.Play();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
}
