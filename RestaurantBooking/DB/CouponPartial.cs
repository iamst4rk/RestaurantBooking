using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.DB
{
    partial class Coupon
    {
        public string Price2
        {
            get
            {
                return Convert.ToDouble(Price).ToString() + " Pуб.";
            }
        }
    }
}
