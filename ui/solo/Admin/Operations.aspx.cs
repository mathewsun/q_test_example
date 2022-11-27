﻿using System;
using System.Collections.Generic;
using Solo.Model;

namespace Solo.Admin
{
    public partial class Operations : System.Web.UI.Page
    {
        public List<Model.Operation> List;

        public int HoursDifference;

        protected void Page_Load(object sender, EventArgs e)
        {
            HoursDifference = Convert.ToInt32(DataHelper.GetSettingByName("HoursDifference").Value);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Params["userid"]))
                {
                    try
                    {
                        Guid userId = new Guid(Request.Params["userid"]);

                        List = DataHelper.GetUserOperations(userId);
                    }
                    catch (System.Exception ex)
                    {
                        DataHelper.AddException(ex);
                    }
                }
                else
                {
                    List = DataHelper.GetLast100Operations();
                }
            }
        }
    }
}