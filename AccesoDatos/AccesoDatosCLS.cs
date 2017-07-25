using Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class AccesoDatosCLS
    {
        developEntities contexto;

        public AccesoDatosCLS()
        {
            contexto = new developEntities();
        }
        public List<Intranet_noticias> ConsultaNoticias()
        {
            List<Intranet_noticias> Noticias = (from u in contexto.Intranet_noticias orderby u.fecha descending select u).ToList();
            SqlConnection.ClearAllPools();
            return Noticias;
        }

        public List<sp_WebAppIntranetConsultaAnuncios_Result> ConsultaAnuncios(int fol)
        {
            List<sp_WebAppIntranetConsultaAnuncios_Result> anuncios = contexto.sp_WebAppIntranetConsultaAnuncios(fol).ToList();
            SqlConnection.ClearAllPools();
            return anuncios;
        }
        public List<sp_WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha, int tipo)
        {
            List<sp_WebAppIntranetConsultaEventos_Result> eventos = contexto.sp_WebAppIntranetConsultaEventos(fecha,tipo).ToList();
            SqlConnection.ClearAllPools();
            return eventos;
        }
        public Intranet_noticias ConsultaNoticiaPorFolio(int folio)
        {
            Intranet_noticias Noticia = (from u in contexto.Intranet_noticias 
                                          where u.num_folio == folio
                                          select u).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return Noticia;
        }
        public sp_WebAppIntranetConsultaAnuncios_Result AnuncioPorFolio(int fol)
        {
            sp_WebAppIntranetConsultaAnuncios_Result anuncios = contexto.sp_WebAppIntranetConsultaAnuncios(fol).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return anuncios;
        }
        public WebAppIntranetAdmAnuncios_Result AdminAnuncios(int num_fol, string titulo, string texto, DateTime fecha, string autor, DateTime fecha_fin, short opcion)
        {
            WebAppIntranetAdmAnuncios_Result resultado = contexto.WebAppIntranetAdmAnuncios(num_fol, titulo, texto, fecha, autor, fecha_fin, opcion).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public WebAppIntranetAdmNoticia_Result AdminNoticias(int folio, string titulo, string noticia, string resumen, DateTime fecha, string imagen, string autor, short opcion)
        {
            WebAppIntranetAdmNoticia_Result resultado = contexto.WebAppIntranetAdmNoticia(folio, titulo, noticia, resumen, fecha, imagen, autor, opcion).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
    }
}
