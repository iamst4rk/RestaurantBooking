using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBooking.DB;

namespace RestaurantBooking.DB
{
    public class DBconnect
    {
        public static RestaurantBookingEntities RestaurantBooking = new RestaurantBookingEntities();
    }
}
