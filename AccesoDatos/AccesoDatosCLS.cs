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
    }
}
