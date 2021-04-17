using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using RitoForCustoms.DataModels;
using RitoForCustoms.DiscordBot;
using RitoForCustoms.JSONclasses.LeagueOfLegends;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RitoForCustoms.BotCommands
{
    class LoLCommands : BaseCommandModule
    {
        [Command("help/lol")]
        public async Task HelpLol(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("lol get help").ConfigureAwait(false);
        }

        [Command("lol")]
        [Description("Requires command in format 'Map|Nick=Champion,Nick=Champion|Nick=Champion,Nick=Champion'. First '|' separates name of map from winning team, and second '|' separetes winning team from loosing team.")]
        public async Task GetGameDataLoL(CommandContext ctx, string msg)
        {
            var gameData = LoLGameData.GameDataFill(msg);
            var embed = new DiscordEmbedBuilder
            {
                Color = new DiscordColor("#FF0000"),
                Title = "Vote up if ok, vote down to cancel",
                Description = "Game summary for mode : " + gameData.Map,
            };
            var newLine = true;
            embed.AddField("--- Victory", "---", false);
            foreach (var player in gameData.PlayerInfo)
            {
                if (player.Victory)
                    embed.AddField((player.Name), player.Champion, true);
                else if (newLine)
                {
                    newLine = false;
                    embed.AddField("--- Defeat", "---", false);
                }
                if (!player.Victory)
                {
                    embed.AddField((player.Name), player.Champion, true);
                };
            }
            await ctx.RespondAsync(embed: embed.Build()).ConfigureAwait(false);
        }

        [Command("lolRotation")]
        public async Task GetFreeRotationLoL(CommandContext ctx)
        {

            var tempConfigfromFileStream = await LoadConfig.GetContentOfConfigFile();
            var configJsonRiotAPI = JsonConvert.DeserializeObject<RiotAPIConfigJSON>(tempConfigfromFileStream);

            string valAPI = configJsonRiotAPI.valAPI;
            string keyAPI = configJsonRiotAPI.keyAPI;

            var httpclient = new HttpClient();
            var freeRotation = await RitoRequests.AskFreeRotation(valAPI, keyAPI, httpclient);
            var allChampionsList = await RitoRequests.AskAllChampions(httpclient);
            var championRotationNames = ConversionAndExtractionFromRequests.ChampionIDtoName(freeRotation, allChampionsList);
            var msg = string.Join(" ,", championRotationNames);

            await ctx.Channel.SendMessageAsync(msg).ConfigureAwait(false);

        }
    }
}
