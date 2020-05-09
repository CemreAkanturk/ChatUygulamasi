using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatUygulamasi.Models
{
    public class Mesaj
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string GonderenAdi { get; set; }

        public string AliciAdi { get; set; }

        public string MesajMetin { get; set; }

        public DateTime Tarih { get; set; }

    

    }
}