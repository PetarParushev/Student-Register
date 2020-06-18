using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentRegister.Data.Context
{
    public class StudentRegisterDBContext : IdentityDbContext
    {
        public StudentRegisterDBContext()
        {

        }

        public StudentRegisterDBContext(DbContextOptions<StudentRegisterDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=localhost;Database=StudentRegisterDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>().HasIndex(s => s.FacultyNumber).IsUnique();
        }
    }
}
