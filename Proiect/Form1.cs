using System.Security.Cryptography;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Proiect
{
    public partial class Form1 : Form
    {
        private MediaPlayer _player = new MediaPlayer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var mediaSource = await ReadFile(@"testing.wav");
            if(mediaSource is not null)
            {
                _player.Source = mediaSource;
                _player.Volume = 100;
                _player.Play();
            }
        }

        private async Task<MediaSource?> ReadFile(string fileName)
        {
            try
            {
                string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
                string filePath = Path.Combine(projectRoot, "Media", fileName);
                MessageBox.Show(filePath);
                var storageFile = await StorageFile.GetFileFromPathAsync(Path.GetFullPath(filePath));
                var mediaSource = MediaSource.CreateFromStorageFile(storageFile);
                return mediaSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show("err");
            }

            return null;
        }
    }
}
