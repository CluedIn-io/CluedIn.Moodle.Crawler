using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CluedIn.Crawling.Moodle.Core.Models
{
    public class CustomField
    {
        public CustomField() { }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("shortname")]
        public string ShortName { get; set; }
    }
}
