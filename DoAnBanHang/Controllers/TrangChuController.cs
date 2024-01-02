using DoAnBanHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnBanHang.Data;
using System.Data.Entity;


namespace DoAnBanHang.Controllers
{
    public class TrangChuController : Controller
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        // GET: TrangChu
        public ActionResult TrangChu( )
        {

            //List<SanPham> sanpham_Ton = new List<SanPham>();
            //var sanPhams = (db.SanPham.Include(s => s.Loai_SP)).ToList();
            //IIterator iterator = new SanPhamIIterator(sanPhams);
            //var sanPham = iterator.First();
            //while (!iterator.IsDone)
            //{
            //    if (sanPham.TonKho != 0)
            //    {
            //        sanpham_Ton.Add(sanPham);
            //        sanPham = iterator.Next();
            //    }

            //}
            //return View(sanpham_Ton);

            //return View(db.SanPham.ToList().Where(s => s.TonKho != 0));
            return View(db.SanPham.ToList()); 
        }
        public ActionResult Search(string search)
        {
            return View(db.SanPham.Where(s => s.TenSP.Contains(search)));
        }
      
    }
}