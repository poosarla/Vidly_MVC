using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{

    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContext = null;

        CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult Customers()
        {
            IEnumerable<CustomerDto> Customers = null;
            try
            {
                Customers = _dbContext.Customers
                    .Include(c => c.MemberShipType)
                    .ToList()
                    .Select(Mapper.Map<Customer, CustomerDto>);
            }
            finally
            {

            }
            return Ok(Customers);
        }

        [HttpDelete]
        public IHttpActionResult Customers(int id)
        {
            try
            {
                var DBCustomer = _dbContext.Customers.Single(c => c.ID == id);
                _dbContext.Customers.Remove(DBCustomer);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;

            }

            return Ok();
        }

        //public CustomerDto getCutomer(int id)
        //{
        //    Customer Customer = null;
        //    try
        //    {
        //        Customer = _dbContext.Customers.SingleOrDefault();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return Mapper.Map<Customer, CustomerDto>(Customer);
        //}



        [System.Web.Http.HttpPost]
        public IHttpActionResult Customers(CustomerDto customermodel)
        {
            try
            {
                var customerinput = Mapper.Map<CustomerDto, Customer>(customermodel);
                _dbContext.Customers.Add(customerinput);
                _dbContext.SaveChanges();

                customermodel.ID = customerinput.ID;
            }
            finally
            {

            }
            //return Created(new Uri(Request.RequestUri + "/" + customer.ID), customermodel);
            return Ok("created");
        }


        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customermodel)
        {
            try
            {
                Customer DbCustomer = _dbContext.Customers.Single(c => c.ID == id);

                Mapper.Map(customermodel, DbCustomer);

                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
