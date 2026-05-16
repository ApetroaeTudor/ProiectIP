/**************************************************************************************************
 *                                                                                                *
 *  File:        LibraryManagementException.cs                                                    *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                         *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                 *
 *  Description: Clasa de tip exceptie personalizata, folosita pentru a propaga probleme cauzate  *
 *               de diverse probleme legate de interactiunea cu colectia de cantece/playlist-uri  *
 *************************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand apare o problema la gestionarea bibliotecii
/// de cantece sau playlist-uri.
/// </summary>
public class LibraryManagementException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat.
    /// </summary>
    /// <param name="message">Mesajul care descrie eroarea aparuta la gestionarea bibliotecii.</param>
    public LibraryManagementException(string message) : base(message) { }

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
    public LibraryManagementException(string message, Exception innerException) 
        : base(message, innerException) { }
}