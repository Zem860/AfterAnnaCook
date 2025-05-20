using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Models
{
    public partial class HW1 : DbContext
    {
        public HW1()
            : base("name=HW11")
        {

        }
        public virtual DbSet<Counties> Counties { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
