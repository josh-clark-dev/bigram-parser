using System.Linq;
using System.Collections.Generic;

namespace BigramParser
{
    public class Histogram
    {
        readonly Parser parser;

        readonly Dictionary<string, int> _Bigrams = new Dictionary<string, int>();

        public Histogram(Parser parser)
        {
            this.parser = parser;
        }

        /// <summary>
        /// Get a histogram of bigrams contained within the text
        /// </summary>
        /// <returns>A readonly collection of bigrams</returns>
        public IReadOnlyCollection<IBigram> GetHistogram(string text)
        {
            var words = parser.ParseText(text);

            var histogram = FindBigrams(words);

            return histogram;
        }

        private IReadOnlyCollection<IBigram> FindBigrams(IReadOnlyCollection<string> wordList)
        {
            GenerateBigrams(wordList.ToArray());

            return _Bigrams
                 .Select(x => new Bigram(x.Key, x.Value))
                 .ToArray();
        }

        private void GenerateBigrams(string[] words)
        {
            for (var i = 0; i < words.Length; i++)
            {
                if (words.Length == i + 1) break;

                if (IsContraction(words[i]))
                {
                    AddOrUpdateBigrams(words[i]);
                }

                var bigram = $"{words[i]} {words[i + 1]}";

                AddOrUpdateBigrams(bigram);
            }
        }

        private bool IsContraction(string word)
        {
            return word.Contains("'");
        }

        private void AddOrUpdateBigrams(string bigram)
        {
            var key = bigram.ToLower();

            if (!_Bigrams.ContainsKey(key))
            {
                _Bigrams.Add(key, 1);
                return;
            }

            _Bigrams[key] += 1;
        }
    }
}
