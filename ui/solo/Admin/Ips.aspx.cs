using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class Ips : System.Web.UI.Page
    {
        public List<Model.LoginStatistics> List;

        public int HoursDifference;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            if (!IsPostBack)
            {
                string ip = Request.Params["ip"];

                if (!string.IsNullOrEmpty(ip))
                {
                    List = DataHelper.GetUsersLoginStatisticsByIp(ip);
                }
            }
        }
    }
}