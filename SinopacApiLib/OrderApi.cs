using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace SinopacApiLib
{
    public class OrderApi
    {
        #region 初始化函式

        /// <summary>
        /// 初始化
        /// ret = init_t4( “A123456789”, “12345678”, “” );
        /// </summary>
        /// <param name="login_id">使用者ID (通常為身份證號，非帳戶)</param>
        /// <param name="login_pass">登入密碼 (連線登入密碼，非憑證密碼)</param>
        /// <param name="dll_path">DLL 放置路徑 (空白或不指定則自動偵測)</param>
        /// <returns>正常：初始化成功 (或：已初始化)   異常：會以 “Error:” 開頭，接著錯誤訊息。</returns>
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string init_t4(string login_id, string login_pass, string dll_path);

        /// <summary>
        /// 將證券、憑證帳戶加入憑證清單 (下單之前必須加入)
        /// 期貨： ret = add_acc_ca( “F002000”, “9999999”, “A123456789”, “C:\eKey\551\A123456789\S”, “12345678” );
        /// 證券： ret = add_acc_ca( “9A95”, “9999999”, “A123456789”, “C:\ekey\551\A123456789\S”, “12345678” );
        /// </summary>
        /// <param name="branch">分行 (期貨以F開頭, 證券僅代分公司代碼) ps.分公司與帳戶可由show_list取得</param>
        /// <param name="account">帳戶</param>
        /// <param name="acc_id">憑證 ID (身份證號)</param>
        /// <param name="acc_ca_path">憑證檔案所在路徑</param>
        /// <param name="acc_ca_pass">憑證密碼</param>
        /// <returns>正常：CA憑證資料登錄成功 異常： “Error:” 開頭，接著錯誤訊息。</returns>
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string add_acc_ca(string branch, string account, string acc_id, string acc_ca_path, string acc_ca_pass);

        /// <summary>
        /// 憑證驗章測試
        /// ret = verify_ca_pass( "F002000", "9999999" );
        /// </summary>
        /// <param name="branch">branch: 分行 (期貨以F開頭, 證券以S開頭)</param>
        /// <param name="account">帳戶</param>
        /// <returns>正常："" 異常：Error: CA驗證錯誤</returns>
        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string verify_ca_pass(string branch, string account);

        #endregion

        #region 下單, 刪單函式

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string stock_order(string buy_or_sell,string branch,  string account, string stock_id, string ord_type, string price, string amount, string price_type);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string stock_cancel(string buy_or_sell, string branch, string account, string stock_id, string price_type, string ord_seq, string ord_no, string pre_order);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string future_order(string buy_or_sell, string branch, string account, string future_id, string price, string amount, string price_type, string ordtype, string octtype);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string future_cancel( string branch, string account, string future_id, string ord_seq, string ord_no, string octtype, string pre_order);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string future_change(string org_seqno, string org_ordno, string branch, string account, string commodity, string new_price, string pre_order);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string option_order(string buy_or_sell, string branch, string account, string option_id, string price, string amount, string price_type, string ordtype, string octtype, string IsComp, string bs3, string commodity2);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string option_cancel(string branch, string account, string option_id, string ord_seq, string ord_no, string octtype, string pre_order);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ffuture_order(string buy_or_sell, string branch, string account, string code, string price1, string price2, string price3, string amount, string price_type, string pre_order, string trade_place, string dtrade, string source);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ffture_cancel(string buy_or_sell, string branch, string account, string code, string ord_seq, string ord_num, string type_1, string pre_order, string trade_place, string dtrade, string source);

        #endregion

        #region 回報, 庫存查詢函式

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string get_response();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string fo_unsettled_qry(string flag, string leng, string next, string prev, string gubn, string group_name, string brance, string account, string type_1, string type_2, string time_out);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string fo_order_qry2(string brance, string account, string code, string ord_match_flag, string ord_type, string oct_type, string daily, string start_date, string end_date, string preorder, string source);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string stock_balance_qry(string flag, string leng, string next, string prev, string gubn, string group_name, string branch, string account, string time_out);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string stock_balance_sum(string branch, string account, string type, string action);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string stock_balance_detail(string branch, string account, string stock, string ttype);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ff_get_response();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ff_get_info(string branch, string account);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ff_get_positions(string branch, string account);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string ff_order_qry(string branch, string account, string start_date, string end_date, string ord_match_flag, string daily);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string fo_get_day_info(string branch, string account);

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string fo_get_hist_info(string branch, string account, string sdate, string edate);

        #endregion

        #region 其他回報查詢方式

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string get_response_log();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int check_response_buffer();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string timer_response_log();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int fifo_response(string response_str);

        //[DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        //public static extern IntPtr get_response_evt(string response_str);

        #endregion

        #region 其他函式

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string change_echo();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int log_out();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string show_version();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string show_list();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern string show_ip();

        [DllImport("C:\\VBA DLL\\t4.dll", SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int do_register(int YorN);

        #endregion


    }
}
