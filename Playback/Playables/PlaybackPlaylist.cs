using Common;
using Playback.Strategies;
using System.Collections.Generic;

namespace Playback.Playables;

/// <summary>
/// Reprezinta un playlist playable, care contine o colectie de elemente redabile.
/// </summary>
public class PlaybackPlaylist : IPlayable
{
    private List<IPlayable> _playables;
    private IPlaybackStrategy _playbackStrategy;
    private PlaylistInfo _playlistInfo;
    
    private IPlayable? _activePlayable; 

    public PlaybackPlaylist(PlaylistInfo playlistInfo)
    {
        _playbackStrategy = new SequentialStrategy();
        _playables = new List<IPlayable>();
        _playlistInfo = playlistInfo;
    }

    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    /// <summary>
    /// Returneaza urmatorul element playable conform strategiei active.
    /// </summary>
    public IPlayable? GetNextPlayable()
    {
        while (true)
        {
            if (_playables.Count == 0) return null;

            if (_activePlayable == null)
            {
                _activePlayable = _playbackStrategy.GetNextPlayable(_playables);
                if (_activePlayable == null) return null;
            }

            var next = _activePlayable.GetNextPlayable();

            if (next is not null) return next;

            _playables.Remove(_activePlayable);
            _activePlayable = null;
        }
    }

    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        _playbackStrategy = playbackStrategy;
        
        foreach (IPlayable playable in _playables)
        {
            playable.SetPlaybackStrategy(playbackStrategy);
        }
    }
}