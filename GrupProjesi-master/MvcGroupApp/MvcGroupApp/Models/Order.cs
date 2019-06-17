using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MvcGroupApp.Models
{
    public class Order : BaseEntity
    {
        [DisplayName("Sipariş Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime OrderDate { get; set; }


        [DisplayName("Toplam Tutar")]
        public float OrderTotalPrice { get; set; }


        [StringLength(250, ErrorMessage = "250 karakterden fazla giriş yaptınız.")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Adres")]
        public string OrderAddress { get; set; }
        

        public virtual ICollection<OrderDetails> orderDetails { get; set; }


        [DisplayName("Kullanıcı")]
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        [DisplayName("Kullanıcı")]
        public virtual User user { get; set; }

        // marka ile ürün arasındaki n-m ilişkiyi 1-n ilişki olarak yaptığımız için, eklenmesicgerekli olan özellik, her ürünün Model numarası farklı olduğu için n-m ilişkiyi 1-n şeklinde yazabiliriz. 
        [DisplayName("Model Numarası")]
        public int ModelNumber { get; set; }

    }
}