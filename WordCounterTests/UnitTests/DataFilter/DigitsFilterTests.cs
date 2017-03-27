using NUnit.Framework;
using System.Collections.Generic;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;

namespace WordCounterTests.UnitTests.DataFilter
{
    [TestFixture]
    public class DigitsFilterTests
    {
        [Test]
        public void Filter_NoDigits_DontFilter()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "for", 35},
                { "this", 26},
                { "comma,", 1},
                { "question?", 1}
            };

            //Act
            var filterDictionary = new DigitsFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }

        [Test]
        public void Filter_DigitsWords_ReturnFilter()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
                { "for", 35},
                { "this", 26},
                { "comma,", 1},
                { "question?", 1}
            };

            //Act
            var filterDictionary = new DigitsFilter().Filter(inputeData);
            inputeData.Remove("24");
            inputeData.Remove("a24");

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }

        [Test]
        public void Filter_OnlyDigitsWords_ReturnEmptyDictionary()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "24", 1},
                { "a24", 1},
            };

            //Act
            var filterDictionary = new DigitsFilter().Filter(inputeData);
            inputeData.Remove("24");
            inputeData.Remove("a24");

            //Assert
            Assert.IsEmpty(filterDictionary);
        }

        [Test]
        public void Filter_EmptyDictionary_ReturnEmptyDictionary()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection() { };

            //Act
            var filterDictionary = new DigitsFilter().Filter(inputeData);

            //Assert
            Assert.IsEmpty(filterDictionary);
        }
    }
}
