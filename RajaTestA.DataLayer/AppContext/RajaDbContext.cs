using Microsoft.EntityFrameworkCore;
using RajaTestA.DomainEntities.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajaTestA.DataLayer.AppContext
{
    public class RajaDbContext : DbContext, IRajaDbContext
    {
        public RajaDbContext()
    {
    }
    public RajaDbContext(DbContextOptions<RajaDbContext> options) : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personnel>().ToTable("Personnels");
            modelBuilder.Entity<Certificate>().ToTable("Certificates");
            modelBuilder.Entity<PersonnelCertificate>().ToTable("PersonnelCertificates");
        }
    }
}
