using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Solo.Model;
using Newtonsoft.Json;

namespace Solo
{
    /// <summary>
    /// Сводное описание для PayPayMakeTransferHandler
    /// </summary>
    public class PayPayMakeTransferHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            CashOuts item = DataHelper.GetCashOutForPayment();

            string json = string.Empty;//JsonConvert.SerializeObject(item);

            context.Response.ContentType = "text/json";
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}