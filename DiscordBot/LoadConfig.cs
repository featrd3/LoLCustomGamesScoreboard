using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RitoForCustoms.DiscordBot
{
    public class LoadConfig
    {
        public static async Task<string> GetContentOfConfigFile()
        {
            var tempConfigfromFileStream = string.Empty;
            using (var fileStream = File.OpenRead(@"..\..\..\BotConfigFile.json"))
            using (var streamReader = new StreamReader(fileStream, new UTF8Encoding(false)))
                tempConfigfromFileStream = await streamReader.ReadToEndAsync().ConfigureAwait(false);
            return tempConfigfromFileStream;

        }
    }
}
