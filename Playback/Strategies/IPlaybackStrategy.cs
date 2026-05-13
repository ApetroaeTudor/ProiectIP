using Common;
using Playback.Playables;

namespace Playback.Strategies;

public interface IPlaybackStrategy
{
    IPlayable GetNextPlayable(List<IPlayable> songs);
}