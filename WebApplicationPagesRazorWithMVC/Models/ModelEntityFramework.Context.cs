﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplicationPagesRazorWithMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InstagramEntities : DbContext
    {
        public InstagramEntities()
            : base("name=InstagramEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Photo> Photo { get; set; }
        public virtual DbSet<tLike> tLike { get; set; }
        public virtual DbSet<tUser> tUser { get; set; }
        public virtual DbSet<Tweet> Tweet { get; set; }
        public virtual DbSet<Share> Share { get; set; }
    
        public virtual ObjectResult<verifyUser_Result> verifyUser(string nameUser)
        {
            var nameUserParameter = nameUser != null ?
                new ObjectParameter("NameUser", nameUser) :
                new ObjectParameter("NameUser", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<verifyUser_Result>("verifyUser", nameUserParameter);
        }
    }
}