using System;
using System.Collections.Generic;
using System.Linq;
using Solo.Model;

namespace Solo.Admin
{
    public partial class CashOut : System.Web.UI.Page
    {
        public List<Model.CashOuts> list;

        public int HoursDifference;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["userid"]))
                {
                    try
                    {
                        Guid userId = new Guid(Request.Params["userid"]);

                        list = DataHelper.GetUserCashOuts(userId);
                    }
                    catch (System.Exception ex)
                    {
                        DataHelper.AddException(ex);
                    }
                }
                else
                {
                    list = DataHelper.GetAllCashOuts();
                }
            }
        }
    }
}