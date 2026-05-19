/********************************************************************************************************
 *                                                                                                      *
 *  File:        FileReader.cs                                                                          *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                               *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                                       *
 *  Description: Clasa statica utilitara care se ocupa cu deschiderea si copierea fisierelor de pe disc *
 *                                                                                                      *
 ********************************************************************************************************/

using Windows.Storage;
using CustomExceptions;

namespace FileManagement;

/// <summary>
/// Clasa statica utilitara pentru incarcarea si copierea fisierelor de pe disc.
/// Furnizeaza metode pentru localizarea directorului Media, copierea
/// fisierelor audio noi si incarcarea fisierelor existente ca obiecte StorageFile.
/// </summary>
public static class FileReader
{
    /// <summary>
    /// Construieste calea absoluta catre un fisier din directorul Media
    /// </summary>
    /// <param name="fileName">
    /// Numele fisierului specificat
    /// </param>
    /// <returns>
    /// Calea absoluta completa catre fisierul specificat in directorul Media
    /// </returns>
    /// <exception cref="DirectoryNotFoundException">
    /// Aruncata cand nu se gaseste niciun director "Media" in ierarhia de directoare
    /// </exception>
    /// <exception cref="PathBuildingException">
    /// Aruncata cand argumentele transmise sunt nule, invalide sau calea rezultata
    /// este prea lunga pentru sistemul de operare.
    /// </exception>
    public static string GetSpecifiedDirPath(string fileName, string dirName)
    {
        try
        {
            if (fileName == null || dirName == null)
            {
                throw new ArgumentNullException("Argumentele nu pot fi nule");
            }

            DirectoryInfo? directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory != null && !directory.GetDirectories(dirName).Any())
            {
                directory = directory.Parent;
            }
            if (directory == null)
            {
                throw new DirectoryNotFoundException("ERROR - Nu s-a putut gasi directorul cu Media");
            }
            var mediaDirectory = directory.FullName;
            return Path.Combine(mediaDirectory, $"{dirName}\\{fileName}");
        }
        catch (ArgumentNullException argumentNullException)
        {
            throw new PathBuildingException($"ERROR - argumente nule trimise. {argumentNullException.Message}", argumentNullException);
        }
        catch (ArgumentException argumentException)
        {
            throw new PathBuildingException($"ERROR - argumente invalide trimise {argumentException.Message}", argumentException);
        }
        catch(PathTooLongException pathTooLongException)
        {
            throw new PathBuildingException($"ERROR - calea este prea lunga {pathTooLongException.Message}", pathTooLongException);
        }
    }

    /// <summary>
    /// Incarca un fisier audio nou prin copierea acestuia din locatia sursa
    /// in directorul Media al aplicatiei, suprascriind orice fisier existent
    /// cu acelasi nume.
    /// </summary>
    /// <param name="fullPath">
    /// Calea absoluta completa catre fisierul sursa care urmeaza sa fie copiat
    /// </param>
    /// <returns>
    /// Un obiect de tip StorageFile, reprezentand fisierul sursa
    /// de la calea originala
    /// </returns>
    /// <exception cref="PathBuildingException">
    /// Aruncata cand nu se poate determina directorul Media, cand argumentele
    /// de cale sunt invalide sau cand constructia caii esueaza
    /// </exception>
    /// <exception cref="IOException">
    /// Aruncata cand operatia de copiere a fisierului esueaza din cauza unor
    /// probleme de intrare/iesire
    /// </exception>
    /// <exception cref="Exception">
    /// Aruncata pentru orice alta eroare neasteptata
    /// </exception>
    public static async Task<StorageFile> LoadNewSongAsync(string fullPath)
    {
        try
        {
            string mediaDirectoryPath = GetSpecifiedDirPath("", "Media");
            string? directoryName = Path.GetDirectoryName(mediaDirectoryPath);
            if (directoryName is null)
            {
                throw new PathBuildingException("ERROR - nu a reusit obtinerea numelui directorului de media");
            }
            Directory.CreateDirectory(directoryName);
            string fileName = Path.GetFileName(fullPath);
            string newPath = Path.Combine(mediaDirectoryPath, fileName);

            File.Copy(fullPath, newPath, overwrite: true);

            return await StorageFile.GetFileFromPathAsync(fullPath);
        }
        catch (ArgumentException argumentException)
        {
            // TODO: daca citesc un empty string, trebuie handled special
            throw new PathBuildingException($"ERROR - argumente invalide trimise {argumentException.Message}", argumentException);
        }
        catch (IOException)
        {
            throw;
        }
        catch (PathBuildingException)
        {
            throw;
        }
        catch (Exception exception)
        {
            throw new Exception($"ERROR - eroare generica {exception.Message}", exception);
        }
    }

    /// <summary>
    /// Incarca un fisier audio existent din directorul Media al aplicatiei
    /// </summary>
    /// <param name="fileName">
    /// Numele fisierului (cu extensie) care se afla deja in directorul Media
    /// </param>
    /// <returns>
    /// Un obiect StorageFile reprezentand fisierul gasit
    /// in directorul Media
    /// </returns>
    /// <exception cref="PathBuildingException">
    /// Aruncata cand calea construita nu este valida ca argument pentru sistem
    /// </exception>
    /// <exception cref="DirectoryNotFoundException">
    /// Aruncata GetSpecifiedDirPath cand directorul Media nu exista
    /// </exception>
    public static async Task<StorageFile> LoadSong(string fileName)
    {
        string fileFullPath = GetSpecifiedDirPath(fileName, "Media");
        try
        {
            return await StorageFile.GetFileFromPathAsync(fileFullPath);
        }
        catch (ArgumentException argumentException)
        {
            throw new PathBuildingException($"ERROR - path-ul construit {fileFullPath} nu e valid ca argument. {argumentException.Message}", argumentException);
        }
    }
}