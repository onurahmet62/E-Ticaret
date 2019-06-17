using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class Category : BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        public virtual ICollection<Product> product { get; set; }
       
    }
}