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
    
    public partial class WorkshopRecord
    {
        public int Id { get; set; }
        public string IdClient { get; set; }
        public Nullable<int> IdWorkshop { get; set; }
        public Nullable<int> LastDigits { get; set; }
        public string Owner { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string State { get; set; }
    }
}
