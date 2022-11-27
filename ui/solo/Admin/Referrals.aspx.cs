using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class Referrals : System.Web.UI.Page
    {
        public List<Model.spGetRefferalsResult> ListItems;

        public int HoursDifference;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            if (!IsPostBack)
            {
                string userId = Request.Params["userid"];

                if (!string.IsNullOrEmpty(userId))
                {
                    ListItems = DataHelper.GetUserReferrals(new Guid(userId));
                }
                else
                {
                    ListItems = DataHelper.GetUserReferrals(null);
                }
            }
        }
    }
}