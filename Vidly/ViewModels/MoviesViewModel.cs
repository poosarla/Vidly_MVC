using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MoviesViewModel
    {
        public Movie Movie { get; set; }

        public List<Customer> CustomerList { get; set; }

        public Customer Customer { get; set; }

        public List<Movie> MoviesList { get; set; }

        public List<Genre> GenreList { get; set; }

        // public NewCustomerViewModel NewCustomerViewModel { get; set; }
    }

}