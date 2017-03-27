using NUnit.Framework;
using WordCounterService.Application.DataFilter;
using WordCounterService.Domain;

namespace WordCounterTests.UnitTests.DataFilter
{
    [TestFixture]
    public class IgnoreCaseFilterTests
    {
        [Test]
        public void Filter_AllLower_ReturnInpute()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "a", 1 },
                { "comma,", 1},
                { "for", 35},
                { "question?", 1},
                { "this", 26}

            };

            //Act
            var actual = new IgnoreCaseFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(inputeData, actual);
        }

        [Test]
        public void Filter_AllUpper_ReturnAllLower()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "A", 1 },
                { "FOR", 35},
                { "THIS", 26},
                { "COMA,", 1},
                { "QUESTION?", 1}
            };

            WordCountCollection expected = new WordCountCollection()
            {
                { "a", 1 },
                { "for", 35},
                { "this", 26},
                { "coma,", 1},
                { "question?", 1}
            };

            //Act
            var actual = new IgnoreCaseFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_SomeUpper_ReturnAllLower()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection()
            {
                { "A", 1 },
                { "for", 35},
                { "This", 26},
                { "coMa,", 1},
                { "QUESTION?", 1}
            };

            WordCountCollection expected = new WordCountCollection()
            {
                { "a", 1 },
                { "for", 35},
                { "this", 26},
                { "coma,", 1},
                { "question?", 1}
            };

            //Act
            var actual = new IgnoreCaseFilter().Filter(inputeData);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Filter_EmptyDictionary_ReturnEmptyDictionary()
        {
            //Arrange
            WordCountCollection inputeData = new WordCountCollection() { };

            //Act
            var actual = new IgnoreCaseFilter().Filter(inputeData);

            //Assert
            Assert.IsEmpty(actual);
        }
    }
}
