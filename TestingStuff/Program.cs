using Core;
using CustomExceptions;
using FileManagement;
using Playback;
using Playback.Playables;
using Playback.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManagement;
using Windows.Storage;

namespace Proiect_Ip.Tests
{
    /// <summary>
    /// Clasa de test care implementeaza IPlayable pentru a simula o melodie in teste.
    /// </summary>
    public class DummyPlayable : IPlayable
    {
        /// <summary>
        /// Numele elementului redabil.
        /// </summary>
        public string Name { get; set; }

        private bool _hasBeenPlayed = false;

        /// <summary>
        /// Initializeaza un nou obiect dummy cu numele specificat.
        /// </summary>
        public DummyPlayable(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Metoda necesara interfetei. Implementare goala pentru teste.
        /// </summary>
        public void AddPlayable(IPlayable playable) { }

        /// <summary>
        /// Returneaza instanta curenta o singura data pentru a simula redarea, apoi returneaza null.
        /// </summary>
        public IPlayable? GetNextPlayable()
        {
            if (!_hasBeenPlayed)
            {
                _hasBeenPlayed = true;
                return this;
            }
            return null;
        }

        /// <summary>
        /// Metoda necesara interfetei. Implementare goala pentru teste.
        /// </summary>
        public void SetPlaybackStrategy(IPlaybackStrategy playbackStrategy) { }
    }


    [TestClass]
    public class QueueTest
    {
        /// <summary>
        /// Testeaza daca PlaybackQueue sare peste elementele deja redate si se goleste corect la final.
        /// </summary>
        [TestMethod]
        public void PlaybackQueue_ShouldSkipFinishedElements()
        {
            var queue = new PlaybackQueue();
            var song1 = new DummyPlayable("Song 1");
            var song2 = new DummyPlayable("Song 2");

            queue.AddPlayable(song1);
            queue.AddPlayable(song2);

            var first = queue.GetNextPlayable();
            var second = queue.GetNextPlayable();
            var third = queue.GetNextPlayable();

            Assert.AreEqual(song1, first);
            Assert.AreEqual(song2, second, "Trebuia sa se treaca la a doua melodie.");
            Assert.IsNull(third, "Coada trebuie sa fie goala.");
        }

        /// <summary>
        /// Testeaza daca metoda Clear goleste complet coada de redare.
        /// </summary>
        [TestMethod]
        public void PlaybackQueue_Clear_ShouldEmptyTheQueue()
        {
            var queue = new PlaybackQueue();
            queue.AddPlayable(new DummyPlayable("song1"));

            queue.Clear();

            Assert.IsNull(queue.GetNextPlayable(), "Coada trebuie sa fie goala.");
        }

        /// <summary>
        /// Verifica daca PlaybackQueue foloseste strategia de redare care i-a fost atribuita.
        /// </summary>
        [TestMethod]
        public void PlaybackQueue_ShouldUseAssignedStrategy()
        {
            var queue = new PlaybackQueue();
            var song1 = new DummyPlayable("Song 1");
            var song2 = new DummyPlayable("Song 2");

            queue.AddPlayable(song1);
            queue.AddPlayable(song2);

            var first = queue.GetNextPlayable();
            queue.SetPlaybackStrategy(new RepeatStrategy());
            var second = queue.GetNextPlayable();

            Assert.AreEqual(song1, first);
            Assert.AreEqual(song2, second);
        }
    }

    [TestClass]
    public class PlaylistTests
    {
        /// <summary>
        /// Verifica daca PlaybackPlaylist aplica corect strategia de redare atribuita.
        /// </summary>
        [TestMethod]
        public void Playlist_ShouldUseAssignedStrategy()
        {
            var playlist = new PlaybackPlaylist(null);
            var song1 = new DummyPlayable("S1");
            var song2 = new DummyPlayable("S2");
            playlist.AddPlayable(song1);
            playlist.AddPlayable(song2);

            var result1 = playlist.GetNextPlayable();
            playlist.SetPlaybackStrategy(new RepeatStrategy());
            var result2 = playlist.GetNextPlayable();

            Assert.AreEqual(song1, result1);
            Assert.AreEqual(song2, result2);
        }
    }

