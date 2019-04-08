using FDPN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FDPN.Controllers
{
    public class BannersController : BASEController
    {

        // GET: Banners
        public ActionResult Index()
        {
            List<Banners> banners = db.Banners.ToList();
            return View(banners);
        }

        // GET: Banners/Details/5
        public ActionResult Details(int id)
        {
            Banners banner = db.Banners.Find(id);
            return View();
        }

        // GET: Banners/Create
        public ActionResult Create()
        {
            Banners banner = new Banners();
            ViewBag.titulo = "Crear banner";
            List<string> nombrefotos = new List<string>();
            Session["fotos"] = nombrefotos;
            return View(banner);

        }

        // POST: Banners/Create
        [HttpPost]
        public ActionResult Create(Banners banner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> nombrefotos = Session["Fotos"] as List<string> ?? new List<string>();
                    banner.Foto = nombrefotos[0];

                    db.Banners.Add(banner);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                ViewBag.titulo = "Crear banner";
                return View(banner);
            }
            catch (Exception ex)
            {
                ViewBag.titulo = "Crear banner";
                return View("_ParcialCrearEditar", banner);
            }
        }

        // GET: Banners/Edit/5
        public ActionResult Edit(int id)
        {
            Banners banner = db.Banners.Find(id);
            ViewBag.titulo = "Editar banner";
            return View(banner);
        }

        // POST: Banners/Edit/5
        [HttpPost]
        public ActionResult Edit(Banners banner)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    //string nombrefotos = Session["Fotos"] as string ?? "";
                    Banners BannerAActualizaar = db.Banners.Find(banner.BannerId);
                    string fullPath = Request.MapPath("~/Content/img/Fotos/" + BannerAActualizaar.Foto);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }

                    List<string> nombrefotos = Session["Fotos"] as List<string> ?? new List<string>();
                    BannerAActualizaar.Foto = nombrefotos[nombrefotos.Count()-1];

                    UpdateModel(BannerAActualizaar);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.titulo = "Editar banner";
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                string err = ex.InnerException.ToString();
                ViewBag.titulo = "Editar banner";
                return View(banner);
            }
        }

        // GET: Banners/Delete/5
        public ActionResult Delete(int id)
        {
            Banners banner = db.Banners.Find(id);
            return View(banner);
        }

        // POST: Banners/Delete/5
        [HttpPost]
        public ActionResult Delete(Banners banner)
        {
            try
            {
                banner = db.Banners.Find(banner.BannerId);
                db.Banners.Remove(banner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(banner);
            }
        }

    }
}