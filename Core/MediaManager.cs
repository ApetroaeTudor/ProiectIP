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
using Playback;
using Playback.Playables;
using Playback.Strategies;

namespace Core;

public class MediaManager : IDisposable
{
    private PlaybackMaster _playbackMaster;
    private PlaybackQueue _queue;

    public MediaManager()
    {
        _queue = new PlaybackQueue();
        _playbackMaster = new PlaybackMaster();
        _playbackMaster.OnSongEnded += PlayNextSong;
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

        // if (_songRepository.getSongByFileName(songInfo.FileName))
        // {
        //     
        // }

        // daca nu e in repository, da load local
        try
        {
            StorageFile songStorageFile = await FileReader.LoadSong(songInfo.FileName);
            MediaSource songMediaSource = FileProcessor.GetMediaSource(songStorageFile);
            _playbackMaster.SetSource(songMediaSource);
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

    public async void AddSongToLibrary(string path)
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
    }

    public void Dispose()
    {
        if (_playbackMaster != null)
        {
            _playbackMaster.OnSongEnded -= PlayNextSong;
        }
    }
}
