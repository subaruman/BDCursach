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
    public class СотрудникиController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Сотрудники
        public ActionResult Index()
        {
            var сотрудники = db.Сотрудники.Include(с => с.Спортивный_клуб).Include(с => с.Тренер);
            return View(сотрудники.ToList());
        }

        // GET: Сотрудники/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // GET: Сотрудники/Create
        public ActionResult Create()
        {
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название");
            ViewBag.ID_Сотрудника = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд");
            return View();
        }

        // POST: Сотрудники/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Сотрудника,Имя,Фамилия,Телефон,Должность,Общий_стаж,Зарплата,ID_Спорт_клуба")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Сотрудники.Add(сотрудники);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", сотрудники.ID_Спорт_клуба);
            ViewBag.ID_Сотрудника = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", сотрудники.ID_Сотрудника);
            return View(сотрудники);
        }

        // GET: Сотрудники/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", сотрудники.ID_Спорт_клуба);
            ViewBag.ID_Сотрудника = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", сотрудники.ID_Сотрудника);
            return View(сотрудники);
        }

        // POST: Сотрудники/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Сотрудника,Имя,Фамилия,Телефон,Должность,Общий_стаж,Зарплата,ID_Спорт_клуба")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(сотрудники).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", сотрудники.ID_Спорт_клуба);
            ViewBag.ID_Сотрудника = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", сотрудники.ID_Сотрудника);
            return View(сотрудники);
        }

        // GET: Сотрудники/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // POST: Сотрудники/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Сотрудники сотрудники = db.Сотрудники.Find(id);
            db.Сотрудники.Remove(сотрудники);
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
