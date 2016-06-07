using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace QRTest1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();

            Bitmap img = encoder.Encode("HashHashHash");

            img.Save("C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg", ImageFormat.Jpeg);

            QRImage.ImageUrl = "img.jpg";



        }
    }
}