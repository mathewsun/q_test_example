using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solo.Admin
{
    public partial class AdminMenu : System.Web.UI.UserControl
    {
        public bool IsAdmin
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}