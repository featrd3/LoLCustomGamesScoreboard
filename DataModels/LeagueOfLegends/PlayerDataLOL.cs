using System;
using System.Collections.Generic;
using System.Text;

namespace RitoForCustoms.DataModels.LeagueOfLegends
{
    class PlayerDataLOL
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Champion { get; set; }
        public bool Victory { get; set; }

        public List<PlayerDataLOL> PlayerDataFill(string[] stringPlayers, DateTime date, Boolean victoryBool)
        {
            List<PlayerDataLOL> winningData = new List<PlayerDataLOL>();

            foreach (string j in stringPlayers)
            {
                var playerInfo = j.Split('=');

                var player = new PlayerDataLOL();
                player.Date = date;
                player.Name = playerInfo[0];
                player.Champion = playerInfo[1];
                player.Victory = victoryBool;

                winningData.Add(player);
            };
            return (winningData);
        }
    }
}
