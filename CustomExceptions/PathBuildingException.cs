/*****************************************************************************************
 *                                                                                       *
 *  File:        PathBuildingException.cs                                                *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                        *
 *  Description: Exceptie folosita pentru propagarea mesajelor multiple legate           *
 *               legate de rezolvarea path-urilor                                        *
 ****************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand constructia sau rezolvarea
/// unei cai catre un fisier sau director esueaza.
/// </summary>
public class PathBuildingException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat
    /// </summary>
    /// <param name="message">
    /// Mesajul care descrie eroarea aparuta la constructia caii
    /// </param>
    public PathBuildingException(string message) : base(message) { }

    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat
    /// si o referinta la exceptia interna
    /// </summary>
    /// <param name="message">
    /// Mesajul care descrie eroarea aparuta la constructia caii
    /// </param>
    /// <param name="innerException">
    /// Exceptia originala care a declansat aceasta eroare
    /// </param>
    public PathBuildingException(string message, Exception innerException) 
        : base(message, innerException) { }
}