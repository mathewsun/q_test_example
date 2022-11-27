using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Solo.Model;

namespace Solo
{
    /// <summary>
    /// Сводное описание для PayPayMakeTransferWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class PayPayMakeTransferWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public List<PayPayMakeTransferClassTest> GetEnteredCO()
        {
            return DataHelper.GetEnteredCO();
        }

        [WebMethod]
        public void AddCO(int coId)
        {
            DataHelper.SetCashOutFinished(coId);
        }

        [WebMethod]
        public GetQiwiPhonesCheckHistoryQueueItem GetQiwiPhonesCheckHistoryQueue()
        {
            GetQiwiPhonesCheckHistoryQueueItem result = DataHelper.GetQiwiPhonesCheckHistoryQueue();

            return result;
        }

        [WebMethod]
        public void UpdateQiwiPhonesCheckHistoryQueue(int id, double balance, List<CheckQiwiPayment> list)
        {
            DataHelper.UpdateQiwiPhonesCheckHistoryQueue(id, balance, list);
        }
    }
}
