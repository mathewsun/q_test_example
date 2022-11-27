using System;
using System.Collections.Generic;
using System.Web.UI;
using Solo.Model;

namespace Solo
{
    public partial class _Default : Page
    {
        public List<New> ListNews;

        public string UsercCount;

        public string UsersCountRegisteredToday;

        public string UsersCountOnline;

        public string FullCashIn;

        public string TodayCashIn;

        public string FullCashOut;

        public string TodayCashOut;

        public string SafetyDeposite;

        public string TodayPercent;
        
        public int RandomInt;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListNews = DataHelper.GetActiveNewsLast5();

            //if (!IsPostBack)
            //{
            //    Random rnd = new Random();

            //    RandomInt = rnd.Next(-2, 2);

            //    UsercCount = DataHelper.GetSettingByName("UsersCount").Value;

            //    UsersCountRegisteredToday = DataHelper.GetUsersCountRegistered24Hours().ToString();

            //    UsersCountOnline = DataHelper.GetUsersCountOnline().ToString();

            //    UsersCountOnline = (Convert.ToInt32(UsersCountOnline) + RandomInt).ToString();

            //    FullCashIn = DataHelper.GetCashInsFullSum().ToString("N2");

            //    TodayCashIn = DataHelper.GetCashInsIn24HoursSum().ToString("N2");
                
            //    TodayPercent = DataHelper.GetTodayPercent().ToString("N2");

            //    FullCashOut = DataHelper.GetCashOutsFullSum().ToString("N2");

            //    TodayCashOut = DataHelper.GetCashOutsIn24HoursSum().ToString("N2");
            //}
        }

        public void LoginStatus1_LoggedOut(Object sender, System.EventArgs e)
        {
            Session.Remove("User");

            Response.Redirect("/");
        }
    }
}