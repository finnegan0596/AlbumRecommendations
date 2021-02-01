﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlbumRecommendations.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return default(T);

            var r = new Random();
            var list = enumerable as IList<T> ?? enumerable.ToList();
            return list.ElementAt(r.Next(0, list.Count()));
        }
    }
}