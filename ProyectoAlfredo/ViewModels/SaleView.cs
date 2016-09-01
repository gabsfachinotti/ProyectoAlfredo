using ProyectoAlfredo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.ViewModels
{
    public class SaleView
    {
        public Customer Customer { get; set; }

        [Display(Name = "Fecha de Venta")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Fecha de Carga")]
        public DateTime UploadDate { get; set; }

        public Product Product { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}