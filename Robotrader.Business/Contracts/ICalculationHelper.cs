using System.Collections.Generic;

namespace Robotrader.Business.Contracts
{
    public interface ICalculationHelper
    {
        double ExponencialMovingAverage(int period, List<double> prices);
        double SimpleMovingAverage(int period, List<double> prices);
    }
}