using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using Entidades;
using LogicaNegocio;

namespace WebAppIntranetSkytex
{
    public partial class Cumpleañeros : System.Web.UI.Page
    {
        LogicaNegocioCLS logica = new LogicaNegocioCLS();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = logica.cumpleanios(DateTime.Today.Date, 1);
            DataList1.DataBind();
            DataList2.DataSource = logica.cumpleanios(DateTime.Today.Date, 0);
            DataList2.DataBind();
        }
        public string RutaImagen(string Nombre, string num,int tipo)
        {
            string url = "";
            //Load the Image to be written on.
            Bitmap bitMapImage = new
               System.Drawing.Bitmap(Server.MapPath("~/Media/Liston.png"));
            Graphics graphicImage = Graphics.FromImage(bitMapImage);
            //Smooth graphics is nice.
            graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
            //Write your text.
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            Rectangle rect1 = new Rectangle(80, 0, 395, 110);
            graphicImage.DrawString(Nombre,
               new Font("Arial", 24, FontStyle.Bold),
               SystemBrushes.WindowText, rect1, sf);
            if (tipo==1)
            {
                //Save the new image to the response output stream.
                bitMapImage.Save(Server.MapPath("~/Media/Cumpleanios" + num + "X.png"), ImageFormat.Png);
                url = "~/Media/Cumpleanios" + num + "X.png";
            }
            else
            {
                //Save the new image to the response output stream.
                bitMapImage.Save(Server.MapPath("~/Media/Cumpleanios" + num + ".png"), ImageFormat.Png);
                url = "~/Media/Cumpleanios" + num + ".png";
            }
            //Clean house.
            graphicImage.Dispose();
            bitMapImage.Dispose();
            return url;
        }
        public string fecha_cumple(object fec)
        {
            DateTime fech = Convert.ToDateTime(fec);
            string fecha = fech.ToString("d MMMM");
            return fecha;
        }
    }
}