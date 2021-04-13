using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using RitoForCustoms.JSONclasses.LeagueOfLegends;

namespace RitoForCustoms.RiotAPI
{
    class ExampleAPIUsage
    {
        static async void Example()
        {
            var httpclient = new HttpClient();

            var tempConfigfromFileStream = string.Empty;
            using (var fileStream = File.OpenRead(@"..\..\..\BotConfigFile.json"))
            using (var streamReader = new StreamReader(fileStream, new UTF8Encoding(false)))
            tempConfigfromFileStream = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            var configJsonRiotAPI = JsonConvert.DeserializeObject<RiotAPIConfigJSON>(tempConfigfromFileStream);

            string valAPI = configJsonRiotAPI.valAPI;
            string keyAPI = configJsonRiotAPI.keyAPI;

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

