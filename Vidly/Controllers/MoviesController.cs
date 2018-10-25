using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    [RoutePrefix("Movies")]
    //[Authorize]
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {

            //var MoviesList = _context.Movies.Include(m => m.Genre).ToList();

            //var MovieViewmodel = new MoviesViewModel()
            //{
            //    MoviesList = MoviesList,
            //};

            //return View(MovieViewmodel);.
          
            return View();
        }


        public ActionResult MovieForm(int? MovieID)
        {



            MoviesViewModel movieViewmodel = new MoviesViewModel()
            {

                //  GenreList = _context.GenreLKP.ToList(),
            };

            if (MovieID.HasValue && MovieID > 0)
            {
                movieViewmodel.Movie = _context.Movies.SingleOrDefault(m => m.ID == MovieID);
                movieViewmodel.GenreList = _context.GenreLKP.ToList();
            }
            else
            {
                movieViewmodel.GenreList = _context.GenreLKP.ToList();
            }

            return View(movieViewmodel);
        }

        [HttpPost]
        public ActionResult SaveMovie(MoviesViewModel movieViewmodel)
        {

            if (ModelState.IsValid)
            {


                if (movieViewmodel.Movie.ID > 0)
                {
                    Movie moviemodelinDB = _context.Movies.Single(m => m.ID == movieViewmodel.Movie.ID);

                    moviemodelinDB.Name = movieViewmodel.Movie.Name;
                    moviemodelinDB.GenreID = movieViewmodel.Movie.GenreID;
                    moviemodelinDB.ReleasedDate = movieViewmodel.Movie.ReleasedDate;
                    moviemodelinDB.NumberinStock = movieViewmodel.Movie.NumberinStock;

                }
                else
                {
                    _context.Movies.Add(movieViewmodel.Movie);
                }

                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction("");
            }
            else
            {
                movieViewmodel.GenreList = _context.GenreLKP.ToList();
                return View("MovieForm", movieViewmodel);
            }

        }

        [Route("Details/{MovieID}")]
        public ActionResult Details(int MovieID)
        {

            var MovieDetails = _context.Movies.SingleOrDefault(m => m.ID == MovieID);

            var MovieViewmodel = new MoviesViewModel()
            {
                Movie = MovieDetails,
            };

            return View(MovieViewmodel);
        }

        // GET: Movies
        public ActionResult Random()
        {

            var objMOvie = new Movie() { Name = "Rudra" };

            var Customers = new List<Customer> {

                new Customer{Name="narangi"},
                new Customer{Name="orange"}
            };

            var ViewModel = new MoviesViewModel()
            {
                Movie = objMOvie,

                CustomerList = Customers,
            };

            return View(ViewModel);

            //ViewData["Movie"] = Movie;

            //return View();

            // return Content("Hello World");

            // return HttpNotFound();

            // return new EmptyResult();

            //return RedirectToAction("Index", "Home", new { Pageno = 1, sort = 1 });
        }

        public ActionResult Edit(int id)
        {


            return Content("id = " + id);
        }

        //public ActionResult Index(int? PageIndex, string SortBy)
        //{
        //    if (!PageIndex.HasValue)
        //        PageIndex = 1;

        //    if (String.IsNullOrWhiteSpace(SortBy))
        //        SortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortBy={1}", PageIndex, SortBy));

        //}

        //[Route("Movies/Released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int Year, int month)
        {
            return Content(Year + " / " + month);
        }

        //public ActionResult Action()
        //{
        //    return View();
        //}

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            // base.Dispose(disposing);
        }
    }
}