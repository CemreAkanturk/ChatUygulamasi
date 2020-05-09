using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatUygulamasi.Models
{
    public class DataContext:DbContext
    {

        public virtual DbSet<Mesaj> Mesajs { get; set; }
      

    }
}