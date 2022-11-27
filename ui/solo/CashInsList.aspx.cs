using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solo.Model;

namespace Solo
{
    public partial class CashInsList : System.Web.UI.Page
    {
        public List<spGetTop100CashInsResult> ListCashIns;

        public string FullCashIn;

        public string TodayCashIn;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListCashIns = DataHelper.GetLast100CashIns();

                FullCashIn = DataHelper.GetCashInsFullSum().ToString("N2");

                TodayCashIn = DataHelper.GetCashInsIn24HoursSum().ToString("N2");
            }
        }
    }
}