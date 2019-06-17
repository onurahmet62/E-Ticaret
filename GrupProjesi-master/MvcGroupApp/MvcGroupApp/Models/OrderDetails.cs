using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class OrderDetails:BaseEntity
    {
        [DisplayName("Sipariş Toplam Tutarı")]
        public int Total { get; set; }

        [DisplayName("Sipariş Fiyatı")]
        public float Price { get; set; }


        [DisplayName("Sipariş")]
        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        [DisplayName("Sipariş")]
        public virtual Order order { get; set; }


        [DisplayName("Ürün")]
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        [DisplayName("Ürün")]
        public virtual Product product { get; set; }
    }
}