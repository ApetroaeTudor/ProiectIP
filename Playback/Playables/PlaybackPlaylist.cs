/********************************************************************************************************
 *                                                                                                      *
 *  File:        PlaybackPlaylist.cs                                                                    *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                               *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                       *
 *  Description: Clasa folosita pentru a grupa cantece in playlist-uri in cadrul procesului de playback *
 ********************************************************************************************************/

using Common;
using Playback.Strategies;

namespace Playback.Playables;

/// <summary>
/// Reprezinta un playlist playable, care contine o colectie de elemente redabile.
/// </summary>
public class PlaybackPlaylist : IPlayable
{
    private List<IPlayable> _playables;
    private IPlaybackStrategy _playbackStrategy;
    private PlaylistInfo _playlistInfo;

    /// <summary>
    /// Initializeaza un playlist cu informatiile date, folosind strategia secventiala implicit.
    /// </summary>
    /// <param name="playlistInfo">Informatiile despre playlist.</param>
    public PlaybackPlaylist(PlaylistInfo playlistInfo)
    {
        _playbackStrategy = new SequentialStrategy();
        _playables = new List<IPlayable>();
        _playlistInfo = playlistInfo;
    }

    /// <summary>
    /// Adauga un element playable in playlist.
    /// </summary>
    /// <param name="playable">Elementul de adaugat.</param>
    public void AddPlayable(IPlayable playable)
    {
        _playables.Add(playable);
    }

    /// <summary>
    /// Returneaza urmatorul element playable conform strategiei active.
    /// </summary>
    public IPlayable GetNextPlayable()
    {
        return _playbackStrategy.GetNextPlayable(_playables);
    }

    /// <summary>
    /// Seteaza strategia de redare pentru playlist.
    /// </summary>
    /// <param name="playbackStrategy">Strategia de aplicat.</param>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        _playbackStrategy = playbackStrategy;
    }
}