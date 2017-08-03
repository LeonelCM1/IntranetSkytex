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

        public List<WebAppIntranetConsultaEventos_Result> ConsultaAnuncios()
        {
            List<WebAppIntranetConsultaEventos_Result> anuncios = contexto.WebAppIntranetConsultaEventos(DateTime.Today.Date,0,0,1).ToList();
            SqlConnection.ClearAllPools();
            return anuncios;
        }
        public List<WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha,int folio, int tipo, short sw_anuncio)
        {
            List<WebAppIntranetConsultaEventos_Result> eventos = contexto.WebAppIntranetConsultaEventos(fecha,folio, tipo,sw_anuncio).ToList();
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
        public WebAppIntranetAdmEventos_Result AdminAnuncios(int num_fol, string titulo, string texto, DateTime fecha, string autor, DateTime fecha_ini,DateTime fecha_fin,short sw_anuncio, short opcion)
        {
            WebAppIntranetAdmEventos_Result resultado = contexto.WebAppIntranetAdmEventos(num_fol, titulo, texto, fecha, autor,fecha_ini, fecha_fin,sw_anuncio, opcion).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public WebAppIntranetAdmNoticia_Result AdminNoticias(int folio, string titulo, string noticia, string resumen, DateTime fecha, string imagen, string autor, short opcion)
        {
            WebAppIntranetAdmNoticia_Result resultado = contexto.WebAppIntranetAdmNoticia(folio, titulo, noticia, resumen, fecha, imagen, autor, opcion).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public List<WebAppIntranetBirthday_Result> cumpleanios(DateTime fecha, short tipo)
        {
            List<WebAppIntranetBirthday_Result> cumpleanieros = contexto.WebAppIntranetBirthday(fecha, tipo).ToList();
            SqlConnection.ClearAllPools();
            return cumpleanieros;
        }
    }
}
