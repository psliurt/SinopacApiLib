using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinopacApiLib
{
    public class FutureEnterResult
    {

        public bool ParseSuccess { get; set; }

        public int TradeType { get; set; }
        public string Account { get; set; }
        public string FutureOrOption { get; set; }
        public string FutureCode { get; set; }
        public string CallOrPut { get; set; }
        public decimal RequestPrice { get; set; }
        public int RequestQty { get; set; }
        public string RequestSeqNo { get; set; }
        public string RequestNo { get; set; }
        public string BuyOrSell { get; set; }
        public string PriceType { get; set; }

        public string OrderType { get; set; }

        public string FutureOctType { get; set; }
        public string FutureMtType { get; set; }
        public string FutureComposit { get; set; }

        public string CancelFutureOrOption { get; set; }
        public string CancelCode { get; set; }
        public string CancelOptionType { get; set; }
        public string CancelBuySell { get; set; }
        public string CancelPrice { get; set; }
        public string CancelQty { get; set; }


        public string RequestDateStr { get; set; }
        public string PreOrderDateStr { get; set; }
        public string RequestTimeStr { get; set; }  
        public string PreOrderType { get; set; }
        public string ErrorCode { get; set; }
        public string ServerMsg { get; set; }
        


        public FutureEnterResult()
        {
            ParseSuccess = false;
        }

        public FutureEnterResult ParseRecord(string record)
        {
            if (string.IsNullOrEmpty(record))
            { 
                ParseSuccess = false; 
                return this;            
            }

            if (record.Length < 184)
            {
                ParseSuccess = false;
                return this;
            }

            this.TradeType = int.Parse(record.Substring(0, 2));
            this.Account = record.Substring(2, 15);
            this.FutureOrOption = record.Substring(17, 1);
            this.FutureCode = record.Substring(18, 10);
            this.CallOrPut = record.Substring(28, 1);
            this.BuyOrSell = record.Substring(29, 1);
            this.RequestPrice = decimal.Parse(record.Substring(30, 12));
            this.PriceType = record.Substring(42, 3);
            this.RequestQty = int.Parse(record.Substring(45, 4));
            this.RequestNo = record.Substring(49, 6);
            this.RequestSeqNo = record.Substring(55, 6);
            this.OrderType = record.Substring(61, 3);
            this.FutureOctType = record.Substring(64, 1);
            this.FutureMtType = record.Substring(65, 1);
            this.FutureComposit = record.Substring(66, 2);
            this.CancelFutureOrOption = record.Substring(68, 1);
            this.CancelCode = record.Substring(69, 10);
            this.CancelOptionType = record.Substring(79, 1);
            this.CancelBuySell = record.Substring(80, 1);
            this.CancelPrice = record.Substring(81, 12);
            this.CancelQty = record.Substring(93, 4);
            this.RequestDateStr = record.Substring(97, 8);
            this.PreOrderDateStr = record.Substring(105, 8);
            this.RequestTimeStr = record.Substring(113, 6);
            this.PreOrderType = record.Substring(119, 1);
            this.ErrorCode = record.Substring(120, 4);
            this.ServerMsg = record.Substring(124, 60);

            ParseSuccess = true;
            return this;
        }

        
    }
}
