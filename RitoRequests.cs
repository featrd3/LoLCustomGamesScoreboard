using Newtonsoft.Json;
using RitoForCustoms;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RitoForCustoms
{
    public class RitoRequests
    {
        public async static Task<RootChampionDTO> AskAllChampions(HttpClient httpclient)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Uri myUri = new Uri("http://ddragon.leagueoflegends.com/cdn/11.6.1/data/en_US/champion.json", UriKind.Absolute);
            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var allChampionResponse = JsonConvert.DeserializeObject<RootChampionDTO>(content);
            return allChampionResponse;
        }

        public async static Task<ChampionRotationJSON> AskFreeRotation(string valAPI, string keyAPI, HttpClient httpclient)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/platform/v3/champion-rotations", UriKind.Absolute);
            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            request.Headers.Add(valAPI, keyAPI);
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var rotationResponse = JsonConvert.DeserializeObject<ChampionRotationJSON>(content);
            return rotationResponse;
        }

        public async static Task<SummonerData> AskSummonerByName(string valAPI, string keyAPI, HttpClient httpclient, string summonerName)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + summonerName, UriKind.Absolute);

            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            request.Headers.Add(valAPI, keyAPI);
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var summonerResponse = JsonConvert.DeserializeObject<SummonerData>(content);
            return summonerResponse;
        }

        public async static Task<SummonerData> AskMatchByMatchID(string valAPI, string keyAPI, HttpClient httpclient, string matchID)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/match/v4/matches/" + matchID, UriKind.Absolute);

            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            request.Headers.Add(valAPI, keyAPI);
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var summonerResponse = JsonConvert.DeserializeObject<SummonerData>(content);
            return summonerResponse;
        }

        public async static Task<SummonerData> AskMatchByAccountID(string valAPI, string keyAPI, HttpClient httpclient, string EncryptedSummonerID, string parameters)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + EncryptedSummonerID + "?" + parameters, UriKind.Absolute);

            request.RequestUri = myUri;
            request.Method = HttpMethod.Get;
            request.Headers.Add(valAPI, keyAPI);
            HttpResponseMessage response = await httpclient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var summonerResponse = JsonConvert.DeserializeObject<SummonerData>(content);
            return summonerResponse;
        }
    }
}
