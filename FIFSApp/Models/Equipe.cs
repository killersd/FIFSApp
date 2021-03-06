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
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Equipe
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Equipe()
        {
            this.EquipeCampeonato = new HashSet<EquipeCampeonato>();
            this.UsuarioEquipe = new HashSet<UsuarioEquipe>();
        }*/
    
        public int Id { get; set; }
        [Required (ErrorMessage ="Este campo � obrigat�rio")]
        public string Sigla { get; set; }
        [Required (ErrorMessage ="Este campo � obrigat�rio")]//vai ser validado atraves do script no index
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo � obrigat�rio")]
        public int Situacao { get; set; }
        public string Imagem { get; set; }
        public Nullable<int> Carro_Id { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImagem { get; set; }

        public Equipe()
        {
            Imagem = "~/Arquivos/Imagens/equipe.png";
        }

         



        public virtual Carro Carro { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipeCampeonato> EquipeCampeonato { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsuarioEquipe> UsuarioEquipe { get; set; }
    }
}
