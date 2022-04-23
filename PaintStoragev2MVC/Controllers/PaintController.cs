using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (DBModel db = new DBModel())
            {
                List<Paint> empList = db.Paint.ToList<Paint>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Paint());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Paint.Where(x => x.PaintID == id).FirstOrDefault<Paint>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Paint emp)
        {
            using (DBModel db = new DBModel())
            {
                if (emp.PaintID == 0)
                {
                    db.Paint.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }


        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Paint emp = db.Paint.Where(x => x.PaintID == id).FirstOrDefault<Paint>();
                db.Paint.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}