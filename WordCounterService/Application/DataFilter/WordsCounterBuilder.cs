using System;
using System.Linq;
using WordCounterService.Domain;

namespace WordCounterService.Application.DataFilter
{
    public class WordsCounterBuilder
    {
        public WordCountCollection SortedWords { get; private set; }

        public static implicit operator WordCountCollection(WordsCounterBuilder builder)
        {
            return builder.Build();
        }

        public WordsCounterBuilder(string data)
        {
            SortedWords = new WordCountCollection();
            var allWords = data.Replace("\r", String.Empty).Replace("\t", String.Empty).Replace("\n", String.Empty).Split(' ');
            foreach (var word in allWords)
            {
                SortedWords.AddToCounter(word);
            }
        }

        public WordsCounterBuilder WithPunctuationFilter()
        {
            if (SortedWords.Any())
            {
                SortedWords = new PunctuationFilter().Filter(SortedWords);
            }
            return this;
        }

        public WordsCounterBuilder WithDigitsFilter()
        {
            if (SortedWords.Any())
            {
                SortedWords = new DigitsFilter().Filter(SortedWords);
            }
            return this;
        }

        public WordsCounterBuilder WithCompositeFilter(int lenghtOfComposedWord)
        {
            var lengthNotProvided = 0;

            if(lenghtOfComposedWord == lengthNotProvided)
            {
                lenghtOfComposedWord = GetMaxWordsLength(SortedWords);
            }
            if (SortedWords.Any())
            {
                SortedWords = new ComposedWordsFilter(lenghtOfComposedWord).Filter(SortedWords);
            }
            return this;
        }

        public WordsCounterBuilder WithIgnoreCaseFilter()
        {
            if (SortedWords.Any())
            {
                SortedWords = new IgnoreCaseFilter().Filter(SortedWords);
            }

            return this;
        }

        public WordCountCollection Build()
        {
            return SortedWords;
        }

        private int GetMaxWordsLength(WordCountCollection sortedWords)
        {
            return SortedWords.Max(d => d.Key.Length);
        }
    }
}
