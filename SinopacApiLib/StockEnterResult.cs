using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinopacApiLib
{
    /// <summary>
    /// 參考永豐API附件9的說明
    /// </summary>
    public class StockEnterResult
    {
        public bool ParseSuccess { get; set; }
        public int TradeType { get; set; }
        public string Account { get; set; }
        public string StockCode { get; set; }
        public decimal RequestPrice { get; set; }
        public int RequestQty { get; set; }
        public string RequestSeqNo { get; set; }
        public string RequestDateStr { get; set; }
        public string TradeDateStr { get; set; }
        public string RequestTimeStr { get; set; }        
        public string RequestNo { get; set; }
        public string SourceType { get; set; }
        public string OrgSeqNo { get; set; }
        public string BuyOrSell { get; set; }
        public string OrderType1 { get; set; }
        public string OrderType2 { get; set; }
        public string MarketType { get; set; }
        public string PriceType { get; set; }
        public string OrderStatus { get; set; }
        public string ServerMsg { get; set; }


        public StockEnterResult()
        {
            ParseSuccess = false;
        }

        public StockEnterResult ParseRecord(string record)
        {
            if (string.IsNullOrEmpty(record))
            { 
                ParseSuccess = false; 
                return this;            
            }

            if (record.Length < 141)
            {
                ParseSuccess = false;
                return this;
            }

            this.TradeType = int.Parse(record.Substring(0, 2));
            this.Account = record.Substring(2, 15);
            this.StockCode = record.Substring(17, 6);
            this.RequestPrice = decimal.Parse(record.Substring(23, 6));
            this.RequestQty = int.Parse(record.Substring(29, 2));
            this.RequestSeqNo = record.Substring(31, 6);
            this.RequestDateStr = record.Substring(37, 8);
            this.TradeDateStr = record.Substring(45, 8);
            this.RequestTimeStr = record.Substring(53, 6);
            this.RequestNo = record.Substring(59, 5);
            this.SourceType = record.Substring(64, 3);
            this.OrgSeqNo = record.Substring(67, 6);
            this.BuyOrSell = record.Substring(73, 1);
            this.OrderType1 = record.Substring(74, 1);
            this.OrderType2 = record.Substring(75, 1);
            this.MarketType = record.Substring(76, 1);
            this.PriceType = record.Substring(77, 1);
            this.OrderStatus = record.Substring(78, 2);
            this.ServerMsg = record.Substring(80, 60);

            ParseSuccess = true;
            return this;
        }
    }

    
}
