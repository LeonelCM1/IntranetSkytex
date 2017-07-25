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
    public partial class Editar_Anuncio : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        int folio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["fol"]!=null)
            {
                folio = Convert.ToInt32(Request.QueryString["fol"]);
                if (!IsPostBack)
                {
                    sp_WebAppIntranetConsultaAnuncios_Result anuncio = logica.AnuncioPorFolio(folio);
                    if (anuncio!=null)
                    {
                        txtTitulo.Text = anuncio.titulo;
                        txtAnuncio.Text = anuncio.texto;
                        txtFecha.Text = anuncio.fecha_fin.Date.ToString("yyyy-MM-dd");
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text;
            string texto = txtAnuncio.Text;
            DateTime fecha = DateTime.Today;
            DateTime fecha_fin = Convert.ToDateTime(txtFecha.Text);
            WebAppIntranetAdmAnuncios_Result resultado = logica.AdminAnuncios(folio, titulo, texto, fecha, "LNC", fecha_fin, 2);
            if (resultado.error==0)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmAnuncios_Result resultado = logica.AdminAnuncios(folio, "","",DateTime.Today,"",DateTime.Today,3);
                if (resultado.error==0)
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
    }
}