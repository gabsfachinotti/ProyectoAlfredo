using ProyectoAlfredo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.ViewModels
{
    public class PurchaseView
    {
        [Display(Name = "Proveedor")]
        public Provider Provider { get; set; }

        [Display(Name = "Fecha de Compra")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Fecha de Carga")]
        public DateTime UpdateDate { get; set; }

        public IList<ProductDetail> Products { get; set; }

        public float TotalPurchase { get {float total = 0;
                                            foreach (var item in Products)
                                            { total = total + (float)item.TotalDetail; }
                                            return total ; } }
    }
}