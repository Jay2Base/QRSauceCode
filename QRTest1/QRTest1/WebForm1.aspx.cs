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

        protected void Button3_Click(object sender, EventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();




            application.Visible = true;


            List<formInputs> formInputsList = new List<formInputs>
{
    new formInputs {Org="HSBC", Name="Jay",Code="C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg"},
    new formInputs {Org="SANT", Name="Sakis",Code="C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg"},
    new formInputs {Org="BARC", Name="Kev",Code="C:\\SAUCE\\QRTest1\\QRTest1\\img.jpg"}
};

            formInputsList.ForEach(x => NewMethod(application, x));


        }

        private  void NewMethod(Microsoft.Office.Interop.Word.Application application, formInputs input)
        {

            EcodeDataInQR(input.Org, input.Name);

            var document = new Microsoft.Office.Interop.Word.Document();
            document = application.Documents.Add(Template: @"c:\sauce\sauce.docx");
            foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
            {
                if (field.Code.Text.Contains("Organisation"))
                {
                    field.Select();
                    application.Selection.TypeText(input.Org);
                }
                else if (field.Code.Text.Contains("Name"))
                {
                    field.Select();
                    application.Selection.TypeText(input.Name);
                }
                else if (field.Code.Text.Contains("SauceCode"))
                {
                    field.Select();
                    application.Selection.InlineShapes.AddPicture(input.Code);
                }
            }
        }
    }

    public class formInputs
    {
        public string Org { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

}