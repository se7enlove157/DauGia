using DauGia.Data;
using DauGia.Fitters;
using DauGia.Helper;
using DauGia.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    [CheckLogin]
    public class ManagerController : Controller
    {
        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManagerUser()
        {
            return View();
        }

        public ActionResult ManagerTicket()
        {
            return View();
        }

        // xem danh sach tat ca cac nguoi dung dau gia
        public ActionResult ReviewAuction()
        {
            int ma = CurrentContext.CurUser().MaNguoiDung;
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.DauGiaSanPham.Include("SanPham").Include("NguoiDung").Where(x => x.SanPham.MaNguoiDung == ma).ToList();
                return View(query);
            }
        }
        // xem danh sach nguoi dung thang
        public ActionResult ReviewAuctionWin()
        {
            int ma = CurrentContext.CurUser().MaNguoiDung;
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.DauGiaSanPham.Include("SanPham").Include("NguoiDung").Where(x => x.SanPham.MaNguoiDung == ma && x.ThangCuoc == true).ToList();
                return View(query);
            }
        }
        // kich nguoi dung
        public ActionResult LockUser(int masp, int maNguoiDung)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                DauGiaSanPham dg = ql.DauGiaSanPham.Where(x => x.MaNguoiDung == maNguoiDung && x.MaSanPham == masp).FirstOrDefault();
                dg.KichNguoiDung = true; // khong cho dau gia
                ql.SaveChanges();
                DauGiaSanPham chuyengia = ql.DauGiaSanPham.Where(x => x.MaSanPham == masp).OrderBy(x => x.DauGiaNguoiDung).Take(1).FirstOrDefault();
                chuyengia.GiuGiaCaoNhat = true;
                ql.SaveChanges();
                return RedirectToAction("Index", "System");
            }
        }

        // Danh sach nguoi da thang cuoc
        public ActionResult ListBy()
        {
            int ma = CurrentContext.CurUser().MaNguoiDung;
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.DauGiaSanPham.Include("SanPham").Include("NguoiDung").Where(x => x.SanPham.MaNguoiDung == ma && x.ThangCuoc == true).ToList();
                return View(query);
            }
        }

        // xem danh sach san pham dang va con han
        public ActionResult ReviewList()
        {
            var ma = CurrentContext.CurUser().MaNguoiDung;
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                DateTime date = DateTime.Now;
                var query = ql.SanPham.Where(x => x.MaNguoiDung == ma).ToList();
                return View(query);
            }
        }

        // them vao muc uu thich
        [HttpPost]
        public ActionResult AddWist(WistModel w)
        {
            var ma = CurrentContext.CurUser().MaNguoiDung;
            DateTime date = DateTime.Now;
            UuThich u = new UuThich
            {
                MaNguoiDung = ma,
                MaSanPham = w.IdProduct,
                NgayHienTai = date,
            };

            using (DauGiaEntities ql = new DauGiaEntities())
            {
                // kiem tra xem danh sach uu thich da co san pham hay chua, 1 la co
                var query = ql.UuThich.SingleOrDefault(x => x.MaNguoiDung == ma && x.MaSanPham == w.IdProduct);
                if (query == null)
                {
                    ql.UuThich.Add(u);
                    ql.SaveChanges();
                    ModelState.Clear();
                }

                return RedirectToAction("Index", "Home");
            }
        }

        // xem danh sach uu thich
        public ActionResult ReviewWist()
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var ma = CurrentContext.CurUser().MaNguoiDung;
                var query = ql.UuThich.Include("SanPham").Where(x => x.MaNguoiDung == ma).ToList();
                return View(query);
            }
        }

    }
}