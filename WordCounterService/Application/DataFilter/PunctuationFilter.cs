using WordCounterService.Domain;
using WordCounterService.Utils;
using System.Linq;

namespace WordCounterService.Application.DataFilter
{
    public class PunctuationFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            char[] punctuationSign = new char[11] { '\'', ';', ':', '-', '!', '.', '?', '"', '(', ')', ','};
            var words = wordsCounter.Keys.ToList();
            words.ForEach(d => { string cleanKey = d.Clean(punctuationSign);
                                        if (!cleanKey.Equals(d)) 
                                        {
                                            if (!string.IsNullOrEmpty(cleanKey))
                                            {
                                                wordsCounter.AddToCounter(d.Clean(punctuationSign), wordsCounter[d]);
                                            }
                                            wordsCounter.Remove(d);
                                        }});

            return wordsCounter;
        }
    }
}
