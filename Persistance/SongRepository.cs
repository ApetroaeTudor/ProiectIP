/****************************************************************************************************
 *                                                                                                  *
 *  File:        SongRepository.cs                                                                  *
 *  Copyright:   (c) 2026, Nichifor Codrin-George                                                   *
 *  E-mail:      codirn-george.nichifor@student.tuiasi.ro                                           *
 *  Description: Clasa expune metode pentru accesul la cantecele salvate asigurand si sincronizarea *
 *               cu baza de date                                                                    *
 ***************************************************************************************************/


using Common;
using Persistance;

public class SongRepository
{
    private readonly AppDbContext _context;
    private List<SongInfo> _songs;

    public SongRepository(AppDbContext context)
    {
        _context = context;
        _songs = _context.Songs.ToList();
    }

    internal SongInfo? GetById(string id) =>
        _songs.FirstOrDefault(s => s.Id == id);

    public SongInfo? GetSongByTitle(string title) =>
        _songs.FirstOrDefault(s => s.SongTitle.Equals(title, StringComparison.OrdinalIgnoreCase));


    public SongInfo? GetSongByFileName(string filename) =>
        _songs.FirstOrDefault(s => s.FileName.Equals(filename, StringComparison.OrdinalIgnoreCase));
    
    public async Task AddSong(SongInfo song)
    {
        var ctx = AppDbContext.Create();
        
        if (!_songs.Contains(song))
        {
            ctx.Songs.Add(song);
            await _context.SaveChangesAsync();
            ctx.Add(song);
        }
    }

    public async Task RemoveSong(string id)
    {
        var song = _songs.FirstOrDefault(s => s.Id == id);
        if (song is not null)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            _songs.Remove(song);
        }
    }
}