    [TestClass]
    public class StrategyTests
    {
        /// <summary>
        /// Testeaza daca SequentialStrategy returneaza elementele in ordine si le elimina din lista.
        /// </summary>
        [TestMethod]
        public void SequentialStrategy_ShouldReturnElementsInOrder()
        {
            var strategy = new SequentialStrategy();
            var song1 = new DummyPlayable("song1");
            var song2 = new DummyPlayable("song2");
            var list = new List<IPlayable> { song1, song2 };

            var firstResult = strategy.GetNextPlayable(list);
            Assert.AreEqual(song1, firstResult);
            Assert.AreEqual(1, list.Count);

            var secondResult = strategy.GetNextPlayable(list);
            Assert.AreEqual(song2, secondResult);
            Assert.AreEqual(0, list.Count);
        }

        /// <summary>
        /// Verifica daca RepeatStrategy pastreaza lista intacta dupa extragerea unui element.
        /// </summary>
        [TestMethod]
        public void RepeatStrategy_ShouldKeepListIntact()
        {
            var strategy = new RepeatStrategy();
            var song = new DummyPlayable("song1");
            var list = new List<IPlayable> { song };
            var result = strategy.GetNextPlayable(list);

            Assert.AreEqual(song, result);
            Assert.AreEqual(1, list.Count, "RepeatStrategy nu trebuie sa stearga elemente.");
        }

        /// <summary>
        /// Testeaza daca ShuffleStrategy extrage toate elementele, golind lista la final.
        /// </summary>
        [TestMethod]
        public void ShuffleStrategy_ShouldPickAllElements()
        {
            var strategy = new ShuffleStrategy();
            var list = new List<IPlayable> { new DummyPlayable("song1"), new DummyPlayable("song2"), new DummyPlayable("song3") };
            strategy.GetNextPlayable(list);
            strategy.GetNextPlayable(list);
            strategy.GetNextPlayable(list);

            Assert.AreEqual(0, list.Count, "Lista trebuie sa fie goala dupa 3 redari.");
        }
    }

    [TestClass]
    public class MediaManagerTests
    {
        /// <summary>
        /// Verifica declansarea evenimentului PlaybackDoneOcurred si mesajul la terminarea redarii.
        /// </summary>
        [TestMethod]
        public void PlayNextSong_ShouldHavePlaybackDoneEvent()
        {
            var manager = new MediaManager();
            manager.ClearQueue();

            bool eventRaised = false;
            string message = "";

            void HandlePlaybackDone(object? sender, PlaybackDoneException e)
            {
                eventRaised = true;
                message = e.Message;
            }
            manager.PlaybackDoneOcurred += HandlePlaybackDone; //adaugam functia in lista de event listeners

            manager.PlayNextSong();

            Assert.IsTrue(eventRaised, "Evenimentul PlaybackDoneOcurred trebuia declansat.");
            Assert.IsTrue(message.Contains("finalizate"), "Mesaj de eroare neasteptat.");
        }

        /// <summary>
        /// Testeaza daca metodele de activare a strategiilor se executa fara erori.
        /// </summary>
        [TestMethod]
        public void ActivateStrategies_ShouldExecuteWithoutErrors()
        {
            var manager = new MediaManager();

            manager.ActivateShuffle();
            manager.ActivateRepeat();
            manager.ActivateSequential();
        }

        /// <summary>
        /// Verifica daca un MediaManager proaspat instantiat nu are nicio melodie incarcata.
        /// </summary>
        [TestMethod]
        public void HasCurrentSong_WhenManagerIsCreated_ShouldBeFalse()
        {
            var manager = new MediaManager();

            bool hasSong = manager.HasCurrentSong();

            Assert.IsFalse(hasSong, "Playerul nu trebuie sa aiba melodii la initializare.");
        }

