using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }

        [Display(Name = "Proveedor")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public string ProviderName { get; set; }

        [Display(Name = "Teléfono")]
        public int Phone { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<ProductProvider> Products { get; set; }
    }
}