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
        public string fol;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["n"]!=null)
            {
                int folio = Convert.ToInt32(Request.QueryString["n"]);
                Intranet_noticias noticia = logica.ConsultaNoticiaPorFolio(folio);
                if (noticia!=null)
                {
                    lblTitulo.Text = noticia.titulo;
                    if (noticia.imagenUrl!=null && noticia.imagenUrl!="")
                    {
                        Image1.Visible = true;
                        Image1.ImageUrl = "~/Media/Mini/" + noticia.imagenUrl;
                    }
                    else
                    {
                        Image1.Visible = divImagen.Visible = divVacio.Visible = false;
                    }
                    //lblNoticia.Text = noticia.noticia;
                    Literal1.Text = noticia.noticia;
                    fol = noticia.num_folio.ToString();
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
        public string Validar()
        {
            string medida = "col-md-8 text-center";
            if (!Image1.Visible)
            {
                medida = "col-md-12 text-center";
            }
            return medida;
        }
    }
}