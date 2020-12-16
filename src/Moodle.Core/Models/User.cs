using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CluedIn.Crawling.Moodle.Core.Models
{
    public class User
    {

        public User() { }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idnumber")]
        public string IdNumber { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("firstname")]
        public string FirstName { get; set; }

        [JsonProperty("lastname")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("auth")]
        public string Auth { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("department")]
        public string Department { get; set; }

        [JsonProperty("alternatename")]
        public string AlternateName { get; set; }

        [JsonProperty("customfields")]
        public List<CustomField> CustomFields { get; set; }

    }
}
