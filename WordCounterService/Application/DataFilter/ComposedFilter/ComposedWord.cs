using System.Collections.Generic;
using WordCounterService.Utils;

namespace WordCounterService.Application.DataFilter
{
    public class ComposedWord
    {
        public string Word { get; private set; }
        private bool _starWithExistingWord;
        private bool _endWithExistingWord;

        public ComposedWord(string word)
        {
            Word = word;
            _starWithExistingWord = false;
            _endWithExistingWord = false;
        }

        public void Match(IEnumerable<string> startWords, IEnumerable<string> endWords)
        {
            if (!IfFullMatch())
            {
                _starWithExistingWord = false;
                _endWithExistingWord = false;
                startWords.ForEach(word => { if (Word.StartsWith(word)) { _starWithExistingWord = true; } });
                endWords.ForEach(word => { if (Word.EndsWith(word)) { _endWithExistingWord = true; } });
            }
        }

        public bool IfFullMatch()
        {
            return _starWithExistingWord && _endWithExistingWord;
        }
    }
}
