/*****************************************************************************************************
 *                                                                                                   *
 *  File:        IPlayable.cs                                                                        *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                            *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                    *
 *  Description: Clasa de tip interfata folosita in procesul de playback composite                   *
 ****************************************************************************************************/

using Playback.Strategies;

namespace Playback.Playables;

/// <summary>
/// Interfata pentru elementele din coada de playback
/// </summary>
public interface IPlayable
{
    /// <summary>
    /// Adauga un element in colectia curenta.
    /// </summary>
    /// <param name="playable">Elementul de adaugat.</param>
    public void AddPlayable(IPlayable playable);

    /// <summary>
    /// Returneaza urmatorul element, conform strategiei active.
    /// </summary>
    public IPlayable? GetNextPlayable();

    /// <summary>
    /// Seteaza strategia de redare folosita pentru selectia elementelor.
    /// </summary>
    /// <param name="playbackStrategy">Strategia de aplicat.</param>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy);
}