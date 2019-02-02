using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace magazyn.Areas.Magazine.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Items_has_OrderList/Orders
        public ActionResult Index()
        {
            var entities = new Models.Database1Entities2();
            return View(entities.Items_has_OrderList.ToList());

        }

        public ActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNew(Models.Items_has_OrderList orders)
        {
            var db = new Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Items_has_OrderList.Add(orders);
                db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            return this.View(orders);
        }


        public ActionResult Edit(int? id)
        {
            var db = new Models.Database1Entities2();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Items_has_OrderList orders = db.Items_has_OrderList.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }
            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Id_Items,Id_Employees")] Models.Items_has_OrderList orders)
        {
            var db = new Magazine.Models.Database1Entities2();

            if (ModelState.IsValid)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orders);
        }

        public ActionResult Delete(int id)
        {
            var db = new Models.Database1Entities2();
            Models.Items_has_OrderList orders = db.Items_has_OrderList.Find(id);

            if (orders == null)
            {
                return HttpNotFound();
            }

            return this.View(orders);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var db = new Models.Database1Entities2();
            Models.Items_has_OrderList orders = db.Items_has_OrderList.Find(id);
            db.Items_has_OrderList.Remove(orders);
            db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}