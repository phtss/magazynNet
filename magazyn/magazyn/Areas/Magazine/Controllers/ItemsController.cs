using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace magazyn.Areas.Magazine.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Magazine/Items
        public ActionResult Index()
        {
            var entities = new Models.Database1Entities2();
            return View(entities.Items.ToList());

        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(Models.Items items)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Items.Add(items);
                db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(items);
        }


        public ActionResult Edit(int? id)
        {
            var db = new Models.Database1Entities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Items items = db.Items.Find(id);
            if (items == null)
            {
                return HttpNotFound();
            }
            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Amount,Price,Tax")] Models.Items items)
        {
            var db = new Magazine.Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Entry(items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(items);
        }

        public ActionResult Delete(int id)
        {
            var db = new Models.Database1Entities2();
            Models.Items items = db.Items.Find(id);

            if (items == null)
            {
                return HttpNotFound();
            }

            return this.View(items);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var db = new Models.Database1Entities2();
            Models.Items items = db.Items.Find(id);
            db.Items.Remove(items);
            db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}