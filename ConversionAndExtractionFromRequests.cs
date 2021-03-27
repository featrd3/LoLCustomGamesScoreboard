using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RitoForCustoms
{
    public class ConversionAndExtractionFromRequests    
    {
        public static List<string> ChampionIDtoName(ChampionRotationJSON contentID, RootChampionDTO allChampionsList)
        {
            var championName = allChampionsList.Data.Where(p => contentID.freeChampionIds.Contains(Int32.Parse(p.Value.key))).Select(p => p.Value.id).ToList<string>();
            return championName;
        }
    }
}
