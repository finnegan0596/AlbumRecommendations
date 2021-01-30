namespace AlbumScraper.Models
{
    public class Album
    {
        public int Id { get; set; }

        public int Rank { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public string SpotifyUrl { get; set; }

        public int Year { get; set; }

        public int Score { get; set; }

        public string Genre { get; set; }
    }
}