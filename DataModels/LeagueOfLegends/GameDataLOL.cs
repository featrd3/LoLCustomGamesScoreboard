using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RitoForCustoms.DataModels.LeagueOfLegends
{
    class GameDataLOL
    {
        public string Map { get; set; }
        public DateTime Date { get; set; }
        public List<PlayerDataLOL> PlayerInfo { get; set; }

        public GameDataLOL(string msg)
        {
            var date = DateTime.Now;
            var splitByVerticalLine = msg.Split('|');
            var mode = splitByVerticalLine[0];
            var winningTeam = splitByVerticalLine[1];
            var losingTeam = splitByVerticalLine[2];

            PlayerDataLOL playerDataWin = new PlayerDataLOL();
            var playerDataW = playerDataWin.PlayerDataFill(winningTeam.Split(';'), date, true);
            PlayerDataLOL playerDataLose = new PlayerDataLOL();
            var playerDataL = playerDataLose.PlayerDataFill(losingTeam.Split(';'), date, false);

            Date = date;
            Map = mode;
            PlayerInfo = playerDataW.Concat(playerDataL).ToList();
        }

    }
}
