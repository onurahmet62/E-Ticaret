using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class Basket:BaseEntity
    {

        [DisplayName("Sepet Tutarı")]
        public float BasketPrice { get; set; }

        [DisplayName("Adet")]
        public int Amount { get; set; }



        [DisplayName("Ürün")]
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        [DisplayName("Ürün")]
        public virtual Product product { get; set; }



        [DisplayName("Kullanıcı")]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [DisplayName("Kullanıcı")]
        public virtual User user { get; set; }



    }
}