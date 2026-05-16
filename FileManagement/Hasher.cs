/*********************************************************************************************
 *                                                                                           *
 *  File:        Hasher.cs                                                                   *
 *  Copyright:   (c) 2026, Apetroae Tudor                                                    *
 *  E-mail:      tudor.apetroae@student.tuiasi.ro                                            *
 *  Description: Utilitar folosit pentru a aplica algoritmul SHA-256 pe un string            *
 ********************************************************************************************/

namespace FileManagement;

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Clasa statica utilitara pentru generarea de identificatori unici
/// prin folosirea algoritmului SHA-256 asupra unui sir de caractere.
/// Rezultatul este codificat in format Base64
/// </summary>
public static class Hasher
{
    /// <summary>
    /// Calculeaza hash-ul SHA-256 al sirului de intrare si il returneaza
    /// ca sir codificat in Base64
    /// </summary>
    /// <param name="input">
    /// Sirul de caractere asupra caruia se aplica algoritmul SHA-256.
    /// </param>
    /// <returns>
    /// Un sir de caractere Base64 reprezentand hash-ul SHA-256 al intrarii
    /// </returns>
    public static string GetHash(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = SHA256.HashData(inputBytes);
        return Convert.ToBase64String(hashBytes);
    }
}