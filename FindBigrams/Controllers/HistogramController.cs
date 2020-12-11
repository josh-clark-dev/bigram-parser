using BigramParser;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FindBigrams.Controllers
{
    [ApiController]
    public class HistogramController : ControllerBase
    {
        readonly Histogram _histogramInstance;

        public HistogramController()
        {
            _histogramInstance = new Histogram(new Parser());
        }

        [HttpPost]
        [Route("/api/histogram")]
        public IReadOnlyCollection<IBigram> GetHistogram(UserInput input)
        {
            var histogram = _histogramInstance.GetHistogram(input.Text);

            return histogram;
        }
    }
}