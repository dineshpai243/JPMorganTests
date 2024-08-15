using JPMorganTests;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JPMorganUnitTests
{
    [TestFixture]
    public class MaxwordAlphabetSearchTests
    {
        private MaxwordAlphabetSearch _maxwordAlphabetSearch;

        [SetUp]
        public void Setup()
        {
            _maxwordAlphabetSearch = new MaxwordAlphabetSearch();
        }

        [TestCase("This is a very long sentence and I want to educate everyone in this whole crazy world",
           new char[] { 'z', 'e', 'I' },
           new string[] { "crazy", "sentence", "I" })]
        public void CheckAlphabetSearchInSentence(string sentence, char[] toFind, string[] expResult)
        {
            // Arrange
            _maxwordAlphabetSearch.AddOrUpdateSentence(sentence);

            // Act
            for (int i = 0; i < expResult.Length; i++)
            {
                var result = _maxwordAlphabetSearch.FindChar(toFind[i]);

                // Assert
                Assert.AreEqual(expResult[i], result);
            }
        }

        [TestCase("There are. Those are Quite a few fox in the wild",
            new char[] { 'T', 'f', 'l' }, new string[]{"There", "few", "wild"} )]
        public void CheckSameLengthSearch(string sentence, char[] toFind, string[] expResult)
        {
            // Arrange
            _maxwordAlphabetSearch.AddOrUpdateSentence(sentence);

            // Act
            for (int i = 0; i < expResult.Length; i++)
            {
                var result = _maxwordAlphabetSearch.FindChar(toFind[i]);

                // Assert
                Assert.AreEqual(expResult[i], result);
            }
        }

        [Test]
        public void CheckNotFoundAlphabet()
        {
            // Arrange
            _maxwordAlphabetSearch.AddOrUpdateSentence("Check For Non Occurance");

            // Act
            var result = _maxwordAlphabetSearch.FindChar('p');

            // Assert
            Assert.AreEqual(string.Empty, result);
        }

        [Test]
        public void CheckEmptySentence()
        {
            // Arrange
            _maxwordAlphabetSearch.AddOrUpdateSentence("");

            // Act
            var result = _maxwordAlphabetSearch.FindChar('p');

            // Assert
            Assert.AreEqual(string.Empty, result);
        }






    }
}
