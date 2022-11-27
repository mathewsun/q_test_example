using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class Articles : System.Web.UI.Page
    {
        public List<Model.Article> ListItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListItems = DataHelper.GetArticles();
        }
    }
}