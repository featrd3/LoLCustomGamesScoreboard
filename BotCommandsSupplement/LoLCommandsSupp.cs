using DSharpPlus.Entities;
using RitoForCustoms.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using static RitoForCustoms.DataModels.LoLGameData;

namespace RitoForCustoms.BotCommandsSupplement
{
    class LoLCommandsSupp
    {
        public static  DiscordEmbedBuilder LolEmbedBuilder(GameData gameData)
        {
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
            return embed;
        }
    }
}
