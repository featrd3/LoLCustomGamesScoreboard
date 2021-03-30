using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace RitoForCustoms
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var httpclient = new HttpClient();

            string valAPI = "X-Riot-Token";
            string keyAPI = "RGAPI-983c7f2f-3a48-41fe-a698-28976b2af30b";

            string summonerName = "FeatRd3";

            var freeRotation = await RitoRequests.AskFreeRotation(valAPI, keyAPI, httpclient);

            var allChampionsList = await RitoRequests.AskAllChampions(httpclient);

            var summonerData = await RitoRequests.AskSummonerByName(valAPI, keyAPI, httpclient, summonerName);

            var championRotationNames = ConversionAndExtractionFromRequests.ChampionIDtoName(freeRotation, allChampionsList);

            var matchHistoryByAccount = await RitoRequests.AskMatchByAccountID(valAPI, keyAPI, httpclient, summonerData.accountId, "champion&queue&season&endTime&beginTime&endIndex&beginIndex");

        }
    }
}
