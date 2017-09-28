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
                if (user.num_reng==1)
                {
                    Session["user_cve"] = usuario;
                    Session["rol"] = user.prm14;
                    Page.Response.Redirect(Page.Request.Url.ToString(), true);
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Usuario Bloqueado');</script>");
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
        public string encripta(string _data)
        {
            string _key24 = "123456789012345678901234";
            string _iv ="password";
            byte[] key = Encoding.ASCII.GetBytes(_key24);
            byte[] iv = Encoding.ASCII.GetBytes(_iv);
            byte[] data = Encoding.ASCII.GetBytes(_data);
            byte[] enc = new byte[0];
            TripleDES tdes = TripleDES.Create();

            tdes.Mode = CipherMode.CBC;
            tdes.Padding = PaddingMode.Zeros;
            tdes.IV = iv;
            tdes.Key = key;

            ICryptoTransform ict = tdes.CreateEncryptor();
            enc = ict.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(enc);
        }

        public List<WebAppIntranetConsultaUsuarios_Result> ListaDeApps()
        {
            List<WebAppIntranetConsultaUsuarios_Result> apps = new List<WebAppIntranetConsultaUsuarios_Result>();
            string usuario ="zzz";
            if (Session["user_cve"]!=null)
	        {
                usuario = Session["user_cve"].ToString();
            }
            apps = logica.Intranet_Usuarios(usuario, 2);
            return apps;
        }
    }
}