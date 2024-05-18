using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBooking.DB
{
    partial class  Order
    {
        public string Price3
        {
            get
            {
                return Convert.ToDouble(FullPrice).ToString() + " Руб.";
            }
        }
    }
}
