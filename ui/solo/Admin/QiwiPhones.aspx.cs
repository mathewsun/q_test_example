using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class QiwiPhones : System.Web.UI.Page
    {
        public List<Model.Phones> ListItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CheckNumber = Request.QueryString["update"];

            if (!string.IsNullOrEmpty(CheckNumber))
            {
                DataHelper.CheckQiwiAccountPaymentsHistory(CheckNumber);
            }

            Fill();
        }

        private void Fill()
        {
            ListItems = DataHelper.GetQiwiPhoneNumber();
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e, Phones item)
        {

        }

        protected void ButtonUpdateWorkNumber_Click(object sender, EventArgs e)
        {
            DataHelper.UpdateQiwiAccountBalanceSmallNumber();

            Fill();
        }
    }
}