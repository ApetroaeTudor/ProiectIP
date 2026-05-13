using Common;
using Playback.Playables;

namespace Playback.Strategies;

public class SequentialStrategy : IPlaybackStrategy
{
    public IPlayable GetNextPlayable(List<IPlayable> playables)
    {
        if (playables.Count == 0)
        {
            return null;
        }
        
        IPlayable nextSong = playables[0];
        playables.RemoveAt(0);
        return nextSong;
    }
}