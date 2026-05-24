/****************************************************************************************************
 *                                                                                                  *
 *  File:        SongRepository.cs                                                                  *
 *  Copyright:   (c) 2026, Nichifor Codrin-George                                                   *
 *  E-mail:      codirn-george.nichifor@student.tuiasi.ro                                           *
 *  Description: Clasa expune metode pentru accesul la cantecele salvate asigurand si sincronizarea *
 *               cu baza de date                                                                    *
 ***************************************************************************************************/


using Common;
using Microsoft.EntityFrameworkCore;
using Persistance;

public class SongRepository
{
    private readonly AppDbContext _context;
    private List<SongInfo> _songs;

    public SongRepository(AppDbContext context)
    {
        _context = context;
        _songs = _context.Songs.AsNoTracking().ToList();
    }
    /// <summary>
    /// Returnează un cântec după id fără a accesa baza de date
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    internal SongInfo? GetById(string id) =>
        _songs.FirstOrDefault(s => s.Id == id);
    /// <summary>
    /// Returnează un cântec după titlu fără a accesa baza de date
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    public SongInfo? GetSongByTitle(string title) =>
        _songs.FirstOrDefault(s => s.SongTitle.Equals(title, StringComparison.OrdinalIgnoreCase));
    /// <summary>
    /// Returnează un cântec după numele fiserului fără a accesa baza de date
    /// </summary>
    /// <param name="filename"></param>
    /// <returns></returns>
    public SongInfo? GetSongByFileName(string filename) =>
        _songs.FirstOrDefault(s => s.FileName.Equals(filename, StringComparison.OrdinalIgnoreCase));
    /// <summary>
    /// Adaugă asincron un cântec în baza de date
    /// </summary>
    /// <param name="song"></param>
    /// <returns></returns>
    public async Task AddSong(SongInfo song)
    {
        bool exists = await _context.Songs.AnyAsync(s => s.Id == song.Id);

        if (!exists)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        
            if (!_songs.Any(s => s.Id == song.Id))
                _songs.Add(song);
        }
    }
    /// <summary>
    /// Scoate asincron un cântec din baza de date
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task RemoveSong(string id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id);
        if (song is not null)
        {
            _context.Attach(song);             
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            _songs.Remove(song);
        }
    }
}