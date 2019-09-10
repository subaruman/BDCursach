using System;
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
    public class ДоговорController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Договор
        public ActionResult Index()
        {
            var договор = db.Договор.Include(д => д.Секция).Include(д => д.Спортсмен);
            return View(договор.ToList());
        }

        // GET: Договор/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            return View(договор);
        }

        // GET: Договор/Create
        public ActionResult Create()
        {
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1");
            ViewBag.Номер_договора = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя");
            return View();
        }

        // POST: Договор/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Номер_договора,Дата_заключения,Стоимость,Серия_и_номер_паспорта,Дата_выдачи_паспорта,Кем_выдан_паспорт,Срок_действия_договора,ID_Группы")] Договор договор)
        {
            if (ModelState.IsValid)
            {
                db.Договор.Add(договор);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", договор.ID_Группы);
            ViewBag.Номер_договора = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", договор.Номер_договора);
            return View(договор);
        }

        // GET: Договор/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", договор.ID_Группы);
            ViewBag.Номер_договора = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", договор.Номер_договора);
            return View(договор);
        }

        // POST: Договор/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Номер_договора,Дата_заключения,Стоимость,Серия_и_номер_паспорта,Дата_выдачи_паспорта,Кем_выдан_паспорт,Срок_действия_договора,ID_Группы")] Договор договор)
        {
            if (ModelState.IsValid)
            {
                db.Entry(договор).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", договор.ID_Группы);
            ViewBag.Номер_договора = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", договор.Номер_договора);
            return View(договор);
        }

        // GET: Договор/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Договор договор = db.Договор.Find(id);
            if (договор == null)
            {
                return HttpNotFound();
            }
            return View(договор);
        }

        // POST: Договор/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Договор договор = db.Договор.Find(id);
            db.Договор.Remove(договор);
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
