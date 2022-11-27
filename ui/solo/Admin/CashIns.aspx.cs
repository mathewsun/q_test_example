using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class CashIns : System.Web.UI.Page
    {
        public List<Model.CashIns> list;

        public int HoursDifference;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            if (!IsPostBack)
            {
                list = DataHelper.GetLast50CashIns();
            }
        }
    }
}