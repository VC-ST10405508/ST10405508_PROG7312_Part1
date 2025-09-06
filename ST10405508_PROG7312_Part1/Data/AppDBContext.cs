using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ST10405508_PROG7312_Part1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<ReportIssue> reportIssues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();
        }
    }
}
