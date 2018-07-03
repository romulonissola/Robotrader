using System;
using System.Collections.Generic;
using System.Text;

namespace Robotrader.Business.Entities.IntegrationEntities.Binance
{
    public class TickerPrice
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }
}
