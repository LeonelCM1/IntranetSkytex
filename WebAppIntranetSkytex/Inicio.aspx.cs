using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using LogicaNegocio;
using System.Web.Services;
using System.Drawing;

namespace WebAppIntranetSkytex
{
    public partial class Inicio : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridNoticias.DataSource = logica.ConsultaNoticias(0,1,1);
            GridNoticias.DataBind();
            dtAnuncios.DataSource = logica.ConsultaAnuncios();
            dtAnuncios.DataBind();
            dlEventos.DataSource = logica.ConsultaEventos(DateTime.Today,0, 5,0);
            dlEventos.DataBind();
        }
        public string validaImagen(object url)
        {
            string disponible = "";
            if (url != null && url != "")
            {
                disponible="display:initial;";
            }
            else
            {
                disponible = "display:none;";
            }
            return disponible;
        }
        public string validaImagen2(object url)
        {
            string size = "";
            if (url != null && url != "")
            {
                size = "col-md-8";
            }
            else
            {
                size = "col-md-12";
            }
            return size;
        }
        public string miniatura(object url)
        {
            string nuevaurl = "";
            if (url!=null && url!="")
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/Media/"+url));
                System.Drawing.Image thumb = img.GetThumbnailImage(230, 160, null, IntPtr.Zero);
                img.Dispose();
                thumb.Save(Server.MapPath("~/Media/Mini/"+url));
                nuevaurl = "~/Media/Mini/" + url;
            }
            return nuevaurl;
        }
        public string DevuelveDiaMes(object fecha, int opc)
        {
            string DiaMes="";
            if (fecha!=null)
            {
                DateTime fec = Convert.ToDateTime(fecha);
                if (opc==1)
                {
                    DiaMes = fec.Day.ToString();
                }
                else
                {
                    DiaMes = String.Format("{0:MMMM}", fec);
                }
            }
            return DiaMes;
        }
        protected void btnAgregarAnuncio_Click(object sender, EventArgs e)
        {            
            string titulo = txtNuevoTitulo.Text;
            string texto = txtNuevoTexto.Text.Replace(Environment.NewLine,"<br/>");
            DateTime fecha = DateTime.Today;
            DateTime fecha_fin = Convert.ToDateTime(txtNuevaFechaFin.Text);
            DateTime fecha_ini = Convert.ToDateTime(txtNuevaFechaInicio.Text);
            if (validarFechas(fecha_ini,fecha_fin))
            {
                if (txtNuevoTitulo.Text.Trim(' ') != "" && txtNuevoTexto.Text.Trim(' ') != "")
                {
                    WebAppIntranetAdmEventos_Result resultado = logica.AdminAnuncios(1, titulo, texto, fecha, Session["user_cve"].ToString(), fecha_ini, fecha_fin, 1, 1);
                    if (resultado.error == 0)
                    {
                        txtNuevoTitulo.Text = txtNuevoTexto.Text = txtNuevaFechaFin.Text = "";
                        Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Verificar las fechas ingresadas');</script>");
            }
        }

        protected void Calendario_DayRender(object sender, DayRenderEventArgs e)
        {
            List<WebAppIntranetConsultaEventos_Result> eventos = logica.ConsultaEventos(DateTime.Today,0, 2,0);
            foreach (var item in eventos)
            {
                if (e.Day.Date.CompareTo(item.fecha_ini.Date)>= 0 && e.Day.Date.CompareTo(item.fecha_fin.Date)<=0)
                {
                    if (!e.Day.Date.Equals(Calendario.SelectedDate))
                    {
                        if (e.Day.IsOtherMonth)
                        {
                            e.Cell.BackColor = Color.DarkSeaGreen;
                        }
                        else
                        {
                            e.Cell.BackColor = Color.DarkGreen;
                            e.Cell.ForeColor = Color.White;
                        }
                    }
                }
            }
        }

        protected void Calendario_SelectionChanged(object sender, EventArgs e)
        {
            if (Calendario.SelectedDate.Month!=Calendario.VisibleDate.Month)
            {
                Calendario.VisibleDate = Calendario.SelectedDate;          
            }
            List<WebAppIntranetConsultaEventos_Result> eventos = logica.ConsultaEventos(Calendario.SelectedDate,0, 3,0);
            if (eventos.Count == 1)
            {
                lblTituloEvento.Text = eventos.FirstOrDefault().titulo;
                lblFechaInicio.Text = eventos.FirstOrDefault().fecha_ini.Date.ToString("dd/MMMM/yyyy");
                lblFechaFin.Text = eventos.FirstOrDefault().fecha_fin.Date.ToString("dd/MMMM/yyyy");
                lblTextoEvento.Text = eventos.FirstOrDefault().texto;
                lblNumFolEvento.Text = eventos.FirstOrDefault().num_fol.ToString();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MuestraEvento();", true);
                Calendario.SelectedDates.Remove(Calendario.SelectedDate);
            }
            else if (eventos.Count>1)
            {
                lblSeleccionaEventoDia.Text = Calendario.SelectedDate.Date.ToString("D");
                ListaEventos.DataSource = eventos;
                ListaEventos.DataBind();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "SeleccionaEvento();", true);
                Calendario.SelectedDates.Remove(Calendario.SelectedDate);
            }
            else
            {
                if (Session["user_cve"]!=null)
                {
                    Calendario.SelectedDates.Remove(Calendario.SelectedDate);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MuestraNuevoEvento();", true);
                }
                else
                {
                    Calendario.SelectedDates.Remove(Calendario.SelectedDate);
                    Response.Write("<script type=\"text/javascript\">alert('No hay eventos para el dia seleccionado');window.location.href = 'Inicio.aspx';</script>");
                }
                
            }
        }

        protected void btnEventos_Click(object sender, EventArgs e)
        {
            Button lnk = sender as Button;
            string folio = lnk.Attributes["CustomParameter"].ToString();
            WebAppIntranetConsultaEventos_Result evento = logica.ConsultaEventos(DateTime.Today.Date, Convert.ToInt32(folio), 4, 0).FirstOrDefault();
            lblTituloEvento.Text = evento.titulo;
            lblFechaInicio.Text = evento.fecha_ini.Date.ToString("dd/MMMM/yyyy");
            lblFechaFin.Text = evento.fecha_fin.Date.ToString("dd/MMMM/yyyy");
            lblTextoEvento.Text = evento.texto;
            lblNumFolEvento.Text = folio;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "MuestraEvento();", true);
        }

        protected void btnEditarEvento_Click(object sender, EventArgs e)
        {
            Response.Redirect("Editar_Evento.aspx?fol=" + lblNumFolEvento.Text);
        }

        protected void btnNuevoEvento_Click(object sender, EventArgs e)
        {
            try
            {
                string titulo = txtNuevoTituloEvento.Text;
                string texto = txtNuevoTextoEvento.Text;
                DateTime fecha_ini = Convert.ToDateTime(txtNuevaFechaIniEvento.Text);
                DateTime fecha_fin = Convert.ToDateTime(txtNuevaFechaFinEvento.Text);
                if (validarFechas(fecha_ini, fecha_fin))
                {
                    if (txtNuevoTituloEvento.Text.Trim(' ') != "" && txtNuevoTextoEvento.Text.Trim(' ') != "")
                    {
                        WebAppIntranetAdmEventos_Result resultado = logica.AdminAnuncios(0, titulo, texto, DateTime.Today.Date, Session["user_cve"].ToString(), fecha_ini, fecha_fin, 0, 1);
                        if (resultado.error == 0)
                        {
                            txtNuevoTituloEvento.Text = txtNuevoTextoEvento.Text = txtNuevaFechaFinEvento.Text = txtNuevaFechaIniEvento.Text = "";
                            Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');window.location.href = 'Inicio.aspx';</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Verificar las fechas ingresadas');</script>");
                }
            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');window.location.href = 'Inicio.aspx';</script>");
            }
        }

        protected void GridNoticias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridNoticias.PageIndex = e.NewPageIndex;
            GridNoticias.DataBind();
        }
        public bool validarFechas(DateTime fec_ini, DateTime fecha_fin)
        {
            bool valida = false;
            int a = DateTime.Compare(fec_ini, fecha_fin);//fecha inicial debe ser menor a la fecha final
            int b = DateTime.Compare(DateTime.Now.Date, fec_ini);//fecha inicial debe ser mayor a la fecha actual
            if (a < 0 && b <= 0)
            {
                valida = true;
            }
            else
            {
                valida = false;
            }
            return valida;
        }

        protected void Calendario_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            dlEventos.DataSource = null;
            dlEventos.DataSource = logica.ConsultaEventos(e.NewDate, 0, 5, 0);
            dlEventos.DataBind();
        }
    }
}