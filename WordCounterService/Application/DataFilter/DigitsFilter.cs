using WordCounterService.Utils;
using System.Text.RegularExpressions;
using WordCounterService.Domain;
using System.Linq;

namespace WordCounterService.Application.DataFilter
{
    public class DigitsFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            string digitsPattern = @"\d";
            var words = wordsCounter.Keys.ToList();
            words.ForEach(d => { if (Regex.IsMatch(d, digitsPattern)) { wordsCounter.Remove(d); }});

            return wordsCounter;
        }
    }
}
