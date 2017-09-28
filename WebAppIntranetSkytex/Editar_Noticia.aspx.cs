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
            if (Session["user_cve"] != null && (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2))
            {
                if (Request.QueryString["n"]!=null)
                {
                    folio = Convert.ToInt32(Request.QueryString["n"]);
                    if (!IsPostBack)
                    {
                        WebAppIntranetConsultaNoticias_Result noticia = logica.ConsultaNoticias(folio, 1, 2).FirstOrDefault();
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
            if (txtResumen.Text.Length > 250)
            {
                Response.Write("<script type=\"text/javascript\">alert('El resumen solo puede contener 250 caracteres');</script>");
            }
            else if (txtTitulo.Text.Trim(' ') != "" && CKEditor1.Text.Trim(' ') != "" && txtResumen.Text.Trim(' ') != "")
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
                    WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, titulo, noticia, resumen, DateTime.Today, imagen, Session["user_cve"].ToString(),1,DateTime.Today, 2);
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
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');window.location.href = window.location.href;</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, "", "", "", DateTime.Today, "",Session["user_cve"].ToString(),1,DateTime.Today, 3);
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