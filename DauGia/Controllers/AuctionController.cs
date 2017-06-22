using DauGia.Data;
using DauGia.Fitters;
using DauGia.Helper;
using DauGia.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace DauGia.Controllers
{
    [CheckLogin]
    public class AuctionController : Controller
    {
        // GET: Auction
        public ActionResult Index()
        {
            return View();
        }

        private void Mail(int ma, float price, int productid)
        {
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                var query = ql.SanPham.Where(x => x.MaSanPham == productid).FirstOrDefault();
                var productName = query.TenSanPham;
                var productPrice = query.Gia.ToString() ;
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/teamplate/sendmail.html"));
                content = content.Replace("{{CustomerName}}", CurrentContext.CurUser().TaiKhoan);
                content = content.Replace("{{Name}}", CurrentContext.CurUser().TenNguoiDung);
                content = content.Replace("{{Price}}", price.ToString("N0"));
                content = content.Replace("{{productName}}", productName);
                content = content.Replace("{{productPrice}}", productPrice.ToString());
                var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                string email = CurrentContext.CurUser().Email.ToString();
                new MailHelper().SendMail("a", "He thong dau gia", content);
            }
        }

        // them người dùng đấu giá và kiểm tra người dùng có bị kích hay không
        [HttpPost]
        public ActionResult Add(AuctionModel item)
        {
           
            var ma = CurrentContext.CurUser().MaNguoiDung;
            DateTime date = DateTime.Now;
            DauGiaSanPham daugiasp = new DauGiaSanPham
            {
                MaSanPham = item.productID,
                MaNguoiDung = ma,
                NgayHienTai = date,
                DauGiaNguoiDung = item.priceAuction
            };
            using (DauGiaEntities ql = new DauGiaEntities())
            {
                // dk đấu giá là 1 user khác với user ra giá, người đó không được kích
                var query = ql.DauGiaSanPham
                    .Where(x => x.MaNguoiDung == ma && x.KichNguoiDung == true && x.MaNguoiDung == ma)
                    .Count();
                // La User dang ban san pham
                var checkUser = ql.SanPham.Where(x => x.MaSanPham == item.productID && x.MaNguoiDung == ma).Count();
                var checkPrice = ql.SanPham.SingleOrDefault(x => (x.Gia + x.BuocGia) < item.priceAuction);
                if (query == 0 && checkUser == 0 && checkPrice != null)
                {
                    //ViewBag.Message = "Bạn đấu giá thành công và chờ hệ thống kiểm tra!";
                    ql.DauGiaSanPham.Add(daugiasp);
                    ql.SaveChanges();
                    ModelState.Clear();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //ViewBag.Message = "Bạn đã bị kích và không được đấu giá!";
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}