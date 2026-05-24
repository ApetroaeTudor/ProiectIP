using Common;
using Playback.Strategies;

namespace Playback.Playables;

/// <summary>
/// Reprezinta un cantec individual, ca element playable de baza.
/// </summary>
public class Song : IPlayable
{
    private SongInfo _songInfo;
    private bool _isPlayed = false;
    private bool _isRepeatEnabled = false;

    /// <summary>
    /// Returneaza informatiile despre cantec.
    /// </summary>
    public SongInfo GetSongInfo()
    {
        return _songInfo;
    }

    /// <summary>
    /// Initializeaza cantecul cu informatiile specificate.
    /// </summary>
    /// <param name="songInfo">Informatiile despre cantec.</param>
    public Song(SongInfo songInfo)
    {
        _songInfo = songInfo;
    }

    /// <summary>
    /// Neimplementat. Un cantec nu poate contine alte elemente redabile.
    /// </summary>
    public void AddPlayable(IPlayable playable)
    {
        // metoda nu e implementata
    }

    /// <summary>
    /// Returneaza instanta curenta. Daca repetarea este activa, se returneaza mereu.
    /// Altfel, se returneaza o singura data, apoi null.
    /// </summary>
    public IPlayable? GetNextPlayable()
    {
        if (_isRepeatEnabled)
        {
            return this;
        }

        if (!_isPlayed)
        {
            _isPlayed = true;
            return this;
        }
        
        return null;
    }

    /// <summary>
    /// Detecteaza daca strategia setata este de tip Repeat.
    /// </summary>
    /// <param name="playbackStrategy">Strategia de aplicat.</param>
    public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy)
    {
        _isRepeatEnabled = (playbackStrategy is RepeatStrategy);

        if (_isRepeatEnabled)
        {
            _isPlayed = false;
        }
    }
}