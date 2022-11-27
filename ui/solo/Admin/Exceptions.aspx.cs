using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class Exceptions : System.Web.UI.Page
    {
        public List<Model.Exception> ListItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ListItems = DataHelper.GetExceptionsLast100();
            }
        }
    }
}