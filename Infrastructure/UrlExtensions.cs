using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace WebPetProject.Infrastructure
{
    //s
    public static class UrlExtensions
    {
        //Generates a URL to which the browser will return after the shopping cart, taking into account the query string if it exists
        public static string PathAndQuery(this HttpRequest request)
            => request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" 
                    : request.Path.ToString();
    }
}
