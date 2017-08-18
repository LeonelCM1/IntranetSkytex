using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Text;
using System.Security.Cryptography;
using System.IO;

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
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}