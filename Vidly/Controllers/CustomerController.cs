using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private VidlyContext db = new VidlyContext();

        // GET: Customer
        public ActionResult Index()
        {
            // The Include method allows you to get data from another Model, in this case, DiscountRate
            // from MembershipType model. This is called Eager Loading.
            return View(db.Customers.Include(c => c.MembershipType).ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // Action method that allows a creation of a customer.
        public ActionResult New()
        {
            var membershipTypes = db.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            ViewBag.customerId = 0;
            ViewBag.Title = "New Customer";

            return View("CustomerForm", viewModel);
        }

        // Action that saves the customer to the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            // Check to see if this is a new customer, if not, update the customer.
            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            db.SaveChanges(); // This saves the customer into the database.

            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };

            ViewBag.customerId = customer.Id;
            ViewBag.Title = "Edit Customer";

            return View("CustomerForm", viewModel);


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
