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

        public List<sp_WebAppIntranetConsultaAnuncios_Result> ConsultaAnuncios()
        {
            List<sp_WebAppIntranetConsultaAnuncios_Result> anuncios = contexto.sp_WebAppIntranetConsultaAnuncios().ToList();
            SqlConnection.ClearAllPools();
            return anuncios;
        }
        public List<sp_WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha, int tipo)
        {
            List<sp_WebAppIntranetConsultaEventos_Result> eventos = contexto.sp_WebAppIntranetConsultaEventos(fecha,tipo).ToList();
            SqlConnection.ClearAllPools();
            return eventos;
        }
        public sp_WebAppIntranetInsertaNoticia_Result InsertarNoticia(string titulo, string noticia, string resumen, DateTime fecha, string imagen, string autor)
        {
            sp_WebAppIntranetInsertaNoticia_Result resultado = contexto.sp_WebAppIntranetInsertaNoticia(titulo, noticia, resumen, fecha, imagen, autor).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public Intranet_noticias ConsultaNoticiaPorFolio(int folio)
        {
            Intranet_noticias Noticia = (from u in contexto.Intranet_noticias 
                                          where u.num_folio == folio
                                          select u).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return Noticia;
        }
    }
}
