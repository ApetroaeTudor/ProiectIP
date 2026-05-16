/************************************************************************************
 *                                                                                  *
 *  File:        ShuffleStrategy.cs                                                 *
 *  Copyright:   (c) 2026, Apetroae Tudor                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                   *
 *  Description: Strategie de redare aleatoare, care selecteaza elementele          *
 *               in ordine random din lista                                         *
 ************************************************************************************/

using Playback.Playables;

namespace Playback.Strategies;

/// <summary>
/// Strategie de redare aleatoare, care selecteaza elementele in ordine random.
/// </summary>
public class ShuffleStrategy : IPlaybackStrategy
{
    /// <summary>
    /// Returneaza un element ales aleator din lista si il elimina. Returneaza null daca lista e goala.
    /// </summary>
    /// <param name="playables">Lista de elemente redabile.</param>
    public IPlayable GetNextPlayable(List<IPlayable> playables)
    {
        if (playables.Count == 0)
        {
            return null;
        }
        
        int index = new Random().Next(0, playables.Count);
        IPlayable song = playables[index];
        playables.RemoveAt(index);
        return song;
    }
}