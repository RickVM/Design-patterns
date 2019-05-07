using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strategypattern
{
    interface IQueueHandler
    {
        List<int> CalculateOptimalQueue(List<Request> requestedSectors, int head);
    }
}
