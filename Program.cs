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
            string keyAPI = "RGAPI-6af83c4e-88ac-4774-b87b-71b0106bc5bd";

            var contentID = await RitoRequests.AskFreeRotation(valAPI, keyAPI, httpclient);

            var allChampionsList = await RitoRequests.AskAllChampions(httpclient);

            var championRotationNames = ConversionAndExtractionFromRequests.ChampionIDtoName(contentID, allChampionsList);
            

        }
    }
}
