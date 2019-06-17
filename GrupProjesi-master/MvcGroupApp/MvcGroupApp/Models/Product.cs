using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcGroupApp.Models
{
    public class Product : BaseEntity
    {
        [StringLength(200, ErrorMessage = "200 karakterden fazla giriş yaptınız")]
        [Required(ErrorMessage = "Bu Alan Zorunludur")]
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [DisplayName("Ürün Resmi")]
        public string ProductPhoto { get; set; }

        [DisplayName("Ürün Fiyatı")]
        public float ProductPrice { get; set; }


        [DisplayName("Marka")]
        public int? BrandsId { get; set; }
        [ForeignKey("BrandsId")]
        [DisplayName("Marka")]
        public virtual Brand Brand { get; set; }
        

        [DisplayName("Kategori")]
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [DisplayName("Kategori")]
        public virtual Category Categories { get; set; }


        public virtual ICollection<Basket> Baskets { get; set; }  // iliskide 1 olan kisim
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }  // iliskide 1 olan kisim
        public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }  // iliskide 1 olan kısım


        // Stok durumunu ayrı tablo yazmıştık ürüntedarikçi tablosuna toplam tutar miktarını eklediğim için stok durumunu tekrardan buraya çektim .

        [DisplayName("Stok Durumu")]
        public int StokState { get; set; }

        //  ek olarak ürünün silinmesi durumunda oluşacak  aksaklığı önlemek için olması gereken özellik
        [DisplayName("Silindi Mi")]
        public bool IsItDeleted { get; set; }

    }

}