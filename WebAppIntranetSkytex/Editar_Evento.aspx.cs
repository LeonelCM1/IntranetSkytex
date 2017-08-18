using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;

namespace WebAppIntranetSkytex
{
    public partial class Editar_Evento : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        int folio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_cve"] != null && (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2))
            {
                if (Request.QueryString["fol"] != null)
                {
                    folio = Convert.ToInt32(Request.QueryString["fol"]);
                    if (!IsPostBack)
                    {
                        WebAppIntranetConsultaEventos_Result anuncio = logica.ConsultaEventos(DateTime.Today.Date, folio, 4, 0).FirstOrDefault();
                        if (anuncio != null)
                        {
                            txtTitulo.Text = anuncio.titulo;
                            txtAnuncio.Text = anuncio.texto;
                            txtFechaIni.Text = anuncio.fecha_ini.Date.ToString("yyyy-MM-dd");
                            txtFechaFin.Text = anuncio.fecha_fin.Date.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            Response.Redirect("Inicio.aspx");
                        }

                    }
                }
                else
                {
                    Response.Redirect("Inicio.aspx");
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string texto = txtAnuncio.Text;
            DateTime fecha = DateTime.Today;
            DateTime fecha_ini = Convert.ToDateTime(txtFechaIni.Text);
            DateTime fecha_fin = Convert.ToDateTime(txtFechaFin.Text);
            if (validarFechas(fecha_ini,fecha_fin))
            {
                WebAppIntranetAdmEventos_Result resultado = logica.AdminAnuncios(folio, titulo, texto, fecha, Session["user_cve"].ToString(), fecha_ini, fecha_fin, 0, 2);
                if (resultado.error == 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Verificar las fechas ingresadas');</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmEventos_Result resultado = logica.AdminAnuncios(folio, "", "", DateTime.Today, "", DateTime.Today, DateTime.Today, 0, 3);
                if (resultado.error == 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');</script>");
                }
            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }
        public bool validarFechas(DateTime fec_ini, DateTime fecha_fin)
        {
            bool valida = false;
            int a = DateTime.Compare(fec_ini, fecha_fin);//fecha inicial debe ser menor a la fecha final
            if (a < 0)
            {
                valida = true;
            }
            else
            {
                valida = false;
            }
            return valida;
        }
    }
}