using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class ProductSupplier:BaseEntity
    {
        [DisplayName("Ürün")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [DisplayName("Ürün")]
        public virtual Product product { get; set; }


        [DisplayName("Satıcı")]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        [DisplayName("Satıcı")]
        public virtual Supplier supplier { get; set; }

               
        [DisplayName("Alış Tarihi")]
        public DateTime Date { get; set; }

        [DisplayName("Alış Fiyatı")]
        public float PurchasePrice { get; set; }

        // Örneğin A ürününden kaç tane sipariş verildiğinin bilgisinin tutulması için gerek gördüğüm için ekledim.
        [DisplayName("Sipariş Miktarı")]
        public int OrderAmount { get; set; }
    }
}