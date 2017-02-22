using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinopacApiLib;
using Newtonsoft;

namespace SinopacApiLib
{
    public class SinopacOrderAgent
    {
        private static SinopacOrderAgent _instance { get; set; }

        private string _apiVersion { get; set; }

        private string _serverIp { get; set; }

        private string _accountsOfThisId { get; set; }

        private string _echoSetting { get; set; }

        private SinopacOrderAgent()
        {
            //可以利用讀取設定檔的方式來初始化這個library
            string apiInitializeResult = OrderApi.init_t4("", "", "");
            if (apiInitializeResult.StartsWith("Error"))
            {
                throw new Exception("下單元件初始化失敗");
            }

            string loadCaResult = OrderApi.add_acc_ca("", "", "", "", "");
            if (loadCaResult.StartsWith("Error"))
            {
                throw new Exception("讀取憑證錯誤");
            }

            string testCaResult = OrderApi.verify_ca_pass("", "");
            if (testCaResult.StartsWith("Error"))
            {
                throw new Exception("測試憑證錯誤");
            }

            _apiVersion = OrderApi.show_version();
            Console.WriteLine("Api Version: {0}", _apiVersion);

            _serverIp = OrderApi.show_ip(); // ip should be sinotrade.com.tw
            Console.WriteLine("Server IP: {0}", _serverIp);

            _accountsOfThisId = OrderApi.show_list();
            Console.WriteLine("Accounts Of This Id: {0}", _accountsOfThisId);

            _echoSetting = OrderApi.change_echo();//default is [ ON ], Now I call the function, it should be [ Off ]
            Console.WriteLine("Echo setting: {0}", _echoSetting);
        }

        public static SinopacOrderAgent Initialize()
        {
            if (_instance != null)
            {
                _instance = new SinopacOrderAgent();
            }
            return _instance;
        }

        public static SinopacOrderAgent Instance()
        {
            return Initialize();
        }

        public StockEnterResult EnterStockOrder(OrderEnterDirection direction, string stockCode, decimal price, int qty, StockEnterPriceType priceType)
        {
            string record
                = OrderApi.stock_order("B", "", "", "", "", "", "", "");
            StockEnterResult result = new StockEnterResult();
            return result.ParseRecord(record);
        }

        public FutureEnterResult EnterFutureOrder(OrderEnterDirection direction, string futureCode, decimal price, int qty, FutureEnterPriceType priceType, FutureEnterTradeType tradeType, FutureEnterPositionType positionType)
        {
            string record = OrderApi.future_order("", "", "", "", "", "", "", "", "");
            FutureEnterResult result = new FutureEnterResult();
            return result.ParseRecord(record);
        }

        public void EnterOptionOrder()
        {
            string record = OrderApi.option_order("", "", "", "", "", "", "", "", "", "", "", "");
            OptionEnterResult result = new OptionEnterResult();
        }

        public void CancelStockOrder()
        { 
        
        }

        public void CancelFutureOrder()
        { }

        public void CancelOptionOrder()
        { 
        
        }

        public void QueryResponseRecord()
        {
            string record =  OrderApi.get_response_log();
        }

        public void ModifyFutureOrder()
        { 
        
        }


        public void GetFutureOptionsHistoryInterest()
        { 
            
        }

        public void DestroyInstance()
        {
            int ret = OrderApi.log_out();
            _instance = null;
        }
    }

    public enum OrderEnterDirection
    { 
        Long,
        Short
    }

    public enum StockEnterPriceType
    {
        Limit, //限價
        LimitUp, //漲停價
        LimitDown //跌停價

    }

    public enum FutureEnterPriceType
    {
        MarketPrice, //市價
        LimitPrice //限價
    }

    public enum FutureEnterTradeType
    {
        Rod,
        Fok,
        Ioc
    }

    public enum FutureEnterPositionType
    {
        NewPosition, //新倉
        ClosePosition, //平倉
        Auto, //自動
        DayTrade //當沖
    }
}
