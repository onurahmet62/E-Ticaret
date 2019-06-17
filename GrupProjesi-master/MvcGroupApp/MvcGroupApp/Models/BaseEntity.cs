using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcGroupApp.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreateDate { get; set; }

        [DisplayName("Oluşturan Kullanıcı")]
        public string CreatedBy { get; set; }

        [DisplayName("Güncelleme Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime UpdateDate { get; set; }

        [DisplayName("Güncelleyen Kullanıcı")]
        public string UpdatedBy { get; set; }
    }
}