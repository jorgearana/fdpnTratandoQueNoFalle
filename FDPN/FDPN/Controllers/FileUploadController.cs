using FDPN.Helpers;
using FDPN.Views.Administrador;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace jQuery_File_Upload.MVC5.Controllers
{
    public class FileUploadController : Controller
    {
        FilesHelper filesHelper;
        String tempPath = "~/Content/img/Fotos/";
        String serverMapPath = "~/Content/img/Fotos/";
        private string StorageRoot
        {
            get { return Path.Combine(HostingEnvironment.MapPath(serverMapPath)); }
        }
        private string UrlBase = "/img/Fotos/";
        String DeleteURL = "/Administrador/DeleteFile/?file=";
        String DeleteType = "GET";
        public FileUploadController()
        {
           filesHelper = new FilesHelper(DeleteURL, DeleteType, StorageRoot, UrlBase, tempPath, serverMapPath);
        }
      
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show()
        {
            JsonFiles ListOfFiles = filesHelper.GetFileList();
            var model = new FilesViewModel()
            {
                Files = ListOfFiles.files
            };
          
            return View(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upload()
        {
            var resultList = new List<ViewDataUploadFilesResult>();
           
            var CurrentContext = HttpContext;

            filesHelper.UploadAndShowResults(CurrentContext, resultList);
            JsonFiles files = new JsonFiles(resultList);
            List<string> nombrefotos = Session["Fotos"] as List<string> ?? new List<string>();

            //foreach (var file in files.files)
            //{
            //    nombrefotos.Add(file.name);
            //}
            Session["Fotos"] = nombrefotos;
            bool isEmpty = !resultList.Any();
            if (isEmpty)
            {
                return Json("Error ");
            }
            else
            {
                return Json(files);
            }
        }
        public JsonResult GetFileList()
        {
            var list=filesHelper.GetFileList();
            return Json(list,JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult DeleteFile(string file)
        {
            List<string> nombrefotos = Session["Fotos"] as List<string>;
            nombrefotos.Remove(file);
            filesHelper.DeleteFile(file);
            Session["Fotos"] = nombrefotos;
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
       
    }
}