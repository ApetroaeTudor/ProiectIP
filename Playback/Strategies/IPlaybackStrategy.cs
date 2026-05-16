/************************************************************************************
 *                                                                                  *
 *  File:        IPlaybackStrategy.cs                                               *
 *  Copyright:   (c) 2026, Apetroae Tudor                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                   *
 *  Description: Interfata pentru strategiile de redare. Ofera posibilitatea de a   *
 *               defini care e urmatorul cantec in playback                         *
 ************************************************************************************/

using Playback.Playables;

namespace Playback.Strategies;

/// <summary>
/// Interfata pentru strategiile de selectie a urmatorului element playable.
/// </summary>
public interface IPlaybackStrategy
{
    /// <summary>
    /// Returneaza urmatorul element redabil din lista, conform strategiei implementate.
    /// </summary>
    /// <param name="songs">Lista de elemente redabile disponibile.</param>
    IPlayable GetNextPlayable(List<IPlayable> songs);
}