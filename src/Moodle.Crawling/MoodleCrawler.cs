using System.Collections.Generic;

using CluedIn.Core.Crawling;
using CluedIn.Crawling.Moodle.Core;
using CluedIn.Crawling.Moodle.Infrastructure.Factories;

namespace CluedIn.Crawling.Moodle
{
    public class MoodleCrawler : ICrawlerDataGenerator
    {
        private readonly IMoodleClientFactory clientFactory;
        public MoodleCrawler(IMoodleClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public IEnumerable<object> GetData(CrawlJobData jobData)
        {
            if (!(jobData is MoodleCrawlJobData moodlecrawlJobData))
            {
                yield break;
            }

            var client = clientFactory.CreateNew(moodlecrawlJobData);

            //retrieve data from provider and yield objects
            
        }       
    }
}
