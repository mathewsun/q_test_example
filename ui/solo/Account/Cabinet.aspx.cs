using System;
using Solo.Model;

namespace Solo.Account
{
    public partial class Cabinet : BasicPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    this.UpdateSession();

            //    double balance = DataHelper.GetBalanceWithUpdateByName(Context.User.Identity.Name);

            //    double todayPercent = DataHelper.GetTodayPercent();

            //    double averageMonthPercent = (Math.Pow(1 + (todayPercent / 100), 30) - 1) * 100;

            //    double profitPerHour = (((balance / 100) * todayPercent) / 24);

            //    double profitPerDay = ((balance / 100) * todayPercent);

            //    double profitPerMonth = (balance / 100) * averageMonthPercent;

            //    Users user = DataHelper.GetUser(User.UserId);

            //    LabelEarnedFull.Text = (Math.Truncate(user.Earned * 100) / 100).ToString("F2");

            //    LabelEarnedToday.Text = (Math.Truncate(user.EarnedToday * 100) / 100).ToString("F2");

            //    LabelTodayPercent.Text = todayPercent.ToString("N2");

            //    LabelMonthPercent.Text = averageMonthPercent.ToString("N2");

            //    LabelProfitPerHour.Text = profitPerHour.ToString("N2");

            //    LabelProfitPerDay.Text = profitPerDay.ToString("N2");

            //    LabelProfitPerMonth.Text = profitPerMonth.ToString("N2");
            //}
        }
    }
}