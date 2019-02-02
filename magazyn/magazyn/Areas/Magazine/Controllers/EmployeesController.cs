using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace magazyn.Areas.Magazine.Home
{
    public class EmployeesController : Controller
    {
        // GET: Magazine/Employees
        public ActionResult Index()
        {
            var entities = new Models.Database1Entities2();
            return View(entities.Employees.ToList());
        }

        public ActionResult ListById(int ?id)
        {
            var entities = new Models.Database1Entities2();
            List<Models.Employees> employees = (from x in entities.Employees where x.Id_Magazine == id select x).ToList();
            return View(employees);
        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(Models.Employees employees)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
                db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(employees);
        }

        public ActionResult Edit(int? id)
        {
            var db = new Models.Database1Entities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Telephone,City,Adress, Id_Magazine")] Models.Employees employees)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }


        public ActionResult Delete(int id)
        {
            var db = new Models.Database1Entities2();
            Models.Employees employees = db.Employees.Find(id);

            if (employees == null)
            {
                return HttpNotFound();
            }

            return this.View(employees);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var db = new Models.Database1Entities2();
            Models.Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
            db.SaveChanges();

            return this.RedirectToAction("Index");
        }


    }
}