using AlbumRecommendations.Repositories.Contracts;
using AlbumScraper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace AlbumRecommendations.WebApi.Controllers
{
    [ApiController]
    [Route("")]
    public class AlbumsController : ControllerBase
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IAlbumRepository _albumRepository;

        public AlbumsController(ILogger<AlbumsController> logger, IAlbumRepository albumRepository)
        {
            _logger = logger;
            _albumRepository = albumRepository;
        }

        [HttpGet("albums")]
        public IEnumerable<Album> GetAllAlbums(int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, "GetAlbums()");
            return _albumRepository.GetAlbums(null, minScore, maxScore, null, null);
        }

        [HttpGet("albums/{title}")]
        public IEnumerable<Album> GetForTitle(string title, int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, "GetAlbums()");
            return _albumRepository.GetAlbums(null, minScore, maxScore, null, title);
        }

        [HttpGet("year/{year}/albums")]
        public IEnumerable<Album> GetForYear(int year, int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, $"GetAlbums({year})");
            return _albumRepository.GetAlbums(year, minScore, maxScore, null, null);
        }

        [HttpGet("artist/{artist}/albums")]
        public IEnumerable<Album> GetForArtist(string artist, int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, $"GetAlbums({artist})");
            return _albumRepository.GetAlbums(null, minScore, maxScore, artist, null);
        }

        [HttpGet("artist/{artist}/year/{year}/albums")]
        public IEnumerable<Album> GetForArtistAndYear(string artist, int year, int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, $"GetAlbums({artist}, {year})");
            return _albumRepository.GetAlbums(year, minScore, maxScore, artist, null);
        }

        [HttpGet("artist/{artist}/albums/{title}")]
        public IEnumerable<Album> GetForArtistAndTitle(string artist, string title, int? minScore, int? maxScore)
        {
            _logger.Log(LogLevel.Information, $"GetAlbums({artist}, {title})");
            return _albumRepository.GetAlbums(null, minScore, maxScore, artist, title);
        }
    }
}