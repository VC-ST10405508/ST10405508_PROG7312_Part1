using Microsoft.EntityFrameworkCore;
using ST10405508_PROG7312_Part1.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ST10405508_PROG7312_Part1.Data
{
    public class AppDbContext : DbContext
    {
        //a constructor that will call from the entity framework predefined class (Teddy Smith, 2022):
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //vars that will store info regarding db (TeddySmith, 2022):
        public DbSet<User> users { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<ReportIssue> reportIssues { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique email
            modelBuilder.Entity<User>()
                .HasIndex(u => u.email)
                .IsUnique();
        }
    }
}
//Reference List:

//Teddy Smith. 2022. ASP.NET Core MVC 2022 - 3. Installing Entity Framework + DB context. [Video Online]. Avaliable at: https://www.youtube.com/watch?v=af_tK9LUiX0&list=PL82C6-O4XrHde_urqhKJHH-HTUfTK6siO&index=3&ab_channel=TeddySmith [Accessed 6 September 2025].
