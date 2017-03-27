using System.Linq;
using System.Collections.Generic;
using WordCounterService.Utils;
using WordCounterService.Domain;

namespace WordCounterService.Application.DataFilter
{
    public class ComposedWordsFilter : IFilter
    {
        private int _wordLength;
        private List<string> _wordsThatMatch = new List<string>();

        public ComposedWordsFilter(int wordLength)
        {
            _wordLength = wordLength;
        }

        public WordCountCollection Filter(WordCountCollection wordsCounter)
        {
            var allPossiblePartWords = new List<string>();
            var wordsCounterKesy = wordsCounter.Keys.ToList();
            wordsCounter.ForEach(d => { if (d.Key.Length < _wordLength) { allPossiblePartWords.Add(d.Key); } });
            IEnumerable<ComposedWord> allPosibleComposedWords = wordsCounterKesy.Where(d => d.Length == _wordLength)
                                                                                .ForEach(d => new ComposedWord(d));

            for (int length = 1; length <=_wordLength/2; length++)
            {
                MatchWordsWithLenght(allPosibleComposedWords.ToList(), allPossiblePartWords, length);
            }

            wordsCounterKesy.ForEach(d => { if (!_wordsThatMatch.Contains(d)) { wordsCounter.Remove(d); }});

            return wordsCounter;
        }


        private void MatchWordsWithLenght(List<ComposedWord> composedWords, IEnumerable<string> words, int length)
        {
            var isWordHalfLenght = _wordLength % 2 == 0 && 
                                    length == _wordLength / 2;

            if (isWordHalfLenght) { MatchWordsWithSameLengh(composedWords, words, length); }
            else { MatchWordsDifferentLenght(composedWords, words, length); }
        }


        private void MatchWordsWithSameLengh(List<ComposedWord> composedWords, IEnumerable<string> words, int length)
        {
            List<string> partialWords = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == length && !partialWords.Contains(word)) { partialWords.Add(word); }
            }
            FindMatch(composedWords, partialWords, partialWords);
        }


        private void MatchWordsDifferentLenght(List<ComposedWord> composedWords, IEnumerable<string> words, int length)
        {
            List<string> partialWordLengthA = new List<string>();
            List<string> partialWordLengthB = new List<string>();
            foreach (var word in words)
            {
                if (word.Length == length && !partialWordLengthA.Contains(word)) { partialWordLengthA.Add(word); }
                else if (word.Length == _wordLength - length && !partialWordLengthB.Contains(word)) { partialWordLengthB.Add(word); }
            }
            FindMatch(composedWords, partialWordLengthA, partialWordLengthB);
        }


        private void FindMatch(List<ComposedWord> composedWords, 
                               IEnumerable<string> PartialWordsWithLenghtA, 
                               IEnumerable<string> PartialWordsWithLenghtB)
        {
            foreach (var composedWord in composedWords)
            {
                composedWord.Match(startWords: PartialWordsWithLenghtA, endWords: PartialWordsWithLenghtB);
                composedWord.Match(startWords: PartialWordsWithLenghtB, endWords: PartialWordsWithLenghtA);
                if(composedWord.IfFullMatch()) { _wordsThatMatch.Add(composedWord.Word); }
            }
        }
    }    
}
