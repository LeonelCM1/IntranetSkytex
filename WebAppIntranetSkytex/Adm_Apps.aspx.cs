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
    public partial class Adm_Apps : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["user_cve"] != null) && (Convert.ToInt16(Session["rol"]) == 1 || Convert.ToInt16(Session["rol"]) == 2))
            {
                if (!IsPostBack)
                {
                    llenaLista();

                }
            }
            else
            {
                Response.Redirect("Inicio.aspx");
            }
        }

        protected void ListaApps_TextChanged(object sender, EventArgs e)
        {
            if (ListaApps.SelectedValue!="new" && ListaApps.SelectedValue!= "NA")
            {
                DivForm.Visible = DivBotonesActualizar.Visible = true;
                DivBotonesGuardar.Visible = false;
                WebAppIntranetConsultaApps_Result aplicacion = logica.ConsultaApps(Convert.ToInt16(ListaApps.SelectedValue)).FirstOrDefault();
                lblFolio.Text = aplicacion.folio.ToString();
                txtNombre.Text = aplicacion.nombre;
                txtUrl.Text = aplicacion.url;
                ddlTipoDeApp.SelectedValue = aplicacion.restriccion.ToString();
            }
            else if (ListaApps.SelectedValue=="new")
            {
                DivForm.Visible = DivBotonesGuardar.Visible = true;
                DivBotonesActualizar.Visible = false;
                lblFolio.Text = ((Convert.ToInt16(logica.Intranet_Usuarios("", 8).FirstOrDefault().rol))+1).ToString();
                txtNombre.Text = "";
                txtUrl.Text = "";
                ddlTipoDeApp.SelectedValue = "2";
            }
            else
            {
                DivForm.Visible = DivBotonesGuardar.Visible = DivBotonesActualizar.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ListaApps.SelectedValue = "NA";
            DivForm.Visible = DivBotonesGuardar.Visible = DivBotonesActualizar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmUsuarios_Result resultado = logica.AdminUsuarios("001", Convert.ToInt16(lblFolio.Text), txtNombre.Text, Convert.ToInt16(ddlTipoDeApp.SelectedValue), 5);
                WebAppIntranetAdmUsuarios_Result resultado2 = logica.AdminUsuarios("002", Convert.ToInt16(lblFolio.Text), txtUrl.Text, 1, 5);
                if (resultado.error == 0 && resultado2.error == 0)
                {
                    llenaLista();
                    DivForm.Visible = DivBotonesGuardar.Visible = DivBotonesActualizar.Visible = false;
                    Response.Write("<script type=\"text/javascript\">alert('Aplicación Guardada');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: \n Nombre:" + resultado.mensaje + "\n URL:" + resultado2.mensaje + "');</script>");
                }

            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }
        private void llenaLista()
        {
            ListaApps.DataSource = logica.Intranet_Usuarios("", 7);
            ListaApps.DataValueField = "rol";
            ListaApps.DataTextField = "app";
            ListaApps.DataBind();
            ListaApps.Items.Insert(0, new ListItem("Seleccione una Opción", "NA"));
            ListaApps.Items.Insert(1, new ListItem("Nueva Aplicación", "new"));
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                WebAppIntranetAdmUsuarios_Result resultado = logica.AdminUsuarios("001", Convert.ToInt16(lblFolio.Text), txtNombre.Text, Convert.ToInt16(ddlTipoDeApp.SelectedValue), 6);
                WebAppIntranetAdmUsuarios_Result resultado2 = logica.AdminUsuarios("002", Convert.ToInt16(lblFolio.Text), txtUrl.Text, 1, 6);
                if (resultado.error == 0 && resultado2.error == 0)
                {
                    llenaLista();
                    DivForm.Visible = DivBotonesGuardar.Visible = DivBotonesActualizar.Visible = false;
                    Response.Write("<script type=\"text/javascript\">alert('Aplicación Actualizada');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: \n Nombre:" + resultado.mensaje + "\n URL:" + resultado2.mensaje + "');</script>");
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
                WebAppIntranetAdmUsuarios_Result resultado = logica.AdminUsuarios("001", Convert.ToInt16(lblFolio.Text), "", 0, 7);
                if (resultado.error == 0)
                {
                    llenaLista();
                    DivForm.Visible = DivBotonesGuardar.Visible = DivBotonesActualizar.Visible = false;
                    Response.Write("<script type=\"text/javascript\">alert('Aplicación Eliminada');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error:" + resultado.mensaje + "');</script>");
                }

            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }
    }
}