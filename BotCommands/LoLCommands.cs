using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity.Extensions;
using Newtonsoft.Json;
using RitoForCustoms.BotCommandsSupplement;
using RitoForCustoms.DataModels;
using RitoForCustoms.DiscordBot;
using RitoForCustoms.JSONclasses;
using RitoForCustoms.JSONclasses.LeagueOfLegends;
using System;
using System.Collections.Generic;
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
            var interactivity = ctx.Client.GetInteractivity();

            var gameData = LoLGameData.GameDataFill(msg);
            var embed = LoLCommandsSupp.LolEmbedBuilder(gameData);

            var tempConfigfromFileStream = await LoadConfig.GetContentOfConfigFile();
            var configJson = JsonConvert.DeserializeObject<BotConfigJSON>(tempConfigfromFileStream);
            var duration = TimeSpan.FromSeconds(Convert.ToInt32(configJson.pollDuration)); 

            var response = await CommonBotCommands.AddAndRespondPoolThumbs(ctx, interactivity, embed, duration);

            if (response)
                await ctx.Channel.SendMessageAsync("Input accepted").ConfigureAwait(false);
            else
                await ctx.Channel.SendMessageAsync("nok").ConfigureAwait(false);
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
            var msg = string.Join(", ", championRotationNames);

            await ctx.Channel.SendMessageAsync(msg).ConfigureAwait(false);

        }
    }
}
