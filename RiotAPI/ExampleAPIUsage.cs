using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace RitoForCustoms.RiotAPI
{
    class ExampleAPIUsage
    {
        static async void Example()
        {
            var httpclient = new HttpClient();

            string valAPI = "X-Riot-Token";
            string keyAPI = "RGAPI-4de6686a-60a6-4101-9d21-bfb67f147902";

            string summonerName = "FeatRd3";

            string matchID = "2787797586";

            int timePeriod = 7200000;

            var freeRotation = await RitoRequests.AskFreeRotation(valAPI, keyAPI, httpclient);

            var allChampionsList = await RitoRequests.AskAllChampions(httpclient);

            var summonerData = await RitoRequests.AskSummonerByName(valAPI, keyAPI, httpclient, summonerName);

            var championRotationNames = ConversionAndExtractionFromRequests.ChampionIDtoName(freeRotation, allChampionsList);

            var matchHistoryByAccount = await RitoRequests.AskMatchByAccountID(valAPI, keyAPI, httpclient, summonerData.accountId, FilterParameters.TimeCustomParameters(timePeriod));

            var matchHistoryByID = await RitoRequests.AskMatchByMatchID(valAPI, keyAPI, httpclient, matchID);

        }
    }
}

