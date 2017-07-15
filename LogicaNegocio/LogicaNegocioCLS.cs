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
        public List<sp_WebAppIntranetConsultaAnuncios_Result> ConsultaAnuncios()
        {
            return (datos.ConsultaAnuncios());
        }
        public List<sp_WebAppIntranetConsultaEventos_Result> ConsultaEventos(DateTime fecha, int tipo)
        {
            return (datos.ConsultaEventos(fecha,tipo));
        }
    }
}
