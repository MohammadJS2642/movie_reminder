using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UserAuth.Models;

namespace UserAuth.DBContext
{
    public partial class MovieReminderAuthenticationDbContext : DbContext
    {
        public MovieReminderAuthenticationDbContext()
        {
        }

        public MovieReminderAuthenticationDbContext(DbContextOptions<MovieReminderAuthenticationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserAuthentication> UserAuthentications { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=movieReminderAuthentication");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAuthentication>(entity =>
            {
                entity.ToTable("UserAuthentication");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Family).HasMaxLength(250);

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
