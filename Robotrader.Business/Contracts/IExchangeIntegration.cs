using System.Collections.Generic;
using System.Threading.Tasks;
using Robotrader.Business.Entities.IntegrationEntities.Binance;

namespace Robotrader.Business.Contracts
{
    public interface IExchangeIntegration
    {
        Task<List<CandleStick>> GetCandleStickAsync(string symbol, string interval);
        Task<decimal> GetCurrentPriceAsync(string symbol);
    }
}