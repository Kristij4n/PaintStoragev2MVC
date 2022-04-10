using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PaintStoragev2MVC.Models;

namespace PaintStoragev2MVC.Controllers
{
    public class PaintController : Controller
    {
        // GET: Paint
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (PaintStorageDBEntities db = new PaintStorageDBEntities())
            {
                List<PaintDB> paintList = db.PaintDB.ToList<PaintDB>();
                return Json(new { data = paintList }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]

        public ActionResult AddOrEdit(int id = 0)
        {
            return View(new PaintDB());
        }

        [HttpPost]

        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}