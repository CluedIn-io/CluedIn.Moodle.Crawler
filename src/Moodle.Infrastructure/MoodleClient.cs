using System;
using System.Net;
using System.Threading.Tasks;
using CluedIn.Core.Providers;
using CluedIn.Crawling.Moodle.Core;
using Newtonsoft.Json;
using RestSharp;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using CluedIn.Crawling.Moodle.Core.Models;

namespace CluedIn.Crawling.Moodle.Infrastructure
{
    public class MoodleClient
    {
        private readonly ILogger<MoodleClient> _log;
        private readonly MoodleCrawlJobData _crawlJobData;
        private readonly IRestClient _client;

        public MoodleClient(ILogger<MoodleClient> log, MoodleCrawlJobData moodleCrawlJobData)
        {
            _log = log ?? throw new ArgumentNullException(nameof(log));
            _crawlJobData = moodleCrawlJobData ?? throw new ArgumentNullException(nameof(moodleCrawlJobData));

            _client = new RestClient();
            _client.BaseUrl = new Uri("https://moodle.lederne.dk/webservice/rest/server.php?");
        }

        public IEnumerable<User> GetUsers()
        {
            var request = new RestRequest(Method.GET);
            request.AddParameter("wstoken", _crawlJobData.WebserviceToken);
            request.AddParameter("wsfunction", "local_wspraxis_get_users");
            request.AddParameter("moodlewsrestformat", "json");

            var response = _client.Execute(request, request.Method);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                _log.LogError($"Request to failed, response {response.ErrorMessage} ({response.StatusCode})");
                yield break;
            }

            List<User> responseData;
            try
            {
                responseData = JsonConvert.DeserializeObject<List<User>>(response.Content);
            }
            catch (Exception e)
            {
                _log.LogError($"Error trying to parse response data. Message: {e.Message}");
                yield break;
            }

            foreach (var user in responseData)
            {
                yield return user;
            }
        }

        public AccountInformation GetAccountInformation()
        {
            return new AccountInformation("", "");
        }
    }
}
