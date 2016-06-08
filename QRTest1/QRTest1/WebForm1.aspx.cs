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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string source = Organisation.Text;
            string name = LastName.Text;

            EcodeDataInQR(source, name);
        }

        private void EcodeDataInQR(string source, string name)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();

            Bitmap img = encoder.Encode(source + '-' + name);

            //hash up data in some method

            img.Save("C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg", ImageFormat.Jpeg);

            QRImage.ImageUrl = "img.jpg";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Bitmap bm = Bitmap.FromFile("C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg") as Bitmap;

            QRCodeBitmapImage QRToDecode = new QRCodeBitmapImage(bm);

            ReadQRCode(QRToDecode);

        }

        private void ReadQRCode(QRCodeBitmapImage QRToDecode)
        {
            QRCodeDecoder decoder = new QRCodeDecoder();

            string DecodedDataFromQR = decoder.Decode(QRToDecode);

            Decoded.Text = DecodedDataFromQR;
        }
    }
}