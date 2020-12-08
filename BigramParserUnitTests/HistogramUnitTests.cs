using System;
using System.Linq;
using Xunit;
using BigramParser;

namespace BigramParserUnitTests
{
    public class HistogramUnitTests
    {
        [Fact]
        public void GetHistogram_EmptyText_EmptyIBigramList()
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(null);

            Assert.True(wordList.Count == 0);
        }

        [Theory]
        [InlineData("Quick!", "")]
        [InlineData("The Quick.", "the quick: 1")]
        [InlineData("The Quick The Quick.", "the quick: 2,quick the: 1")]
        //[InlineData("I'm a test", "i'm a test: 1")] // TODO: tomorrow
        public void GetHistogram_ValidBigrams_IBigramList(string text, string expected)
        {
            var histogram = new Histogram(new Parser());

            var wordList = histogram.GetHistogram(text);

            var actual = string.Join(",", wordList.Select(x => $"{x.Words}: {x.Count}"));

            Assert.Equal(expected, actual);
        }
    }
}
