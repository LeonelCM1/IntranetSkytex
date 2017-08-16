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
        public WebAppIntranetAdmComentarios_Result comentarios(int num_fol, string comentario, string user_cve, DateTime fecha, short sw_visible, int num_folp, short opcion)
        {
            WebAppIntranetAdmComentarios_Result coment = contexto.WebAppIntranetAdmComentarios(num_fol, comentario, user_cve, fecha, sw_visible, num_folp, opcion).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return coment;
        }
        public List<WebAppIntranetConsultaComentarios_Result> ConsultaComentarios(int num_fol, int num_folp, short opcion)
        {
            List<WebAppIntranetConsultaComentarios_Result> lista_coment = contexto.WebAppIntranetConsultaComentarios(num_fol, num_folp, opcion).ToList();
            SqlConnection.ClearAllPools();
            return lista_coment;
        }
        public List<xcuser> Usuarios()
        {
            List<xcuser> users = (from u in contexto.xcuser where u.ef_cve == "001" && u.status == 1 select u).Distinct().ToList();
            SqlConnection.ClearAllPools();
            return users;
        }
        public string Login(string user, string pass)
        {
            string usr_cve;
            var result = (from usuario in contexto.xcuser
                          where
                            usuario.user_cve.Equals(user) &&
                            usuario.password.Equals(pass)
                          select usuario).SingleOrDefault();

            if (result == null)
            {
                return usr_cve = null;
            }
            else
            {
                if (string.IsNullOrEmpty(result.user_cve) == false)
                {
                    usr_cve = result.user_cve;
                    return usr_cve;
                }
                else
                {
                    return usr_cve = null;
                }
            }
        }
        public string nombreUsuario(string user_cve)
        {
            string nombre = (from usuario in contexto.xcuser
                          where
                            usuario.user_cve.Equals(user_cve)
                          select usuario.nombre).SingleOrDefault();
            if (nombre==null)
            {
                nombre = "Usuario no encontrado";
            }
            SqlConnection.ClearAllPools();
            return nombre;
        }
        public List<WebAppIntranetConsultaUsuarios_Result> Intranet_Usuarios(string user_cve, short tipo)
        {
            List<WebAppIntranetConsultaUsuarios_Result> usuarios = contexto.WebAppIntranetConsultaUsuarios(user_cve, tipo).ToList();
            SqlConnection.ClearAllPools();
            return usuarios;
        }
        public WebAppIntranetAdmUsuarios_Result AdminUsuarios(string user_cve, short rol, string app, short sw_activo, short tipo)
        {
            WebAppIntranetAdmUsuarios_Result resultado = contexto.WebAppIntranetAdmUsuarios(user_cve, rol, app, sw_activo, tipo).FirstOrDefault();
            SqlConnection.ClearAllPools();
            return resultado;
        }
        public List<WebAppIntranetConsultaApps_Result> ConsultaApps(short tipo)
        {
            List<WebAppIntranetConsultaApps_Result> apps = contexto.WebAppIntranetConsultaApps(tipo).ToList();
            SqlConnection.ClearAllPools();
            return apps;
        }
    }
}
