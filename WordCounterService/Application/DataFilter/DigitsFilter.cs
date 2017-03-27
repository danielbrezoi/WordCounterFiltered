using WordCounterService.Utils;
using System.Text.RegularExpressions;
using WordCounterService.Domain;

namespace WordCounterService.Application.DataFilter
{
    public class DigitsFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            string digitsPattern = @"\d";
            wordsCounter.ForEach(d => { if (Regex.IsMatch(d.Key, digitsPattern)) { wordsCounter.Remove(d.Key); }});

            return wordsCounter;
        }
    }
}
