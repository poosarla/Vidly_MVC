using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public List<Customer> CustomerList { get; set; }

    }

    public class IndexCustomersViewModel
    {
        public List<Customer> CustomerList { get; set; }
    }

}