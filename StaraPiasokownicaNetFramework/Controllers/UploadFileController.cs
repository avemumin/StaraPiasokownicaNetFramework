using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using StaraPiasokownicaNetFramework.Models;

namespace StaraPiasokownicaNetFramework.Controllers
{
    public class UploadFileController : Controller
    {
        List<tblImages> list = new List<tblImages>();
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        private string compareEquals;
        private bool IsValidCVontentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("application/pdf") ||
                   contentType.Equals("image/jpg") || contentType.Equals("image/jpeg");
        }

        private int FilesType(string contentType)
        {
            if (contentType.Equals("image/png"))
            {
                return 1;
            }
            else if (contentType.Equals("application/pdf"))
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
        private bool isValidContentLength(int contentLength)
        {
            return ((contentLength / 1024) / 1024) < 10;
        }


        [HttpPost]
        public ActionResult Process(HttpPostedFileBase photo)
        {
            if (photo == null)
            {
                ViewBag.Error = "Nie wybrano pliku";
                return View("Index");
            }

            if (!IsValidCVontentType(photo.ContentType))
            {
                ViewBag.Error = "Dostępne formaty to [PNG] [JPG] [PDF]";
                return View("Index");
            }
            else if (!isValidContentLength(photo.ContentLength))
            {
                ViewBag.Error = "Za duzy plik";
                return View("Index");
            }
            else
            {
                if (photo.ContentLength > 0)
                {
                    DbDataContext cos = new DbDataContext();
                    StringBuilder sb = new StringBuilder();

                    byte[] bytes;
                    var fileName = Path.GetFileName(photo.FileName);
                    // var path = Path.Combine(Server.MapPath())
                    ViewBag.TypeOfFile = FilesType(photo.ContentType);
                    ViewBag.fileName = photo.FileName;

                    

                    using (BinaryReader br = new BinaryReader(photo.InputStream))
                    {
                        bytes = br.ReadBytes(photo.ContentLength);
                    }

                    var item = new tblImages
                    {
                        Id = 1,
                        ImageDate = bytes,
                        Size = 5,
                        Name = fileName,
                    };
                    list.Add(new tblImages()
                        {Id = item.Id, ImageDate = item.ImageDate, Size = item.Size, Name = item.Name});
                    //string base64 = Convert.ToBase64String(bytes);
                    cos.Files.Add(new tblImages
                    {
                        Id = 4,
                        Name = fileName,
                        Size = 6,
                        ImageDate = bytes
                    });
                    
                    cos.SaveChanges();
                  
                    //  @ViewBag.picture = (bytes);

                }

                return View("Success");
            }
            //

        }
    }
}