using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace magazyn.Areas.Magazine
{
    public class HomeController : Controller
    {


    // GET: Magazine/Home
    public ActionResult Index()
        {
           var entities = new Models.Database1Entities2();
            return View(entities.Magazine.ToList());

        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(Models.Magazine magazine)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Magazine.Add(magazine);
                db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(magazine);
        }


        public ActionResult Edit(int? id)
        {
            var db = new Models.Database1Entities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Magazine magazine = db.Magazine.Find(id);
            if (magazine == null)
            {
                return HttpNotFound();
            }
            return View(magazine);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,City,Adress,NIP")] Models.Magazine magazine)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Entry(magazine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(magazine);
        }

        public ActionResult Delete(int id)
        {
            var db = new Models.Database1Entities2();
            Models.Magazine magazine = db.Magazine.Find(id);

            if (magazine == null)
            {
                return HttpNotFound();
            }

            return this.View(magazine);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var db = new Models.Database1Entities2();
            Models.Magazine magazine = db.Magazine.Find(id);
            db.Magazine.Remove(magazine);
            db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}