using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class ProductPurchase
    {
        [Key]
        public int ProductPurchaseID { get; set; }
        public int ProductID { get; set; } //Clave Foránea de Producto (Product)
        public int PurchaseID { get; set; } //Clave Foránea de Compra (Purchase)

        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
    }
}