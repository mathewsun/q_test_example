using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solo.Model
{
    public class CheckQiwiPayment
    {
        public int UserPublicId { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string AcceptedAccount { get; set; }

        public string SendAccount { get; set; }
    }
}