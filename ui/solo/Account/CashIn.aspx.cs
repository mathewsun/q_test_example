using System;
using System.Security.Cryptography;
using System.Text;
using Solo.Model;

namespace Solo.Account
{
    public partial class CashIn : BasicPage
    {
        public string QiwiAccount;

        public string QiwiAccountCheck;

        protected void Page_Load(object sender, EventArgs e)
        {
            QiwiAccount = DataHelper.GetActiveQiwiAcoountNumber();

            QiwiAccountCheck = QiwiAccount;
        }
    }
}