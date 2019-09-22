using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ТренерController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Тренер
        public ActionResult Index()
        {
            var тренер = db.Тренер.Include(т => т.Секция).Include(т => т.Сотрудники);
            return View(тренер.ToList());
        }

        // GET: Тренер/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренер = db.Тренер.Find(id);
            if (тренер == null)
            {
                return HttpNotFound();
            }
            return View(тренер);
        }

        // GET: Тренер/Create
        public ActionResult Create()
        {
            ViewBag.ID_Тренера = new SelectList(db.Секция, "ID_Группы", "Секция1");
            ViewBag.ID_Тренера = new SelectList(db.Сотрудники, "ID_Сотрудника", "Имя");
            return View();
        }

        // POST: Тренер/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Тренера,Спортивный_разряд,Вид_спорта")] Тренер тренер)
        {
            if (ModelState.IsValid)
            {
                db.Тренер.Add(тренер);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Тренера = new SelectList(db.Секция, "ID_Группы", "Секция1", тренер.ID_Тренера);
            ViewBag.ID_Тренера = new SelectList(db.Сотрудники, "ID_Сотрудника", "Имя", тренер.ID_Тренера);
            return View(тренер);
        }

        // GET: Тренер/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренер = db.Тренер.Find(id);
            if (тренер == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Тренера = new SelectList(db.Секция, "ID_Группы", "Секция1", тренер.ID_Тренера);
            ViewBag.ID_Тренера = new SelectList(db.Сотрудники, "ID_Сотрудника", "Имя", тренер.ID_Тренера);
            return View(тренер);
        }

        // POST: Тренер/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Тренера,Спортивный_разряд,Вид_спорта")] Тренер тренер)
        {
            if (ModelState.IsValid)
            {
                db.Entry(тренер).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Тренера = new SelectList(db.Секция, "ID_Группы", "Секция1", тренер.ID_Тренера);
            ViewBag.ID_Тренера = new SelectList(db.Сотрудники, "ID_Сотрудника", "Имя", тренер.ID_Тренера);
            return View(тренер);
        }

        // GET: Тренер/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренер тренер = db.Тренер.Find(id);
            if (тренер == null)
            {
                return HttpNotFound();
            }
            return View(тренер);
        }

        // POST: Тренер/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Тренер тренер = db.Тренер.Find(id);
            db.Тренер.Remove(тренер);
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
