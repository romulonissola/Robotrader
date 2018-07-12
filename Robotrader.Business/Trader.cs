using Robotrader.Business.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Robotrader.Business
{
    public class Trader : ITrader
    {
        public async Task TradeAsync(Guid id, List<string> pairs, List<ITraderRule> traderRules, CancellationToken cancelToken)
        {
            throw new NotImplementedException();
            //using (var file = File.CreateText($@"d:\teste{id.ToString().Replace("-", "")}.txt"))
            //{
            //    while (true)
            //    {
            //        if (cancelToken.IsCancellationRequested)
            //        {
            //            await file.WriteLineAsync("canceled");
            //            file.Close();
            //            break;
            //        }
            //        file.WriteLine($"{id} - {DateTime.Now}");
            //    }
            //}
        }
    }
}
