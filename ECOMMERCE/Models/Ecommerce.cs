using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ECOMMERCE.Models
{
    public class ECommerce : DbContext
    {
        public ECommerce() : base("Ecommerce")
        {

        }
        public DbSet<Product> products { get; set; }
    }
}