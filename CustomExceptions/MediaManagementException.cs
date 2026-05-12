/*********************************************************************************************
 *                                                                                           *
 *  File:        MediaManagementException.cs                                                 *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                    *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                            *
 *  Description: Exceptie folosita pentru a transmite informatii de eroare despre procesarea *
 *               fisierelor cu informatie despre playback                                    *
 ********************************************************************************************/

namespace CustomExceptions;

/// <summary>
/// Exceptie personalizata aruncata atunci cand procesarea unui fisier media esueaza,
/// incluzand situatii precum fisiere invalide, lipsa metadatelor sau erori
/// la crearea sursei de redare
/// </summary>
public class MediaManagementException : Exception
{
    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat
    /// </summary>
    /// <param name="message">
    /// Mesajul care descrie eroarea aparuta la procesarea fisierului media
    /// </param>
    public MediaManagementException(string message) : base(message) { }

    /// <summary>
    /// Initializeaza o noua instanta a clasei cu un mesaj de eroare specificat
    /// si o referinta la exceptia interna
    /// </summary>
    /// <param name="message">
    /// Mesajul care descrie eroarea aparuta la procesarea fisierului media
    /// </param>
    /// <param name="innerException">
    /// Exceptia originala care a declansat aceasta eroare
    /// </param>
    public MediaManagementException(string message, Exception innerException) 
        : base(message, innerException) { }
}