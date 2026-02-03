using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStreamingService
{
    /// <summary>
    /// Song type. Random PlayCount. _counter to auto increment id
    /// </summary>
    public class Song
    {
        private static int _counter = 1;
        public string SongId { get; }           // Given in the question to be string
        public string Title { get; init; }
        public string Artist { get; init; }
        public string Genre { get; init; }
        public string Album { get; init; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }
        Random random = new Random();


        public Song()
        {
            SongId = _counter++.ToString();
            PlayCount = random.Next(100000,9000394);

        }
    }


    /// <summary>
    /// Playlist type. 
    /// </summary>
    public class Playlist
    {
        public string PlaylistId { get; init; }
        public string Name { get; set; }
        public string CreatedBy { get;  }
        public List<Song> Songs { get; set; } = new List<Song>();

        public Playlist()
        {

        }

    }

    /// <summary>
    /// User type
    /// </summary>
    public class User
    {
        private static int _counter = 1;
        public string UserId { get; init; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; }

        public List<Playlist> UserPlaylists = new List<Playlist>();


        public User()
        {
            UserId = _counter++.ToString();
        }
    }

    /// <summary>
    /// Music Manager Class with all the methods and data storage of Songs and Users
    /// </summary>
    public class MusicManager
    {

        public List<Song> Songs = new List<Song>();     // Store Songs
        public List<User> users = new List<User>();    // Store Users

        /// <summary>
        /// Method to Add Songs of song type in the Songs List 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="artist"></param>
        /// <param name="genre"></param>
        /// <param name="album"></param>
        /// <param name="duration"></param>
        public void AddSong(string title, string artist, string genre,string album,TimeSpan duration)
        {
            Song s1 = new Song()
            {
                Title = title,
                Artist = artist,
                Genre = genre,
                Album = album,
                Duration = duration
            };
            Songs.Add(s1);
            Console.WriteLine("Song added successfully.");
        }

        /// <summary>
        /// Method to add user in the Users list.
        /// </summary>
        /// <param name="name"></param>
        public void AddUser(string name)
        {
            users.Add(new User() { UserName = name });
            Console.WriteLine("User added successfully.");
        }

        /// <summary>
        /// Method to create playlist if user is present in the users list (validating with user id)
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="playlistName"></param>
        public void CreatePlaylist(string userId, string playlistName)
        {
            foreach (User u1 in users)
            {
                if (u1.UserId == userId)
                {
                    Playlist p1 = new Playlist()
                    {
                        PlaylistId = userId,
                        Name = playlistName
                    };
                    return;
                }
            }
            Console.WriteLine("User not found.");

        }

        /// <summary>
        /// Method to add songs to playlist with playlist exists.
        /// </summary>
        /// <param name="playlistId"></param>
        /// <param name="songId"></param>
        /// <returns></returns>
        public bool AddSongToPlaylist(string playlistId, string songId)
        {
            if (playlistId == null) { return false; }

            Playlist p = new Playlist();
            Song s = new Song();

            foreach(Song s1 in Songs)
            {
                if (s1.SongId == songId)
                {
                    p.Songs.Add(s1);
                    Console.WriteLine("Song Added Successfully in the playlist.");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method to group songs by genre
        /// </summary>
        /// <returns>Dictionary</returns>
        public Dictionary<string, List<Song>> GroupSongsByGenre()
        {
            Song s = new Song();
            return new Dictionary<string, List<Song>>(
                Songs.GroupBy(g => g.Genre).ToDictionary(g => g.Key, g => g.ToList())
                );
        }

        /// <summary>
        /// Method to retreive most played songs.
        /// </summary>
        /// <param name="count"></param>
        /// <returns>List</returns>
        public List<Song> GetTopPlayedSongs(int count)
        {
            Song s = new Song();
            //return Songs.Where(s => s.PlayCount > count).OrderBy(o=>o.PlayCount).ToList();       // Songs having playCount > count
            return Songs.OrderByDescending(s => s.PlayCount).Take(count).ToList();                // Top 'count' songs.

        }

        /// <summary>
        /// Method to get userId for the input user name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns>int</returns>
        public int ReturnUserId(string Name)
        {
            foreach (User u in users)
            {
                if(u.UserName.ToLower().Trim() == Name.ToLower().Trim())
                {
                    return int.Parse(u.UserId);
                }
            }
            Console.WriteLine("User not found.");            
            return 0;
        }

    }

    /// <summary>
    /// Main Class
    /// </summary>
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // Music Manager instance to call methods
            MusicManager mm = new MusicManager();

            mm.AddSong("Salvatore", "Lana Del Rey", "Pop", "Honeymoon", TimeSpan.FromMinutes(3, 41));
            mm.AddSong("Open Heart", "The Weeknd", "RnB", "Hurry Up Tomorrow", TimeSpan.FromMinutes(3, 54));
            mm.AddSong("4 Raws", "Esdeekid", "Hip Hop", "Single", TimeSpan.FromMinutes(3, 23));
            mm.AddSong("Know Me", "NAV", "Hip Hop", "Bad Habits", TimeSpan.FromMinutes(3, 38));

            mm.AddUser("Nikhil");          // Adding User
            mm.CreatePlaylist("1", "Playlist 1");   // Adding Playlist 
            
            // Songs by genre
            foreach(var s in mm.GroupSongsByGenre())
            {
                Console.WriteLine($"Genre : {s.Key}");
                Console.WriteLine("Songs: ");
                foreach (var s1 in s.Value)
                {
                    Console.WriteLine(" -"+s1.Title);
                }
            }

            // Top 3 Played Songs
            Console.WriteLine("\nTop 3 played Songs : ");
            foreach (var s in mm.GetTopPlayedSongs(3))
            {
                Console.WriteLine($"{s.Title} was played {s.PlayCount} times.");
            }

            // User Name and their playlists
            Console.WriteLine("\nUsers");
            foreach (User u in mm.users)
            {
                Console.WriteLine(u.UserName + u.UserId);
                Console.WriteLine("Playlists : ");
                foreach(var k in u.UserPlaylists)
                {
                    Console.WriteLine(k.Name);
                }
            }

            // User Id for the input Name
            Console.WriteLine("User Id of Nikhil: ");
            Console.WriteLine(mm.ReturnUserId("Nikhil"));




        }
    }



}
