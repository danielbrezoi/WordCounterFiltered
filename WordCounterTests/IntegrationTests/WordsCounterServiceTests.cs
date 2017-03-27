using Moq;
using NUnit.Framework;
using WordCounterService;
using WordCounterService.Application.DataReader;
using WordCounterService.Utils;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;
using System.Collections;
using System.Collections.Generic;

namespace WordCounterTests.IntegrationTests
{
    [TestFixture]
    public class WordsCounterServiceTests
    {
        private WordsCounterService GetService(string data, IEnumerable<FiltersEnum> filters)
        {
            var result = new Result();
            Mock<IDataReader> mockDataReader = new Mock<IDataReader>();
            mockDataReader.Setup(t => t.ReadData(result));
            mockDataReader.Setup(t => t.GetData()).Returns(data);

            return new WordsCounterService(mockDataReader.Object, result, filters);
        }

        [Test, TestCaseSource(typeof(WordsCounterServiceTests), "AllFilters")]
        public WordCountCollection Service_WithAllFilters_ReturnFilterResult(string data, int length)
        {
            var filters = new List<FiltersEnum>() { FiltersEnum.IgnoreCase, FiltersEnum.Digits, FiltersEnum.Punctuation, FiltersEnum.Compose };
            var service = GetService(data, filters);

            var actualResult = service.GetWordsCounter(length);

            return actualResult;
        }

        public static IEnumerable AllFilters
        {
            get
            {
                yield return new TestCaseData("This is. my th!", 4).Returns(new WordCountCollection() { { "this", 1 } });
                yield return new TestCaseData("This is. my th! thiS Is. my tH!", 4).Returns(new WordCountCollection() { { "this", 2 } });
            }
        }
    }
}
