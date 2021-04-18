using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RitoForCustoms.DataModels
{
    class LoLGameData
    {
        public class GameData
        {
            public string Map { get; set; }
            public DateTime Date { get; set; }
            public List<PlayerData> PlayerInfo { get; set; }

            public GameData(string msg)
            {
                var date = DateTime.Now;
                var splitByVerticalLine = msg.Split('|');
                var mode = splitByVerticalLine[0];
                var winningTeam = splitByVerticalLine[1];
                var losingTeam = splitByVerticalLine[2];

                LoLGameData.PlayerData playerDataWin = new LoLGameData.PlayerData();
                var playerDataW = playerDataWin.PlayerDataFill(winningTeam.Split(';'), date, true);
                LoLGameData.PlayerData playerDataLose = new LoLGameData.PlayerData();
                var playerDataL = playerDataLose.PlayerDataFill(losingTeam.Split(';'), date, false);

                Date = date;
                Map = mode;
                PlayerInfo = playerDataW.Concat(playerDataL).ToList();
            }
            
        }

        public class PlayerData
        {
            public DateTime Date { get; set; }
            public string Name { get; set; }
            public string Champion { get; set; }
            public bool Victory { get; set; }

            public List<PlayerData> PlayerDataFill(string[] stringPlayers, DateTime date, Boolean victoryBool)
            {
                List<PlayerData> winningData = new List<PlayerData>();

                foreach (string j in stringPlayers)
                {
                    var playerInfo = j.Split('=');

                    var player = new PlayerData();
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
}
