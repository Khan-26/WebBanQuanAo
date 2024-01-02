//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using DoAnBanHang.Models;


//namespace DoAnBanHang.Models
//{
//    public sealed class DanhMucSingleton
//    {
//        public static DanhMucSingleton Instance { get; } = new DanhMucSingleton();

//        public List<Loai_SP> list_LoaiSP { get; } = new List<Loai_SP>();
//        private DanhMucSingleton() { }

//        //Only one time
//        //Chỉ 1 lần
//        public void Init(AppDbContext context)
//        {
//            // kiểm tra xem listcate có khởi tạo bao giờ chưa

//            if (listCatgegory.Count == 0)
//            {
//                var categories = context.Categories
//                    .Include(c => c.CategoryChildren) //<- Nạp các category con
//                    .AsEnumerable()
//                    .Where(c => c.ParentCategory == null)
//                    .ToList();

//                // đẩy hết item vào trong cái list
//                foreach (var item in categories)
//                {
//                    listCatgegory.Add(item);
//                }
//            }
//        }

//        public void Update(AppDbContext context)
//        {
//            listCatgegory.Clear();
//            Init(context);
//        }
//    }
//}