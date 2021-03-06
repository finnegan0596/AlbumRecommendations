﻿using AlbumScraper.Scrapers;
using Newtonsoft.Json;
using System;

namespace AlbumScraper
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var albums = AlbumOfTheYearScraper.GetAlbums(args[0], Int32.Parse(args[1]), Int32.Parse(args[2]), Int32.Parse(args[3]));
            string json = JsonConvert.SerializeObject(albums, Formatting.Indented);
            System.IO.File.WriteAllText(args[4], json);
        }
    }
}