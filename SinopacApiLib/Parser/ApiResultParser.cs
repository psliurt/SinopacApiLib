using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinopacApiLib.Parser
{
    public abstract class ApiResultParser
    {
        public static ApiResultParser CreateParser(ParserType t)
        {
            switch (t)
            { 
                case ParserType.EnterInfo:
                    return new EnterInfoParser();                    
                case ParserType.FutureEnterInfo:
                    break;
                case ParserType.FutureOptionEnterReturn:
                    break;
                case ParserType.FutureOptionUnsettled:
                    break;
                case ParserType.HistoryBalance:
                    break;
                case ParserType.OverseaFutureBalanceInfo:
                    break;
                case ParserType.OverseaFutureEnterInfo:
                    break;
                case ParserType.OverseaFutureEnterReturn:
                    break;
                case ParserType.OverseaFuturePosition:
                    break;
                case ParserType.ProactiveReport:
                    break;
                case ParserType.SecurityBalance:
                    break;
                case ParserType.SecurityBalanceDetail:
                    break;
                case ParserType.SecurityBalanceSum:
                    break;
                case ParserType.SecurityEnterReturn:
                    break;
                case ParserType.ThatDayBalance:
                    break;
                default:
                    break;
            }
            return null;
        }

        public abstract ParseResult Parse(string record);
    }

    public enum ParserType
    { 
        /// <summary>
        /// 附件(一)： 國內下單查詢
        /// </summary>
        EnterInfo,

        /// <summary>
        /// 附件(二)： 國外期貨下單查詢 
        /// </summary>
        OverseaFutureEnterInfo,

        /// <summary>
        /// 附件(三)：主動回報格式
        /// </summary>
        ProactiveReport,
        /// <summary>
        /// 附件(五)： 國內當日權益數查詢
        /// </summary>
        ThatDayBalance,

        /// <summary>
        /// 附件(六)： 國內歷史權益數查詢
        /// </summary>
        HistoryBalance,

        /// <summary>
        /// 附件(七)： 國內期權委託查詢
        /// </summary>
        FutureEnterInfo,

        /// <summary>
        /// 附件(八)： 證券庫存查詢
        /// </summary>
        SecurityBalance,

        /// <summary>
        /// 附件(九)： 證券下單、刪單回傳
        /// </summary>
        SecurityEnterReturn,

        /// <summary>
        /// 附件(十)： 期貨、選擇權下單回傳 
        /// </summary>
        FutureOptionEnterReturn,

        /// <summary>
        /// 附件(十一)： 期權未平倉查詢
        /// </summary>
        FutureOptionUnsettled,

        /// <summary>
        /// 附件(十二)： 國外期貨部位查詢
        /// </summary>
        OverseaFuturePosition,

        /// <summary>
        /// 附件(十三)： 國外期貨權益數查詢
        /// </summary>
        OverseaFutureBalanceInfo,

        /// <summary>
        /// 附件(十四)： 國外期貨下單回傳
        /// </summary>
        OverseaFutureEnterReturn,

        /// <summary>
        /// 附件(十五) ： 國內證券未實現損益匯總查詢
        /// </summary>
        SecurityBalanceSum,

        /// <summary>
        /// 附件(十六)： 國內證券未實現損益明細
        /// </summary>
        SecurityBalanceDetail,

    }
}
