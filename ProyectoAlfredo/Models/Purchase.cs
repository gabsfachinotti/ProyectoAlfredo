using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoAlfredo.Models
{
    public class Purchase
    {
        [Key]
        public int PurchaseID { get; set; }

        [Display(Name = "Fecha de Compra")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime DatePurchase { get; set; }

        [Display(Name = "Fecha de Carga")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Campo Obligatorio")]
        public DateTime UploadDate { get; set; }

        public int ProviderID { get; set; } //Clave Foránea de Proveedor (Provider)

        public virtual Provider Provider { get; set; }

        public virtual ICollection<ProductPurchase> Products { get; set; }

        [Display(Name = "Cantidad Comprada")]
        public float Quantity { get; set; }
    }
}