        /// <summary>
        /// Verifica daca apelarea metodei Dispose pentru stergerea resurselor nu arunca exceptii.
        /// </summary>
        [TestMethod]
        public void Dispose_WhenCalled_ShouldNotThrowExceptions()
        {
            var manager = new MediaManager();

            manager.Dispose();
        }
    }

    [TestClass]
    public class PlaybackMasterTests
    {
        /// <summary>
        /// Verifica daca ajustarea volumului cu diverse valori pozitive si negative functioneaza fara erori.
        /// </summary>
        [TestMethod]
        public void AdjustVolume_ShouldNotThrowExceptions()
        {
            var manager = new MediaManager();

            manager.AdjustVolume(-20.0);
            manager.AdjustVolume(0.0);
            manager.AdjustVolume(50.0);
            manager.AdjustVolume(100.0);
            manager.AdjustVolume(150.0);
        }

        /// <summary>
        /// Verifica daca apelarea metodei Pause se executa fara a arunca exceptii.
        /// </summary>
        [TestMethod]
        public void Pause_WhenCalled_ShouldNotThrowExceptions()
        {
            var manager = new MediaManager();

            manager.Pause();
        }

        /// <summary>
        /// Testeaza daca golirea cozii functioneaza corect si reseteaza melodia curenta.
        /// </summary>
        [TestMethod]
        public void ClearQueue_WhenCalled_ShouldNotThrowExceptions()
        {
            var manager = new MediaManager();

            manager.ClearQueue();

            Assert.IsFalse(manager.HasCurrentSong(), "Dupa ClearQueue nu trebuie sa existe cantec curent.");
        }

        /// <summary>
        /// Verifica daca reluarea redarii (Resume) fara o melodie incarcata nu arunca exceptii.
        /// </summary>
        [TestMethod]
        public void Resume_WhenNoSongIsLoaded_ShouldNotThrowException()
        {
            var playbackMaster = new PlaybackMaster();

            playbackMaster.Resume();
        }

        /// <summary>
        /// Testeaza metodele de control (play, pause, skip) pentru a asigura ca nu pica in lipsa unei melodii.
        /// </summary>
        [TestMethod]
        public void ControlMethods_WhenNoSongLoaded_ShouldNotThrowException()
        {
            var master = new PlaybackMaster();

            master.Play();
            master.Pause();
            master.Resume();
            master.SkipSeconds(10);
            master.SkipSeconds(-10);
        }

        /// <summary>
        /// Verifica daca pozitia melodiei este 0 atunci cand nu este incarcat nimic in player.
        /// </summary>
        [TestMethod]
        public void GetCurrentSongPosition_WhenNoSongLoaded_ShouldReturnZero()
        {
            var master = new PlaybackMaster();
            var position = master.GetCurrentSongPosition();

            Assert.AreEqual(TimeSpan.Zero, position, "Pozitia trebuie sa fie 0 la initializare.");
        }

        /// <summary>
        /// Verifica daca durata melodiei este 0 atunci cand nu este incarcat nimic in player.
        /// </summary>
        [TestMethod]
        public void GetCurrentSongDuration_WhenNoSongLoaded_ShouldReturnZero()
        {
            var master = new PlaybackMaster();
            var position = master.GetCurrentSongDuration();

            Assert.AreEqual(TimeSpan.Zero, position, "Durata trebuie sa fie 0 la initializare.");
        }

        /// <summary>
        /// Testeaza daca apelarea metodei Clear reseteaza corect proprietatea de control SongsLoaded.
        /// </summary>
        [TestMethod]
        public void Clear_ShouldSetSongsLoadedToFalse()
        {
            var master = new PlaybackMaster();
            master.SongsLoaded = true;

            master.Clear();

            Assert.IsFalse(master.SongsLoaded, "Clear trebuie sa seteze SongsLoaded la false.");
        }
    }


