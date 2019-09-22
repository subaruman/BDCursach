using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class СоревнованияController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Соревнования
        public ActionResult Index()
        {
            return View(db.Соревнования.ToList());
        }

        // GET: Соревнования/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Соревнования соревнования = db.Соревнования.Find(id);
            if (соревнования == null)
            {
                return HttpNotFound();
            }
            return View(соревнования);
        }

        // GET: Соревнования/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Соревнования/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Соревнований,Дата_соревнований,Тип_соревнований,Вид_спорта,Спонсор_соревнований,Место_проведения")] Соревнования соревнования)
        {
            if (ModelState.IsValid)
            {
                db.Соревнования.Add(соревнования);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(соревнования);
        }

        // GET: Соревнования/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Соревнования соревнования = db.Соревнования.Find(id);
            if (соревнования == null)
            {
                return HttpNotFound();
            }
            return View(соревнования);
        }

        // POST: Соревнования/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Соревнований,Дата_соревнований,Тип_соревнований,Вид_спорта,Спонсор_соревнований,Место_проведения")] Соревнования соревнования)
        {
            if (ModelState.IsValid)
            {
                db.Entry(соревнования).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(соревнования);
        }

        // GET: Соревнования/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Соревнования соревнования = db.Соревнования.Find(id);
            if (соревнования == null)
            {
                return HttpNotFound();
            }
            return View(соревнования);
        }

        // POST: Соревнования/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Соревнования соревнования = db.Соревнования.Find(id);
            db.Соревнования.Remove(соревнования);
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
