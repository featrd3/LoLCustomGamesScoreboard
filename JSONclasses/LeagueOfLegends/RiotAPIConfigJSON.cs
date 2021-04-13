using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RitoForCustoms.JSONclasses.LeagueOfLegends
{
    public class RiotAPIConfigJSON
    {
        [JsonProperty("valAPI")]
        public string valAPI { get; private set; }
        [JsonProperty("keyAPI")]
        public string keyAPI { get; private set; }
    }
}
