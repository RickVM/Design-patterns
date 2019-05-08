using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diskScheduler
{
    class Request
    {
        public int sector { get; }
        public DateTime created { get; }

        public Request(int sector)
        {
            this.sector = sector;
            this.created = new DateTime();
        }

        public override string ToString()
        {
            return $"{sector.ToString()},";
        }
    }
}
