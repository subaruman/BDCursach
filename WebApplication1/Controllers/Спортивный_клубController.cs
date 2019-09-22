using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Спортивный_клубController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Спортивный_клуб
        public ActionResult Index()
        {
            var спортивный_клуб = db.Спортивный_клуб.Include(с => с.Владелец);
            return View(спортивный_клуб.ToList());
        }

        // GET: Спортивный_клуб/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортивный_клуб спортивный_клуб = db.Спортивный_клуб.Find(id);
            if (спортивный_клуб == null)
            {
                return HttpNotFound();
            }
            return View(спортивный_клуб);
        }

        // GET: Спортивный_клуб/Create
        public ActionResult Create()
        {
            ViewBag.ID_Спорт_клуба = new SelectList(db.Владелец, "ID_Владельца", "Имя");
            return View();
        }

        // POST: Спортивный_клуб/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Спорт_клуба,Название,Адрес,Телефон,Дата_основания")] Спортивный_клуб спортивный_клуб)
        {
            if (ModelState.IsValid)
            {
                db.Спортивный_клуб.Add(спортивный_клуб);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Спорт_клуба = new SelectList(db.Владелец, "ID_Владельца", "Имя", спортивный_клуб.ID_Спорт_клуба);
            return View(спортивный_клуб);
        }

        // GET: Спортивный_клуб/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортивный_клуб спортивный_клуб = db.Спортивный_клуб.Find(id);
            if (спортивный_клуб == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Спорт_клуба = new SelectList(db.Владелец, "ID_Владельца", "Имя", спортивный_клуб.ID_Спорт_клуба);
            return View(спортивный_клуб);
        }

        // POST: Спортивный_клуб/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Спорт_клуба,Название,Адрес,Телефон,Дата_основания")] Спортивный_клуб спортивный_клуб)
        {
            if (ModelState.IsValid)
            {
                db.Entry(спортивный_клуб).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Спорт_клуба = new SelectList(db.Владелец, "ID_Владельца", "Имя", спортивный_клуб.ID_Спорт_клуба);
            return View(спортивный_клуб);
        }

        // GET: Спортивный_клуб/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Спортивный_клуб спортивный_клуб = db.Спортивный_клуб.Find(id);
            if (спортивный_клуб == null)
            {
                return HttpNotFound();
            }
            return View(спортивный_клуб);
        }

        // POST: Спортивный_клуб/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Спортивный_клуб спортивный_клуб = db.Спортивный_клуб.Find(id);
            db.Спортивный_клуб.Remove(спортивный_клуб);
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
