using System;
using System.Collections.Generic;
using System.Text;

namespace RitoForCustoms
{
    class FilterParameters
    {
        static public string NoCustomParameters() 
        {
            return ("champion&queue&season&endTime&beginTime&endIndex&beginIndex");
        }
        static public string TimeCustomParameters(int time)
        {
            time = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds - time;

            return ("champion&queue&season&endTime&beginTime=" + time.ToString() + "&endIndex&beginIndex");
        }
    }
}
