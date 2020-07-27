using CluedIn.Core.Crawling;
using CluedIn.Crawling;
using CluedIn.Crawling.Moodle;
using CluedIn.Crawling.Moodle.Infrastructure.Factories;
using Moq;
using Should;
using Xunit;

namespace Crawling.Moodle.Unit.Test
{
    public class MoodleCrawlerBehaviour
    {
        private readonly ICrawlerDataGenerator _sut;

        public MoodleCrawlerBehaviour()
        {
            var nameClientFactory = new Mock<IMoodleClientFactory>();

            _sut = new MoodleCrawler(nameClientFactory.Object);
        }

        [Fact]
        public void GetDataReturnsData()
        {
            var jobData = new CrawlJobData();

            _sut.GetData(jobData)
                .ShouldNotBeNull();
        }
    }
}
