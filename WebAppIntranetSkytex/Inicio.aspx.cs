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
    public partial class Inicio : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        SelectedDatesCollection dates;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridNoticias.DataSource = logica.ConsultaNoticias();
            GridNoticias.DataBind();
            dtAnuncios.DataSource = logica.ConsultaAnuncios();
            dtAnuncios.DataBind();
            dates = Calendario.SelectedDates;
            MuestraEventos();
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
        public void MuestraEventos()
        {
            List<sp_WebAppIntranetConsultaEventos_Result> eventos = logica.ConsultaEventos(DateTime.Today,2);
            foreach (var item in eventos)
            {
                for (int i = item.fecha_ini.Day; i <=item.fecha_fin.Day; i++)
                {
                    dates.Add(Convert.ToDateTime(i + "/" + DateTime.Today.Month + "/2017"));
                }
            }
            dlEventos.DataSource = logica.ConsultaEventos(DateTime.Today, 1);
            dlEventos.DataBind();
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
    }
}