using System.Collections.Generic;
using System.Linq;

namespace Penalty.Crosscut.Utilities.Extensions
{
    public static class CommaSeparateToList
    {
        public static List<string> ToListFromCommaSeparateString(this string sentence)
        {
            return sentence != null
                ? sentence?.Split(',').ToList()
                : new List<string>();
        }
    }
}
