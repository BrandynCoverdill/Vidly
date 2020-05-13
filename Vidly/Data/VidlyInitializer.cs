using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<VidlyContext>
    {
        protected override void Seed(VidlyContext context)
        {
            var movies = new List<Movie>
            {
                new Movie {Id = 1, Name="Shrek"},
                new Movie {Id = 2, Name="How To Train Your Dragon"}
            };
            movies.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "John Smith"},
                new Customer {Id = 2, Name = "Mary Williams"}
            };
            customers.ForEach(c => context.Customers.Add(c));
            context.SaveChanges();
        }
    }
}