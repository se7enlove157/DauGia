using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            return View();
        }

        public ActionResult ProductDetail()
        {
            return View();
        }
        // 5 sản phẩm có ra giá nhiều nhất
        public ActionResult PartialSanPhamRaGiaNhieu(int masp, int giasp, int theloaiId)
        {
            //using (DAMobileEntities ql = new DAMobileEntities())
          
        }
        // 5 sản phẩm có giá cao nhất
        public ActionResult PartialSanPhamRaGiaCaoNhat()
        {

        }
        // 5 sản phẩm có gần kết thúc
        public ActionResult PartialSanPhamGanKetThuc()
        {

        }
        // GET: /SanPham/
        [HttpGet]

        public ActionResult TatCaSanPham(int? id, int curPage = 1, int id_nsx = 0)
        {


        }
        //
        // GET: /SanPham/sanphamchitiet
        [HttpGet]
        public ActionResult SanPhamChiTiet(int? spid_x)
        {
        }
        public Action
        public ActionResult Sort(int sort)
        {
            return View();
        }
    }
}