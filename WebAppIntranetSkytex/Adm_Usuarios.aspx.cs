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
    public partial class Adm_Usuarios : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user_cve"] != null) && (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2))
            {
                if (!IsPostBack)
                {
                    ddlUsuarios.DataSource = logica.Usuarios();
                    ddlUsuarios.DataValueField = "user_cve";
                    ddlUsuarios.DataTextField = "nombre";
                    ddlUsuarios.DataBind();
                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            divBody.Visible = true;
            btnActualizar.Enabled = true;
            lblUsuario.Text = ddlUsuarios.SelectedValue;
            lblNombre.Text = ddlUsuarios.SelectedItem.Text;
            ListaApps.DataSource = null;
            ListaApps.DataSource = logica.Intranet_Usuarios("001", 2);
            ListaApps.DataValueField = "rol";
            ListaApps.DataTextField = "app";
            ListaApps.DataBind();
            ListaRoles.Visible = true;
            List<WebAppIntranetConsultaUsuarios_Result> usuario = logica.Intranet_Usuarios(ddlUsuarios.SelectedValue,1);
            if (usuario.Count==0)
            {
                ListaRoles.ClearSelection();
                ListaRoles.Items[0].Selected = true;
                btnBloquear.CssClass = "btn btn-warning";
                lblBloqueo.Text = "Bloquear Usuario";
            }
            else
            {
                if (usuario.FirstOrDefault().sw_activo!=1)
                {
                    btnBloquear.CssClass = "btn btn-danger";
                    lblBloqueo.Text = "Usuario Bloqueado";
                }
                else
                {
                    btnBloquear.CssClass = "btn btn-warning";
                    lblBloqueo.Text = "Bloquear Usuario";
                }
                ListaRoles.ClearSelection();
                ListaRoles.Items[Convert.ToInt32(usuario.FirstOrDefault().rol)].Selected = true;
                List<WebAppIntranetConsultaUsuarios_Result> appsUser = logica.Intranet_Usuarios(ddlUsuarios.SelectedValue,3);
                foreach (var item in appsUser)
                {
                    if (ListaApps.Items.FindByValue(item.rol.ToString())!=null)
                    {
                        int i = Convert.ToInt32(ListaApps.Items.IndexOf(ListaApps.Items.FindByValue(item.rol.ToString())));
                        ListaApps.Items[i].Selected = true;
                    }
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            short rol = Convert.ToInt16(ListaRoles.SelectedValue);
            int error = 0;
            WebAppIntranetAdmUsuarios_Result AdminRol = logica.AdminUsuarios(lblUsuario.Text, rol, "Intranet", 1, 1);
            if (AdminRol.error==1)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + AdminRol.mensaje + "');</script>");
                error = 1;
            }
            foreach (ListItem item in ListaApps.Items)
            {
                if (item.Selected)
                {
                    WebAppIntranetAdmUsuarios_Result AgregaApp = logica.AdminUsuarios(lblUsuario.Text, rol, item.Value, 1, 2);
                    if (AgregaApp.error == 1)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('" + AgregaApp.mensaje + "');</script>");
                        error = 1;
                    }
                }
                else
                {
                    WebAppIntranetAdmUsuarios_Result QuitaApp = logica.AdminUsuarios(lblUsuario.Text, rol, item.Value, 1, 3);
                    if (QuitaApp.error == 1)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('" + QuitaApp.mensaje + "');</script>");
                        error = 1;
                    }
                }
            }
            if (error==0)
            {
                Response.Write("<script type=\"text/javascript\">alert('Actualizado');</script>");
            }
        }

        protected void btnBloquear_Click(object sender, EventArgs e)
        {
            short rol = Convert.ToInt16(ListaRoles.SelectedValue);
            short bloqueo = 0;
            if (lblBloqueo.Text=="Usuario Bloqueado")
            {
                bloqueo = 1;
            }
            WebAppIntranetAdmUsuarios_Result bloquear = logica.AdminUsuarios(lblUsuario.Text, rol, "Intranet", bloqueo, 4);
            if (bloquear.error==0)
            {
                if (bloqueo==0)
                {
                   btnBloquear.CssClass = "btn btn-danger";
                    lblBloqueo.Text = "Usuario Bloqueado";
                    Response.Write("<script type=\"text/javascript\">alert('Bloqueado');</script>");
                }
                else
                {
                    btnBloquear.CssClass = "btn btn-warning";
                    lblBloqueo.Text = "Bloquear Usuario";
                    Response.Write("<script type=\"text/javascript\">alert('Desbloqueado');</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('" + bloquear.mensaje + "');</script>");
            }
        }
    }
}