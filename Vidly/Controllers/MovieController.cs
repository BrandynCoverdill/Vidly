using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {
        private VidlyContext db = new VidlyContext();

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek"
            };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"},
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
        // GET: Movie
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        public ActionResult New()
        {
            List<SelectListItem> movieGenres = new List<SelectListItem>
            {
                new SelectListItem {Text="Action", Value="Action"},
                new SelectListItem {Text="Thriller", Value="Thriller"},
                new SelectListItem {Text="Family", Value="Family"},
                new SelectListItem {Text="Romance", Value="Romance"},
                new SelectListItem {Text="Comedy", Value="Comedy"}
            };

            ViewBag.genres = movieGenres;
            ViewBag.movieId = 0;
            ViewBag.Title = "New Movie";

            return View("MovieForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> movieGenres = new List<SelectListItem>
                    {
                        new SelectListItem {Text="Action", Value="Action"},
                        new SelectListItem {Text="Thriller", Value="Thriller"},
                        new SelectListItem {Text="Family", Value="Family"},
                        new SelectListItem {Text="Romance", Value="Romance"},
                        new SelectListItem {Text="Comedy", Value="Comedy"}
                    };

                ViewBag.genres = movieGenres;
                ViewBag.Title = "New Movie";
                return View("MovieForm", movie);
            }

            if (movie.Id == 0)
            {
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.SingleOrDefault(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;

                }

            db.SaveChanges();

            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> movieGenres = new List<SelectListItem>
            {
                new SelectListItem {Text="Action", Value="Action"},
                new SelectListItem {Text="Thriller", Value="Thriller"},
                new SelectListItem {Text="Family", Value="Family"},
                new SelectListItem {Text="Romance", Value="Romance"},
                new SelectListItem {Text="Comedy", Value="Comedy"}
            };
            ViewBag.movieId = movie.Id;
            ViewBag.genres = movieGenres;
            ViewBag.Title = "Edit Movie";

            return View("Edit", movie);


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
