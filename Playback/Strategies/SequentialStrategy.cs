/************************************************************************************
 *                                                                                  *
 *  File:        SequentialStrategy.cs                                              *
 *  Copyright:   (c) 2026, Apetroae Tudor                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                   *
 *  Description: Strategie de redare secventiala, care parcurge elementele          *
 *               in ordinea din lista                                               *
 ************************************************************************************/

using Playback.Playables;

namespace Playback.Strategies;

/// <summary>
/// Strategie de redare secventiala, care parcurge elementele in ordinea din lista.
/// </summary>
public class SequentialStrategy : IPlaybackStrategy
{
    /// <summary>
    /// Returneaza primul element din lista si il elimina. Returneaza null daca lista e goala.
    /// </summary>
    /// <param name="playables">Lista de elemente redabile.</param>
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