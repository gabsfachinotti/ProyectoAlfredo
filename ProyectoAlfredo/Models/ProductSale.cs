using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class ProductSale
    {
        [Key]
        public int ProductSaleID { get; set; }
        public int ProductID { get; set; } //Clave Foránea Producto (Product)
        public int SaleID { get; set; } //Clave Foránea Venta (Sale)

        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
    }
}