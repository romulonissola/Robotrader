using Newtonsoft.Json;
using Robotrader.Business.Entities.IntegrationEntities.Binance.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robotrader.Business.Entities.IntegrationEntities.Binance
{
    [JsonConverter(typeof(ArrayConverter))]
    public class CandleStick
    {
        [ArrayProperty(0), JsonConverter(typeof(TimestampConverter))]
        public DateTime OpenTime { get; set; }

        [ArrayProperty(1)]
        public decimal Open { get; set; }

        [ArrayProperty(2)]
        public decimal High { get; set; }

        [ArrayProperty(3)]
        public decimal Low { get; set; }

        [ArrayProperty(4)]
        public decimal Close { get; set; }

        [ArrayProperty(5)]
        public decimal BaseAssetVolume { get; set; }

        [ArrayProperty(6), JsonConverter(typeof(TimestampConverter))]
        public DateTime CloseTime { get; set; }

        [ArrayProperty(7)]
        public decimal QuoteAssetVolume { get; set; }

        [ArrayProperty(8)]
        public int NumberOfTrades { get; set; }

        [ArrayProperty(9)]
        public decimal TakerBuyBaseAssetVolume { get; set; }

        [ArrayProperty(10)]
        public decimal TakerBuyQuoteAssetVolume { get; set; }

        [ArrayProperty(11)]
        public decimal Ignore { get; set; }
    }
}
