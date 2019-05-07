using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategypattern
{
    class ShortestSeekTime : IQueueHandler
    {

        // Code is moderately modified but based upon java example: https://www.geeksforgeeks.org/program-for-sstf-disk-scheduling-algorithm/
        public List<int> CalculateOptimalQueue(List<Request> requestedSectors, int head)
        {
            // stores sequence in which disk access is done 
            List<int> seekSequence = new List<int>();
            if (requestedSectors == null || requestedSectors.Count <= 0)
            {
                return seekSequence;
            }
            List<node> diff = new List<node>(requestedSectors.Count());
            for(int i = 0; i < requestedSectors.Count; i++)
            {
                diff.Add(new node());
            }

            for (int i = 0; i < requestedSectors.Count; i++)
            {
                calculateDifference(requestedSectors, head, diff);

                int index = findMin(diff);

                diff[index].accessed = true;
                seekSequence.Add(requestedSectors[index].sector);
                // accessed track is now new head 
                head = requestedSectors[index].sector;
            }
            return seekSequence;
        }
        class node
        {
            public int distance { get; set; }
            public Boolean accessed { get; set; }

            public node()
            {
                accessed = false;
            }
        }
        // Calculates difference of each  
        // track number with the head position 
        private static void calculateDifference(List<Request> requestedSectors,
                                            int head, List<node> diff)

        {
            for (int i = 0; i < diff.Count; i++)
            {
                diff[i].distance = Math.Abs(requestedSectors[i].sector - head);
            }
        }

        // find unaccessed track  
        // which is at minimum distance from head 
        private static int findMin(List<node> diff)
        {
            int index = -1, minimum = int.MaxValue;

            for (int i = 0; i < diff.Count; i++)
            {
                if (!diff[i].accessed && minimum > diff[i].distance)
                {

                    minimum = diff[i].distance;
                    index = i;
                }
            }
            return index;
        }
    }
}

