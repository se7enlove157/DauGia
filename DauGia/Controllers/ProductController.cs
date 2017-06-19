using DauGia.Data;
using System.Linq;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [HttpGet]
        public ActionResult Index(int? id, int curPage = 1, int id_nsx = 0)
        {
            if (curPage < 1)
            {
                curPage = 1;
            }
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.SanPham;
                int n = query.Count();
                int nPages = n / 12;

                if (n % 12 > 0)
                {
                    nPages++;
                    ViewBag.NextCuoi = n / 12 + 1;
                }
                ViewBag.Pages = nPages;
                ViewBag.curPage = curPage;
                // neu trang = 1 thi k cho
                if (curPage < 1)
                {
                    ViewBag.PrevPage = 1;
                }
                else
                {
                    ViewBag.PrevPage = curPage - 1;
                }
                ViewBag.NextPage = curPage + 1;
                int nSkip = (curPage - 1) * 12;
                var list = query
                    .OrderBy(p => p.MaSanPham)
                    .Skip(nSkip).Take(12)
                    .ToList();
                return View(list);
                if (list.Count < 1)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        [HttpGet]
        public ActionResult ProductDetail(int? spid_x)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                SanPham sp = ql.SanPham.Where(x => x.MaSanPham == spid_x).FirstOrDefault();
                return View(sp);
            }
        }

        public ActionResult FromCreate()
        {
            return View();
        }

        //// 5 sản phẩm có ra giá nhiều nhất
        //public ActionResult PartialSanPhamRaGiaNhieu(int masp, int giasp, int theloaiId)
        //{
        //    //using (DAMobileEntities ql = new DAMobileEntities())

        //}
        //// 5 sản phẩm có giá cao nhất
        //public ActionResult PartialSanPhamRaGiaCaoNhat()
        //{
        //}
        //// 5 sản phẩm có gần kết thúc
        //public ActionResult PartialSanPhamGanKetThuc()
        //{
        //}
        //// GET: /SanPham/
        //[HttpGet]

        //public ActionResult TatCaSanPham(int? id, int curPage = 1, int id_nsx = 0)
        //{
        //}
        ////
        //// GET: /SanPham/sanphamchitiet
        //[HttpGet]
        //public ActionResult SanPhamChiTiet(int? spid_x)
        //{
        //}
        //public Action
        //public ActionResult Sort(int sort)
        //{
        //    return View();
        //}
    }
}