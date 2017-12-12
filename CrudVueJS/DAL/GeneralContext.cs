using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CrudVueJS.Models;

namespace CrudVueJS.DAL
{
    public class GeneralContext:DbContext
    {

        public GeneralContext():base("name=MyDB") { }

        public DbSet<Personas> Personas { get; set; }

    }
}