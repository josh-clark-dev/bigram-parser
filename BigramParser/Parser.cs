using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BigramParser
{
    public class Parser
    {
        /// <summary>
        /// This method will parse the input text, remove any special characters, and return a list of words.
        /// </summary>
        /// <param name="inputText">The input text from either a string or a file</param>
        /// <returns>A read only collection of words</returns>
        public IReadOnlyCollection<string> ParseText(string inputText)
        {
            if (inputText == null) return Array.Empty<string>();

            var text = RemoveSpecialCharacters(inputText);

            var wordList = GetWordList(text);

            return wordList;
        }

        readonly Regex parserFilter = new Regex("[^0-9a-zA-Z ']+", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private string RemoveSpecialCharacters(string text)
        {
            return parserFilter.Replace(text, string.Empty);
        }

        private static IReadOnlyCollection<string> GetWordList(string text)
        {
            return text
                .Split(" ")
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToArray();
        }
    }
}
