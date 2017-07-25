using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.IO;

namespace WebAppIntranetSkytex
{
    public partial class AgregarNoticia : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (Imagen.HasFile)
            {
                fileName = Path.GetFileName(Imagen.PostedFile.FileName);
                Imagen.PostedFile.SaveAs(Server.MapPath("~/Media/") + fileName);
            }
            else
            {
                fileName = null;
            }
            if (txtResumen.Text.Length>250)
            {
                Response.Write("<script type=\"text/javascript\">alert('El resumen solo puede contener 250 caracteres');</script>");
            }
            else if (txtTitulo.Text!="" && CKEditor1.Text!="")
            {
                string noticia = CKEditor1.Text;
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(0,txtTitulo.Text,noticia, txtResumen.Text, DateTime.Today, fileName, "LNC",1);//user
                if (resultado.error==0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Noticia Agregada Correctamente');window.location.href = 'Inicio.aspx';</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: "+resultado.mensaje+"');</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');</script>");
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inicio.aspx");
        }

    }
}