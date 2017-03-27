using NUnit.Framework;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;

namespace WordCounterTests.UnitTests.DataFilter
{
    [TestFixture]
    public class WordsCounterBuilderTests
    {
        [Test]
        public void Builder_WithoutFilters_ReturnsResult()
        {
            //Arrange
            var inputData = "This is just a test1. This is.";
            var expectedColection = new WordCountCollection()
            {
                { "This", 2 },
                { "is", 1 },
                { "just", 1 },
                { "a", 1},
                { "test1.", 1},
                { "is.", 1}
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData);

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

        public void Builder_WithPunctuationFilters_ReturnsFilterResult()
        {
            //Arrange
            var inputData = "This is just a test1. This is.";
            var expectedColection = new WordCountCollection()
            {
                { "This", 2 },
                { "is", 2 },
                { "just", 1 },
                { "a", 1},
                { "test1", 1}
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData).WithPunctuationFilter();

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

        [Test]
        public void Builder_WithDigitFilters_ReturnsFilterResult()
        {
            //Arrange
            var inputData = "This is just a test1. This is.";
            var expectedColection = new WordCountCollection()
            {
                { "This", 2 },
                { "is", 1 },
                { "just", 1 },
                { "a", 1},
                { "is.", 1}
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData).WithDigitsFilter();

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

        [Test]
        public void Builder_WithComposedFilters_ReturnsFilterResult()
        {
            //Arrange
            var inputData = "This is just a test1. Th is is.";
            var lenghtOfWord = 4;
            var expectedColection = new WordCountCollection()
            {
                { "This", 1 },
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData).WithCompositeFilter(lenghtOfWord);

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

        [Test]
        public void Builder_WithDigitAndPunctuation_Filters_ReturnsFilterResult()
        {
            //Arrange
            var inputData = "This is just a test1. This is.";
            var expectedColection = new WordCountCollection()
            {
                { "This", 2 },
                { "is", 2 },
                { "just", 1 },
                { "a", 1}
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData).WithDigitsFilter().WithPunctuationFilter();

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

        [Test]
        public void Builder_WithDigitAndPunctuationAndComposeFilters_ReturnsFilterResult()
        {
            //Arrange
            var inputData = "This is just a test1. Th is is. This.";
            var sizeOfWord = 4;
            var expectedColection = new WordCountCollection()
            {
                { "this", 2 }
            };

            //Act
            WordCountCollection filterdColection = new WordsCounterBuilder(inputData)
                                                       .WithDigitsFilter()
                                                       .WithPunctuationFilter()
                                                       .WithIgnoreCaseFilter()
                                                       .WithCompositeFilter(sizeOfWord);

            //Assert
            Assert.AreEqual(expectedColection, filterdColection);
        }

    }
}
