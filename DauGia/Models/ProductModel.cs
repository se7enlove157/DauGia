using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace DauGia.Models
{
    public class ProductModel
    {
        public int Masp { get; set; }
        public string TenSanPham { get; set; }
        public string Hinh1 { get; set; }
        public string Hinh2 { get; set; }
        public string Hinh3 { get; set; }
        public int MaTL { get; set; }
        public double Gia { get; set; }
        public int MaNguoiDung { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public double BuocGia { get; set; }
        public double GiaMuaNgay { get; set; }
    }
}