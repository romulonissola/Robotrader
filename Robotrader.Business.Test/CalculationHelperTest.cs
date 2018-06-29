using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Robotrader.Business.Test
{
    public class CalculationHelperTest
    {
        [Fact]
        public void ShoulReturnSimpleMovingAverageFrom5WhenPassingValues()
        {
            var calcHelper = new CalculationHelper();
            var listToCalc = new List<double>()
            {
                11,12,13,14,15
            };
            var sma = calcHelper.SimpleMovingAverage(5, listToCalc);
            Assert.Equal(13, sma);
        }

        [Fact]
        public void ShoulReturnExponencialMovingAverageFrom2WhenPassingValues()
        {
            var calcHelper = new CalculationHelper();
            var listToCalc = new List<double>()
            {
                6107,
                6109.05,
                6106.58,
                6106.86,
                6088.10,
                6048.19,
                5920.68,
                5940,
                5853.98,
                5894.37,
                5874,
                5868.32,
                5886.09
            };
            var sma = calcHelper.ExponencialMovingAverage(2, listToCalc);
            Assert.Equal("5881,4464", sma.ToString("0000.0000"));
        }
    }
}
