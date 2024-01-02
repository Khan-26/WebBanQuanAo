using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnBanHang.Models;

namespace DoAnBanHang.Data
{
   
    public sealed class Singleton
    {
        DB_BanHang1Entities db = new DB_BanHang1Entities();
        public static Singleton Instance { get; } = new Singleton();

        public Singleton() { }

        public void SuaThongTin (SanPham sanPham)
        {
            var check = db.SanPham.Find(sanPham.ID_SP);
            check.GioiTinh = sanPham.GioiTinh;
            check.ID_Loai = sanPham.ID_Loai;
            check.NgayNhapHang = sanPham.NgayNhapHang;
            check.TonKho = sanPham.TonKho;
            check.TenSP = sanPham.TenSP;
            check.DonGia = sanPham.DonGia;
            if (sanPham.Image.Contains("~/Image/"))
            {
                check.Image = sanPham.Image;
            }
            else
                check.Image = "~/Image/" + sanPham.Image;
            //db.Entry(sanPham).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}