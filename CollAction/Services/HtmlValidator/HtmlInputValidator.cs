using Ganss.XSS;
using System.Linq;

namespace CollAction.Services.HtmlValidator
{
    public sealed class HtmlInputValidator : IHtmlInputValidator
    {
        public bool IsSafe(string? inputHtml)
        {
            if (inputHtml == null)
            {
                return true;
            }

            var sanitizer = new HtmlSanitizer(
                allowedTags:
                    new[]
                    {
                        "p",
                        "br",
                        "strong",
                        "em",
                        "i",
                        "u",
                        "a",
                        "ol",
                        "ul",
                        "li"
                    },
                allowedSchemes:
                    new string[]
                    {
                        "http",
                        "https"
                    },
                allowedAttributes:
                    new[]
                    {
                        "target",
                        "href"
                    },
                uriAttributes:
                    new[]
                    {
                        "href"
                    },
                allowedCssProperties:
                    Enumerable.Empty<string>());

            bool isSafe = true;

            sanitizer.RemovingTag += (a, b) => { isSafe = false; };

            sanitizer.RemovingAttribute += (a, b) => { isSafe = false; };

            sanitizer.RemovingStyle += (a, b) => { isSafe = false; };

            sanitizer.RemovingCssClass += (a, b) => { isSafe = false; };

            sanitizer.RemovingAtRule += (a, b) => { isSafe = false; };

            sanitizer.RemovingComment += (a, b) => { isSafe = false; };

            string output = sanitizer.Sanitize(inputHtml);

            return isSafe;
        }
    }
}