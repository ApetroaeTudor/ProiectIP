/**************************************************************************************************
 *                                                                                                *
 *  File:        SongInfo.cs                                                                      *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                         *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                 *
 *  Description: Clasa de tip fatada care abstractizeaza functionalitatile principale de playback *
 *************************************************************************************************/

using System.Text;
using Windows.Media.Core;
using Windows.Storage;
using Common;
using CustomExceptions;
using FileManagement;
using Persistance;
using Playback;
using Playback.Playables;
using Playback.Strategies;

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
    
    public event EventHandler<PlaybackFailedException>? PlaybackErrorOccurred;
    public event EventHandler<PlaybackDoneException>? PlaybackDoneOcurred; 

    /// <summary>
    /// Constructor. Initializeaza componentele si conecteaza evenimentul de sfarsit de cantec.
    /// </summary>
    public MediaManager()
    {
        _queue = new PlaybackQueue();
        _playbackMaster = new PlaybackMaster();
        _playbackMaster.OnSongEnded += PlayNextSong;
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
            PlaybackDoneOcurred?.Invoke(this, new PlaybackDoneException("Toate cantecele din queue sunt finalizate! Pentru a continua adaugati alte cantece in queue"));
        }
        if (next is not Song)
        {
            PlaybackErrorOccurred?.Invoke(this, new PlaybackFailedException("ERROR - Playback esuat!"));
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
            // throw new LibraryManagementException("ERROR - Problema la salvarea unui playlist! ", ex);
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