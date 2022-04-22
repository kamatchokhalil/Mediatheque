using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Configurations;
using Domain.Entities;

namespace Data
{
    public class Context: DbContext
    {
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Emprunt> Emprunts { get; set; }
        public DbSet<Livre> Livres { get; set; }
        public DbSet<Mediatheque> Mediatheques { get; set; }
        public DbSet<Video> Videos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source= (localdb)\MSSQLLOCALDB; INITIAL CATALOG= MediathequeProject; INTEGRATED SECURITY= TRUE").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpruntConfig());
        }
    }
}
