/*****************************************************************************************************
 *                                                                                                   *
 *  File:        PlaybackDoneException.cs                                                            *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                            *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                    *
 *  Description: Exceptie propagata in momentul in care se termina toate cantecele incarcate, pentru *
 *               a semnala utilizatorului acest lucru                                                *
 ****************************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand coada de redare s-a golit si nu mai exista
/// cantece de redat.
/// </summary>
public class PlaybackDoneException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat.
    /// </summary>
    /// <param name="message">Mesajul care semnaleaza terminarea cantecelor din coada.</param>
    public PlaybackDoneException(string message) : base(message) { }

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
    public PlaybackDoneException(string message, Exception innerException) 
        : base(message, innerException) { }
}