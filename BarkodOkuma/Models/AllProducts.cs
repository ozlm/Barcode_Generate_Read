using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarkodOkuma.Data;
namespace BarkodOkuma.Models
{
    public class AllProducts : Inheritance
    {
        public AllProducts()
        {
            base.db = new Data.VEGADBEntities();

        }
        public List<listEnvanter_Result> All()
        {
            return db.listEnvanter().ToList();

        }
    }
}