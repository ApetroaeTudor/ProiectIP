/*********************************************************************************************
 *                                                                                           *
 *  File:        FileProcessor.cs                                                            *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                    *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                            *
 *  Description: Utilitar care se ocupa de obtinerea informatiilor din fisierul primit.      *
 *               Informatiile sunt folosite la playback, la afisarea informatiilor despre    *
 *               cantece si la stocarea informatiilor despre cantece.                        *
 ********************************************************************************************/

using Windows.Media.Core;
using Windows.Storage;
using Common;
using CustomExceptions;

namespace FileManagement;

/// <summary>
/// Clasa statica utilitara pentru extragerea informatiilor dintr-un fisier audio
/// </summary>
public static class FileProcessor
{
    /// <summary>
    /// Creeaza un obiect MediaSource din fisierul de stocare primit
    /// </summary>
    /// <param name="file">
    /// Fisierul audio de tip StorageFile din care se construieste sursa media
    /// </param>
    /// <returns>
    /// Un obiect MediaSource creat din fisierul primit
    /// </returns>
    /// <exception cref="MediaManagementException">
    /// Aruncata in urmatoarele situatii:
    /// <list type="bullet">
    /// <item><description>Tipul fisierului nu este suportat ca sursa media</description></item>
    /// <item><description>Fisierul nu a fost gasit pe disc</description></item>
    /// <item><description>Orice alta eroare neasteptata aparuta la crearea sursei media</description></item>
    /// </list>
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Aruncata direct cand parametrul file este null.
    /// </exception>
    public static MediaSource GetMediaSource(StorageFile file)
    {
        try
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }
            return MediaSource.CreateFromStorageFile(file);
        }
        catch (ArgumentException argNullException)
        {
            throw new MediaManagementException("ERROR - tip de fisier invalid", argNullException);
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            throw new MediaManagementException("ERROR - fisierul nu a fost gasit", fileNotFoundException);
        }
        catch (Exception exception)
        {
            throw new MediaManagementException($@"ERROR - {exception.Message}", exception);
        }
    }

    /// <summary>
    /// Extrage asincron metadatele unui fisier audio si le returneaza ca obiect SongInfo
    /// </summary>
    /// <param name="file">
    /// Fisierul audio de tip StorageFiledin care se citesc proprietatile muzicale
    /// </param>
    /// <returns>
    /// Un obiect SongInfo populat cu datele extrase din fisier
    /// </returns>
    /// <exception cref="MediaManagementException">
    /// Aruncata in urmatoarele situatii:
    /// <list type="bullet">
    /// <item><description>Fisierul nu contine proprietati muzicale</description></item>
    /// <item><description>Fisierul nu a fost gasit pe disc</description></item>
    /// <item><description>Orice alta eroare neasteptata aparuta la citirea proprietatilor</description></item>
    /// </list>
    /// </exception>
    public static async Task<SongInfo> GetSongInfoAsync(StorageFile file)
    {
        try
        {
            var musicProperties = await file.Properties.GetMusicPropertiesAsync();
            if (musicProperties is null)
            {
                throw new MediaManagementException("ERROR - nu exista proprietati despre muzica in acest fisier");
            }

            string title = musicProperties.Title;
            string artist = musicProperties.Artist;
            string album = musicProperties.Album;
            int duration = (int)musicProperties.Duration.TotalSeconds;
            string fileName = Path.GetFileName(file.Path);

            string hash = Hasher.GetHash($"{fileName}${title}${artist}");

            return new SongInfo
            {
                Id = hash,
                SongTitle = title,
                Artist = artist,
                Album = album,
                DurationSecs = duration,
                FileName = fileName
            };
        }
        catch (FileNotFoundException fileNotFoundException)
        {
            throw new MediaManagementException("ERROR - fisierul nu a fost gasit", fileNotFoundException);
        }
        catch (MediaManagementException mediaManagementException)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new MediaManagementException($@"ERROR - {exception.Message}", exception);
        }
    }
}