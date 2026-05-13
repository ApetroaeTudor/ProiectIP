using Common;
using Playback.Playables;

namespace Playback.Strategies;

public class ShuffleStrategy : IPlaybackStrategy
{
    public IPlayable GetNextPlayable(List<IPlayable> playables)
    {
        if (playables.Count == 0)
        {
            return null;
        }
        
        int index = new Random().Next(0, playables.Count);
        IPlayable song = playables[index];
        playables.RemoveAt(index);
        return song;
    }
}