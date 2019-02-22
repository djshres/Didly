using Didly.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Didly.ViewModels;
using System;

namespace Didly.Controllers
{
    [AllowAnonymous]
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList();
            return View(movie);
        }

        public ActionResult Create()
        {
            var movie = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View(movie);
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewmodel = new MovieFormViewModel()
                {
                    Movie=movie,
                    Genres = _context.Genres.ToList()
                };
                return View(viewmodel);
            }
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                HttpNotFound();
            var movies = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View(movies);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreId = movie.GenreId;
            movieInDb.NumberInstock = movie.NumberInstock;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);

        }
        public ActionResult Delete(int id)
        {
            var movies = _context.Movies.Single(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            _context.Movies.Remove(movies);
            _context.SaveChanges();
                return RedirectToAction("Index");
           
        }
       

    }
}
