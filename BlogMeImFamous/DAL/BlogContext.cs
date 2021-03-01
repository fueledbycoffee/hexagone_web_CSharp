using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogMeImFamous.Models;

namespace BlogMeImFamous.DAL
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Commentaire> Commentaires { get; set; }

        public DbSet<User> Users;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseMySQL("server=localhost;database=blogmeimfamous;user=root;password=toto123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Titre).IsRequired();
                entity.Property(e => e.Contenu).IsRequired();
                entity.Property(e => e.DatePublication).IsRequired();
                entity.HasMany(e => e.Commentaires).WithOne(e => e.Parent);
            });

            modelBuilder.Entity<Commentaire>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Contenu).IsRequired();
                entity.Property(e => e.DatePublication).IsRequired();
                entity.HasOne(e => e.Parent).WithMany(e => e.Commentaires);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Username);
            });

        }
    }
}
