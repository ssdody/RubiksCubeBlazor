using Microsoft.AspNetCore.Html;

namespace BlazorApp1.Client.Extensions
{
    using System.Web;

    public static class StringExtensions
    {
        /// <summary>
        /// Convert a standard string into a htmlstring for rendering in a view
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static HtmlString ToHtmlString(this string value)
        {
            return new HtmlString(value);
        }
    }
}
