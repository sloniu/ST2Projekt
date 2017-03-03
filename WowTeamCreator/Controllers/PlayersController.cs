using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WowTeamCreator.DAL;
using WowTeamCreator.Models;

namespace WowTeamCreator.Controllers
{
    [Authorize]
    public class PlayersController : Controller
    {
        private readonly WowContext _db = new WowContext();

        private List<SelectListItem> _listItems = new List<SelectListItem>()
        {
            new SelectListItem
            {
                Text = "Damage",
                Value = "DPS",
                Selected = true
            },
            new SelectListItem
            {
                Text = "Healer",
                Value = "Healer"
            },
            new SelectListItem
            {
                Text = "Tank",
                Value = "Tank"
            }
        };

        // GET: Players
        public ActionResult Index()
        {
            return View(_db.Players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.Roles = _listItems;
            return View();
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,role,level")] Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Players.Add(player);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(player);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Roles = _listItems;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,role,level")] Player player)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(player).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = _db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Player player = _db.Players.Find(id);
//            _db.Players.Remove(player);
//            _db.SaveChanges();
//            return RedirectToAction("Index");
//        }


        // GET: Manage
        public ActionResult Manage()
        {
            return View(_db.Players.ToList());
        }


        // POST: Manage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(IEnumerable<Player> model)
        {
            foreach (var player in model)
            {
                if (player.Selected)
                {
                    Debug.WriteLine(player.Name);
                }
            }
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
