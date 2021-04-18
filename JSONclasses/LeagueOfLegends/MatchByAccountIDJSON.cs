using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace RitoForCustoms
{
    
        public class Match
        {
            public string platformId { get; set; }
            public object gameId { get; set; }
            public int champion { get; set; }
            public int queue { get; set; }
            public int season { get; set; }
            public object timestamp { get; set; }
            public string role { get; set; }
            public string lane { get; set; }
        }

        public class RootMatchByAccID
        {
            public List<Match> matches { get; set; }
            public int startIndex { get; set; }
            public int endIndex { get; set; }
            public int totalGames { get; set; }
        }

    }


