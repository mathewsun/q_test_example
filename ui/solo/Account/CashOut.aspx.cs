using System;
using System.Collections.Generic;
using Solo.Model;
using System.Linq;

namespace Solo.Account
{
    public partial class CashOut : BasicPage
    {
        public List<Model.CashOuts> list;

        public int HoursDifference;

        public int ResultOrder = 0;

        public double Balance;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            Balance = DataHelper.GetBalance(User.UserId);

            if (!IsPostBack)
            {
                FillList();
            }
        }

        public void FillList()
        {
            list = DataHelper.GetUser20CashOuts(User.UserId);

            try
            {
                TextBoxNumber.Text = list.Where(x => x.Type == 1).OrderBy(x => x.WhenDate).Last().Number;
            }
            catch { }
        }

        protected void ButtonCashOut_Click(object sender, EventArgs e)
        {
            double value;

            double valueWithPercents;

            if (!double.TryParse(TextBoxCashOut.Text, out value))
            {
                ResultOrder = 3;

                FillList();

                return;
            }

            valueWithPercents = value;

            int type = Convert.ToInt32(RadioButtonListCashOutType.SelectedItem.Value);

            //if (type == 1 && !TextBoxNumber.Text.StartsWith("+79") && !TextBoxNumber.Text.StartsWith("+38"))
            //{
            //    ResultOrder = 3;

            //    FillList();

            //    return;
            //}

            if (type == 4)
            {
                valueWithPercents = valueWithPercents + 50 + (valueWithPercents / 100 * 2);
            }

            double balance = DataHelper.GetBalance(User.UserId);

            if (balance < valueWithPercents || value <= 0)
            {
                ResultOrder = 2;

                FillList();

                return;
            }

            Model.CashOuts cashOut = new Model.CashOuts
            {
                Value = value,
                Sposob = TextBoxNumber.Text,
                Number = TextBoxNumber.Text,
                State = (int)CashOutStatesEnum.Entered,
                UserId = User.UserId,
                WhenDate = DateTime.Now,
                Type = type
            };

            cashOut.Id = DataHelper.AddCashOut(cashOut);

            #region Списание со счета

            DataHelper.UpdateUserBalance(User.UserId, -valueWithPercents, UpdateBalanceType.CashOut);

            #endregion

            #region Логирование операции

            {
                Operation operation = new Operation
                {
                    UserId = User.UserId,
                    Value = -valueWithPercents,
                    Type = (int)OperationTypesEnum.CashOut,
                    Comment = string.Format("Запрос вывода на сумму {0} р. Способ: {1}. Номер (счет): {2}", value, CashOutTypes.GetName(type), TextBoxNumber.Text),
                    WhenDate = DateTime.Now
                };

                DataHelper.AddOperation(operation);
            }

            #endregion

            #region Оплата платежа

            PaymentHelper.MakePayment(cashOut);

            #endregion

            (Master as SiteBalance).UpdateBalance();

            ResultOrder = 1;

            TextBoxCashOut.Text = string.Empty;
            TextBoxNumber.Text = string.Empty;

            FillList();
        }
    }
}