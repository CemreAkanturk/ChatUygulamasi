using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatUygulamasi.Models
{
    public class Kullanici
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string connectionId { get; set; }
        public string KullaniciAdi { get; set; }

        public string Durum { get; set; }

        public DateTime? CikisTarih { get; set; }

    }
}