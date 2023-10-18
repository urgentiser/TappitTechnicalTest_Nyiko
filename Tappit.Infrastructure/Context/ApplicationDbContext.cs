using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tappit.Domain;

namespace Tappit.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("People", "TappitTechnicalTest");
            });
            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports", "TappitTechnicalTest");
            });
            modelBuilder.Entity<FavouriteSport>(entity =>
            {
                entity.ToTable("FavouriteSports", "TappitTechnicalTest");
            });

        }

        public DbSet<Person> People => Set<Person>();
        public DbSet<Sport> Sports => Set<Sport>();
        public DbSet<FavouriteSport> FavouriteSports => Set<FavouriteSport>();
        
    }
}
