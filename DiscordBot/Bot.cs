using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.IO;
using Newtonsoft.Json;
using RitoForCustoms.JSONclasses;
using RitoForCustoms.BotCommands;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;

namespace RitoForCustoms.DiscordBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunAsync()
        {
            var tempConfigfromFileStream = await LoadConfig.GetContentOfConfigFile();
            var configJson = JsonConvert.DeserializeObject<BotConfigJSON>(tempConfigfromFileStream);

            var config = new DiscordConfiguration()
            { 
                Token = configJson.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
               
            };
        
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            Client.UseInteractivity(new InteractivityConfiguration()
            {
                PollBehaviour = PollBehaviour.KeepEmojis,
                Timeout = TimeSpan.FromSeconds(Convert.ToInt32(configJson.interactivityTimeout))
            }) ;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.prefix },
                EnableDms = true,
                EnableMentionPrefix = true,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<PingPong>();
            Commands.RegisterCommands<LoLCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
    
        private Task OnClientReady(object sender, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
