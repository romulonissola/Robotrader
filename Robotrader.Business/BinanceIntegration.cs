using Robotrader.Business.Entities.IntegrationEntities.Binance;
using Robotrader.Business.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Robotrader.Business
{
    public class BinanceIntegration
    {
        private HttpClientFactory _httpClientFactory;
        public BinanceIntegration(string apiURL)
        {
            _httpClientFactory = new HttpClientFactory(apiURL);
        }
        public async Task<decimal> GetCurrentPriceAsync(string symbol)
        {
            var apiPath = $"v3/ticker/price?symbol={symbol}";
            var price = await _httpClientFactory.GetAsync<TickerPrice>(apiPath);
            return price.Price;
        }

        public Task<List<CandleStick>> GetCandleStickAsync(string symbol, string interval)
        {
            var apiPath = $"v1/klines?symbol={symbol}&interval={interval}";
            return _httpClientFactory.GetAsync<List<CandleStick>>(apiPath);
        }
    }
}
