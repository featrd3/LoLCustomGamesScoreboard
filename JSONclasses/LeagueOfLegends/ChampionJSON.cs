using System;
using System.Collections.Generic;
using System.Text;

namespace RitoForCustoms
{

    public class ChampionRotationJSON
    {
        public List<int> freeChampionIds { get; set; }
        public List<int> freeChampionIdsForNewPlayers { get; set; }
        public int maxNewPlayerLevel { get; set; }
    }

    public class Information
    {
        public double attack { get; set; }
        public double defense { get; set; }
        public double magic { get; set; }
        public double difficulty { get; set; }
    }

    public class ImageInfo
    {
        public string full { get; set; }
        public string sprite { get; set; }
        public string group { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double w { get; set; }
        public double h { get; set; }
    }

    public class Statistics
    {
        public double hp { get; set; }
        public double hpperlevel { get; set; }
        public double mp { get; set; }
        public double mpperlevel { get; set; }
        public double movespeed { get; set; }
        public double armor { get; set; }
        public double armorperlevel { get; set; }
        public double spellblock { get; set; }
        public double spellblockperlevel { get; set; }
        public double attackrange { get; set; }
        public double hpregen { get; set; }
        public double hpregenperlevel { get; set; }
        public double mpregen { get; set; }
        public double mpregenperlevel { get; set; }
        public double crit { get; set; }
        public double critperlevel { get; set; }
        public double attackdamage { get; set; }
        public double attackdamageperlevel { get; set; }
        public double attackspeedperlevel { get; set; }
        public double attackspeed { get; set; }
    }

    public class Champion
    {
        public string version { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string blurb { get; set; }
        public Information info { get; set; }
        public ImageInfo image { get; set; }
        public List<string> tags { get; set; }
        public string partype { get; set; }
        public Statistics stats { get; set; }
    }

    public class RootChampionDTO
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
}
