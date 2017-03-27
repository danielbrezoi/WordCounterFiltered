using WordCounterService.Domain;
using WordCounterService.Utils;

namespace WordCounterService.Application.DataFilter
{
    public class PunctuationFilter : IFilter
    {
        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            char[] punctuationSign = new char[11] { '\'', ';', ':', '-', '!', '.', '?', '"', '(', ')', ','};

            wordsCounter.ForEach(d => { string cleanKey = d.Key.Clean(punctuationSign);
                                        if (!cleanKey.Equals(d.Key)) 
                                        {
                                            wordsCounter.Remove(d.Key);
                                            if (!string.IsNullOrEmpty(cleanKey))
                                            {
                                                wordsCounter.AddToCounter(d.Key.Clean(punctuationSign));
                                            }
                                        }});

            return wordsCounter;
        }
    }
}
