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
            if (txtResumen.Text.Length>250)
            {
                Response.Write("<script type=\"text/javascript\">alert('El resumen solo puede contener 250 caracteres');</script>");
            }
            else
            {
                sp_WebAppIntranetInsertaNoticia_Result resultado = logica.InsertaNoticia(txtTitulo.Text, CKEditor1.Text, txtResumen.Text, DateTime.Now, fileName, "LNC");//user
            }
            
        }

    }
}