using System;
using System.Collections.Generic;

namespace DoubleLinear
{
    public class Program
    {
        public static int DblLinear (int n) 
        {
            List<int> retVals = new List<int>{1};
            int  x = 0;
            int  y = 0;
      
            for (int i = 0; i < n; i++)
            {
                int  nextX = 2 * retVals[x] + 1;
                int  nextY = 3 * retVals[y] + 1;
          
                if (nextX <= nextY)
                {
                    retVals.Add(nextX);
                    ++x;
                    if (nextX == nextY) ++y;
                }
                else
                {
                    retVals.Add(nextY);
                    ++y;
                }
            }
      
            return retVals[n];
        }
    }
}