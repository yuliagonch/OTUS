using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesProject
{
    public static class CollectionExtension
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            SortedDictionary<float, T> numDict = new SortedDictionary<float, T>();

            foreach (T item in collection)
            {
                numDict[convertToNumber(item)] = item;
            }

            return numDict.Last().Value;
        }
    }
}
