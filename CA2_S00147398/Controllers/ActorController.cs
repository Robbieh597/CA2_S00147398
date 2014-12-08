using CA2_S00147398.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA2_S00147398.Controllers
{
    public class ActorController : Controller
    {
        private MovieDb db = new MovieDb();
        //
        // GET: /Actor/

        public ActionResult Index(string sortOrder, string searchString)
        {
            //Allows the actor names to sorted
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_asc" : "";
            var actors = from a in db.Actor
                         select a;
            //Lets the user search for an actor by name
            if (!String.IsNullOrEmpty(searchString))
            {
                actors = actors.Where(a => a.ActorName.Contains(searchString));
            }
            switch (sortOrder)
            { 
                case "name_desc":
                    actors = actors.OrderByDescending(a => a.ActorName);
                break;
            }
            return View(actors.ToList());
        }

        //
        // GET: /Actor/Details/5
        //Gets the actors details
        public ActionResult Details(int id)
        {
            Actors act = db.Actor.Find(id);
            return View(act);
        }
        //Displays partial view of actor detils
        public PartialViewResult ActorById(int id)
        {
            var actor = db.Actor.Find(id);
            @ViewBag.ActorId = id;
            @ViewBag.ScreenName = actor.ScreenName;
            return PartialView("_Actor", actor.ActorName);
        }
        //
        // GET: /Actor/Create
        //Lets the suer create a movie
        public ActionResult Create(int MovieId)
        {
            Actors add = new Actors { MovieID = MovieId };
            return View();
        }

        //
        // POST: /Actor/Create
        //Lets the user create an actor and add them to a movie
        [HttpPost]
        public ActionResult Create(Actors actor, int MovieId)
        {
            actor.MovieID = MovieId;
            if (ModelState.IsValid)
            {
                db.Actor.Add(actor);
                db.SaveChanges();
                return RedirectToAction("Details", "Home", new { id = actor.MovieID });
            }
            return View(actor);
        }

        //
        // GET: /Actor/Edit/5
        //Allows an actor to be edied
        public ActionResult Edit(int id)
        {
            Actors actor = db.Actor.Find(id);
            return View();
        }

        //
        // POST: /Actor/Edit/5
        //Allows and actor to be edited and saves the edits
        [HttpPost]
        public ActionResult Edit(Actors actor, int MovieId)
        {
            if (ModelState.IsValid)
            {
                actor.MovieID = MovieId;
                db.Entry(actor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actor);
        }

        //
        // GET: /Actor/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Actor/Delete/5
        //Lets an actor be deleted
        [HttpPost]
        public ActionResult DeleteActor(int id = 0)
        {
            Actors actor = db.Actor.Find(id);

            return View(actor);
        }
        //Removes the actor from database and saves
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actors actor = db.Actor.Find(id);
            db.Actor.Remove(actor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
