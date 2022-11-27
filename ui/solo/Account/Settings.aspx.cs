using System;
using Solo.Model;

namespace Solo.Account
{
    public partial class Settings : BasicPage
    {
        public Membership MembershipUserMembership;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.UpdateSession();

                MembershipUserMembership = DataHelper.GetUserMembership(User.UserId);

                Model.Referrals referal = DataHelper.GetReferral(User.UserId);

                if (referal != null)
                {
                    Users referrer = DataHelper.GetUser(referal.ReferrerUserId);

                    TextBoxReferrer.Text = referrer.PublicId.ToString();
                    TextBoxReferrer.ReadOnly = true;

                    editReferrerOk.Visible = false;
                }

                TextBoxEmail.Text = MembershipUserMembership.Email;
                TextBoxCommunication.Text = User.Communication;
                TextBoxVkontakteId.Text = User.VkontakteId;
                TextBoxSkype.Text = User.Skype;
                TextBoxIcq.Text = User.Icq;
            }
        }
    }
}