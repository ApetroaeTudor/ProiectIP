using Playback.Strategies;

namespace Playback.Playables;

public class PlaybackPlaylist : IPlayable
{
    private List<IPlayable> _playables;
    private IPlaybackStrategy _playbackStrategy;
    
    public PlaybackPlaylist()
    {
        _playbackStrategy = new SequentialStrategy();
        _playables = new List<IPlayable>();
    }

    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    public IPlayable GetNextPlayable()
    {
        return _playbackStrategy.GetNextPlayable(_playables);
    }

    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        _playbackStrategy = playbackStrategy;
    }
}