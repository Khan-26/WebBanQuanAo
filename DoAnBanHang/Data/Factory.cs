using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnBanHang.Models;

namespace DoAnBanHang.Data
{
   
    public interface ProductsFactory
    {

        List<SanPham> Ds_SanPham();
       
    }
}