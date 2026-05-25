/**************************************************************************************************
 *                                                                                                *
 *  File:        SongInfo.cs                                                                      *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                         *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                 *
 *  Description: Clasa de tip fatada care abstractizeaza functionalitatile principale de playback *
 *************************************************************************************************/

using System.Text;
using Windows.Media.Core;
using Windows.Media.Playlists;
using Windows.Storage;
using Common;
using CustomExceptions;
using FileManagement;
using Microsoft.VisualBasic.FileIO;
using Persistance;
using Playback;
using Playback.Playables;
using Playback.Strategies;
using Exception = System.Exception;

namespace Core;

/// <summary>
/// Clasa principala de management media. Gestioneaza redarea, coada de cantece si biblioteca.
/// </summary>
public class MediaManager : IDisposable
{
    private PlaybackMaster _playbackMaster;
    private PlaybackQueue _queue;
    private SongRepository _songRepository;
    private PlaylistRepository _playlistRepository;
    private bool _isSkipping = false;
    private string _currentSong = string.Empty;
    
    public string CurrentSong => _currentSong;
    public event EventHandler<PlaybackFailedException>? PlaybackErrorOccurred;
    public event EventHandler<PlaybackDoneException>? PlaybackDoneOcurred;
    public event EventHandler<SongInfo>? SongStartedEvent;
    public event EventHandler<bool> SongFinishedEvent;
        
    /// <summary>
    /// Constructor. Initializeaza componentele si conecteaza evenimentul de sfarsit de cantec.
    /// </summary>
    public MediaManager()
    {
        _queue = new PlaybackQueue();
        _playbackMaster = new PlaybackMaster();
        _playbackMaster.OnSongEnded += () =>
        {
            if (_isSkipping) return;
    
            SongFinishedEvent?.Invoke(this, true);
            PlayNextSong();
        };
        var connection = AppDbContext.Create();
        _songRepository = new SongRepository(connection);
        _playlistRepository = new PlaylistRepository(connection);
    }

