/********************************************************************************************************
 *                                                                                                        *
 *  File:        PlaybackQueue.cs                                                                         *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                                 *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                         *
 *  Description: Clasa de nivel inalt folosita pentru manipularea redarii cantecelor si a playlist-urilor *
 ********************************************************************************************************/

using Playback.Strategies;

namespace Playback.Playables;

/// <summary>
/// Coada principala de redare, care gestioneaza ordinea elementelor playable.
/// </summary>
public class PlaybackQueue : IPlayable
{
    private List<IPlayable> _playables;
    private IPlaybackStrategy _playbackStrategy;
    private IPlayable? _activePlayable;

    /// <summary>
    /// Initializeaza o coada de redare goala.
    /// </summary>
    public PlaybackQueue()
    {
        _playables = new List<IPlayable>();    
        _playbackStrategy = new SequentialStrategy();
    }

    /// <summary>
    /// Adauga un element playable la sfarsitul cozii.
    /// </summary>
    /// <param name="playable">Elementul de adaugat.</param>
    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    /// <summary>
    /// Returneaza urmatorul element playable din coada conform strategiei active.
    /// Elimina elementele epuizate. Returneaza null daca coada este goala.
    /// </summary>
    public IPlayable? GetNextPlayable()
    {
        while (true)
        {
            if (_playables.Count == 0) return null;

            if (_activePlayable == null)
            {
                _activePlayable = _playbackStrategy.GetNextPlayable(_playables);
                
                if (_activePlayable == null)
                    return null;
            }

            var next = _activePlayable.GetNextPlayable();

            if (next is not null)
            {
                return next;
            }

            _playables.Remove(_activePlayable);
            _activePlayable = null;
        }
    }

    /// <summary>
    /// Seteaza strategia de redare pentru coada si o propaga catre toate elementele.
    /// </summary>
    /// <param name="playbackStrategy">Strategia de aplicat.</param>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        _playbackStrategy = playbackStrategy;
        
        foreach (IPlayable playable in _playables)
        {
            playable.SetPlaybackStrategy(playbackStrategy);
        }
    }

    /// <summary>
    /// Goleste coada de redare, eliminand toate elementele din lista.
    /// </summary>
    public void Clear()
    {
        _playables.Clear();
        _activePlayable = null;
    }
}