using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaNegocio;
using Entidades;
using System.IO;

namespace WebAppIntranetSkytex
{
    public partial class Editar_Noticia : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        static string imagen;
        int folio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["n"]!=null)
            {
                folio = Convert.ToInt32(Request.QueryString["n"]);
                if (!IsPostBack)
                {
                    Intranet_noticias noticia = logica.ConsultaNoticiaPorFolio(folio);
                    if (noticia!=null)
                    {
                        txtTitulo.Text = noticia.titulo;
                        txtResumen.Text = noticia.resumen;
                        CKEditor1.Text = noticia.noticia;
                        imagen = noticia.imagenUrl;
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
            if (Imagen1.HasFile)
            {
                imagen = Path.GetFileName(Imagen1.PostedFile.FileName);
                Imagen1.PostedFile.SaveAs(Server.MapPath("~/Media/") + imagen);
            }
            string titulo = txtTitulo.Text;
            string resumen = txtResumen.Text;
            string noticia = CKEditor1.Text;
            try
            {
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, titulo, noticia, resumen, DateTime.Today, imagen, "LNC", 2);
                if (resultado.error==0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Noticia Actualizada Correctamente');window.location.href = 'Inicio.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: " + resultado.mensaje + "');</script>");
                }
            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, "", "", "", DateTime.Today, "", "LNC", 3);
                if (resultado.error==0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Noticia Eliminada Correctamente');window.location.href = 'Inicio.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: " + resultado.mensaje + "');</script>");
                }
            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }
    }
}