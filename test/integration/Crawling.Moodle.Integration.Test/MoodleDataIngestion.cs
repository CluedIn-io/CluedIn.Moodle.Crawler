using System.Linq;
using CrawlerIntegrationTesting.Clues;
using Xunit;
using Xunit.Abstractions;

namespace CluedIn.Crawling.Moodle.Integration.Test
{
    public class DataIngestion : IClassFixture<MoodleTestFixture>
    {
        private readonly MoodleTestFixture fixture;
        private readonly ITestOutputHelper output;

        public DataIngestion(MoodleTestFixture fixture, ITestOutputHelper output)
        {
            this.fixture = fixture;
            this.output = output;
        }

        [Theory]
        [InlineData("/Provider/Root", 1)]
        [InlineData("/Infrastructure/User", 4417)]
        public void CorrectNumberOfEntityTypes(string entityType, int leastExpectedCount)
        {
            var foundCount = fixture.ClueStorage.CountOfType(entityType);

            //You could use this method to output the logs inside the test case
            fixture.PrintLogs(output);

            Assert.True(leastExpectedCount <= foundCount, $"{leastExpectedCount} <= {foundCount}");
        }

        [Fact]
        public void EntityCodesAreUnique()
        {
            var count = fixture.ClueStorage.Clues.Count();
            var unique = fixture.ClueStorage.Clues.Distinct(new ClueComparer()).Count();

            //You could use this method to output info of all clues
            fixture.PrintClues(output);

            Assert.Equal(unique, count);
        }

       
    }
}
