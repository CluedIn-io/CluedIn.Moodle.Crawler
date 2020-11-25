using Castle.Windsor;
using CluedIn.Core;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Moodle.Infrastructure.Factories;
using Moq;

namespace CluedIn.Provider.Moodle.Unit.Test.MoodleProvider
{
    public abstract class MoodleProviderTest
    {
        protected readonly ProviderBase Sut;

        protected Mock<IMoodleClientFactory> NameClientFactory;
        protected Mock<IWindsorContainer> Container;

        protected MoodleProviderTest()
        {
            Container = new Mock<IWindsorContainer>();
            NameClientFactory = new Mock<IMoodleClientFactory>();
            var applicationContext = new ApplicationContext(Container.Object);
            Sut = new Moodle.MoodleProvider(applicationContext, NameClientFactory.Object);
        }
    }
}
