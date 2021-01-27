using HtmlAgilityPack;
using System;
using System.Linq;

namespace AlbumScraper.Common.Extensions
{
    public static class HtmlNodeExtensions
    {
        public static string GetInnerTextForClass(this HtmlNode node, string className)
        {
            var descendantsWithClasses = node.Descendants().Where(d => d.Attributes.Contains("class"));
            return descendantsWithClasses.FirstOrDefault(d => d.Attributes["class"].Value.Contains(className))?
                                         .InnerText;
        }

        public static string GetLinkFromAttribute(this HtmlNode node, string attributeName, string attributeValue)
        {
            return node.Descendants().FirstOrDefault(d => d.Attributes.Contains(attributeName) &&
                                                          d.Attributes[attributeName].Value.Contains(attributeValue))?
                                     .GetAttributeValue("href", string.Empty);
        }

        public static string GetInnerTextFromAttribute(this HtmlNode node, string attributeName, string attributeValue)
        {
            return node.Descendants().FirstOrDefault(d => d.Attributes.Contains(attributeName) &&
                                                          d.Attributes[attributeName].Value.Contains(attributeValue))?
                                     .InnerText;
        }
    }
}
