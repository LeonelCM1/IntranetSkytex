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
        public List<WebAppIntranetConsultaEventos_Result> ConsultaAnuncios()
        {
            return (datos.ConsultaAnuncios());
        }
        public List<WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha,int folio, int tipo, short sw_anuncio)
        {
            return (datos.ConsultaEventos(fecha,folio,tipo,sw_anuncio));
        }
        public Intranet_noticias ConsultaNoticiaPorFolio(int folio)
        {
            return (datos.ConsultaNoticiaPorFolio(folio));
        }
        public WebAppIntranetAdmEventos_Result AdminAnuncios(int num_fol, string titulo, string texto, DateTime fecha, string autor, DateTime fecha_ini, DateTime fecha_fin, short sw_anuncio, short opcion)
        {
            return (datos.AdminAnuncios(num_fol, titulo, texto, fecha, autor, fecha_ini, fecha_fin, sw_anuncio, opcion));
        }
        public WebAppIntranetAdmNoticia_Result AdminNoticias(int num_fol, string titulo, string noticia, string resumen, DateTime fecha, string imagen, string autor, short opcion)
        {
            return (datos.AdminNoticias(num_fol, titulo, noticia, resumen, fecha, imagen, autor, opcion));
        }
        public List<WebAppIntranetBirthday_Result> cumpleanios(DateTime fecha, short tipo)
        {
            return (datos.cumpleanios(fecha, tipo));
        }
    }
}
