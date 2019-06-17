using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class Brand:BaseEntity
    {
        [StringLength(50)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Marka Adı")]
        public string BrandName { get; set; }

        public virtual ICollection<Product> product { get; set; }
    }
}