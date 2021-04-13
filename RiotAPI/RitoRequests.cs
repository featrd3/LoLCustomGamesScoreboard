using Newtonsoft.Json;
using RitoForCustoms;
using RitoForCustoms.RiotAPI;
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
            Uri myUri = new Uri("http://ddragon.leagueoflegends.com/cdn/11.6.1/data/en_US/champion.json", UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient);
            var allChampionResponse = JsonConvert.DeserializeObject<RootChampionDTO>(content);
            return allChampionResponse;
        }

        public async static Task<ChampionRotationJSON> AskFreeRotation(string valAPI, string keyAPI, HttpClient httpclient)
        {
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/platform/v3/champion-rotations", UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient, valAPI, keyAPI);
            var rotationResponse = JsonConvert.DeserializeObject<ChampionRotationJSON>(content);
            return rotationResponse;
        }

        public async static Task<SummonerData> AskSummonerByName(string valAPI, string keyAPI, HttpClient httpclient, string summonerName)
        {
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/summoner/v4/summoners/by-name/" + summonerName, UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient, valAPI, keyAPI);
            var summonerResponse = JsonConvert.DeserializeObject<SummonerData>(content);
            return summonerResponse;
        }

        public async static Task<RootMatchByMatchID> AskMatchByMatchID(string valAPI, string keyAPI, HttpClient httpclient, string matchID)
        {
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/match/v4/matches/" + matchID, UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient, valAPI, keyAPI);
            var summonerResponse = JsonConvert.DeserializeObject<RootMatchByMatchID>(content);
            return summonerResponse;
        }

        public async static Task<RootMatchByAccID> AskMatchByAccountID(string valAPI, string keyAPI, HttpClient httpclient, string EncryptedSummonerID, string parameters)
        {
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/" + EncryptedSummonerID + "?" + parameters, UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient, valAPI, keyAPI);
            var summonerResponse = JsonConvert.DeserializeObject<RootMatchByAccID>(content);
            return summonerResponse;
        }
        public async static Task<RootMatchByMatchID> AskMatchByTournamentID(string valAPI, string keyAPI, HttpClient httpclient, string tournamentCode ,string matchID)
        {
            Uri myUri = new Uri("https://eun1.api.riotgames.com/lol/match/v4/matches/by-tournament-code/" + tournamentCode +"/"+ matchID, UriKind.Absolute);
            var content = await CreateAndSendRequest.SendRequest(myUri, httpclient, valAPI, keyAPI);
            var summonerResponse = JsonConvert.DeserializeObject<RootMatchByMatchID>(content);
            return summonerResponse;
        }
    }
}
