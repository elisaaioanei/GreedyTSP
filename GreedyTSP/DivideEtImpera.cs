using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyTSP
{
    public class DivideEtImpera
    {
        public int GetSearchedItemPosition(List<int> list, int searchedItem)
        {
            var minIndex = 0;
            var maxIndex = list.Count - 1;

            while (minIndex <= maxIndex)
            {
                var midIndex = (minIndex + maxIndex) / 2;
                if (searchedItem == list[midIndex])
                {
                    return midIndex;
                }
                else if (searchedItem > list[midIndex])
                {
                    minIndex = midIndex + 1;
                }
                else
                {
                    maxIndex = midIndex - 1;
                }
            }

            return -1;
        }

        public int GetMaxElement(List<int> list)
        {
            return GetMaxElementRecursive(list, 0, list.Count - 1);
        }

        public int GetMaxElementRecursive(List<int> list, int firstIndex, int lastIndex)
        {
            int max1 = 0, max2 = 0;
            if(firstIndex == lastIndex)
            {
                return list[firstIndex];
            }
            else
            {
                var midIndex = (firstIndex + lastIndex) / 2;
                max1 = GetMaxElementRecursive(list, firstIndex, midIndex);
                max2 = GetMaxElementRecursive(list, midIndex + 1, lastIndex);

                if(max1 < max2)
                {
                    return max2;
                }
                else
                {
                    return max1;
                }
            }
        }
    }
}
