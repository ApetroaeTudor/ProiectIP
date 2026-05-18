/************************************************************************************
 *                                                                                  *
 *  File:        PlaybackMaster.cs                                                  *
 *  Copyright:   (c) 2026, Apetroae Tudor                                           *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                   *
 *  Description: Clasa care gestioneaza redarea audio prin intermediul              *
 *               unui MediaPlayer                                                   *
 ************************************************************************************/

using Windows.Media.Core;
using Windows.Media.Playback;

namespace Playback;

/// <summary>
/// Gestioneaza redarea audio, inclusiv play, pauza, volum si pozitie.
/// </summary>
public class PlaybackMaster
{
    private MediaPlayer _mediaPlayer;
    public bool SongsLoaded { get; set; } = false;
    
    /// <summary>
    /// Eveniment declansat la finalul unui cantec.
    /// </summary>
    public event Action OnSongEnded;

    /// <summary>
    /// Initializeaza playerul si adauga un eveniment de sfarsit de cantec.
    /// </summary>
    public PlaybackMaster()
    {
        _mediaPlayer = new MediaPlayer();
        _mediaPlayer.MediaEnded += (sender, args) =>
        {
            OnSongEnded?.Invoke();
        };
    }

    /// <summary>
    /// Porneste redarea.
    /// </summary>
    public void Play()
    {
        _mediaPlayer.Play();
    }

    /// <summary>
    /// Pune redarea pe pauza.
    /// </summary>
    public void Pause()
    {
        _mediaPlayer.Pause();
    }

    /// <summary>
    /// Seteaza volumul playerului. Valorile sunt limitate intre 0 si 100.
    /// </summary>
    /// <param name="amount">Valoarea volumului dorit.</param>
    public void AdjustVolume(double amount)
    {
        if (amount < 0)
        {
            amount = 0;
        }

        if (amount > 100)
        {
            amount = 100;
        }
        _mediaPlayer.Volume = amount;
    }

    /// <summary>
    /// Sare cu un numar de secunde fata de pozitia curenta. Nu depaseste inceputul cantecului.
    /// </summary>
    /// <param name="seconds">Numarul de secunde de sarit (pozitiv sau negativ).</param>
    public void SkipSeconds(double seconds)
    {
        TimeSpan currentSeconds = _mediaPlayer.Position;
        TimeSpan newPosition = currentSeconds.Add(TimeSpan.FromSeconds(seconds));

        if (newPosition < TimeSpan.Zero)
        {
            newPosition = TimeSpan.Zero;
        }
        
        _mediaPlayer.Position = newPosition;
    }

    /// <summary>
    /// Seteaza sursa media pentru player.
    /// </summary>
    /// <param name="source">Sursa media de redat.</param>
    public void SetSource(MediaSource source)
    {
        _mediaPlayer.Source = source;
    }

    /// <summary>
    /// Returneaza pozitia curenta in cantecul redat
    /// </summary>
    /// <returns>
    /// Pozitia curenta ca TimeSpan, sau TimeSpan.
    /// Zero daca playerul nu este initializat
    /// </returns>
    public TimeSpan GetCurrentSongPosition()
    {
        if (_mediaPlayer?.PlaybackSession == null)
        {
            return TimeSpan.Zero;
        }

        return _mediaPlayer.PlaybackSession.Position;
    }

    /// <summary>
    /// Returneaza durata totala a cantecului curent.
    /// </summary>
    /// <returns>
    /// Durata cantecului ca TimeSpan, sau TimeSpan. Zero daca playerul nu este initializat
    /// </returns>
    public TimeSpan GetCurrentSongDuration()
    {
        if (_mediaPlayer?.PlaybackSession == null)
        {
            return TimeSpan.Zero;
        }

        return _mediaPlayer.PlaybackSession.NaturalDuration;
    }

    /// <summary>
    /// Reia redarea unui cantec aflat pe pauza
    /// </summary>
    public void Resume()
    {
        if (_mediaPlayer?.PlaybackSession == null)
        {
            return;
        }
        _mediaPlayer.Play();
    }

    /// <summary>
    /// Reseteaza playerul, eliminand sursa media incarcata si marcand starea ca fara cantec
    /// </summary>
    public void Clear()
    {
        _mediaPlayer.Source = null;
        SongsLoaded = false;
    }
}