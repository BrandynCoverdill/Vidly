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

        }
    }
}