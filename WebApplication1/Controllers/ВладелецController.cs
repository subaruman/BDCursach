using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ВладелецController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Владелец
        public ActionResult Index()
        {
            var владелец = db.Владелец.Include(в => в.Спортивный_клуб);
            return View(владелец.ToList());
        }

        // GET: Владелец/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Владелец владелец = db.Владелец.Find(id);
            if (владелец == null)
            {
                return HttpNotFound();
            }
            return View(владелец);
        }

        // GET: Владелец/Create
        public ActionResult Create()
        {
            ViewBag.ID_Владельца = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название");
            return View();
        }

        // POST: Владелец/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Владельца,Имя,Фамилия,Телефон,Адрес,Дата_рождения,Пол")] Владелец владелец)
        {
            if (ModelState.IsValid)
            {
                db.Владелец.Add(владелец);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Владельца = new SelectList(db.Владелец, "ID_Владельца", "Имя", владелец.ID_Владельца);
            return View(владелец);
        }

        // GET: Владелец/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Владелец владелец = db.Владелец.Find(id);
            if (владелец == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Владельца = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", владелец.ID_Владельца);
            return View(владелец);
        }

        // POST: Владелец/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Владельца,Имя,Фамилия,Телефон,Адрес,Дата_рождения,Пол")] Владелец владелец)
        {
            if (ModelState.IsValid)
            {
                db.Entry(владелец).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Владельца = new SelectList(db.Спортивный_клуб, "ID_Спорт_клуба", "Название", владелец.ID_Владельца);
            return View(владелец);
        }

        // GET: Владелец/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Владелец владелец = db.Владелец.Find(id);
            if (владелец == null)
            {
                return HttpNotFound();
            }
            return View(владелец);
        }

        // POST: Владелец/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Владелец владелец = db.Владелец.Find(id);
            db.Владелец.Remove(владелец);
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
