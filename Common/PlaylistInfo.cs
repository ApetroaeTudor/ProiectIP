/****************************************************************************************************
 *                                                                                                  *
 *  File:        PlaylistInfo.cs                                                                    *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                   *
 *  Description: Clasa de date care tine metadate, informatii relevante si un ID al playlist-urilor *
 *               PlaylistInfo este format prin agregare cu obiecte SongInfo                         *
 ***************************************************************************************************/

namespace Common;

/// <summary>
/// Inregistrare care reprezinta un playlist, continand metadatele
/// acestuia si lista cantecelor asociate ca obiecte
/// </summary>
public record PlaylistInfo
{
    /// <summary>
    /// Identificatorul unic al playlist-ului
    /// </summary>
    public required string Id { get; init; }

    /// <summary>
    /// Numele playlist-ului, afișat in interfata utilizatorului
    /// </summary>
    public string PlaylistName { get; init; } = string.Empty;

    /// <summary>
    /// Lista cantecelor care apartin acestui playlist
    /// </summary>
    public List<SongInfo> Songs { get; init; } = new();
}