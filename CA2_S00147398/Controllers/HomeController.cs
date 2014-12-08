using CA2_S00147398.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA2_S00147398.Controllers
{
    public class HomeController : Controller
    {
        MovieDb db = new MovieDb();
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //Returns a list of movies
            return View(db.Movie.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            //Returns the details of a movie 
            Movies mov = db.Movie.Find(id);
            mov.Actors = (from e in db.Actor
                        where e.MovieID.Equals(id)
                        select e).ToList();
            return View(mov);
        }
        //Returns partial view of actor names and screen names
        public PartialViewResult ActorById(int id)
        {
            var actor = db.Actor.Find(id);
            @ViewBag.ActorId = id;
            @ViewBag.ScreenName = actor.ScreenName;
            return PartialView("_Actor", actor.ActorName);
        }
        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create
        //Allows the creation of a movie
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movie)
        {
            if (ModelState.IsValid)
            {
                db.Movie.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5
        //Allows an actor to be edited
        public ActionResult EditActor(int id)
        {
            Movies movie = db.Movie.Find(id);
            return View(movie);
        }
        //Allows a movie to be edited
        [HttpPost]
        public ActionResult Edit(Movies movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
        //Allows a movie to be deleted
        public ActionResult Delete(int id)
        {
            return View(db.Movie.Find(id));
        }
        //Allows and actor to be deleted
        public ActionResult DeleteActor(int id)
        {
            Movies movie = db.Movie.Find(id);
            return View(movie);
        }
        //Removes the movie from the database
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movies movie = db.Movie.Find(id);
            db.Movie.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
