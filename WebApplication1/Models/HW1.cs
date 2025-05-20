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
        public virtual DbSet<FormData> FormDatas { get; set; }
        public virtual DbSet<Others> Others { get; set; }
        public virtual DbSet<ReportType> ReportTypes { get; set; }
        public virtual DbSet<Counties> Counties { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 禁止 Counties 的多重 Cascade
            modelBuilder.Entity<FormData>()
                .HasRequired(f => f.BusinessCounty)
                .WithMany()
                .HasForeignKey(f => f.BusinessCountyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormData>()
                .HasRequired(f => f.ContactCounty)
                .WithMany()
                .HasForeignKey(f => f.ContactCountyId)
                .WillCascadeOnDelete(false);

            // 同樣處理 Districts
            modelBuilder.Entity<FormData>()
                .HasRequired(f => f.BusinessDistrict)
                .WithMany()
                .HasForeignKey(f => f.BusinessDistrictId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FormData>()
                .HasRequired(f => f.ContactDistrict)
                .WithMany()
                .HasForeignKey(f => f.ContactDistrictId)
                .WillCascadeOnDelete(false);
        }

    }
}
