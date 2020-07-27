using CluedIn.Crawling.Moodle.Core;

namespace CluedIn.Crawling.Moodle.Infrastructure.Factories
{
    public interface IMoodleClientFactory
    {
        MoodleClient CreateNew(MoodleCrawlJobData moodleCrawlJobData);
    }
}
