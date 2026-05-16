/*****************************************************************************************************
 *                                                                                                   *
 *  File:        PlaybackFailedException.cs                                                          *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                            *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                    *
 *  Description: Exceptie propagata in momentul in care apare o problema la playback                 *
 ****************************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand redarea unui cantec esueaza.
/// </summary>
public class PlaybackFailedException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat.
    /// </summary>
    /// <param name="message">Mesajul care descrie eroarea aparuta la redare.</param>
    public PlaybackFailedException(string message) : base(message) { }

    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat
    /// si o referinta la exceptia interna.
    /// </summary>
    /// <param name="message">
    /// Mesajul care descrie eroarea aparuta la constructia caii
    /// </param>
    /// <param name="innerException">
    /// Exceptia originala care a declansat aceasta eroare
    /// </param>
    public PlaybackFailedException(string message, Exception innerException) 
        : base(message, innerException) { }
}