    /// <summary>
    /// Preia urmatorul element din coada si il reda. Arunca exceptie daca nu mai exista cantece.
    /// </summary>
    public async void PlayNextSong()
    {
        IPlayable? next = _queue.GetNextPlayable();
        if (next is null)
        {
            _playbackMaster.SongsLoaded = false;
            PlaybackDoneOcurred?.Invoke(this, new PlaybackDoneException("Toate cantecele din queue sunt finalizate! Pentru a continua adaugati alte cantece in queue"));
            return;
        }
        if (next is not Song)
        {
            _playbackMaster.SongsLoaded = false;
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Playback esuat!"));
            return;
        }
        var song = (Song)next;
        SongInfo songInfo = song.GetSongInfo();

        try
        {
            StorageFile songStorageFile = await FileReader.LoadSong(songInfo.FileName);
            MediaSource songMediaSource = FileProcessor.GetMediaSource(songStorageFile);
            _playbackMaster.SetSource(songMediaSource);
            _playbackMaster.SongsLoaded = true;
            _currentSong = songInfo.SongTitle;
            _playbackMaster.Play();
            SongStartedEvent?.Invoke(this, songInfo); 
        }
        catch (PathBuildingException pathBuildingException)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Problema la construirea path-ului pentru a incarca un cantec din library! ", pathBuildingException));
        }
        catch (DirectoryNotFoundException directoryNotFoundException)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Problema la gasirea directorului Media, folosit pentru library! ", directoryNotFoundException));
        }
        catch (MediaManagementException mediaManagementException)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Problema la procesarea fisierului audio! ", mediaManagementException));
        }
        catch (ArgumentException argumentException)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Problema la argumentele folosite pentru procesarea fisierului audio! ", argumentException));
        }
        catch (Exception ex)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Playback esuat! ", ex));
        }
    }

    /// <summary>
    /// Sare la urmatorul cantec din coada, oprindu-l pe cel curent.
    /// </summary>
    public async Task SkipSong()
    {
        _isSkipping = true;
        _playbackMaster.Pause();
        SongFinishedEvent.Invoke(this, true);
        PlayNextSong();
        await Task.Delay(100); 
    
        _isSkipping = false;
    }

    /// <summary>
    /// Pune redarea pe pauza.
    /// </summary>
    public void Pause()
    {
        _playbackMaster.Pause();
    }

    /// <summary>
    /// Activeaza strategia de redare aleatoare.
    /// </summary>
    public void ActivateShuffle()
    {
        _queue.SetPlaybackStrategy(new ShuffleStrategy());
    }

    /// <summary>
    /// Activeaza strategia de repetare a cantecului curent.
    /// </summary>
    public void ActivateRepeat()
    {
        _queue.SetPlaybackStrategy(new RepeatStrategy());
    }

    /// <summary>
    /// Activeaza strategia de redare secventiala.
    /// </summary>
    public void ActivateSequential()
    {
        _queue.SetPlaybackStrategy(new SequentialStrategy());
    }

    /// <summary>
    /// Adauga un cantec in biblioteca, pornind de la un path absolut sau relativ.
    /// </summary>
    /// <param name="path">Calea catre fisierul audio.</param>
    public async Task AddSongToLibrary(string path)
    {
        try
        {
            StorageFile? songStorageFile = null;

            // Daca path-ul este absolut, incarca fisierul direct
            if (Path.IsPathRooted(path))
            {
                try
                {
                    songStorageFile = await FileReader.LoadNewSongAsync(path);
                }
                catch (PathBuildingException pathBuildingExceptions)
                {
                    throw new LibraryManagementException("ERROR - Nu s-a putut construi path-ul pentru a adauga un cantec in library! ", pathBuildingExceptions);
                }
                catch (IOException ioException)
                {
                    throw new LibraryManagementException("ERROR - Problema la incarcarea fisierului audio pentru a il adauga in library! ", ioException);
                }
                catch (Exception ex)
                {
                    throw new LibraryManagementException("ERROR - Eroare la incarcarea unui cantec in library! ", ex);
                }
            }
            else
            {
                // Daca path-ul este relativ, cauta fisierul in directorul Media
                try
                {
                    string songFileName = Path.GetFileName(path);
                    songStorageFile = await FileReader.LoadSong(songFileName);
                }
                catch (ArgumentException argumentException)
                {
                    throw new LibraryManagementException("ERROR - Nu s-a putut incarca fisierul in library, posibil sa nu fie incarcat in directorul Media ", argumentException);
                }
                catch (PathBuildingException pathBuildingExceptions)
                {
                    throw new LibraryManagementException("ERROR - Nu s-a putut incarca fisierul in library, path invalid! ", pathBuildingExceptions);
                }
                catch (DirectoryNotFoundException directoryNotFoundException)
                {
                    throw new LibraryManagementException("ERROR - Nu s-a putut incarca fisierul in library, nu s-a gasit directorul Media! ", directoryNotFoundException);
                }
                catch (Exception ex)
                {
                    throw new LibraryManagementException("ERROR - Nu s-a putut incarca fisierul in library! ", ex);
                }
            }

            if (songStorageFile is null)
            {
                PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Nu s-a putut adauga cantecul in library!"));
                return;
            }

            // Extrage metadatele si salveaza cantecul in baza de date
            try
            {
                SongInfo songMetadata = await FileProcessor.GetSongInfoAsync(songStorageFile);
                await _songRepository.AddSong(songMetadata);
            }
            catch (MediaManagementException mediaManagementException)
            {
                throw new LibraryManagementException("ERROR - Nu s-a putut procesa fisierul deschis! ", mediaManagementException);
            }
            catch (DatabaseConnectionException databaseConnectionException)
            {
                throw new LibraryManagementException("ERROR - Nu s-au putut persista date despre cantecul adaugat! ", databaseConnectionException);
            }
            catch (Exception ex)
            {
                throw new LibraryManagementException("ERROR - Problema la adaugarea datelor despre cantec in library! ", ex);
            }
        }
        catch (ArgumentException argumentException)
        {
            throw new LibraryManagementException("ERROR - Problema la verificarea path-ului trimis pentru adaugarea datelor despre cantec in library! ", argumentException);
        }
        catch (Exception e)
        {
            throw new LibraryManagementException("ERROR - Problema la adaugarea unui cantec in library! ", e);
        }
    }

    /// <summary>
    /// Creeaza un playlist din lista de cantece si il salveaza in biblioteca.
    /// </summary>
    /// <param name="playlistName">Numele playlistului.</param>
    /// <param name="songs">Lista de cantece incluse.</param>
    public async Task AddPlaylistToLibrary(string playlistName, List<SongInfo> songs)
    {
        PlaylistInfo? playlistInfo = null;
        try
        {
            playlistInfo = new PlaylistInfo
            {
                Id = Hasher.GetHash(playlistName),
                PlaylistName = playlistName,
                Songs = songs
            };
        }
        catch (EncoderFallbackException encoderFallbackException)
        {
            throw new LibraryManagementException("ERROR - Problema la crearea id-ului de playlist! ", encoderFallbackException);
        }
        catch (ArgumentException argumentException)
        {
            throw new LibraryManagementException("ERROR - Problema la crearea unui playlist, argumente invalide! ", argumentException);
        }
        catch (Exception ex)
        {
            throw new LibraryManagementException("ERROR - Problema la crearea unui playlist! ", ex);
        }

        if (playlistInfo is null)
        {
            throw new LibraryManagementException("ERROR - Could not add playlist to library, failed to create playlistInfo object!");
        }

        // Salveaza playlistul in baza de date
        try
        {
            await _playlistRepository.AddPlaylist(playlistInfo);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new LibraryManagementException("ERROR - Problema la salvarea unui playlist, la gestionarea conexiunii la baza de date! ", databaseOperationException);
        }
        catch (DatabaseConnectionException databaseConnectionException)
        {
            throw new LibraryManagementException("ERROR - Problema la salvarea unui playlist, la efectuarea unei operatii cu baza de date! ", databaseConnectionException);
        }
        catch (Exception ex)
        {
        }
    }

    /// <summary>
    /// Ajusteaza volumul redarii.
    /// </summary>
    /// <param name="volume">Valoarea volumului dorit.</param>
    public void AdjustVolume(double volume)
    {
        _playbackMaster.AdjustVolume(volume);
    }

    /// <summary>
    /// Adauga un cantec din biblioteca in coada de redare.
    /// </summary>
    /// <param name="fileName">Numele fisierului audio.</param>
    public void AddSongToQueue(string fileName)
    {
        SongInfo? songInfo = _songRepository.GetSongByFileName(Path.GetFileName(fileName));
        if (songInfo is null)
        {
            throw new LibraryManagementException("ERROR - Nu se poate adauga un cantec null in queue!");
        }

        try
        {
            _queue.AddPlayable(new Song(songInfo));
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new LibraryManagementException("ERROR - Problema la salvarea unui cantec la coada, la gestionarea conexiunii la baza de date! ", databaseOperationException);
        }
        catch (DatabaseConnectionException databaseConnectionException)
        {
            throw new LibraryManagementException("ERROR - Problema la salvarea unui cantec la coada, la efectuarea unei operatii cu baza de date! ", databaseConnectionException);
        }
        catch (Exception ex)
        {
            throw new LibraryManagementException("ERROR - Problema la salvarea unui cantec la coada! ", ex);
        }
    }

    /// <summary>
    /// Adauga un playlist din biblioteca in coada de redare, cantec cu cantec.
    /// </summary>
    /// <param name="playlistName">Numele playlistului de adaugat.</param>
    public void AddPlaylistToQueue(string playlistName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        if (playlistInfo is null)
        {
            throw new LibraryManagementException("ERROR - Nu se poate adauga un playlist null in queue!");
        }
        PlaybackPlaylist playlistToAdd = new PlaybackPlaylist(playlistInfo);
        try
        {
            // Adauga fiecare cantec gasit in repository in playlist
            foreach(var song in playlistInfo.Songs)
            {
                var foundSong = _songRepository.GetSongByFileName(song.FileName);
                if (foundSong is not null)
                {
                    playlistToAdd.AddPlayable(new Song(foundSong));
                }
            }      
        
            _queue.AddPlayable(playlistToAdd);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new LibraryManagementException("ERROR - Problema la adaugarea unui cantec din repository in playlist, la gestionarea conexiunii la baza de date! ", databaseOperationException);
        }
        catch (DatabaseConnectionException databaseConnectionException)
        {
            throw new LibraryManagementException("ERROR - Problema la adaugarea unui cantec din repository in playlist, la efectuarea unei operatii cu baza de date! ", databaseConnectionException);
        }
        catch (Exception ex)
        {
            throw new LibraryManagementException("ERROR - Problema la adaugarea unui cantec din repository in playlist! ", ex);
        }
    }

    /// <summary>
    /// Adauga un cantec intr-un playlist existent din library
    /// </summary>
    /// <param name="playlistName">Numele playlistului in care se adauga cantecul.</param>
    /// <param name="songName">Numele fisierului audio de adaugat.</param>
    public async Task AddSongToPlaylist(string playlistName, string songName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        SongInfo? songInfo = _songRepository.GetSongByFileName(songName);
        if (songInfo is null)
        {
            throw new MediaManagementException("Nu se poate adauga un cantec inexistent in playlist");
        }

        try
        {
            await _playlistRepository.AddSongToPlaylist(playlistInfo.Id, songInfo.Id, _songRepository);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new LibraryManagementException("Nu a reusit adaugarea cantecului in playlist ", databaseOperationException);
        }
    }

    /// <summary>
    /// Sterge un cantec din library si din toate playlisturile care il contin.
    /// </summary>
    /// <param name="fileName">Numele fisierului audio de sters.</param>
    public void RemoveSongFromLibrary(string fileName)
    {
        SongInfo? songInfo = _songRepository.GetSongByFileName(fileName);
        if (songInfo == null)
        {
            throw new MediaManagementException("Nu se poate sterge un cantec care nu exista inainte");
        }

        try
        {
            _songRepository.RemoveSong(songInfo.Id);
            _playlistRepository.RemoveSongFromMemory(songInfo.Id);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new MediaManagementException("Nu a reusit stergerea cantecului din library ", databaseOperationException);
        }
    }

    /// <summary>
    /// Redenumeste un playlist existent din library
    /// </summary>
    /// <param name="oldName">Numele curent al playlistului</param>
    /// <param name="newName">Noul nume al playlistului</param>
    public async Task RenamePlaylist(string oldName, string newName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(oldName);
        if (playlistInfo == null)
        {
            throw new MediaManagementException("Nu se poate redenumi un playlist care nu exista inainte");
        }
        var updatedPlaylist = playlistInfo with { PlaylistName = newName };
        try
        {
            await _playlistRepository.RemovePlaylist(playlistInfo.Id);
            await _playlistRepository.AddPlaylist(updatedPlaylist);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new LibraryManagementException($"Nu a reusit redenumirea playlist-ului {oldName} in {newName}", databaseOperationException);
        }
    }

    /// <summary>
    /// Sterge un playlist din library
    /// </summary>
    /// <param name="playlistName">Numele playlistului de sters</param>
    public async Task DeletePlaylist(string playlistName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        if (playlistInfo == null)
        {
            throw new MediaManagementException($"Nu se poate sterge playlist-ul {playlistName}, el nu a fost gasit");
        }

        try
        {
            await _playlistRepository.RemovePlaylist(playlistInfo.Id);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new MediaManagementException($"Eroare la stergerea playlist-ului {playlistName}", databaseOperationException);
        }
    }

    /// <summary>
    /// Sterge un cantec dintr-un playlist existent
    /// </summary>
    /// <param name="playlistName">Numele playlistului din care se sterge cantecul</param>
    /// <param name="songName">Numele fisierului audio de sters</param>
    public async Task RemoveSongFromPlaylist(string playlistName, string songName)
    {
        PlaylistInfo playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        if (playlistInfo == null)
        {
            throw new MediaManagementException($"Playlist-ul {playlistName} nu exista");
        }

        try
        {
            _playlistRepository.RemoveSongFromPlaylist(playlistInfo.Id, songName);
        }
        catch (DatabaseOperationException databaseOperationException)
        {
            throw new MediaManagementException($"Nu s-a reusit stergerea cantecului din playlist");
        }
    }

    /// <summary>
    /// Returneaza lista de cantece dintr-un playlist
    /// </summary>
    /// <param name="playlistName">Numele playlistului interogat</param>
    /// <returns>Lista de cantece din playlist</returns>
    public List<SongInfo> GetPlaylistSongs(string playlistName)
    {
        PlaylistInfo? playlistInfo = _playlistRepository.GetPlaylistByName(playlistName);
        if (playlistInfo == null)
        {
            throw new MediaManagementException($"Nu s-a reusit gasirea playlist-ului {playlistName}");
        }
        return playlistInfo.Songs;
    }

    /// <summary>
    /// Returneaza pozitia curenta in cantecul redat
    /// </summary>
    /// <returns>Pozitia curenta ca TimeSpan</returns>
    public TimeSpan GetCurrentSongPosition()
    {
        try
        {
            return _playbackMaster.GetCurrentSongPosition();
        }
        catch (Exception exception)
        {
            throw new MediaManagementException("Nu se poate obtine pozitia curenta in cantec, eroare din audio player ", exception);
        }
    }

    /// <summary>
    /// Returneaza durata totala a cantecului curent
    /// </summary>
    /// <returns>Durata cantecului ca TimeSpan</returns>
    public TimeSpan GetCurrentSongDuration()
    {
        try
        {
            return _playbackMaster.GetCurrentSongDuration();
        }
        catch (Exception exception)
        {
            throw new MediaManagementException("Nu se poate obtine durata cantecului, eroare din audio player ", exception);
        }
    }

    /// <summary>
    /// Reia redarea unui cantec aflat pe pauza
    /// </summary>
    public void Resume()
    {
        try
        {
            _playbackMaster.Resume();
        }
        catch (Exception exception)
        {
            throw new MediaManagementException("Nu se poate obtine da resume cantecului, eroare din audio player ", exception);
        }
    }

    /// <summary>
    /// Verifica daca exista un cantec incarcat in player
    /// </summary>
    /// <returns>True daca exista un cantec incarcat, false altfel</returns>
    public bool HasCurrentSong()
    {
        try
        {
            return _playbackMaster.SongsLoaded;
        }
        catch (Exception exception)
        {
            throw new MediaManagementException("Eroare la verificarea daca exista un cantec in media player ", exception);
        }
    }
    
    /// <summary>
    /// Goleste coada de redare si reseteaza playerul audio
    /// </summary>
    public void ClearQueue()
    {
        _queue.Clear();
        _playbackMaster.Clear();
    }

    /// <summary>
    /// Sare la o pozitie in cantecul curent, cu numarul de secunde specificat.
    /// </summary>
    /// <param name="seconds">Numarul de secunde de sarit (pozitiv sau negativ).</param>
    public void ChangeSongPosition(double seconds)
    {
        _playbackMaster.SkipSeconds(seconds);
    }

    /// <summary>
    /// Elibereaza resursele si detaseaza evenimentul de sfarsit de cantec.
    /// </summary>
    public void Dispose()
    {
        _playbackMaster.OnSongEnded -= PlayNextSong;
    }
}