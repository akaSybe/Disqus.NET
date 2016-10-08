namespace Disqus.NET.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string word)
        {
            return word.Substring(0, 1).ToLower() + word.Substring(1);
        }
    }
}
