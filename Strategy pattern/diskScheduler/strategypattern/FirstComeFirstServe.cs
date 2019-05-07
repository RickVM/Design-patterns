using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategypattern
{
    class FirstComeFirstServe: IQueueHandler
    {
        public List<int> CalculateOptimalQueue(List<Request> requestedSectors, int head)
        {
            List<int> retv = new List<int>();
            if (requestedSectors != null && requestedSectors.Count > 0)
            {
                requestedSectors.Sort((x, y) => DateTime.Compare(x.created, y.created));
                foreach (Request request in requestedSectors)
                {
                    retv.Add(request.sector);
                }
            }
            return retv;
        }
    }
}
