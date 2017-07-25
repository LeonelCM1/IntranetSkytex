using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace LogicaNegocio
{
    public class LogicaNegocioCLS
    {
        AccesoDatosCLS datos;
        public LogicaNegocioCLS()
        {
            datos = new AccesoDatosCLS();
        }
        public List<Intranet_noticias> ConsultaNoticias()
        {
            return (datos.ConsultaNoticias());
        }
        public List<sp_WebAppIntranetConsultaAnuncios_Result> ConsultaAnuncios(int fol)
        {
            return (datos.ConsultaAnuncios(fol));
        }
        public List<sp_WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha, int tipo)
        {
            return (datos.ConsultaEventos(fecha,tipo));
        }
        public Intranet_noticias ConsultaNoticiaPorFolio(int folio)
        {
            return (datos.ConsultaNoticiaPorFolio(folio));
        }
        public sp_WebAppIntranetConsultaAnuncios_Result AnuncioPorFolio(int folio)
        {
            return (datos.AnuncioPorFolio(folio));
        }
        public WebAppIntranetAdmAnuncios_Result AdminAnuncios(int num_fol, string titulo, string texto, DateTime fecha, string autor, DateTime fecha_fin, short opcion)
        {
            return (datos.AdminAnuncios(num_fol, titulo, texto, fecha, autor, fecha_fin, opcion));
        }
        public WebAppIntranetAdmNoticia_Result AdminNoticias(int num_fol, string titulo, string noticia, string resumen, DateTime fecha, string imagen, string autor, short opcion)
        {
            return (datos.AdminNoticias(num_fol, titulo, noticia, resumen, fecha, imagen, autor, opcion));
        }
    }
}
