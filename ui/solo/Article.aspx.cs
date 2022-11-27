﻿using System;
using Solo.Model;

namespace Solo
{
    public partial class Article : System.Web.UI.Page
    {
        public Model.Article ArticleItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int itemId = Convert.ToInt32(Request.Params["id"]);

                if (itemId != 0)
                {
                    ArticleItem = DataHelper.GetOneArticle(itemId);
                }
            }
        }
    }
}