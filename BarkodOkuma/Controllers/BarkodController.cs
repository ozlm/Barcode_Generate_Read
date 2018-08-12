using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using Bytescout.BarCodeReader;
using BarkodOkuma.Models;
using Aspose.BarCode;
using Aspose.BarCode.BarCodeRecognition;


namespace BarkodOkuma.Controllers
{
    public class BarkodController : Controller
    {
        //
        // GET: /Barkod/

    


        public ActionResult Barkod(string barcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                //The Image is drawn based on length of Barcode text.
                using (Bitmap bitMap = new Bitmap(barcode.Length * 40, 80))
                {
                    //The Graphics library object is generated for the Image.
                    using (Graphics graphics = Graphics.FromImage(bitMap))
                    {
                        //The installed Barcode font.
                        Font oFont = new Font("IDAutomationHC39M", 16);
                        PointF point = new PointF(2f, 2f);

                        //White Brush is used to fill the Image with white color.
                        SolidBrush whiteBrush = new SolidBrush(Color.White);
                        graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

                        //Black Brush is used to draw the Barcode over the Image.
                        SolidBrush blackBrush = new SolidBrush(Color.Black);
                        graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
                    }

                    //The Bitmap is saved to Memory Stream.
                    bitMap.Save(ms, ImageFormat.Png);

                    //The Image is finally converted to Base64 string.
                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }


        public ActionResult Scan(HttpPostedFileBase file)
        {
            Inheritance inh = new Inheritance();
            string barcode = "";
            try
            {
                string path = "";
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
                    file.SaveAs(path);
                }

                // Now we try to read the barcode
                // Instantiate BarCodeReader object
                
                BarCodeReader reader = new BarCodeReader(path, DecodeType.Code39Standard);
                System.Drawing.Image img = System.Drawing.Image.FromFile(path);
                System.Diagnostics.Debug.WriteLine("Width:" + img.Width + " - Height:" + img.Height);

                try
                {
                    // read Code39 bar code
                    while (reader.Read())
                    {

                        // detect bar code orientation
                        ViewBag.Title = reader.GetCodeText();
                        barcode = reader.GetCodeText();
                    }
                    reader.Close();
                }

                catch (Exception exp)
                {

                    System.Console.Write(exp.Message);
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.Title = ex.Message;
            }





            //inh.db.findStock(barcode);

         var result=   inh.db.find(barcode).ToList();


         return View(result);
            





        }
    }
}
