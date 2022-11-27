using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo
{
    public partial class Articles : System.Web.UI.Page
    {
        public List<Model.Article> ListArticles;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListArticles = DataHelper.GetArticles();
        }
    }
}