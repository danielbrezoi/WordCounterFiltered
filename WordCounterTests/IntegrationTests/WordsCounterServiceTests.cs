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
        private WordsCounterService GetService(string data, IEnumerable<FiltersEnum> filters, int lenght)
        {
            var result = new Result();
            Mock<IDataReader> mockDataReader = new Mock<IDataReader>();
            mockDataReader.Setup(t => t.ReadData(result));
            mockDataReader.Setup(t => t.GetData()).Returns(data);

            return new WordsCounterService(mockDataReader.Object, result, filters, lenght);
        }

        [Test, TestCaseSource(typeof(WordsCounterServiceTests), "AllFilters")]
        public WordCountCollection Service_WithAllFilters_ReturnFilterResult(string data, int lenght)
        {
            var filters = new List<FiltersEnum>() { FiltersEnum.IgnoreCase, FiltersEnum.Digits, FiltersEnum.Punctuation, FiltersEnum.Compose };
            var service = GetService(data, filters, lenght);

            var actualResult = service.GetWordsCounter();

            return actualResult;
        }

        public static IEnumerable AllFilters
        {
            get
            {
                yield return new TestCaseData("This is. my th!", 4).Returns(new WordCountCollection() { { "this", 1 } });
                yield return new TestCaseData("This is. my th! thiS Is. my tH!", 4).Returns(new WordCountCollection() { { "this", 2 } });

                var data = "al, albums, aver, bar, barely, be, befoul, bums, by, cat, con, convex, ely, foul, here, hereby, jig, jigsaw, or, saw, tail, tailor, vex, we, weaver";
                var expectedResult = new WordCountCollection() { { "albums", 1 }, { "barely", 1 }, { "befoul", 1 }, { "convex", 1 }, { "hereby", 1 }, { "jigsaw", 1 }, { "tailor", 1 }, { "weaver", 1 } };
                yield return new TestCaseData(data, 6).Returns(expectedResult);
            }
        }
    }
}
