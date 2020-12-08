namespace BigramParser
{
    public interface IBigram
    {
        string Words { get; }
        int Count { get; }
    }

    public class Bigram : IBigram
    {
        public string Words { get; }
        public int Count { get; }

        public Bigram(string words, int count)
        {
            Words = words;
            Count = count;
        }
    }
}
