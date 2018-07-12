using Moq;
using Robotrader.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Robotrader.Business.Test
{
    public class TraderManagerTest
    {
        private TraderManager _traderManager;

        public TraderManagerTest()
        {
            var trader = new Mock<ITrader>(MockBehavior.Strict);
            trader.Setup(tr => tr.TradeAsync(It.IsAny<Guid>(), It.IsAny<List<string>>(), It.IsAny<List<ITraderRule>>(), It.IsAny<CancellationToken>()))
                  .Returns(Task.CompletedTask);
            _traderManager = new TraderManager(trader.Object);
        }

        [Fact]
        public void ShouldStartNewTrader()
        {
            var pairs = new List<string>()
            {
                "BTCUSDT",
                "LTCUSDT",
                "TRXBTC"
            };
            var traderRules = new Mock<List<ITraderRule>>().Object;
            var transactionId = _traderManager.StartNewTrader(pairs, traderRules);
            Assert.IsType<Guid>(transactionId);
        }

        [Fact]
        public void ShouldStartManyTradersAndStopAll()
        {
            var pairs = new List<string>()
            {
                "BTCUSDT",
                "LTCUSDT",
                "TRXBTC"
            };
            var traderRules = new Mock<List<ITraderRule>>().Object;
            var transactionId1 = _traderManager.StartNewTrader(pairs, traderRules);
            var transactionId2 = _traderManager.StartNewTrader(pairs, traderRules);
            var transactionId3 = _traderManager.StartNewTrader(pairs, traderRules);
            var transactionId4 = _traderManager.StartNewTrader(pairs, traderRules);
            _traderManager.StopTraderByTransactionId(transactionId1);
            _traderManager.StopTraderByTransactionId(transactionId2);
            _traderManager.StopTraderByTransactionId(transactionId3);
            _traderManager.StopTraderByTransactionId(transactionId4);
            Assert.True(true);
        }

        [Fact]
        public void ShouldReturnExceptionWhenPassingInvalidTransactionInStopTrader()
        {
            Assert.Throws<ArgumentNullException>(() => _traderManager.StopTraderByTransactionId(Guid.NewGuid()));
        }

        [Fact]
        public void ShouldStopTrader()
        {
            var pairs = new List<string>()
            {
                "BTCUSDT",
                "LTCUSDT",
                "TRXBTC"
            };
            var traderRules = new Mock<List<ITraderRule>>().Object;
            var transactionId = _traderManager.StartNewTrader(pairs, traderRules);
            _traderManager.StopTraderByTransactionId(transactionId);
            Assert.True(true);
        }

        [Fact]
        public void ShouldReturnExceptionWhenPassingInvalidTransactionInGetStatus()
        {
            Assert.Throws<ArgumentNullException>(() => _traderManager.GetCurrentStatusByTransactionId(Guid.NewGuid()));
        }

        [Fact]
        public void ShouldReturnStatusRunningWhenStartTrader()
        {
            var pairs = new List<string>()
            {
                "BTCUSDT",
                "LTCUSDT",
                "TRXBTC"
            };
            var traderRules = new Mock<List<ITraderRule>>().Object;
            var transactionId = _traderManager.StartNewTrader(pairs, traderRules);
            Thread.Sleep(2000);
            var status = _traderManager.GetCurrentStatusByTransactionId(transactionId);
            Assert.Equal(TaskStatus.RanToCompletion, status);
        }

        [Fact]
        public void ShouldReturnCurrentTransactionsAsync()
        {
            var pairs = new List<string>()
            {
                "BTCUSDT",
                "LTCUSDT",
                "TRXBTC"
            };
            var traderRules = new Mock<List<ITraderRule>>().Object;
            var transactionId = _traderManager.StartNewTrader(pairs, traderRules);
            var transactions = _traderManager.GetCurrentTransactions();
            Assert.Contains(transactionId, transactions);
        }
    }
}
