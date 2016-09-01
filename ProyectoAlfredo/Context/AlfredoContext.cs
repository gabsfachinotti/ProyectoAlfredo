using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Context
{
    public class AlfredoContext: DbContext
    {
        public AlfredoContext()
            : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<ProyectoAlfredo.Models.Sale> Sales { get; set; }
    }
}