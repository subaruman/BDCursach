﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class СпортсменController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Спортсмен
        public ActionResult Index()
        {
            return View(db.Спортсмен.ToList());
        }

        // GET: Спортсмен/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортсмен спортсмен = db.Спортсмен.Find(id);
            if (спортсмен == null)
            {
                return HttpNotFound();
            }
            return View(спортсмен);
        }

        // GET: Спортсмен/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Спортсмен/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Спортсмена,Имя,Фамилия,Пол,Дата_рождения,Телефон")] Спортсмен спортсмен)
        {
            if (ModelState.IsValid)
            {
                db.Спортсмен.Add(спортсмен);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(спортсмен);
        }

        // GET: Спортсмен/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортсмен спортсмен = db.Спортсмен.Find(id);
            if (спортсмен == null)
            {
                return HttpNotFound();
            }
            return View(спортсмен);
        }

        // POST: Спортсмен/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Спортсмена,Имя,Фамилия,Пол,Дата_рождения,Телефон")] Спортсмен спортсмен)
        {
            if (ModelState.IsValid)
            {
                db.Entry(спортсмен).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(спортсмен);
        }

        // GET: Спортсмен/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортсмен спортсмен = db.Спортсмен.Find(id);
            if (спортсмен == null)
            {
                return HttpNotFound();
            }
            return View(спортсмен);
        }

        // POST: Спортсмен/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Спортсмен спортсмен = db.Спортсмен.Find(id);
            db.Спортсмен.Remove(спортсмен);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
