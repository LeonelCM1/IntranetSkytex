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
                if (!IsPostBack)
                {
                    WebAppIntranetConsultaNoticias_Result noticia = logica.ConsultaNoticias(folio, 1, 2).FirstOrDefault();
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
                        Literal1.Text = noticia.noticia;
                        fol = noticia.num_folio.ToString();
                        short opc = 0;
                        if (Convert.ToInt16(Session["rol"]) == 0)
                        {
                            opc = 1;
                        }
                        else
                        {
                            opc = 3;
                        }
                        ListaComentarios.DataSource = logica.ConsultaComentarios(0,folio, opc);
                        ListaComentarios.DataBind();
                        if (Session["user_cve"]!=null)
                        {
                            txtUsuarioComentario.Text = logica.nombreUsuario(Session["user_cve"].ToString());
                        }
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
        public string Validar()
        {
            string medida = "col-md-8 text-center";
            if (!Image1.Visible)
            {
                medida = "col-md-12 text-center";
            }
            return medida;
        }

        protected void btnComentar_Click(object sender, EventArgs e)
        {
            if (Session["user_cve"]!=null)
            {
                if (txtComentario.Text.Trim(' ')!="")
                {
                    int folio = Convert.ToInt32(Request.QueryString["n"]);
                    string coment = txtComentario.Text.Replace(Environment.NewLine, "<br/>");
                    string user = Session["user_cve"].ToString();
                    WebAppIntranetAdmComentarios_Result resultado = logica.comentarios(0, coment, user, DateTime.Now, 1, folio, 1);

                    if (resultado.error==0)
                    {
                        ListaComentarios.DataSource = logica.ConsultaComentarios(0,folio, 1);
                        ListaComentarios.DataBind();
                        txtComentario.Text = "";
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Error al comentar');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos'); window.location.href=window.location.href;</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Para poder dejar un comentario debes iniciar sesión');</script>");
            }
        }


        protected void ListaComentarios_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
            TextBox txt = e.Item.FindControl("txtNumFolComent") as TextBox;
            int x = Convert.ToInt32(txt.Text);
            txtFolio.Text = x.ToString();
            int folio = Convert.ToInt32(Request.QueryString["n"]);
            WebAppIntranetConsultaComentarios_Result comentario = logica.ConsultaComentarios(x, folio, 2).FirstOrDefault();
            if (comentario!=null)
            {
                txtComentario.Text = comentario.comentario;
                List<WebAppIntranetConsultaComentarios_Result> com = logica.ConsultaComentarios(0, folio, 1);
                com.RemoveAt(e.Item.ItemIndex);
                ListaComentarios.DataSource = com;
                ListaComentarios.DataBind();
                ListaComentarios.Enabled = false;
                divBody.Style.Value ="background-color:gray;";
                btnGuardar.Visible = btnCancelar.Visible = true;
                btnComentar.Visible = false;
                txtComentario.Focus();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtComentario.Text = "";
            divBody.Style.Value = "background-color:none;";
            btnGuardar.Visible = btnCancelar.Visible = false;
            btnComentar.Visible = true;
            ListaComentarios.Enabled = true;
            int folio = Convert.ToInt32(Request.QueryString["n"]);
            List<WebAppIntranetConsultaComentarios_Result> com = logica.ConsultaComentarios(0, folio, 1);
            ListaComentarios.DataSource = com;
            ListaComentarios.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int folio = Convert.ToInt32(txtFolio.Text);
            int foliop = Convert.ToInt32(Request.QueryString["n"]);
            WebAppIntranetAdmComentarios_Result resultado = logica.comentarios(folio, txtComentario.Text, Session["user_cve"].ToString(), DateTime.Today, 1, foliop, 2);
            if (resultado.error==0)
            {
                txtComentario.Text = "";
                divBody.Style.Value = "background-color:none;";
                btnGuardar.Visible = btnCancelar.Visible = false;
                btnComentar.Visible = true;
                ListaComentarios.Enabled = true;
                List<WebAppIntranetConsultaComentarios_Result> com = logica.ConsultaComentarios(0, foliop, 1);
                ListaComentarios.DataSource = com;
                ListaComentarios.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('"+resultado.mensaje+"r');</script>");
            }
        }

        protected void ListaComentarios_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txt = e.Item.FindControl("txtNumFolComent") as TextBox;
            int folio = Convert.ToInt32(txt.Text);
            int foliop = Convert.ToInt32(Request.QueryString["n"]);
            WebAppIntranetAdmComentarios_Result resultado = logica.comentarios(folio, "", Session["user_cve"].ToString(), DateTime.Today, 1, foliop, 3);
            if (resultado.error == 0)
            {
                List<WebAppIntranetConsultaComentarios_Result> com = logica.ConsultaComentarios(0, foliop, 1);
                ListaComentarios.DataSource = com;
                ListaComentarios.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "r');</script>");
            }
        }

        protected void ListaComentarios_CancelCommand(object source, DataListCommandEventArgs e)
        {
            TextBox txt = e.Item.FindControl("txtNumFolComent") as TextBox;
            int folio = Convert.ToInt32(txt.Text);
            int foliop = Convert.ToInt32(Request.QueryString["n"]);
            WebAppIntranetAdmComentarios_Result resultado = logica.comentarios(folio, "", Session["user_cve"].ToString(), DateTime.Today, 1, foliop, 4);
            if (resultado.error == 0)
            {
                List<WebAppIntranetConsultaComentarios_Result> com = logica.ConsultaComentarios(0, foliop, 3);
                ListaComentarios.DataSource = com;
                ListaComentarios.DataBind();
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "r');</script>");
            }
        }

        public bool validaUserComentarios(string user)
        {
            if (Session["user_cve"]!=null)
            {
                if (user==Session["user_cve"].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
        public string estiloBoton(string sw)
        {
            string estilo = "btn btn-default btn-sm";
            if (sw=="0")
            {
                estilo = "btn btn-danger btn-sm";
            }
            return estilo;
        }
        public string nombreDelUsuario(string user_cve)
        {
            return logica.nombreUsuario(user_cve);
        }

        public string code()
        {
            string codigo = "";
            string letras = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            for (int i = 1; i <= 11; i++)
            {
                int x = rnd.Next(0,35);
                codigo = codigo + letras.Substring(x, 1);
            }
            return codigo;
        }
    }
}