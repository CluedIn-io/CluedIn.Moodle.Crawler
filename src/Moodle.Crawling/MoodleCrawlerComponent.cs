using CluedIn.Core;
using CluedIn.Crawling.Moodle.Core;

using ComponentHost;

namespace CluedIn.Crawling.Moodle
{
    [Component(MoodleConstants.CrawlerComponentName, "Crawlers", ComponentType.Service, Components.Server, Components.ContentExtractors, Isolation = ComponentIsolation.NotIsolated)]
    public class MoodleCrawlerComponent : CrawlerComponentBase
    {
        public MoodleCrawlerComponent([NotNull] ComponentInfo componentInfo)
            : base(componentInfo)
        {
        }
    }
}

