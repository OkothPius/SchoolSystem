using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KilimoSchoolSystem.Models;
using Stream = KilimoSchoolSystem.Models.Stream;

namespace KilimoSchoolSystem.Data
{
    public class KilimoSchoolSystemContext : DbContext
    {
        public KilimoSchoolSystemContext (DbContextOptions<KilimoSchoolSystemContext> options)
            : base(options)
        {
        }

        public DbSet<KilimoSchoolSystem.Models.Student> Student{ get; set; } = default!;
        public DbSet<KilimoSchoolSystem.Models.Stream> Stream { get; set; }

        // Seeding Data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedDatabase(modelBuilder);
        }

        private void SeedDatabase(ModelBuilder modelBuilder)
        {
            SeedStream(modelBuilder);
            SeedStudent(modelBuilder);
        }

        private void SeedStream(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stream>().HasData(new Stream { StreamId = 1, StreamName = "Form 1A"});
            modelBuilder.Entity<Stream>().HasData(new Stream() { StreamId = 2, StreamName = "Form 1B" });
            modelBuilder.Entity<Stream>().HasData(new Stream() { StreamId = 3, StreamName = "Form 1C" });

        }

        private void SeedStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student 
            { 
                StudentId = 1, 
                AdmissionNumber = "k123/2020",
                Name = "Jake Osin", 
                DOB = DateTime.Parse("2005-2-12"), 
                StreamId = 2 
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 2,
                AdmissionNumber = "k124/2020",
                Name = "Marie Danov",
                DOB = DateTime.Parse("2005-2-12"),
                StreamId = 3
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 3,
                AdmissionNumber = "k125/2020",
                Name = "Paul Morris",
                DOB = DateTime.Parse("2005-2-12"),
                StreamId = 1
            });

            modelBuilder.Entity<Student>().HasData(new Student
            {
                StudentId = 4,
                AdmissionNumber = "k126/2020",
                Name = "Blessing Nuvida",
                DOB = DateTime.Parse("2005-2-12"),
                StreamId = 3
            });
        }
    }
}
