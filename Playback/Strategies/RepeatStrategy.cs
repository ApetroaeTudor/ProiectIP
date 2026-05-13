using Common;
using Playback.Playables;

namespace Playback.Strategies;

public class RepeatStrategy : IPlaybackStrategy
{
    public IPlayable GetNextPlayable(List<IPlayable> playables)
    {
        if (playables.Count == 0)
        {
            return null;
        }
        
        return playables[0];
    }
}