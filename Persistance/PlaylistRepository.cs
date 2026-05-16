/****************************************************************************************************
 *                                                                                                  *
 *  File:        SongRepository.cs                                                                  *
 *  Copyright:   (c) 2026, Nichifor Codrin-George                                                   *
 *  E-mail:      codirn-george.nichifor@student.tuiasi.ro                                           *
 *  Description: Clasa expune metode pentru accesul la playlisturile salvate asigurand si           *
 *               sincronizarea cu baza de date                                                      *
 ***************************************************************************************************/

using Common;
using Microsoft.EntityFrameworkCore;
using Persistance;

public class PlaylistRepository
{
    private readonly AppDbContext _context;
    private List<PlaylistInfo> _playlists;

    public PlaylistRepository(AppDbContext context)
    {
        _context = context;
        _playlists = _context.Playlists.Include(p => p.Songs).ToList();
    }

    public PlaylistInfo? GetPlaylistById(string id) =>
        _playlists.FirstOrDefault(p => p.Id == id);

    public PlaylistInfo? GetPlaylistByName(string name) =>
        _playlists.FirstOrDefault(p => p.PlaylistName.Equals(name, StringComparison.OrdinalIgnoreCase));

    public List<SongInfo> GetSongsInPlaylist(string playlistId) =>
        _playlists.FirstOrDefault(p => p.Id == playlistId)?.Songs.ToList() ?? new();

    public async Task AddPlaylist(PlaylistInfo playlist)
    {
        _playlists.Add(playlist);
        _context.Playlists.Add(playlist);
        await _context.SaveChangesAsync();
    }

    public async Task AddSongToPlaylist(string playlistId, string songId, SongRepository songRepo)
    {
        var playlist = _playlists.FirstOrDefault(p => p.Id == playlistId);
        var song = songRepo.GetById(songId);

        if (playlist is not null && song is not null)
        {
            if (!playlist.Songs.Contains(song))
            {
                playlist.Songs.Add(song);
                await _context.SaveChangesAsync();
            }
        }
    }


    public async Task RemoveSongFromPlaylist(string playlistId, string songId)
    {
        var playlist = _playlists.FirstOrDefault(p => p.Id == playlistId);
        var song = playlist?.Songs.FirstOrDefault(s => s.Id == songId);

        if (song is not null)
        {
            playlist!.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }

    public async Task RemovePlaylist(string id)
    {
        var playlist = _playlists.FirstOrDefault(p => p.Id == id);
        if (playlist is not null)
        {
            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();
            _playlists.Remove(playlist);
        }
    }
}
