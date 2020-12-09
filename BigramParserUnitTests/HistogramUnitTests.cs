using System;
using System.Linq;
using Xunit;
using BigramParser;

namespace BigramParserUnitTests
{
    public class HistogramUnitTests
    {
        [Fact]
        public void GetHistogram_NullText_EmptyIBigramList()
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(null);

            Assert.True(wordList.Count == 0);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void GetHistogram_WhitespaceOnlyText_EmptyIBigramList(string text)
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(text);

            Assert.True(wordList.Count == 0);
        }

        [Theory]
        [InlineData("Quick", "")]
        [InlineData("The Quick", "the quick: 1")]
        [InlineData("The Quick The Quick", "the quick: 2,quick the: 1")]
        public void GetHistogram_ValidBigrams_IBigramList(string text, string expected)
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(text);

            var actual = string.Join(",", wordList.Select(x => $"{x.Words}: {x.Count}"));

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Quick brown!", "quick brown: 1")]
        [InlineData("!@#$%(This !@{}[]\" is*&%$^& awesome).", "this is: 1,is awesome: 1")]
        [InlineData("The Quick The Quick.", "the quick: 2,quick the: 1")]
        public void GetHistogram_SpecialCharacters_IBigramList(string text, string expected)
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(text);

            var actual = string.Join(",", wordList.Select(x => $"{x.Words}: {x.Count}"));

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetHistogram_TextWithLineBreak_IBigramList()
        {
            var histogram = new Histogram(new Parser());

            var text = "the" + Environment.NewLine + " fox";

            var wordList = histogram.GetHistogram(text);

            var actual = string.Join(",", wordList.Select(x => $"{x.Words}: {x.Count}"));

            var expected = "the fox: 1";

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("I'm", "")]
        [InlineData("I'm a contraction.", "i'm: 1,i'm a: 1,a contraction: 1")]
        public void GetHistogram_Contractions_IBigramList(string text, string expected)
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(text);

            var actual = string.Join(",", wordList.Select(x => $"{x.Words}: {x.Count}"));

            Assert.Equal(expected, actual);
        }
    }
}
