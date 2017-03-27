using NUnit.Framework;
using System.Collections.Generic;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;

namespace WordCounterTests.UnitTests.DataFilter
{
    [TestFixture]
    public class ComposedWordsFilterTests
    {
        [Test]
        public void Filter_Length_1_ReturnEmpty()
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
            var filterDictionary = new ComposedWordsFilter(1).Filter(inputeData);

            //Assert
            Assert.IsEmpty(filterDictionary);
        }


        [Test]
        public void Filter_Length_0_ReturnFilterWithBigestWordLenght()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "a24", 1},
            };

            //Act
            var filterDictionary = new ComposedWordsFilter(1).Filter(inputeData);
            inputeData.Remove("a");
            inputeData.Remove("24");

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }


        [Test]
        public void Filter_NoComposeWords_ReturnEmpty()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "for", 35},
                { "this", 26},
                { "comma", 1},
                { "question", 1}
            };

            //Act
            var filterDictionary = new ComposedWordsFilter(1).Filter(inputeData);

            //Assert
            Assert.IsEmpty(filterDictionary);
        }


        [Test]
        public void Filter_HaseComposeWords_ReturnsOnlyComposeWords()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "24", 1},
                { "for", 35},
                { "this", 26},
                { "comma", 1},
                { "thiscomma", 26},
                { "quest", 20},
                { "question", 1},
                { "ions", 3}
            };

            //Act
            var filterDictionary = new ComposedWordsFilter(9).Filter(inputeData);
            var expectedDictionary = new WordCountCollection() { { "thiscomma", 26 }, { "questions", 1 } };

            //Assert
            Assert.AreEqual(inputeData, filterDictionary);
        }


        [Test]
        public void Filter_PartialMatch_ReturnsEmpty()
        {
            //Arrange
            WordCountCollection notFullMatch = new WordCountCollection()
            {
                { "a", 1 },
                { "asa", 2 }
            };

            WordCountCollection overlapping = new WordCountCollection()
            {
                { "as", 3 },
                { "sa", 2 },
                { "asa", 2 },
                { "sada", 3 },
                { "sa", 2 },
                { "ada", 2 }
            };

            //Act
            var notFullMatchFilter = new ComposedWordsFilter(3).Filter(notFullMatch);
            var overlappingFilter = new ComposedWordsFilter(4).Filter(overlapping);

            //Assert
            Assert.IsEmpty(notFullMatchFilter);
            Assert.IsEmpty(overlappingFilter);
        }


        [Test]
        public void Filter_EmptyInput_ReturnEmpty()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection() { };

            //Act
            var filterDictionaryLenght0 = new ComposedWordsFilter(0).Filter(inputeData);
            var filterDictionaryLength1 = new ComposedWordsFilter(1).Filter(inputeData);
            var filterDictionaryOtherLenght = new ComposedWordsFilter(25).Filter(inputeData);

            //Assert
            Assert.IsEmpty(filterDictionaryLenght0);
            Assert.IsEmpty(filterDictionaryLength1);
            Assert.IsEmpty(filterDictionaryOtherLenght);
        }
    }
}
