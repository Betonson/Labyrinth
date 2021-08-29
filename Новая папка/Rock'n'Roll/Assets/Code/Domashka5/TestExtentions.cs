using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RockAndRoll
{
    public static class TestExtentions
    {
        public static int LengthOf(this string self)
        {
            return self.Length;
        }

        public static int CountEntries<T>(this T self, List<T> coll)
        {
            int entries=0;
            foreach (var elem in coll)
            {
                if (EqualityComparer<T>.Default.Equals(elem, self)) entries++;
            }
            return entries;
        }

        public static int CountEntriesViaLinq<T>(this T self, List<T> coll)
        {
            int entries = coll.Where(elem => EqualityComparer<T>.Default.Equals(elem, self)).Count();
            //var countedEntries = coll.Where(elem => EqualityComparer<T>.Default.Equals(elem, self));
            //int entries = countedEntries.Count;
            return entries;
        }

    }
}