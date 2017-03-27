using WordCounterService.Domain;
using System.Linq;

namespace WordCounterService.Application.DataFilter
{
    public class IgnoreCaseFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            var words = wordsCounter.Keys.ToList();
            foreach (var word in words)
            {
                if (word.Any(char.IsUpper))
                {
                    wordsCounter.AddToCounter(word.ToLower(), wordsCounter[word]);
                    wordsCounter.Remove(word);
                }
            }

            return wordsCounter;
        }
    }
}