//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantBooking.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auth
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auth()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int User_ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
