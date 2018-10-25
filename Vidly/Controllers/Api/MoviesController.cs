using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{

    public class MoviesController : ApiController
    {
        private ApplicationDbContext _dbContext = null;

        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        [Authorize(Roles = RolesNames.CanManageMovies)]
        public IHttpActionResult Movies()
        {
            List<Movie> MoviesList = null;
            try
            {
                MoviesList = _dbContext.Movies.Include(m => m.Genre).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(MoviesList);
        }
    }
}
