using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Display(Name = "Costo por unidad")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Precio de Venta por unidad")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal SalePrice { get; set; }

        [Display(Name = "Última Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime LastPurchase { get; set; }

        [Display(Name = "Fecha de Carga")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime UploadDate { get; set; }

        public float Stock { get; set; }

        [Display(Name ="Stock mínimo")]
        public float minimum { get; set; }

        public bool State { get; set; }

        public int CategoryID { get; set; } //Clave Foránea de Rubro (Category)

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductPurchase> Purchases { get; set; }
        public virtual ICollection<ProductProvider> Providers { get; set; }
        public virtual ICollection<ProductSale> Sales { get; set; }
    }
}
