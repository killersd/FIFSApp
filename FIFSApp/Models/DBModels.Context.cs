﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBModel : DbContext
    {
        public DBModel()
            : base("name=DBModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Campeonato> Campeonato { get; set; }
        public virtual DbSet<Carro> Carro { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Circuito> Circuito { get; set; }
        public virtual DbSet<CircuitoCampeonato> CircuitoCampeonato { get; set; }
        public virtual DbSet<Equipe> Equipe { get; set; }
        public virtual DbSet<EquipeCampeonato> EquipeCampeonato { get; set; }
        public virtual DbSet<EtiquetaTag> EtiquetaTag { get; set; }
        public virtual DbSet<MembroCampeonato> MembroCampeonato { get; set; }
        public virtual DbSet<RegistroDisputa> RegistroDisputa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioEquipe> UsuarioEquipe { get; set; }
    }
}
