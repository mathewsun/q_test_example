using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class DatabaseTables : System.Web.UI.Page
    {
        public List<fnGetTablesRowsResult> ListCounts;

        protected void Page_Load(object sender, EventArgs e)
        {
            ListCounts = DataHelper.GetTablesRowsCount();
        }
    }
}