using Playback.Strategies;

namespace Playback.Playables;

public interface IPlayable
{
    public void AddPlayable(IPlayable playable);
    public IPlayable GetNextPlayable();
    
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy);
}