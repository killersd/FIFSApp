//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FIFSApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UsuarioEquipe
    {
        public int Id { get; set; }
        public System.DateTime DataEntrada { get; set; }
        public Nullable<int> Equipe_Id { get; set; }
        public Nullable<int> Usuario_Id { get; set; }
    
        public virtual Equipe Equipe { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}