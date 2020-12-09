using System;
using Xunit;
using BigramParser;

namespace BigramParserUnitTests
{
    public class ParserUnitTests
    {
        [Fact]
        public void ParseText_EmptyText_EmptyWordList()
        {
            string text = null;

            var parser = new Parser();

            var actual = parser.ParseText(text);
            var expected = Array.Empty<string>();

            Assert.Equal(expected, actual);

        }

        [Theory]
        [InlineData("Quick!", "Quick")]
        [InlineData("The    Quick", "The Quick")]
        [InlineData("The: Quick; Brown.", "The Quick Brown")]
        [InlineData("!@#$%^&*()_+The: Quick;<>?/| Brown.", "The Quick Brown")]
        [InlineData("I'm a test", "I'm a test")]
        public void ParseText_SpecialCharacterRemoval_WordList(string text, string expectedValues)
        {
            var parser = new Parser();

            var actual = parser.ParseText(text);
            var expected = expectedValues.Split(" ");

            Assert.Equal(expected, actual);
        }
    }
}
