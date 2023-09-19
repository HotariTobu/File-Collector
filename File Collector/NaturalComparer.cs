using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Collector
{
    internal class NaturalComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xIndex = 0;
            var yIndex = 0;

            while (true)
            {
                var nx = 0;
                var ny = 0;

                while (xIndex < x.Length && int.TryParse(x[xIndex].ToString(), out var ix))
                {
                    nx *= 10;
                    nx += ix;
                    xIndex++;
                }

                while (yIndex < y.Length && int.TryParse(y[yIndex].ToString(), out var iy))
                {
                    ny *= 10;
                    ny += iy;
                    yIndex++;
                }

                var compare = nx - ny;
                if (compare != 0)
                {
                    return compare;
                }

                if (xIndex == x.Length || yIndex == y.Length)
                {
                    break;
                }

                var cx = x[xIndex];
                var cy = y[yIndex];
                
                compare = StringComparer.CurrentCultureIgnoreCase.Compare(cx, cy);
                if (compare != 0)
                {
                    return compare;
                }

                xIndex++;
                yIndex++;
            }

            return (x.Length - xIndex) - (y.Length - yIndex);
        }
    }
}
