using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RitoForCustoms.JSONclasses
{
    public class BotConfigJSON
    {
        [JsonProperty("token")]
        public string token { get; private set; }
        [JsonProperty("prefix")]
        public string prefix { get; private set; }
        [JsonProperty("interactivityTimeout")]
        public string interactivityTimeout { get; private set; }
        [JsonProperty("pollDuration")]
        public string pollDuration { get; private set; }
    }
}
