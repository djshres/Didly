using Didly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Didly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movie = GetMovies();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies().SingleOrDefault(m => m.Id == id);
            if (movies == null)
                return HttpNotFound();
            return View(movies);

        }

        public IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id=1,Name="Titanic"},
                new Movie{Id=2,Name="Avatar"}
            };
        }
    }
}