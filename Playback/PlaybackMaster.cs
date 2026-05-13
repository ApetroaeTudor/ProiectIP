using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI.Composition.Interactions;
using Playback.Playables;

namespace Playback;

public class PlaybackMaster
{
    private MediaPlayer _mediaPlayer;

    public event Action OnSongEnded;
    public PlaybackMaster()
    {
        _mediaPlayer = new MediaPlayer();
        _mediaPlayer.MediaEnded += (sender, args) =>
        {
            OnSongEnded?.Invoke();
        };
    }

    public void Play()
    {
        _mediaPlayer.Play();
    }

    public void Pause()
    {
        _mediaPlayer.Pause();
    }

    public void AdjustVolume(double amount)
    {
        double oldVolume = _mediaPlayer.Volume;
        if (oldVolume + amount < 0)
        {
            _mediaPlayer.Volume = 0;
        }
        else if (oldVolume + amount > 100)
        {
            _mediaPlayer.Volume = 100;
        }
        _mediaPlayer.Volume = oldVolume + amount;
    }

    public void SkipSeconds(double seconds)
    {
        TimeSpan currentSeconds = _mediaPlayer.Position;
        TimeSpan newPosition = currentSeconds.Add(TimeSpan.FromSeconds(seconds));

        if (newPosition < TimeSpan.Zero)
        {
            newPosition = TimeSpan.Zero;
        }
        
        _mediaPlayer.Position = newPosition;
    }
    public void SetSource(MediaSource source)
    {
        _mediaPlayer.Source = source;
    }
    
}