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
    
    public partial class ForumComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public System.DateTime Date { get; set; }
        public int ForumId { get; set; }
        public int AuthorId { get; set; }
    
        public virtual Forum Forum { get; set; }
        public virtual User User { get; set; }
    }
}