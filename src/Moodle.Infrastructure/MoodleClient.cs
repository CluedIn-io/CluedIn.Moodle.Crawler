using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CluedIn.Core.Logging;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Moodle.Core;
using Newtonsoft.Json;
using RestSharp;

namespace CluedIn.Crawling.Moodle.Infrastructure
{
    // TODO - This class should act as a client to retrieve the data to be crawled.
    // It should provide the appropriate methods to get the data
    // according to the type of data source (e.g. for AD, GetUsers, GetRoles, etc.)
    // It can receive a IRestClient as a dependency to talk to a RestAPI endpoint.
    // This class should not contain crawling logic (i.e. in which order things are retrieved)
    public class MoodleClient
    {
        private const string BaseUri = "http://sample.com";

        private readonly ILogger log;

        private readonly IRestClient client;

        public MoodleClient(ILogger log, MoodleCrawlJobData moodleCrawlJobData, IRestClient client) // TODO: pass on any extra dependencies
        {
            if (moodleCrawlJobData == null)
            {
                throw new ArgumentNullException(nameof(moodleCrawlJobData));
            }

            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.log = log ?? throw new ArgumentNullException(nameof(log));
            this.client = client ?? throw new ArgumentNullException(nameof(client));

            // TODO use info from moodleCrawlJobData to instantiate the connection
            client.BaseUrl = new Uri(BaseUri);
            client.AddDefaultParameter("api_key", moodleCrawlJobData.ApiKey, ParameterType.QueryString);
        }

        private async Task<T> GetAsync<T>(string url)
        {
            var request = new RestRequest(url, Method.GET);

            var response = await client.ExecuteTaskAsync(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var diagnosticMessage = $"Request to {client.BaseUrl}{url} failed, response {response.ErrorMessage} ({response.StatusCode})";
                log.Error(() => diagnosticMessage);
                throw new InvalidOperationException($"Communication to jsonplaceholder unavailable. {diagnosticMessage}");
            }

            var data = JsonConvert.DeserializeObject<T>(response.Content);

            return data;
        }

        public AccountInformation GetAccountInformation()
        {
            //TODO - return some unique information about the remote data source
            // that uniquely identifies the account
            return new AccountInformation("", ""); 
        }

        public IEnumerable<object> Get(string token, string function)
        {
            var request = string.Format("http://moodleurl.com/webservice/rest/server.php?wstoken={0}&wsfunction={1}&moodlewsrestformat=json", token, function);
            using (HttpClient httpClient = new HttpClient())
            {
                var response = httpClient.GetAsync(request).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //TODO log error
                }
                else if (response.StatusCode != HttpStatusCode.OK)
                {
                    //TODO: log error
                }
                var results = JsonConvert.DeserializeObject<List<object>>(responseContent);
                foreach (var item in results)
                {
                    yield return item;
                }
            }
        }
    }
}
