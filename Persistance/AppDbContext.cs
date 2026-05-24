/****************************************************************************************************
 *                                                                                                  *
 *  File:        SongRepository.cs                                                                  *
 *  Copyright:   (c) 2026, Nichifor Codrin-George                                                   *
 *  E-mail:      codirn-george.nichifor@student.tuiasi.ro                                           *
 *  Description: Clasa mapeaza clasele model SongInfo si PlaylistInfo pe baza de date cu ajutorul   *
 *               frameworkului EntityFramework ce se ocupa si de rezolvarea relatiei many to many   *
 *               dintre cantece si playlisturi                                                      *
 ***************************************************************************************************/
using Microsoft.EntityFrameworkCore;
using Common;
using CustomExceptions;
using FileManagement;

namespace Persistance
{
    public class AppDbContext : DbContext
    {
        internal AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        internal DbSet<SongInfo> Songs => Set<SongInfo>();
        internal DbSet<PlaylistInfo> Playlists => Set<PlaylistInfo>();
        /// <summary>
        /// Configurează schema bazei de date în Entity Framework Core
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<SongInfo>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.SongTitle).HasMaxLength(200);
                    entity.Property(e => e.Artist).HasMaxLength(200);
                    entity.Property(e => e.Album).HasMaxLength(200);
                    entity.Property(e => e.FileName).HasMaxLength(500);
                });

                modelBuilder.Entity<PlaylistInfo>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.PlaylistName).IsRequired().HasMaxLength(200);

                    entity.HasMany(p => p.Songs)
                          .WithMany()
                          .UsingEntity("PlaylistSongs");
                });
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("ERROR - eroare de tip neidentificat", ex);
            }
        }
        /// <summary>
        /// Metoda fabrica
        /// </summary>
        /// <returns></returns>
        /// <exception cref="DatabaseConnectionException"></exception>
        public static AppDbContext Create()
        {
            try
            {
                string dbPath = FileReader.GetSpecifiedDirPath("sqlite_testing.db", "DB");
                var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionBuilder.UseSqlite($"Data Source={dbPath}");
                var instance = new AppDbContext(optionBuilder.Options);
                instance.Database.EnsureCreated();
                return instance;
            }
            catch (DirectoryNotFoundException directoryNotFoundException)
            {
                throw new DatabaseConnectionException("ERROR - problema la conectarea la baza de date", directoryNotFoundException);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("ERROR - eroare de tip neidentificat", ex);
            }
        }
    }
}