    [TestClass]
    public class HasherTests
    {
        /// <summary>
        /// Testeaza daca acelasi input procesat de mai multe ori genereaza de fiecare data acelasi hash.
        /// </summary>
        [TestMethod]
        public void GetHash_SameInput_ShouldReturnSameHash()
        {
            string input = "TestPlaylist123";

            string hash1 = Hasher.GetHash(input);
            string hash2 = Hasher.GetHash(input);

            Assert.AreEqual(hash1, hash2, "Hash-urile aceluiasi string trebuie sa fie identice.");
        }

        /// <summary>
        /// Testeaza daca input-uri diferite genereaza in mod corect hash-uri unice si diferite.
        /// </summary>
        [TestMethod]
        public void GetHash_DifferentInputs_ShouldReturnDifferentHashes()
        {
            string input1 = "Playlist1";
            string input2 = "Playlist2";

            string hash1 = Hasher.GetHash(input1);
            string hash2 = Hasher.GetHash(input2);

            Assert.AreNotEqual(hash1, hash2, "Stringuri diferite trebuie sa aiba hash-uri diferite.");
        }

        /// <summary>
        /// Verifica daca algoritmul genereaza hash-ul SHA-256 corect in Base64 pentru un string de test cunoscut.
        /// </summary>
        [TestMethod]
        public void GetHash_KnownString_ShouldReturnExpectedBase64SHA256()
        {
            string input = "test";

            string expectedHash = "n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=";

            string actualHash = Hasher.GetHash(input);

            Assert.AreEqual(expectedHash, actualHash, "Algoritmul SHA-256 nu a produs rezultatul corect.");
        }

        /// <summary>
        /// Verifica daca generarea unui hash dintr-un string gol se realizeaza cu succes fara exceptii.
        /// </summary>
        [TestMethod]
        public void GetHash_EmptyString_ShouldNotThrowException()
        {
            string emptyInput = "";

            string result = Hasher.GetHash(emptyInput);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        /// <summary>
        /// Testeaza daca furnizarea unui argument de tip null arunca corect exceptia ArgumentNullException.
        /// </summary>
        [TestMethod]
        public void GetHash_NullInput_ShouldThrowArgumentNullException()
        {
            try
            {
                Hasher.GetHash(null!); //null!- forteaza argumentul sa fie null
                Assert.Fail("Trebuia aruncata exceptia ArgumentNullException.");
            }
            catch (ArgumentNullException)
            {

            }
        }
    }

    [TestClass]
    public class FileReaderTest
    {
        /// <summary>
        /// Verifica daca trimiterea unui argument null catre metoda de citire arunca PathBuildingException.
        /// </summary>
        [TestMethod]
        public void GetSpecifiedDirPath__ShouldThrowPathBuildingException()
        {
            try
            {
                FileReader.GetSpecifiedDirPath(null!, "Media");
                Assert.Fail("Trebuia aruncata exceptia PathBuildingException.");
            }
            catch (PathBuildingException)
            {

            }
        }

        /// <summary>
        /// Verifica daca interogarea unui director inexistent ridica exceptia DirectoryNotFoundException.
        /// </summary>
        [TestMethod]
        public void GetSpecifiedDirPath_ShouldThrowDirectoryNotFoundException()
        {
            try
            {
                FileReader.GetSpecifiedDirPath("fisier.mp3", "WhateverFolder");
                Assert.Fail("Trebuia aruncata exceptia DirectoryNotFoundException.");
            }
            catch (DirectoryNotFoundException)
            {

            }
        }
    }

    [TestClass]
    public class FileProcessorTests
    {
        /// <summary>
        /// Testeaza daca furnizarea unui input null la obtinerea sursei media genereaza MediaManagementException.
        /// </summary>
        [TestMethod]
        public void GetMediaSource_ShouldThrowArgumentNullException()
        {
            try
            {
                FileProcessor.GetMediaSource(null!);
                Assert.Fail("Trebuia aruncata exceptia MediaManagementException pentru null.");
            }
            catch (MediaManagementException)
            {

            }
        }
    }
}