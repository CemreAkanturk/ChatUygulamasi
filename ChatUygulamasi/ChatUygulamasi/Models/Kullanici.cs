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
        public Kullanici()
        {
            this.Mesajs = new HashSet<Mesaj>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string KullaniciAdi { get; set; }

        public bool Durumu { get; set; }

        public virtual ICollection<Mesaj> Mesajs { get; set; }


    }
}