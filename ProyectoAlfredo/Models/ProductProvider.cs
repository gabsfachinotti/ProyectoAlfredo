using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class ProductProvider
    {
        [Key]
        public int ProductProviderID { get; set; }
        public int ProductID { get; set; } //Clave Foránea de Producto (Product)
        public int ProviderID { get; set; } //Clave Foránea de Proveedor (Provider)

        public virtual Product Product { get; set; }
        public virtual Provider Provider { get; set; }
    }
}