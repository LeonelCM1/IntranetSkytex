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
    public partial class Nuevo_Ingreso : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<WebAppIntranetConsultaNoticias_Result> Lista = logica.ConsultaNoticias(0, 0, 3);
                ListaNuevosIngresos.DataSource = Lista;
                ListaNuevosIngresos.DataBind();
                ListaEmpleados.DataSource = Lista;
                ListaEmpleados.DataValueField = "num_folio";
                ListaEmpleados.DataTextField = "titulo";
                ListaEmpleados.DataBind();
                ListaEmpleados.Items.Insert(0, new ListItem("< Selecciona un empleado >", "NA"));
                ListaEmpleadosEliminar.DataSource = Lista;
                ListaEmpleadosEliminar.DataValueField = "num_folio";
                ListaEmpleadosEliminar.DataTextField = "titulo";
                ListaEmpleadosEliminar.DataBind();
                ListaEmpleadosEliminar.Items.Insert(0, new ListItem("< Selecciona un empleado >", "NA"));
            }
        }
        public string miniatura(object url)
        {
            string nuevaurl = "";
            if (url != null && url != "")
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Media/" + url));
                System.Drawing.Image thumb = img.GetThumbnailImage(230, 160, null, IntPtr.Zero);
                img.Dispose();
                thumb.Save(Server.MapPath("~/Media/Mini/" + url));
                nuevaurl = "~/Media/Mini/" + url;
            }
            return nuevaurl;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text.Trim(' ') != "" && txtPuesto.Text.Trim(' ') != "" && txtArea.Text.Trim(' ') != "")
            {
                string fileName = "";
                if (Foto.HasFile)
                {
                    fileName = Path.GetFileName(Foto.PostedFile.FileName);
                    Foto.PostedFile.SaveAs(Server.MapPath("~/Media/") + fileName);
                }
                else
                {
                    fileName = null;
                }
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(0, txtNombre.Text, txtPuesto.Text, txtArea.Text, DateTime.Now, fileName, Session["user_cve"].ToString(),0,DateTime.Today, 1);//user
                if (resultado.error == 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Empleado Agregado Correctamente');window.location.href = window.location.href;</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: " + resultado.mensaje + "');window.location.href = window.location.href;</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');window.location.href = window.location.href;</script>");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string imagen = "";
            if (txtEditPuesto.Text.Trim(' ') != "" && txtEditArea.Text.Trim(' ') != "" && ListaEmpleados.SelectedValue != "NA")
            {
                if (FotoEdit.HasFile)
                {
                    imagen = Path.GetFileName(FotoEdit.PostedFile.FileName);
                    FotoEdit.PostedFile.SaveAs(Server.MapPath("~/Media/") + imagen);
                }
                string titulo = ListaEmpleados.SelectedItem.Text;
                int folio = Convert.ToInt32(ListaEmpleados.SelectedValue);
                string resumen = txtEditArea.Text;
                string noticia = txtEditPuesto.Text;
                try
                {
                    WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, titulo, noticia, resumen, DateTime.Today, imagen, Session["user_cve"].ToString(), 1, DateTime.Today, 2);
                    if (resultado.error == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Actualizado Correctamente');window.location.href = window.location.href;</script>");
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
                int folio = Convert.ToInt32(ListaEmpleadosEliminar.SelectedValue);
                WebAppIntranetAdmNoticia_Result resultado = logica.AdminNoticias(folio, "", "", "", DateTime.Today, "", Session["user_cve"].ToString(), 0, DateTime.Today, 3);
                if (resultado.error == 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Eliminado Correctamente');window.location.href = window.location.href;</script>");
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