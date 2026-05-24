/****************************************************************************************************
 *                                                                                                  *
 *  File:        SongRepository.cs                                                                  *
 *  Copyright:   (c) 2026, Nichifor Codrin-George                                                   *
 *  E-mail:      codirn-george.nichifor@student.tuiasi.ro                                           *
 *  Description: Clasa expune metode pentru accesul la playlisturile salvate asigurand si           *
 *               sincronizarea cu baza de date                                                      *
 ***************************************************************************************************/

using Common;
using CustomExceptions;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Windows.UI.WebUI;

public class PlaylistRepository
{
    private readonly AppDbContext _context;
    private List<PlaylistInfo> _playlists;

    public PlaylistRepository(AppDbContext context)
    {
        try
        {
            _context = context;
            _playlists = _context.Playlists.Include(p => p.Songs).AsNoTracking().ToList();
        }
        catch (Exception ex)
        {
            throw new DatabaseConnectionException("ERROR - eroare la creearea PlaylistRepo", ex);
        }
    }
    /// <summary>
    /// Returnează playlistul cu id-ul dat ca parametru fără să acceseze baza de date
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public PlaylistInfo? GetPlaylistById(string id)
    {
        try
        {
            return _playlists.FirstOrDefault(p => p.Id == id);
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la accesarea playlistului", ex);
        }
    }

    /// <summary>
    /// Returnează playlistul cu numele dat ca parametru fără să acceseze baza de date
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public PlaylistInfo? GetPlaylistByName(string name)
    {
        try
        {
            return _playlists.FirstOrDefault(p => p.PlaylistName.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la accesarea playlistului", ex);
        }
    }

    /// <summary>
    /// Returnează cântecele din playlist fără să acceseze baza de date
    /// </summary>
    /// <param name="playlistId"></param>
    /// <returns></returns>
    public List<SongInfo> GetSongsInPlaylist(string playlistId)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(playlistId))
                throw new ArgumentException("ID-ul playlistului nu poate fi gol", nameof(playlistId));

            return _playlists.FirstOrDefault(p => p.Id == playlistId)?.Songs.ToList() ?? new();
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la accesarea cântecelor", ex);
        }
    }

    /// <summary>
    /// Adaugă asincron un playlist în baza de date
    /// </summary>
    /// <param name="playlist"></param>
    /// <returns></returns>
    /// <exception cref="DatabaseOperationException"></exception>
    public async Task AddPlaylist(PlaylistInfo playlist)
    {
        try
        {
            bool alreadyExists = await _context.Playlists.AnyAsync(p => p.Id == playlist.Id);
        
            if (!alreadyExists)
            {
                foreach (var song in playlist.Songs)
                {
                    var trackedSong = _context.Songs.Local.FirstOrDefault(s => s.Id == song.Id);
                    if (trackedSong == null)
                    {
                        _context.Songs.Attach(song);
                    }
                }
                _context.Playlists.Add(playlist);
                await _context.SaveChangesAsync();
            }

            if (!_playlists.Any(p => p.Id == playlist.Id))
            {
                _playlists.Add(playlist);
            }
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - nu a reusit salvarea playlist-ului! ",ex);
        }
    }
    /// <summary>
    /// Adaugă asincron un cântec într-un playlist
    /// </summary>
    /// <param name="playlistId"></param>
    /// <param name="songId"></param>
    /// <param name="songRepo"></param>
    /// <returns></returns>
    public async Task AddSongToPlaylist(string playlistId, string songId, SongRepository songRepo)
    {
        try
        {
            var playlist = _playlists.FirstOrDefault(p => p.Id == playlistId);
            var song = songRepo.GetById(songId);

            if (playlist is not null && song is not null)
            {
                if (!playlist.Songs.Any(s => s.Id == songId))
                {
                    try
                    {
                        if (_context.Entry(playlist).State == EntityState.Detached)
                        {
                            _context.Playlists.Attach(playlist);
                        }

                        if (_context.Entry(song).State == EntityState.Detached)
                        {
                            _context.Songs.Attach(song);
                        }

                        playlist.Songs.Add(song);

                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        playlist.Songs.Remove(song);
                        Console.WriteLine($"Eroare: {ex.Message}");
                        throw;
                    }
                    finally
                    {
                        _context.Entry(playlist).State = EntityState.Detached;
                        _context.Entry(song).State = EntityState.Detached;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new DatabaseConnectionException("ERROR - eroare de tip neidentificat", ex);
        }
    }
    /// <summary>
    /// Scoate asincron un cântec dintr-un playlist
    /// </summary>
    /// <param name="playlistId"></param>
    /// <param name="songId"></param>
    /// <returns></returns>
    public async Task RemoveSongFromPlaylist(string playlistId, string songId)
    {
        try
        {
            var playlist = _playlists.FirstOrDefault(p => p.Id == playlistId);
            var song = playlist?.Songs.FirstOrDefault(s => s.Id == songId);

            if (playlist is not null && song is not null)
            {
                _context.Attach(playlist);
                _context.Attach(song);
                playlist.Songs.Remove(song);
                await _context.SaveChangesAsync();
                _context.Entry(playlist).State = EntityState.Detached;
                _context.Entry(song).State = EntityState.Detached;
            }
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la ștergerea unui cântec", ex);
        }
    }
    /// <summary>
    /// Șterge asincron un playlist din baza de date
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task RemovePlaylist(string id)
    {
        try
        {
            var playlist = _playlists.FirstOrDefault(p => p.Id == id);
            if (playlist is not null)
            {
                _context.Attach(playlist);
                _context.Playlists.Remove(playlist);
                await _context.SaveChangesAsync();
                _playlists.Remove(playlist);
            }
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la ștergerea unui playlist", ex);
        }
    }
    /// <summary>
    /// Șterge un cântec din memorie
    /// </summary>
    /// <param name="songId"></param>
    public void RemoveSongFromMemory(string songId)
    {
        try
        {
            foreach (var playlist in _playlists)
            {
                var songToRemove = playlist.Songs.FirstOrDefault(s => s.Id == songId);
                if (songToRemove != null)
                {
                    playlist.Songs.Remove(songToRemove);
                }
            }
        }
        catch (Exception ex)
        {
            throw new DatabaseOperationException("ERROR - eroare la ștergerea unui cântec din memorie", ex);
        }
    }
}
