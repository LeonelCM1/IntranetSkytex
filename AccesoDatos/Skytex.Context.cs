﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class developEntities : DbContext
    {
        public developEntities()
            : base("name=developEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Intranet_Anuncios> Intranet_Anuncios { get; set; }
        public virtual DbSet<Intranet_noticias> Intranet_noticias { get; set; }
    
        public virtual ObjectResult<sp_WebAppIntranetConsultaAnuncios_Result> sp_WebAppIntranetConsultaAnuncios()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WebAppIntranetConsultaAnuncios_Result>("sp_WebAppIntranetConsultaAnuncios");
        }
    
        public virtual ObjectResult<sp_WebAppIntranetConsultaEventos_Result> sp_WebAppIntranetConsultaEventos(Nullable<System.DateTime> fecha_consulta, Nullable<int> tipo)
        {
            var fecha_consultaParameter = fecha_consulta.HasValue ?
                new ObjectParameter("fecha_consulta", fecha_consulta) :
                new ObjectParameter("fecha_consulta", typeof(System.DateTime));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_WebAppIntranetConsultaEventos_Result>("sp_WebAppIntranetConsultaEventos", fecha_consultaParameter, tipoParameter);
        }
    }
}