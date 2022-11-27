using System;
using System.Collections.Generic;
using System.Web.UI;
using Solo.Model;
using Membership = Solo.Model.Membership;

namespace Solo.Admin
{
    public partial class User : BasicPage
    {
        public Model.Users UserItem;

        public Membership MembershipUser;

        public Solo.Model.Referrals Referer;

        public List<Model.LoginStatistics> ListLoginStatistics;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillUser();
            }
        }

        public void FillUser()
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                try
                {
                    Guid userId = new Guid(Request.Params["id"]);

                    UserItem = DataHelper.GetUser(userId);
                }
                catch (System.Exception ex)
                {
                    DataHelper.AddException(ex);
                }

                if (UserItem == null)
                {
                    string userName = Request.Params["id"];

                    UserItem = DataHelper.GetUserByName(userName);
                }

                if (UserItem != null)
                {
                    MembershipUser = DataHelper.GetUserMembership(UserItem.UserId);

                    LabelUserName.Text = UserItem.UserName;

                    LabelRegistered.Text = MembershipUser.CreateDate.ToString("dd.MM.yyyy HH:mm");

                    TextBoxBalance.Text = UserItem.Balance.ToString("N2");

                    LabelEmail.Text = MembershipUser.Email;

                    Referer = DataHelper.GetReferral(UserItem.UserId);

                    LabelUserIsBlocked.Text = MembershipUser.IsLockedOut ? "Да" : "Нет";

                    if (Referer != null)
                    {
                        LabelReferal.Text = DataHelper.GetUser(Referer.ReferrerUserId).UserName;
                    }

                    ListLoginStatistics = DataHelper.GetLoginStatistics(UserItem.UserName);
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            Model.Users userValue = new Model.Users();

            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                Guid userId = new Guid(Request.Params["id"]);

                userValue = DataHelper.GetUser(userId);

                userValue.Balance = Convert.ToDouble(TextBoxBalance.Text);

                DataHelper.UpdateUser(userValue);

                //Event eventItem = new Event
                //{
                //    Value = string.Format("Администратор изменил баланс пользователю {0} на {1}", userValue.UserName, userValue.Balance),
                //    WhenDate = DateTime.Now
                //};

                //DataHelper.AddEvent(eventItem);

                FillUser();
            }
        }

        protected void ButtonBlock_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                Guid userId = new Guid(Request.Params["id"]);

                DataHelper.BlockUser(userId);

                FillUser();
            }
        }

        protected void ButtonUnBlock_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                Guid userId = new Guid(Request.Params["id"]);

                DataHelper.UnBlockUser(userId);

                FillUser();
            }
        }
    }
}