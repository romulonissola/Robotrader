using System.Linq;
using System.Collections.Generic;
using TicTacTec.TA.Library;
using System;
using Robotrader.Business.Contracts;

namespace Robotrader.Business
{
    public class CalculationHelper : ICalculationHelper
    {
        public double SimpleMovingAverage(int period, List<double> prices)
        {
            return prices.Take(period).Sum() / period;
        }

        public double ExponencialMovingAverage(int period, List<double> prices)
        {
            double[] output = new double[prices.Count];

            Core.Ema(0, prices.Count - 1, prices.ToArray(), period, out int begin, out int length, output);
            
            return output[length -1];
        }
    }
}
