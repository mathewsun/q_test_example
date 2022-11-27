using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solo.Model;

namespace Solo
{
    public partial class CashOutsList : System.Web.UI.Page
    {
        public List<Model.spGetTop100CashOutsResult> ListCashOuts;

        public string FullCashOut;

        public string TodayCashOut;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListCashOuts = DataHelper.GetLast100CashOuts();

                FullCashOut = DataHelper.GetCashOutsFullSum().ToString("N2");

                TodayCashOut = DataHelper.GetCashOutsIn24HoursSum().ToString("N2");
            }
        }
    }
}