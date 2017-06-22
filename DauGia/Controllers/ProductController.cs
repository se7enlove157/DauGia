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
        public ActionResult Search(string search, int curPage = 1)
        {
            if (curPage < 1)
            {
                curPage = 1;
            }
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.SanPham
                    .Include("DanhMuc")
                    .Where(x => x.DanhMuc.TenTheLoai.Contains(search) || x.TenSanPham.Contains(search));
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
                    return View();
                }
            }
        }
    }
}