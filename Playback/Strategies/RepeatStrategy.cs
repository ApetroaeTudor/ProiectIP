/************************************************************************************
 *                                                                                  *
 *  File:        RepeatStrategy.cs                                                  *
 *  Copyright:   (c) 2026, Apetroae Tudor                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                   *
 *  Description: Strategie de redare care repeta primul element din lista           *
 ************************************************************************************/

using Playback.Playables;

namespace Playback.Strategies;

/// <summary>
/// Strategie de redare care repeta primul element din lista.
/// </summary>
public class RepeatStrategy : IPlaybackStrategy
{
    /// <summary>
    /// Returneaza mereu primul element din lista. Returneaza null daca lista e goala.
    /// </summary>
    /// <param name="playables">Lista de elemente redabile.</param>
    public IPlayable GetNextPlayable(List<IPlayable> playables)
    {
        if (playables.Count == 0)
        {
            return null;
        }
        
        return playables[0];
    }
}