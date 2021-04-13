using Newtonsoft.Json;
using RitoForCustoms.DiscordBot;
using System;
using System.Net.Http;

namespace RitoForCustoms
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }
    }
}
