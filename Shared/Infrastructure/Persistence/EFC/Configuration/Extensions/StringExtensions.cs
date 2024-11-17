
using Humanizer;

namespace HealMeAppBackend.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions
{
     /// <summary>
    ///     Provides extension methods for string manipulation, such as converting
    ///     to snake_case and pluralizing strings.
    /// </summary>
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string text)
        {
            return new string(Convert(text.GetEnumerator()).ToArray());
        }

        public static string ToPlural(this string text)
        {
            return text.Pluralize();
        }

        static IEnumerable<char> Convert(CharEnumerator e)
        {
            if (!e.MoveNext()) yield break;
            
            yield return char.ToLower(e.Current);

            while (e.MoveNext())
            {
                if (char.IsUpper(e.Current))
                {
                    yield return '_';
                    yield return char.ToLower(e.Current);   
                }
                else
                {
                    yield return e.Current;
                }
            }
        }
    }
}
