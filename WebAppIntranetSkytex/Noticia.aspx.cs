using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;

namespace WebAppIntranetSkytex
{
    public partial class Noticia : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["n"]!=null)
            {
                int folio = Convert.ToInt32(Request.QueryString["n"]);
                Intranet_noticias noticia = logica.ConsultaNoticiaPorFolio(folio);
                lblTitulo.Text = noticia.titulo;
                if (noticia.imagenUrl!=null)
                {
                    Image1.Visible = true;
                    Image1.ImageUrl = "~/Media/Mini/" + noticia.imagenUrl;
                }
                else
                {
                    Image1.Visible = false;
                }
                lblNoticia.Text = noticia.noticia;
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
            
        }
    }
}