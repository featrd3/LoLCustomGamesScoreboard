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
    /*
    public class Data
    {
        public Champion Aatrox { get; set; }
        public Champion Ahri { get; set; }
        public Champion Akali { get; set; }
        public Champion Alistar { get; set; }
        public Champion Amumu { get; set; }
        public Champion Anivia { get; set; }
        public Champion Annie { get; set; }
        public Champion Aphelios { get; set; }
        public Champion Ashe { get; set; }
        public Champion AurelionSol { get; set; }
        public Champion Azir { get; set; }
        public Champion Bard { get; set; }
        public Champion Blitzcrank { get; set; }
        public Champion Brand { get; set; }
        public Champion Braum { get; set; }
        public Champion Caitlyn { get; set; }
        public Champion Camille { get; set; }
        public Champion Cassiopeia { get; set; }
        public Champion Chogath { get; set; }
        public Champion Corki { get; set; }
        public Champion Darius { get; set; }
        public Champion Diana { get; set; }
        public Champion Draven { get; set; }
        public Champion DrMundo { get; set; }
        public Champion Ekko { get; set; }
        public Champion Elise { get; set; }
        public Champion Evelynn { get; set; }
        public Champion Ezreal { get; set; }
        public Champion Fiddlesticks { get; set; }
        public Champion Fiora { get; set; }
        public Champion Fizz { get; set; }
        public Champion Galio { get; set; }
        public Champion Gangplank { get; set; }
        public Champion Garen { get; set; }
        public Champion Gnar { get; set; }
        public Champion Gragas { get; set; }
        public Champion Graves { get; set; }
        public Champion Hecarim { get; set; }
        public Champion Heimerdinger { get; set; }
        public Champion Illaoi { get; set; }
        public Champion Irelia { get; set; }
        public Champion Ivern { get; set; }
        public Champion Janna { get; set; }
        public Champion JarvanIV { get; set; }
        public Champion Jax { get; set; }
        public Champion Jayce { get; set; }
        public Champion Jhin { get; set; }
        public Champion Jinx { get; set; }
        public Champion Kaisa { get; set; }
        public Champion Kalista { get; set; }
        public Champion Karma { get; set; }
        public Champion Karthus { get; set; }
        public Champion Kassadin { get; set; }
        public Champion Katarina { get; set; }
        public Champion Kayle { get; set; }
        public Champion Kayn { get; set; }
        public Champion Kennen { get; set; }
        public Champion Khazix { get; set; }
        public Champion Kindred { get; set; }
        public Champion Kled { get; set; }
        public Champion KogMaw { get; set; }
        public Champion Leblanc { get; set; }
        public Champion LeeSin { get; set; }
        public Champion Leona { get; set; }
        public Champion Lillia { get; set; }
        public Champion Lissandra { get; set; }
        public Champion Lucian { get; set; }
        public Champion Lulu { get; set; }
        public Champion Lux { get; set; }
        public Champion Malphite { get; set; }
        public Champion Malzahar { get; set; }
        public Champion Maokai { get; set; }
        public Champion MasterYi { get; set; }
        public Champion MissFortune { get; set; }
        public Champion MonkeyKing { get; set; }
        public Champion Mordekaiser { get; set; }
        public Champion Morgana { get; set; }
        public Champion Nami { get; set; }
        public Champion Nasus { get; set; }
        public Champion Nautilus { get; set; }
        public Champion Neeko { get; set; }
        public Champion Nidalee { get; set; }
        public Champion Nocturne { get; set; }
        public Champion Nunu { get; set; }
        public Champion Olaf { get; set; }
        public Champion Orianna { get; set; }
        public Champion Ornn { get; set; }
        public Champion Pantheon { get; set; }
        public Champion Poppy { get; set; }
        public Champion Pyke { get; set; }
        public Champion Qiyana { get; set; }
        public Champion Quinn { get; set; }
        public Champion Rakan { get; set; }
        public Champion Rammus { get; set; }
        public Champion RekSai { get; set; }
        public Champion Rell { get; set; }
        public Champion Renekton { get; set; }
        public Champion Rengar { get; set; }
        public Champion Riven { get; set; }
        public Champion Rumble { get; set; }
        public Champion Ryze { get; set; }
        public Champion Samira { get; set; }
        public Champion Sejuani { get; set; }
        public Champion Senna { get; set; }
        public Champion Seraphine { get; set; }
        public Champion Sett { get; set; }
        public Champion Shaco { get; set; }
        public Champion Shen { get; set; }
        public Champion Shyvana { get; set; }
        public Champion Singed { get; set; }
        public Champion Sion { get; set; }
        public Champion Sivir { get; set; }
        public Champion Skarner { get; set; }
        public Champion Sona { get; set; }
        public Champion Soraka { get; set; }
        public Champion Swain { get; set; }
        public Champion Sylas { get; set; }
        public Champion Syndra { get; set; }
        public Champion TahmKench { get; set; }
        public Champion Taliyah { get; set; }
        public Champion Talon { get; set; }
        public Champion Taric { get; set; }
        public Champion Teemo { get; set; }
        public Champion Thresh { get; set; }
        public Champion Tristana { get; set; }
        public Champion Trundle { get; set; }
        public Champion Tryndamere { get; set; }
        public Champion TwistedFate { get; set; }
        public Champion Twitch { get; set; }
        public Champion Udyr { get; set; }
        public Champion Urgot { get; set; }
        public Champion Varus { get; set; }
        public Champion Vayne { get; set; }
        public Champion Veigar { get; set; }
        public Champion Velkoz { get; set; }
        public Champion Vi { get; set; }
        public Champion Viego { get; set; }
        public Champion Viktor { get; set; }
        public Champion Vladimir { get; set; }
        public Champion Volibear { get; set; }
        public Champion Warwick { get; set; }
        public Champion Xayah { get; set; }
        public Champion Xerath { get; set; }
        public Champion XinZhao { get; set; }
        public Champion Yasuo { get; set; }
        public Champion Yone { get; set; }
        public Champion Yorick { get; set; }
        public Champion Yuumi { get; set; }
        public Champion Zac { get; set; }
        public Champion Zed { get; set; }
        public Champion Ziggs { get; set; }
        public Champion Zilean { get; set; }
        public Champion Zoe { get; set; }
        public Champion Zyra { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public string format { get; set; }
        public string version { get; set; }
        public Data data { get; set; }
    }

*/

    public class RootChampionDTO
    {
        public string Type { get; set; }
        public string Version { get; set; }
        public Dictionary<string, Champion> Data { get; set; }
    }
}
