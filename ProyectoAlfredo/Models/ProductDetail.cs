using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class ProductDetail: Product
    {
        public float Quantity { get; set; }

        public decimal TotalDetail { get { return (decimal)Quantity * SalePrice; } }
    }
}