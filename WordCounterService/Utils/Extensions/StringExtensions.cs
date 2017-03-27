using System.Linq;

namespace WordCounterService.Utils
{
    public static class StringExtensions
    {
        /// <summary>
        /// This will return true if string will contain any of the chars
        /// </summary>
        public static string Clean(this string word, params char[] charsToVerify)
        {
            foreach (var character in charsToVerify)
            {
                if (word.Contains(character))
                {
                    word = word.Replace(character.ToString(), string.Empty); //I'm creating string from char because is more cheap(computational) that to have a params of string, because strings are reference type and have a lot of overhead.
                }
            }

            return word;
        }
    }
}
