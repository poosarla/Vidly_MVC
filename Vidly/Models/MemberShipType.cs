using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MemberShipType
    {
        public int ID { get; set; }

        public string MemberShipTypeDesc { get; set; }

        public int DiscountRate { get; set; }

        public int DurationinMonths { get; set; }

        public int SignUpFee { get; set; }
    }
}