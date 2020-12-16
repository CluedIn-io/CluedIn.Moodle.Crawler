using System.Collections.Generic;
using CluedIn.Crawling.Moodle.Core;

namespace CluedIn.Crawling.Moodle.Integration.Test
{
  public static class MoodleConfiguration
  {
    public static Dictionary<string, object> Create()
    {
      return new Dictionary<string, object>
            {
                { MoodleConstants.KeyName.WebserviceToken, "ead95586e1d9c876fc243f392bf94ffb" }
            };
    }
  }
}
