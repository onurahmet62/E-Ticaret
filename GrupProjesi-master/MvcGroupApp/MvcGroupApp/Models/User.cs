using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{

    public class User : BaseEntity
    {
        //AspUsers tablosundan gelen UserID
        public string UserId { get; set; }

        [StringLength(200, ErrorMessage = "50 karakterden fazla girdiniz.")]
        //[Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Adı")]
        public string UserName { get; set; }


        [StringLength(200, ErrorMessage = "50 karakterden fazla girdiniz.")]
        //[Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Soyadı")]
        public string UserSurname { get; set; }


        [StringLength(200, ErrorMessage = "50 karakterden fazla girdiniz.")]
      //  [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Eposta")]
        public string UserMail { get; set; }


        [StringLength(200, ErrorMessage = "20 karakterden fazla girdiniz.")]
       // [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Telefon")]
        public string UserPhone { get; set; }


        [StringLength(200, ErrorMessage = "400 karakterden fazla girdiniz.")]
      //  [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Adres")]
        public string UserAddress { get; set; }


        [StringLength(200, ErrorMessage = "Şifreniz en 6")]
        [DisplayName("Şifre")]
        public string UserPassword { get; set; }


        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Kullanıcı Tipi")]
        public string UserType { get; set; }

        public virtual ICollection<Basket> basket { get; set; }
        public virtual ICollection<Order> order { get; set; }

    }
}