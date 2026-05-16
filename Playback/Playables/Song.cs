/*************************************************************************************************************
 *                                                                                                           *
 *  File:        Song.cs                                                                                     *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                                    *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                            *
 *  Description: Clasa frunza in ierarhia playable. Contine informatiile necesare pentru a incarca un cantec *
 ************************************************************************************************************/

using Common;
using Playback.Strategies;

namespace Playback.Playables;

/// <summary>
/// Reprezinta un cantec individual, ca element playable de baza.
/// </summary>
public class Song : IPlayable
{
    private SongInfo _songInfo;

    /// <summary>
    /// Returneaza informatiile despre cantec.
    /// </summary>
    public SongInfo GetSongInfo()
    {
        return _songInfo;
    }

    /// <summary>
    /// Initializeaza cantecul cu informatiile specificate.
    /// </summary>
    /// <param name="songInfo">Informatiile despre cantec.</param>
    public Song(SongInfo songInfo)
    {
        _songInfo = songInfo;
    }

    /// <summary>
    /// Neimplementat. Un cantec nu poate contine alte elemente redabile.
    /// </summary>
    public void AddPlayable(IPlayable playable)
    {
        // metoda nu e implementata
    }

    /// <summary>
    /// Returneaza instanta curenta, cantecul fiind propriul sau element playable.
    /// </summary>
    public IPlayable GetNextPlayable()
    {
        return this;
    }

    /// <summary>
    /// Neimplementat. Un cantec individual nu foloseste strategii de redare.
    /// </summary>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        // metoda neimplementata
    }
}