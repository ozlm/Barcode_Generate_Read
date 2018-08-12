using BarkodOkuma.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BarkodOkuma.Models
{
    public class Inheritance
    {
        public VEGADBEntities db { get; set; }
        public Inheritance()
        {
            this.db = new Data.VEGADBEntities();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~Inheritance()
        {
            this.Dispose();
        }
    }
}