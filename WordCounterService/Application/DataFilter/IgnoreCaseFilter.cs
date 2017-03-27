using WordCounterService.Domain;
using System.Linq;

namespace WordCounterService.Application.DataFilter
{
    public class IgnoreCaseFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection words)
        {
            words.Where(d => {
                if (d.Key.Any(char.IsUpper))
                {
                    words.AddToCounter(d.Key.ToLower());
                    words.Remove(d.Key);
                }
                return false;
            });

            return words;
        }
    }
}