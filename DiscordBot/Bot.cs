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

namespace RitoForCustoms.DiscordBot
{
    public class Bot
    {
        
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead(@"..\..\..\BotConfigFile.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);
            var configJson = JsonConvert.DeserializeObject<BotConfigJSON>(json);


            var config = new DiscordConfiguration()
            {
                Token = configJson.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
                };
        
            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

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
