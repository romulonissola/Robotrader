using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Robotrader.Business.Contracts;

namespace Robotrader.Business.Contracts
{
    public interface ITrader
    {
        Task TradeAsync(Guid id, List<string> pairs, List<ITraderRule> traderRules, CancellationToken cancelToken);
    }
}