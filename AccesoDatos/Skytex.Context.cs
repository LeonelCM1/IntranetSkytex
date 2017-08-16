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
    
        public virtual DbSet<Intranet_noticias> Intranet_noticias { get; set; }
        public virtual DbSet<xcuser> xcuser { get; set; }
    
        public virtual ObjectResult<WebAppIntranetAdmNoticia_Result> WebAppIntranetAdmNoticia(Nullable<int> num_fol, string titulo, string noticia, string resumen, Nullable<System.DateTime> fecha, string imagenUrl, string autor, Nullable<short> opcion)
        {
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("titulo", titulo) :
                new ObjectParameter("titulo", typeof(string));
    
            var noticiaParameter = noticia != null ?
                new ObjectParameter("noticia", noticia) :
                new ObjectParameter("noticia", typeof(string));
    
            var resumenParameter = resumen != null ?
                new ObjectParameter("resumen", resumen) :
                new ObjectParameter("resumen", typeof(string));
    
            var fechaParameter = fecha.HasValue ?
                new ObjectParameter("fecha", fecha) :
                new ObjectParameter("fecha", typeof(System.DateTime));
    
            var imagenUrlParameter = imagenUrl != null ?
                new ObjectParameter("imagenUrl", imagenUrl) :
                new ObjectParameter("imagenUrl", typeof(string));
    
            var autorParameter = autor != null ?
                new ObjectParameter("autor", autor) :
                new ObjectParameter("autor", typeof(string));
    
            var opcionParameter = opcion.HasValue ?
                new ObjectParameter("opcion", opcion) :
                new ObjectParameter("opcion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetAdmNoticia_Result>("WebAppIntranetAdmNoticia", num_folParameter, tituloParameter, noticiaParameter, resumenParameter, fechaParameter, imagenUrlParameter, autorParameter, opcionParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetConsultaEventos_Result> WebAppIntranetConsultaEventos(Nullable<System.DateTime> fecha_consulta, Nullable<int> num_fol, Nullable<int> tipo, Nullable<short> sw_anuncio)
        {
            var fecha_consultaParameter = fecha_consulta.HasValue ?
                new ObjectParameter("fecha_consulta", fecha_consulta) :
                new ObjectParameter("fecha_consulta", typeof(System.DateTime));
    
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(int));
    
            var sw_anuncioParameter = sw_anuncio.HasValue ?
                new ObjectParameter("sw_anuncio", sw_anuncio) :
                new ObjectParameter("sw_anuncio", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetConsultaEventos_Result>("WebAppIntranetConsultaEventos", fecha_consultaParameter, num_folParameter, tipoParameter, sw_anuncioParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetBirthday_Result> WebAppIntranetBirthday(Nullable<System.DateTime> fecha_consulta, Nullable<short> tipo)
        {
            var fecha_consultaParameter = fecha_consulta.HasValue ?
                new ObjectParameter("fecha_consulta", fecha_consulta) :
                new ObjectParameter("fecha_consulta", typeof(System.DateTime));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetBirthday_Result>("WebAppIntranetBirthday", fecha_consultaParameter, tipoParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetConsultaComentarios_Result> WebAppIntranetConsultaComentarios(Nullable<int> num_fol, Nullable<int> num_folp, Nullable<short> opcion)
        {
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var num_folpParameter = num_folp.HasValue ?
                new ObjectParameter("num_folp", num_folp) :
                new ObjectParameter("num_folp", typeof(int));
    
            var opcionParameter = opcion.HasValue ?
                new ObjectParameter("opcion", opcion) :
                new ObjectParameter("opcion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetConsultaComentarios_Result>("WebAppIntranetConsultaComentarios", num_folParameter, num_folpParameter, opcionParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetConsultaUsuarios_Result> WebAppIntranetConsultaUsuarios(string user_cve, Nullable<short> tipo)
        {
            var user_cveParameter = user_cve != null ?
                new ObjectParameter("user_cve", user_cve) :
                new ObjectParameter("user_cve", typeof(string));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetConsultaUsuarios_Result>("WebAppIntranetConsultaUsuarios", user_cveParameter, tipoParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetAdmUsuarios_Result> WebAppIntranetAdmUsuarios(string user_cve, Nullable<short> rol, string app, Nullable<short> sw_visible, Nullable<short> tipo)
        {
            var user_cveParameter = user_cve != null ?
                new ObjectParameter("user_cve", user_cve) :
                new ObjectParameter("user_cve", typeof(string));
    
            var rolParameter = rol.HasValue ?
                new ObjectParameter("rol", rol) :
                new ObjectParameter("rol", typeof(short));
    
            var appParameter = app != null ?
                new ObjectParameter("app", app) :
                new ObjectParameter("app", typeof(string));
    
            var sw_visibleParameter = sw_visible.HasValue ?
                new ObjectParameter("sw_visible", sw_visible) :
                new ObjectParameter("sw_visible", typeof(short));
    
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetAdmUsuarios_Result>("WebAppIntranetAdmUsuarios", user_cveParameter, rolParameter, appParameter, sw_visibleParameter, tipoParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetConsultaApps_Result> WebAppIntranetConsultaApps(Nullable<short> tipo)
        {
            var tipoParameter = tipo.HasValue ?
                new ObjectParameter("tipo", tipo) :
                new ObjectParameter("tipo", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetConsultaApps_Result>("WebAppIntranetConsultaApps", tipoParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetAdmComentarios_Result> WebAppIntranetAdmComentarios(Nullable<int> num_fol, string comentario, string user_cve, Nullable<System.DateTime> fecha_publi, Nullable<short> sw_visible, Nullable<int> num_folp, Nullable<short> opcion)
        {
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var comentarioParameter = comentario != null ?
                new ObjectParameter("comentario", comentario) :
                new ObjectParameter("comentario", typeof(string));
    
            var user_cveParameter = user_cve != null ?
                new ObjectParameter("user_cve", user_cve) :
                new ObjectParameter("user_cve", typeof(string));
    
            var fecha_publiParameter = fecha_publi.HasValue ?
                new ObjectParameter("fecha_publi", fecha_publi) :
                new ObjectParameter("fecha_publi", typeof(System.DateTime));
    
            var sw_visibleParameter = sw_visible.HasValue ?
                new ObjectParameter("sw_visible", sw_visible) :
                new ObjectParameter("sw_visible", typeof(short));
    
            var num_folpParameter = num_folp.HasValue ?
                new ObjectParameter("num_folp", num_folp) :
                new ObjectParameter("num_folp", typeof(int));
    
            var opcionParameter = opcion.HasValue ?
                new ObjectParameter("opcion", opcion) :
                new ObjectParameter("opcion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetAdmComentarios_Result>("WebAppIntranetAdmComentarios", num_folParameter, comentarioParameter, user_cveParameter, fecha_publiParameter, sw_visibleParameter, num_folpParameter, opcionParameter);
        }
    
        public virtual ObjectResult<WebAppIntranetAdmEventos_Result> WebAppIntranetAdmEventos(Nullable<int> num_fol, string titulo, string texto, Nullable<System.DateTime> fecha_publi, string autor, Nullable<System.DateTime> fecha_ini, Nullable<System.DateTime> fecha_fin, Nullable<short> sw_anuncio, Nullable<short> opcion)
        {
            var num_folParameter = num_fol.HasValue ?
                new ObjectParameter("num_fol", num_fol) :
                new ObjectParameter("num_fol", typeof(int));
    
            var tituloParameter = titulo != null ?
                new ObjectParameter("titulo", titulo) :
                new ObjectParameter("titulo", typeof(string));
    
            var textoParameter = texto != null ?
                new ObjectParameter("texto", texto) :
                new ObjectParameter("texto", typeof(string));
    
            var fecha_publiParameter = fecha_publi.HasValue ?
                new ObjectParameter("fecha_publi", fecha_publi) :
                new ObjectParameter("fecha_publi", typeof(System.DateTime));
    
            var autorParameter = autor != null ?
                new ObjectParameter("autor", autor) :
                new ObjectParameter("autor", typeof(string));
    
            var fecha_iniParameter = fecha_ini.HasValue ?
                new ObjectParameter("fecha_ini", fecha_ini) :
                new ObjectParameter("fecha_ini", typeof(System.DateTime));
    
            var fecha_finParameter = fecha_fin.HasValue ?
                new ObjectParameter("fecha_fin", fecha_fin) :
                new ObjectParameter("fecha_fin", typeof(System.DateTime));
    
            var sw_anuncioParameter = sw_anuncio.HasValue ?
                new ObjectParameter("sw_anuncio", sw_anuncio) :
                new ObjectParameter("sw_anuncio", typeof(short));
    
            var opcionParameter = opcion.HasValue ?
                new ObjectParameter("opcion", opcion) :
                new ObjectParameter("opcion", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<WebAppIntranetAdmEventos_Result>("WebAppIntranetAdmEventos", num_folParameter, tituloParameter, textoParameter, fecha_publiParameter, autorParameter, fecha_iniParameter, fecha_finParameter, sw_anuncioParameter, opcionParameter);
        }
    }
}
