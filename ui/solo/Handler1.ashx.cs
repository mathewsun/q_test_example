using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solo
{
    /// <summary>
    /// Сводное описание для Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Привет всем!");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}