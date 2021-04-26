using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RitoForCustoms.BotCommandsSupplement
{
    public class CommonBotCommands
    {
        public async static Task<bool> AddAndRespondPoolThumbs(CommandContext ctx, InteractivityExtension interactivity, DiscordEmbedBuilder embed, TimeSpan duration)
        {
            var poll = await ctx.RespondAsync(embed: embed.Build()).ConfigureAwait(false);
            var emojiStringList = new List<string> { ":thumbsup:", ":thumbsdown:" };
            foreach (var emoji in emojiStringList)
            {
                await poll.CreateReactionAsync(DiscordEmoji.FromName(ctx.Client, emoji)).ConfigureAwait(false);
            }

            return await DetermineResponseFromCreatorThumbs(ctx, interactivity, poll, duration);
        }
        public async static Task<bool> DetermineResponseFromCreatorThumbs(CommandContext ctx, InteractivityExtension interactivity,DiscordMessage poll, TimeSpan duration)
        {
            var result = await interactivity.CollectReactionsAsync(poll, duration).ConfigureAwait(false);

            var thumbsDownReaction = result.Where(x => x.Emoji.Name.Equals("👎")).FirstOrDefault();
            if (thumbsDownReaction != null)
            {
                var creatorGaveThumbsDown = thumbsDownReaction.Users.Where(x => x.Username.Equals(ctx.User.Username)).FirstOrDefault();
                if (creatorGaveThumbsDown != null)
                {
                    return (false);
                }
            }
            var thumbsUpReaction = result.Where(x => x.Emoji.Name.Equals("👍")).FirstOrDefault();
            if (thumbsUpReaction == null)
            {
                return (false);
            } else
            {
                var creatorGaveThumbsUp = thumbsUpReaction.Users.Where(x => x.Username.Equals(ctx.User.Username)).FirstOrDefault();
                if (creatorGaveThumbsUp != null)
                {
                    return (true);
                }
            }
            return (false);
        }
    }
}
