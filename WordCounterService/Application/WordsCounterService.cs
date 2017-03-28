using System.Collections.Generic;
using WordCounterService.Utils;
using WordCounterService.Domain;
using WordCounterService.Application.DataFilter;
using WordCounterService.Application.DataReader;

namespace WordCounterService
{
    public class WordsCounterService
    {
        private readonly string _data;
        private IEnumerable<FiltersEnum> _filters;
        private int _wordsLength;

        public WordsCounterService(IDataReader dataReader, Result result, IEnumerable<FiltersEnum> filters, int wordsLength = 0)
        {
            dataReader.ReadData(result);
            _data = dataReader.GetData();
            _filters = filters;
            _wordsLength = wordsLength;
        }

        public WordCountCollection GetWordsCounter()
        {
            WordsCounterBuilder builder = new WordsCounterBuilder(_data);

            foreach (var filter in _filters)
            {
                switch (filter)
                {
                    case FiltersEnum.Digits:
                        builder = builder.WithDigitsFilter();
                        break;
                    case FiltersEnum.Punctuation:
                        builder = builder.WithPunctuationFilter();
                        break;
                    case FiltersEnum.IgnoreCase:
                        builder = builder.WithIgnoreCaseFilter();
                        break;
                    case FiltersEnum.Compose:
                        builder = builder.WithCompositeFilter(_wordsLength);
                        break;
                    case FiltersEnum.Empty:
                    default:
                        break;
                }
            }

            return builder;
        }
    }
}
