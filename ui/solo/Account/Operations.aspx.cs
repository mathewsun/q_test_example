using System;
using System.Collections.Generic;
using Solo.Model;
using System.Collections.Specialized;

namespace Solo.Account
{
    public partial class Operations : BasicPage
    {
        public List<Model.Operation> List;

        protected void Page_Load(object sender, EventArgs e)
        {
            string CheckNumber = Request.QueryString["ch"];

            if(!string.IsNullOrEmpty(CheckNumber))
            {
                DataHelper.CheckQiwiAccountPaymentsHistory(CheckNumber);
            }
            
            //if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().Contains("CashIn.aspx"))
            //{
            //    DataHelper.CheckAllAccountsQiwiPaymentsHistories();
            //}

            if (!IsPostBack)
            {
                List = DataHelper.GetUserOperationsLast100(User.UserId);
            }
        }
    }
}