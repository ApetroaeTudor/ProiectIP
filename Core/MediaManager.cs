/**************************************************************************************************
 *                                                                                                *
 *  File:        SongInfo.cs                                                                      *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                         *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                 *
 *  Description: Clasa de tip fatada care abstractizeaza functionalitatile principale de playback *
 *************************************************************************************************/

using Windows.Media.Core;
using Windows.Storage;
using Common;
using FileManagement;
using Microsoft.Build.Tasks;
using Persistance;
using Playback;
using Playback.Playables;
using Playback.Strategies;

namespace Core;

public class MediaManager : IDisposable
{
    private PlaybackMaster _playbackMaster;
    private PlaybackQueue _queue;
    private AppDbContext _connection;
    private SongRepository _songRepository;
    private PlaylistRepository _playlistRepository;

    public MediaManager()
    {
        _queue = new PlaybackQueue();
        _playbackMaster = new PlaybackMaster();
        _playbackMaster.OnSongEnded += PlayNextSong;
        _connection = AppDbContext.Create();
        _songRepository = new SongRepository(_connection);
        _playlistRepository = new PlaylistRepository(_connection);
    }

    public async void PlayNextSong()
    {
        IPlayable next = _queue.GetNextPlayable();
        if (next is null)
        {
            // exceptie cu popup la interfata
            return;
        }
        if (next is not Song)
        {
            // ceva rau, erorare
            return;
        }
        var song = (Song)next;
        SongInfo songInfo = song.GetSongInfo();
        
        try
        {
            StorageFile songStorageFile = await FileReader.LoadSong(songInfo.FileName);
            MediaSource songMediaSource = FileProcessor.GetMediaSource(songStorageFile);
            _playbackMaster.SetSource(songMediaSource);
            _playbackMaster.Play();
        }
        catch (Exception ex)
        {
            // trb exception handling care sa ii spuna userului sa incarce cantecul 
        }
    }

    public void Pause()
    {
        _playbackMaster.Pause();
    }
    
    public void ActivateShuffle()
    {
        _queue.SetPlaybackStrategy(new ShuffleStrategy());
    }

    public void ActivateRepeat()
    {
        _queue.SetPlaybackStrategy(new RepeatStrategy());
    }

    public void ActivateSequential()
    {
        _queue.SetPlaybackStrategy(new SequentialStrategy());
    }

    public async Task AddSongToLibrary(string path)
    {
        StorageFile songStorageFile;
        if (Path.IsPathRooted(path))
        {
            songStorageFile = await FileReader.LoadNewSongAsync(path);
        }
        else
        {
            string songFileName = Path.GetFileName(path);
            songStorageFile = await FileReader.LoadSong(songFileName);
        }
        
        // save StorageFile to song repository cache
        // save SongInfo to song repository cache
        SongInfo songMetadata = await FileProcessor.GetSongInfoAsync(songStorageFile);
        await _songRepository.AddSong(songMetadata);
    }

    public async Task AddPlaylistToLibrary(string playlistName, List<SongInfo> songs)
    {
        var playlist = new PlaylistInfo{
            Id = "placeholder2",
            PlaylistName = playlistName,
            Songs = songs
        };
        await _playlistRepository.AddPlaylist(playlist);
    }

    public void AdjustVolume(double volume)
    {
        _playbackMaster.AdjustVolume(volume);
    }

    public void AddSongToQueue(string fileName)
    {
        SongInfo? songInfo = _songRepository.GetSongByFileName(Path.GetFileName(fileName));
        if (songInfo is null)
        {
            return;
            // eroare - se va arunca exceptie custom
        }
        _queue.AddPlayable(new Song(songInfo));
    }

    public void AddPlaylistToQueue(string playlistName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        if (playlistInfo is null)
        {
            return;
            // eroare - se va arunca exceptie custom
        }
        _queue.AddPlayable(new PlaybackPlaylist(playlistInfo));
    }

    public void ChangeSongPosition(double seconds)
    {
        _playbackMaster.SkipSeconds(seconds);
    }

    public void Dispose()
    {
        _playbackMaster.OnSongEnded -= PlayNextSong;
    }
}
