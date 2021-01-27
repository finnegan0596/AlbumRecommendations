using AlbumScraper.Common.Extensions;
using AlbumScraper.Models;
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlbumScraper.Scrapers
{
    public static class AlbumOfTheYearScraper
    {
        public static ICollection<Album> GetAlbums(string baseUrl, int year, int startPage, int endPage)
        {
            var results = new List<Album>();
            
            HtmlWeb website = new HtmlWeb();
            website.AutoDetectEncoding = false;
            website.OverrideEncoding = Encoding.Default;

            while (startPage <= endPage)
            {
                var url = string.Join("/", baseUrl, year, startPage);
                HtmlDocument doc = website.Load(url);

                foreach (var row in doc.DocumentNode.Descendants()
                                                    .Where(d => d.Attributes.Contains("class") &&
                                                                d.Attributes["class"].Value.Contains("albumListRow")))
                {


                    var artistAndTitle = row.GetInnerTextFromAttribute("itemprop", "url");
                    var genre = row.GetInnerTextForClass("albumListGenre");
                    var score = row.GetInnerTextForClass("scoreValue");
                    var spotifyUrl = row.GetLinkFromAttribute("data-track-action", "Spotify");

                    var splitArtistAndTitle = artistAndTitle.Split(" - ");

                    results.Add(new Album
                    {
                        Artist = splitArtistAndTitle.First(),
                        Title = splitArtistAndTitle.Skip(1).First(),
                        Genre = genre,
                        Score = Int32.Parse(score),
                        SpotifyUrl = spotifyUrl
                    });
                }

                startPage++;
            }

            return results;
        }
    }
}
