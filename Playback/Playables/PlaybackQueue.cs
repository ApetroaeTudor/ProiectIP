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

    /// <summary>
    /// Initializeaza o coada de redare goala.
    /// </summary>
    public PlaybackQueue()
    {
        _playables = new List<IPlayable>();    
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
    /// Returneaza urmatorul element playabke din coada. Elimina elementele epuizate.
    /// Returneaza null daca coada este goala.
    /// </summary>
    public IPlayable? GetNextPlayable()
    {
        while (_playables.Count > 0)
        {
            var current = _playables[0];
            var next = current.GetNextPlayable();

            if (next is not null)
            {
                return next;
            }

            // Elementul curent s-a epuizat, il eliminam din coada
            _playables.RemoveAt(0);
        }

        return null;
    }

    /// <summary>
    /// Propaga strategia de redare catre toate elementele din coada.
    /// </summary>
    /// <param name="playbackStrategy">Strategia de aplicat.</param>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
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
    }
    
}