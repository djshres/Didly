using Didly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Didly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer{Id=1,Name="Dheeraj Shrestha"},
                new Customer{Id=2,Name="Miroz Devkota"}
            };
        }
    }
}