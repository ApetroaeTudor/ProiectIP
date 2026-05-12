/***********************************************************************************************
 *                                                                                             *
 *  File:        SongInfo.cs                                                                   *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                      *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                              *
 *  Description: Clasa de date care tine metadate, informatii relevante si un ID al cantecelor *
 **********************************************************************************************/

namespace Common;

/// <summary>
/// Inregistrare care contine metadatele unui cantec extrase din fisierul audio
/// </summary>
public record SongInfo
{
    /// <summary>
    /// Identificatorul generat ca hash SHA-256 din numele fisierului, titlu si artist
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Titlul cantecului extras din tag-urile fisierului audio
    /// </summary>
    public string SongTitle { get; init; } = string.Empty;

    /// <summary>
    /// Numele artistului extras din tag-urile fisierului audio
    /// </summary>
    public string Artist { get; init; } = string.Empty;

    /// <summary>
    /// Numele albumului extras din tag-urile fisierului audio
    /// </summary>
    public string Album { get; init; } = string.Empty;

    /// <summary>
    /// Durata cantecului exprimata in secunde intregi
    /// </summary>
    public int DurationSecs { get; init; } = 0;

    /// <summary>
    /// Numele fisierului audio (cu extensie), extras din calea completa a acestuia
    /// </summary>
    public string FileName { get; init; } = string.Empty;
}