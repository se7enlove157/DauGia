using DauGia.Fitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DauGia.Controllers
{
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
        [CheckLogin]
        public ActionResult ListUser()
        {

        }
        [HttpGet]
        [CheckLogin]
        public ActionResult RemoveUser()
        {
            return RedirectToAction();
        }
        public ActionResult FromResetPass()
        {
            return View();
        }
        public ActionResult ResetPass()
        {
            return RedirectToAction();
        }
        public ActionResult FromAddCategory()
        {
            return View();
        }
        public ActionResult AddCategory()
        {

        }
        public ActionResult FromEditCategory()
        {
            return View();

        }
        public ActionResult EditCategory()
        {

        }
        public ActionResult RemoveCategory()
        {

        }
    }
}