using NUnit.Framework;
using System.Collections.Generic;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;

namespace WordCounterTests.UnitTests.DataFilter
{
    [TestFixture]
    public class PunctuationFilterTests
    {
        [Test]
        public void Filter_NoPunctuation_DontFilter()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
                { "for", 35},
                { "this", 26},
            };

            //Act
            var filterDictionary = new PunctuationFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }

        [Test]
        public void Filter_PunctuationInWords_ReturnFilter()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
                { "for", 35},
                { "this", 26},
                { "comma,", 2},
                { "question?", 1}
            };
            var expected = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
                { "for", 35},
                { "this", 26},
                { "comma", 2},
                { "question", 1}
            };

            //Act
            var filterDictionary = new PunctuationFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }

        [Test]
        public void Filter_PunctuationOutsideWords_ReturnFilter()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
                { "for", 35},
                { "this", 26},
                { ",", 1},
                { "?", 1}
            };

            //Act
            var filterDictionary = new PunctuationFilter().Filter(inputeData);
            inputeData.Remove(",");
            inputeData.Remove("?");

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }

        [Test]
        public void Filter_OnlyPunctuation_ReturnEmptyDictionary()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "?", 1},
                { ",", 1}
            };

            //Act
            var filterDictionary = new PunctuationFilter().Filter(inputeData);
            inputeData.Remove("?");
            inputeData.Remove(",");

            //Assert
            Assert.IsEmpty(filterDictionary);
        }

        [Test]
        public void Filter_EmptyDictionary_ReturnEmptyDictionary()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection() { };

            //Act
            var filterDictionary = new PunctuationFilter().Filter(inputeData);

            //Assert
            Assert.IsEmpty(filterDictionary);
        }
    }
}
