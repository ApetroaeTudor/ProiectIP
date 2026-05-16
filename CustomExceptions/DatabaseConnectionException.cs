/**************************************************************************************************
 *                                                                                                *
 *  File:        DatabaseConnectionException.cs                                                   *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                         *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                 *
 *  Description: Clasa de tip exceptie personalizata, folosita pentru a propaga probleme de tip   *
 *                conexiune la baza de date                                                       *
 *************************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand apare o problema de conexiune la baza de date.
/// </summary>
public class DatabaseConnectionException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat.
    /// </summary>
    /// <param name="message">Mesajul care descrie eroarea de conexiune.</param>
    public DatabaseConnectionException(string message) : base(message) { }

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
    public DatabaseConnectionException(string message, Exception innerException) 
        : base(message, innerException) { }
}