using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    internal static class BinarySearch<T> where T : IComparable
    {
        public static int GetIndexOf(T searchValue, List<T> listToSearch)
            => Search(searchValue, listToSearch, 0, listToSearch.Count);

        static int Search(T searchValue, List<T> listToSearch, int lowerBound, int upperBound)
        {
            if (lowerBound > upperBound) return -1;

            int middleLocation = (lowerBound + upperBound) / 2;
            T middleValue = listToSearch[middleLocation];
            if (middleValue.Equals(searchValue)) return middleLocation;

            if (middleValue.CompareTo(searchValue) > 0)
                return Search(searchValue, listToSearch, lowerBound, middleLocation - 1);

            return Search(searchValue, listToSearch, middleLocation + 1, upperBound);
        }
    }
}