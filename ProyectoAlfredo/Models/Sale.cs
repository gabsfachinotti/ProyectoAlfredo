using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }

        [Display(Name = "Fecha de Venta")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Fecha de Carga")]
        [Required(ErrorMessage = "Campo Obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime UploadDate { get; set; }

        public int CustomerID { get; set; } //Clave Foránea de Cliente (Customer)

        public virtual Customer Customer { get; set; }
        public virtual ICollection<ProductSale> Products { get; set; }

        [Display(Name = "Cantidad")]
        public float Quantity { get; set; }
    }
}