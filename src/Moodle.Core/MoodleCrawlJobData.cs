using CluedIn.Core.Crawling;

namespace CluedIn.Crawling.Moodle.Core
{
    public class MoodleCrawlJobData : CrawlJobData
    {
        public string ApiKey { get; set; }
        public string Token { get; set; }
        public string Function { get; set; }
    }
}
