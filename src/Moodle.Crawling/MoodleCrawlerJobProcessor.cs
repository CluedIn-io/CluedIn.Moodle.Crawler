using CluedIn.Crawling.Moodle.Core;

namespace CluedIn.Crawling.Moodle
{
    public class MoodleCrawlerJobProcessor : GenericCrawlerTemplateJobProcessor<MoodleCrawlJobData>
    {
        public MoodleCrawlerJobProcessor(MoodleCrawlerComponent component) : base(component)
        {
        }
    }
}
