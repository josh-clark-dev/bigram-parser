using System.Linq;
using System.Collections.Generic;

namespace BigramParser
{
    public class Histogram
    {
        private readonly Parser parser;

        public Histogram(Parser parser)
        {
            this.parser = parser;
        }

        /// <summary>
        /// Get bigram histogram
        /// </summary>
        /// <returns>A collection of Bigrams</returns>
        public IReadOnlyCollection<IBigram> GetHistogram(string text)
        {
            var words = parser.ParseText(text);

            var histogram = FindBigrams(words);

            return histogram;
        }

        public IReadOnlyCollection<IBigram> FindBigrams(IReadOnlyCollection<string> wordList)
        {
            var bigrams = new Dictionary<string, int>();

            var words = wordList.ToArray();

            for (var i = 0; i < words.Length; i++)
            {
                if (words.Length == i + 1) break;

                var bigram = $"{words[i].ToLower()} {words[i + 1].ToLower()}";

                if (bigrams.ContainsKey(bigram))
                {
                    bigrams[bigram] += 1;
                }
                else
                {
                    bigrams.Add(bigram, 1);
                }
            }

            return bigrams
                 .Select(x => new Bigram(x.Key, x.Value))
                 .ToArray();
        }
    }
}
