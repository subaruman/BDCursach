using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class СекцияController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Секция
        public ActionResult Index()
        {
            var секция = db.Секция.Include(с => с.Тренер);
            return View(секция.ToList());
        }

        // GET: Секция/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Секция секция = db.Секция.Find(id);
            if (секция == null)
            {
                return HttpNotFound();
            }
            return View(секция);
        }

        // GET: Секция/Create
        public ActionResult Create()
        {
            ViewBag.ID_Группы = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд");
            return View();
        }

        // POST: Секция/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Группы,Количество_людей,Секция1,Вид_спорта")] Секция секция)
        {
            if (ModelState.IsValid)
            {
                db.Секция.Add(секция);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Группы = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", секция.ID_Группы);
            return View(секция);
        }

        // GET: Секция/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Секция секция = db.Секция.Find(id);
            if (секция == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Группы = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", секция.ID_Группы);
            return View(секция);
        }

        // POST: Секция/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Группы,Количество_людей,Секция1,Вид_спорта")] Секция секция)
        {
            if (ModelState.IsValid)
            {
                db.Entry(секция).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Группы = new SelectList(db.Тренер, "ID_Тренера", "Спортивный_разряд", секция.ID_Группы);
            return View(секция);
        }

        // GET: Секция/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Секция секция = db.Секция.Find(id);
            if (секция == null)
            {
                return HttpNotFound();
            }
            return View(секция);
        }

        // POST: Секция/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Секция секция = db.Секция.Find(id);
            db.Секция.Remove(секция);
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
