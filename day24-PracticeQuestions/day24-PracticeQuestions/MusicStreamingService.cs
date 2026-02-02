using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStreamingService
{
    public class Song
    {
        public string SongId { get; }
        public string Title { get; set; }
        public string Artist { get; }
        public string Genre { get; }
        public string Album { get; }
        public TimeSpan Duration { get; set; }
        public int PlayCount { get; set; }


        public Song()
        {

        }
    }


    public class Playlist
    {
        public string PlaylistId { get; }
        public string Name { get; set; }
        public string CreatedBy { get;  }
        public List<Song> Songs { get; set; }

        public Playlist()
        {

        }

    }

    public class User
    {
        public string UserId { get; }
        public string UserName { get; set; }
        public List<string> FavoriteGenres { get; set; }

        public List<Playlist> UserPlaylists { get; set; }

        public User()
        {

        }
    }

    public class MusicManager
    {
        public void AddSong(string title, string artist, string genre,string album,TimeSpan duration)
        {

        }
    }



}
