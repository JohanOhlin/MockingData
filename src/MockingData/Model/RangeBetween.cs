using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockingData.Model
{
    public struct RangeBetween
    {
        public int Min;
        public int Max;

        public RangeBetween(int min, int max)
        {
            Min = min;
            Max = max;
        }
    }
}
