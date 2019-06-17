using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MvcGroupApp.Models
{
    public class Supplier : BaseEntity
    {
        [StringLength(200, ErrorMessage = "200 karakter aşılamaz.")]
        [DisplayName("Tedarikçi Adı")]

        public string SupplierName { get; set; }
        [DisplayName("Tedarikçi Soyadı")]
        [StringLength(200, ErrorMessage = "200 karakter aşılamaz.")]

        public string SupplierSurname { get; set; }
        [DisplayName("Tedarikçi Adresi")]
        [StringLength(200, ErrorMessage = "200 karakter aşılamaz.")]

        public string SupplierAddress { get; set; }
        [DisplayName("Tedarikçi Telefonu")]
        [StringLength(200, ErrorMessage = "200 karakter aşılamaz.")]

        public string SupplierPhone { get; set; }
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }  // iliskide 1 olan kisim
    }
}