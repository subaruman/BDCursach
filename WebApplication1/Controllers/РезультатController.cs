using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class РезультатController : Controller
    {
        private DBConnection db = new DBConnection();

        // GET: Результат
        public ActionResult Index()
        {
            var результат = db.Результат.Include(р => р.Соревнования).Include(р => р.Спортсмен);
            return View(результат.ToList());
        }

        // GET: Результат/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Результат результат = db.Результат.Find(id);
            if (результат == null)
            {
                return HttpNotFound();
            }
            return View(результат);
        }

        // GET: Результат/Create
        public ActionResult Create()
        {
            ViewBag.ID_Результата = new SelectList(db.Соревнования, "ID_Соревнований", "Тип_соревнований");
            ViewBag.ID_Результата = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя");
            return View();
        }

        // POST: Результат/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Результата,Занятое_место,Время,Набрано_очков,ID_Соревнования,Соревнования_ID_Соревнований")] Результат результат)
        {
            if (ModelState.IsValid)
            {
                db.Результат.Add(результат);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Результата = new SelectList(db.Соревнования, "ID_Соревнований", "Тип_соревнований", результат.ID_Результата);
            ViewBag.ID_Результата = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", результат.ID_Результата);
            return View(результат);
        }

        // GET: Результат/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Результат результат = db.Результат.Find(id);
            if (результат == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Результата = new SelectList(db.Соревнования, "ID_Соревнований", "Тип_соревнований", результат.ID_Результата);
            ViewBag.ID_Результата = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", результат.ID_Результата);
            return View(результат);
        }

        // POST: Результат/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Результата,Занятое_место,Время,Набрано_очков,ID_Соревнования,Соревнования_ID_Соревнований")] Результат результат)
        {
            if (ModelState.IsValid)
            {
                db.Entry(результат).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Результата = new SelectList(db.Соревнования, "ID_Соревнований", "Тип_соревнований", результат.ID_Результата);
            ViewBag.ID_Результата = new SelectList(db.Спортсмен, "ID_Спортсмена", "Имя", результат.ID_Результата);
            return View(результат);
        }

        // GET: Результат/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Результат результат = db.Результат.Find(id);
            if (результат == null)
            {
                return HttpNotFound();
            }
            return View(результат);
        }

        // POST: Результат/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Результат результат = db.Результат.Find(id);
            db.Результат.Remove(результат);
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
