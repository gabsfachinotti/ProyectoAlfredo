using ProyectoAlfredo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Repositories
{
    public class PurchaseRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<Product> ProductList()
        {
            var productsList = db.Set<Product>().ToList();
            productsList.Add(new Product { ProductID = 0, Description = "Seleccione un Producto..." });
            productsList.OrderBy(p => p.Description).ToList();

            return productsList;
        }

        public IList<Provider> ProviderList()
        {
            var providersList = db.Set<Provider>().ToList();
            providersList.Add(new Provider { ProviderID = 0, ProviderName = "Seleccione un Proveedor..." });
            providersList.OrderBy(p => p.ProviderName).ToList();

            return providersList;
        }
    }
}