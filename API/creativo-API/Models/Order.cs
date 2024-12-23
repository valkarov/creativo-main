//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace creativo_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    
        public int Id { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int DistrictId { get; set; }
        public int EntrepeneurshipId { get; set; }
        public int DeliveryManId { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime DeliveryDate { get; set; }
        public int State { get; set; }
    
        public virtual District District { get; set; }
        public virtual Entrepeneurship Entrepeneurship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual User User { get; set; }
    }
}
