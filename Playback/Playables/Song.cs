using Common;
using Playback.Strategies;

namespace Playback.Playables;

public class Song : IPlayable
{
    private SongInfo _songInfo;

    public SongInfo GetSongInfo()
    {
        return _songInfo;
    }

    public Song(SongInfo songInfo)
    {
        _songInfo = songInfo;
    }
    
    public void AddPlayable(IPlayable playable)
    {
        // metoda nu e implementata
    }

    public IPlayable GetNextPlayable()
    {
        return this;
    }
    
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        // metoda neimplementata
    }
}