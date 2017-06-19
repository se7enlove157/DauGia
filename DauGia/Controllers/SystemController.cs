using DauGia.Data;
using DauGia.Fitters;
using System.Linq;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    [CheckLogin(RequiredPermission = 0)]
    public class SystemController : Controller
    {
        // GET: System
        // danh sach nguoi dau gia
        public ActionResult Index()
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.DauGiaSanPham.Include("SanPham").Include("NguoiDung").ToList();
                return View(query);
            }
        }

        // Kiem tra gia nguoi ra gia
        public ActionResult CheckUser(int maNguoiDung, int masp)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.DauGiaSanPham.Include("SanPham").Where(x => x.MaNguoiDung == maNguoiDung && x.MaSanPham == masp).FirstOrDefault();
                if (query != null)
                {
                }
                return RedirectToAction("Index", "System");
            }
        }
    }
}