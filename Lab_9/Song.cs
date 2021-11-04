using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_9
{
    class Song
    {
        private string name;
        private string author;
        private Song last_song;
        public Song() { }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            last_song = null;
        }
        public Song(string name, string author, Song last_song) { }
        public static void Search(List<Song> songs)
        {
            bool is_found = false;
            for (int i = 0; i < songs.Count; i++)
            {
                for (int j = 1; j < songs.Count - 1; j++)
                {
                    if (songs[i] != null && songs[j] != null)
                    {
                        if (songs[i].Equals(songs[j]) && i != j)
                        {
                            is_found = true;
                            Console.WriteLine($"Песни под номерами {i + 1} и {j + 1} совпали. Название песни: '{songs[i].name}'. Автор: {songs[i].author}");
                            songs[i] = null;
                        }
                    }
                }
                if (is_found)
                {
                    Search(songs);
                }
            }
        }
        public static string Title(Song song)
        {
            return $"Название песни: '{song.name}'. Автор(ка): {song.author}";
        }
        public bool Equals(Song obj)
        {
            if (obj is Song)
            {
                if ($"Название песни: '{this.name}'. Автор(ка): {this.author}".Equals(Song.Title(obj as Song)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
