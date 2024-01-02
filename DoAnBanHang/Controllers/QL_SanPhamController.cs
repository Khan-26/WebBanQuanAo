using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Models;
using System.Data.Entity;
using System.IO;
using System.Net;
using DoAnBanHang.Controllers;
using Microsoft.Extensions.Logging;
using DoAnBanHang.Data;

namespace DoAnBanHang.Controllers
{
       
    public class QL_SanPhamController : ControllerTemplateMethod
    {
        Singleton s = new Singleton();
        private readonly ILogger<QL_SanPhamController> _logger;
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        public QL_SanPhamController(ILogger<QL_SanPhamController> logger)
        {
            _logger = logger;
        }
        public QL_SanPhamController()
        {

        }
        // GET: QL_SanPham
        public ActionResult Index()
        {
            //_logger.LogInformation("The Index Action was invoked");
            return View(db.SanPham.ToList());

        }
        public ActionResult Add()
        {
            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai");
            ViewBag.Kichco = db.KichCoes.ToList();
            
            return View();
        }
        [HttpPost]
        public ActionResult Add(SanPham sanPham,HttpPostedFileBase fileImage)
        {
            
            if (ModelState.IsValid)
            {
                
                if(fileImage != null || fileImage.ContentLength > 0) 
                {
                    string _FileName = Path.GetFileName(fileImage.FileName);
                    string path = Path.Combine(Server.MapPath("~/Image/"), _FileName);
                    fileImage.SaveAs(path);
                    sanPham.Image = "~/Image/"+_FileName;
                    sanPham.NgayNhapHang = DateTime.Now;
                    db.SanPham.Add(sanPham);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Add");
            }

            ViewBag.ID_Loai = new SelectList(db.Loai_SP, "ID_Loai", "TenLoai", sanPham.ID_Loai);
            
            return View(sanPham);
        }
        public ActionResult Details(int id)
        {
            return View(db.SanPham.Where(s => s.ID_SP == id).FirstOrDefault());
        }
        public ActionResult Edit(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }
        //[HttpPost]
        //public ActionResult Edit(SanPham sanPham)
        //{

        //        db.Entry(sanPham).State = EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");


        //}
        [HttpPost]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                //if (fileImage == null)
                //{
                s.SuaThongTin(sanPham);
                //}
                //else if (fileImage != null || fileImage.ContentLength > 0)
                //{
                //    string _FileName = Path.GetFileName(fileImage.FileName);
                //    string path = Path.Combine(Server.MapPath("~/Image/"), _FileName);
                //    if (System.IO.File.Exists(path))
                //    {
                //        fileImage.SaveAs(path);
                //    }
                //    else
                //    {
                //        fileImage.SaveAs(path);
                //    }
                //    sanPham.Image = "~/Image/" + _FileName;
                //    db.Entry(sanPham).State = EntityState.Modified;
                //    db.SaveChanges();
                //}
               
                return RedirectToAction("Index");

            }
            return View(sanPham);
        }

        // GET: test/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void PrintRoute()
        {
            _logger.LogInformation("Test--------------","");
        }

        protected override void PrintDIs()
        {
            _logger.LogDebug("======DIs=======");
        }
    }
}