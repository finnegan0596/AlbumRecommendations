using AlbumRecommendations.Repositories.Contracts;
using AlbumScraper.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AlbumRecommendations.Repositories
{
    public class JsonAlbumRepository : IAlbumRepository // to potentially be replaced with database repository
    {
        private readonly string dataFilesLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Data");

        public ICollection<Album> GetAlbums()
        {
            var results = new List<Album>();
            foreach (var file in Directory.GetFiles(dataFilesLocation))
            {
                var json = File.ReadAllText(file);
                results.AddRange(JsonConvert.DeserializeObject<ICollection<Album>>(json));
            }

            return results;
        }

        public ICollection<Album> GetAlbums(int? year, int? minScore, int? maxScore, string artist, string title)
        {
            var results = this.GetAlbums().AsEnumerable();
            if (year.HasValue)
                results = results.Where(r => r.Year == year.Value);
            if (minScore.HasValue)
                results = results.Where(r => r.Score >= minScore);
            if (maxScore.HasValue)
                results = results.Where(r => r.Score <= maxScore);

            results = results.Where(r => r.Artist.Contains((artist ?? string.Empty), System.StringComparison.InvariantCultureIgnoreCase));

            results = results.Where(r => r.Title.Contains((title ?? string.Empty), System.StringComparison.InvariantCultureIgnoreCase));

            return results.ToList();
        }
    }
}