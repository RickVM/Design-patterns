using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diskScheduler
{
    class Scan : IQueueHandler
    {
        
        public List<int> CalculateOptimalQueue(List<Request> requestedSectors, int head)
        {
            const int driveSize = 1024000; // Hardcoded and also used in system.Windows.Resources. TODO: Find a nicer way to get/share this constant data
            IEnumerable<Request> sortedRequests = requestedSectors.OrderBy(request => request.sector);

            // Determine if we go up or down first
            if(head > driveSize/2)
            {
               sortedRequests =  sortedRequests.Reverse(); // Top - down
            }

            List<int> retv = new List<int>();
            foreach(Request request in sortedRequests)
            {
                retv.Add(request.sector);
            }
            return retv;
        }
    }
}
