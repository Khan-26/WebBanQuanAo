using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnBanHang.Models;

namespace DoAnBanHang.Data
{
   
        public interface IIterator
        {
            SanPham First();
            SanPham Next();
            bool IsDone { get; }
            SanPham CurrentItem { get; }
        }
        public class SanPhamIIterator : IIterator
        {
            public List<SanPham> _listSanPham { get; } = new List<SanPham>();
            int current = 0;
            int step = 1;
            public SanPhamIIterator(List<SanPham> listSanPham)
            {
                _listSanPham = listSanPham;
            }
            public bool IsDone
            {
                get { return current >= _listSanPham.Count; }
            }
            public SanPham CurrentItem => _listSanPham[current];
            public SanPham First()
            {
                current = 0;
                return _listSanPham[current];
            }
            public SanPham Next()
            {
                current += step;
                if (!IsDone)
                    return _listSanPham[current];
                else
                    return null;
            }
        }

    
}