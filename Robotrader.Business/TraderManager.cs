using Robotrader.Business.Contracts;
using Robotrader.Business.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robotrader.Business
{
    public class TraderManager
    {
        private List<Tuple<Guid, Task, CancellationTokenSource>> _currentTransactions;
        private readonly ITrader _trader;
        public TraderManager(ITrader trader)
        {
            _currentTransactions = new List<Tuple<Guid, Task, CancellationTokenSource>>();
            _trader = trader;
        }
        public TaskStatus GetCurrentStatusByTransactionId(Guid transactionId)
        {
            var transaction = _currentTransactions.FirstOrDefault(a => a.Item1.Equals(transactionId));
            ExceptionHelper.ThrowIfIsNull(nameof(transaction), transaction);
            return transaction.Item2.Status;
        }

        public List<Guid> GetCurrentTransactions()
        {
            return _currentTransactions.Select(a => a.Item1).ToList();
        }

        public Guid StartNewTrader(List<string> pairs, List<ITraderRule> traderRules)
        {
            var currentTransactionId = Guid.NewGuid();
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Task.Run(
                    () => _trader.TradeAsync(currentTransactionId, pairs, traderRules, cancellationTokenSource.Token)
                    , cancellationTokenSource.Token);
            _currentTransactions.Add(
                    new Tuple<Guid, Task, CancellationTokenSource>(currentTransactionId, task, cancellationTokenSource)
                );
            return currentTransactionId;
        }

        public void StopTraderByTransactionId(Guid transactionId)
        {
            var transaction = _currentTransactions.FirstOrDefault(a => a.Item1.Equals(transactionId));
            ExceptionHelper.ThrowIfIsNull(nameof(transaction), transaction);
            transaction.Item3.Cancel();
            _currentTransactions.Remove(transaction);
        }
    }
}
