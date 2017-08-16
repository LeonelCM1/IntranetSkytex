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
    public partial class Noticias : System.Web.UI.MasterPage
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnIniciarSesion.UniqueID;
            if (!IsPostBack)
            {
                ddlUsuarios.DataSource = logica.Usuarios();
                ddlUsuarios.DataValueField = "user_cve";
                ddlUsuarios.DataTextField = "nombre";
                ddlUsuarios.DataBind();
            }
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = logica.Login(ddlUsuarios.SelectedValue.ToString(), txtPassword.Text);
            WebAppIntranetConsultaUsuarios_Result user = logica.Intranet_Usuarios(usuario, 1).FirstOrDefault();
            if (usuario!=null)
            {
                if (user!=null)
                {
                    if (user.sw_activo==1)
                    {
                        Session["user_cve"] = usuario;
                        Session["rol"] = user.rol;
                        Page.Response.Redirect(Page.Request.Url.ToString(), true);
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Usuario Bloqueado');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error al iniciar sesión');</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Datos incorrectos');</script>");
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Inicio.aspx");
        }

    }
}