using Playback.Strategies;

namespace Playback.Playables;

public class PlaybackQueue : IPlayable
{
    private List<IPlayable> _playables;

    public PlaybackQueue()
    {
        _playables = new List<IPlayable>();    
    }
    
    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    public IPlayable GetNextPlayable()
    {
        while (_playables.Count > 0)
        {
            var current = _playables[0];
            var next = current.GetNextPlayable();

            if (next is not null)
            {
                return next;
            }

            _playables.RemoveAt(0);
        }

        return null;
    }
    
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        foreach (IPlayable playable in _playables)
        {
            playable.SetPlaybackStrategy(playbackStrategy);
        }
    }
}