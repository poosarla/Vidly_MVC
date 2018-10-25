using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    //[Authorize]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            //var CustomersList = new List<Customer>
            //{
            //    new Customer{Name="Customer 1",ID=1},
            //    new Customer{Name="Customer 2",ID=2}
            //};
            //==============================
            //var CustomersList = _context.Customers.Include(c => c.MemberShipType).ToList();

            //IndexCustomersViewModel viewModel = new IndexCustomersViewModel()
            //{
            //    CustomerList = CustomersList,
            //};
            //==============================

            //var Result= new ViewResult();

            //Result.View();

            //  return View(viewModel);
            return View();
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var viewModel = new MoviesViewModel();
            try
            {

                var customer = _context.Customers.Include(r => r.MemberShipType).SingleOrDefault(r => r.ID == id);

                //var customer = new Customer { };

                //if (id == 1)
                //{
                //    customer.Name = "Customer 1";
                //    customer.CustomerMovieRecievedDate = DateTime.Now.ToString("MM/dd/yyy");
                //}
                //else if (id == 2)
                //{
                //    customer.Name = "Customer 2";
                //    customer.CustomerMovieRecievedDate = DateTime.Now.ToString("MM/dd/yyy");
                //}

                viewModel = new MoviesViewModel()
                {
                    Customer = customer
                };

            }
            catch (Exception)
            {


            }
            return View(viewModel);
        }

        [Route("Customers/NewCustomer")]
        public ActionResult NewCustomer()
        {
            var MembershipTypes = _context.MemberShipTypes.ToList();

            NewCustomerViewModel CustomerViewModel = new NewCustomerViewModel()
            {
                MemberShipTypes = MembershipTypes,
            };

            return View(CustomerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Customers/Create")]
        public ActionResult Create(NewCustomerViewModel customerViewModel)
        {

            if (ModelState.IsValid)
            {
                if (customerViewModel.Customer.ID > 0)
                {
                    Customer CustomerinDB = _context.Customers.Single(c => c.ID == customerViewModel.Customer.ID);

                    //update the value
                    // TryUpdateModel(CustomerinDB,"",);

                    CustomerinDB.DOB = customerViewModel.Customer.DOB;
                    CustomerinDB.MemberShipTypeID = customerViewModel.Customer.MemberShipTypeID;
                    CustomerinDB.Name = customerViewModel.Customer.Name;
                    CustomerinDB.isSubscribedtoNewsLetter = customerViewModel.Customer.isSubscribedtoNewsLetter;

                }
                else
                {
                    _context.Customers.Add(customerViewModel.Customer);
                }
                _context.SaveChanges();

                return RedirectToAction("");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);

                var MembershipTypes = _context.MemberShipTypes.ToList();
                customerViewModel.MemberShipTypes = MembershipTypes;
                return View("NewCustomer", customerViewModel);
            }
        }

        public ActionResult Edit(int id)
        {
            Customer EditableCustomer = _context.Customers.SingleOrDefault(c => c.ID == id);

            NewCustomerViewModel customerViewModel = new NewCustomerViewModel()
            {
                Customer = EditableCustomer,
                MemberShipTypes = _context.MemberShipTypes.ToList(),
            };

            return View("NewCustomer", customerViewModel);
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
    }
}