using AlbumScraper.Models;
using System.Collections.Generic;

namespace AlbumRecommendations.Repositories.Contracts
{
    public interface IAlbumRepository
    {
        ICollection<Album> GetAlbums();

        ICollection<Album> GetAlbums(int? year, int? minScore, int? maxScore, string artist, string title);

        Album GetSuggestedAlbum(int? minScore, int? maxScore, int? minYear, int? maxYear);
    }
}