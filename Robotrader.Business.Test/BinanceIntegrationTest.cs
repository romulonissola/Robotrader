using Robotrader.Business.Entities.IntegrationEntities.Binance;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Robotrader.Business.Test
{
    public class BinanceIntegrationTest
    {
        private const string BINANCE_API = "https://api.binance.com/api/";

        [Fact]
        public async Task ShoulReturnPriceWhenCallBinanceAPIAsync()
        {
            var symbol = "BTCUSDT";            

            var binanceIntegration = new BinanceIntegration(BINANCE_API);
            var price = await binanceIntegration.GetCurrentPriceAsync(symbol);
            Assert.True(price > 0);
        }

        [Fact]
        public async Task ShoulReturnCandleStickWhenCallBinanceAPIAsync()
        {
            var symbol = "BTCUSDT";
            var interval = IntervalType.OneHour;
            var binanceIntegration = new BinanceIntegration(BINANCE_API);
            var candles = await binanceIntegration.GetCandleStickAsync(symbol, interval);
            Assert.Equal(1000, candles.Count);
        }
    }
}
