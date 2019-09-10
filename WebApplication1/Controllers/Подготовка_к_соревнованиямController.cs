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
    public class Подготовка_к_соревнованиямController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Подготовка_к_соревнованиям
        public ActionResult Index()
        {
            var подготовка_к_соревнованиям = db.Подготовка_к_соревнованиям.Include(п => п.Секция).Include(п => п.Спортивный_клуб).Include(п => п.Тренер);
            return View(подготовка_к_соревнованиям.ToList());
        }

        // GET: Подготовка_к_соревнованиям/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подготовка_к_соревнованиям подготовка_к_соревнованиям = db.Подготовка_к_соревнованиям.Find(id);
            if (подготовка_к_соревнованиям == null)
            {
                return HttpNotFound();
            }
            return View(подготовка_к_соревнованиям);
        }

        // GET: Подготовка_к_соревнованиям/Create
        public ActionResult Create()
        {
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1");
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название");
            ViewBag.ID_Тренера = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд");
            return View();
        }

        // POST: Подготовка_к_соревнованиям/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Тренировки,Дата_тренировки,ID_Спорт_клуба,ID_Группы,ID_Тренера,ID_Соревнования")] Подготовка_к_соревнованиям подготовка_к_соревнованиям)
        {
            if (ModelState.IsValid)
            {
                db.Подготовка_к_соревнованиям.Add(подготовка_к_соревнованиям);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", подготовка_к_соревнованиям.ID_Группы);
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", подготовка_к_соревнованиям.ID_Спорт_клуба);
            ViewBag.ID_Тренера = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", подготовка_к_соревнованиям.ID_Тренера);
            return View(подготовка_к_соревнованиям);
        }

        // GET: Подготовка_к_соревнованиям/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подготовка_к_соревнованиям подготовка_к_соревнованиям = db.Подготовка_к_соревнованиям.Find(id);
            if (подготовка_к_соревнованиям == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", подготовка_к_соревнованиям.ID_Группы);
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", подготовка_к_соревнованиям.ID_Спорт_клуба);
            ViewBag.ID_Тренера = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", подготовка_к_соревнованиям.ID_Тренера);
            return View(подготовка_к_соревнованиям);
        }

        // POST: Подготовка_к_соревнованиям/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Тренировки,Дата_тренировки,ID_Спорт_клуба,ID_Группы,ID_Тренера,ID_Соревнования")] Подготовка_к_соревнованиям подготовка_к_соревнованиям)
        {
            if (ModelState.IsValid)
            {
                db.Entry(подготовка_к_соревнованиям).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Группы = new SelectList(db.Секция, "ID_Группы", "Секция1", подготовка_к_соревнованиям.ID_Группы);
            ViewBag.ID_Спорт_клуба = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", подготовка_к_соревнованиям.ID_Спорт_клуба);
            ViewBag.ID_Тренера = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", подготовка_к_соревнованиям.ID_Тренера);
            return View(подготовка_к_соревнованиям);
        }

        // GET: Подготовка_к_соревнованиям/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подготовка_к_соревнованиям подготовка_к_соревнованиям = db.Подготовка_к_соревнованиям.Find(id);
            if (подготовка_к_соревнованиям == null)
            {
                return HttpNotFound();
            }
            return View(подготовка_к_соревнованиям);
        }

        // POST: Подготовка_к_соревнованиям/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Подготовка_к_соревнованиям подготовка_к_соревнованиям = db.Подготовка_к_соревнованиям.Find(id);
            db.Подготовка_к_соревнованиям.Remove(подготовка_к_соревнованиям);
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
