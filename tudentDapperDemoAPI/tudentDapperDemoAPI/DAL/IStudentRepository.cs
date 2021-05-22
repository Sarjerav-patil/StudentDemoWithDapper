using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentDapperDemoAPI.Models;

namespace StudentDapperDemoAPI.DAL
{
  internal interface IStudentRepository
    {
        List<Student> GetStudents(int amount, string sort);
        Student GetSingleStudent(int StudId);
        void InsertStudent(Student ourStudent);
        void DeleteStudent(int StudId);
        void UpdateStudent(Student ourStudent);
        void Save();
    }
    public partial class StudentDbContext : DbContext
    {
        public StudentDbContext() { }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        //public StudentDbContext(string connectionString) : base(GetOptions(connectionString)) { }

     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"),null);
        }

        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        //private static DbContextOptions GetOptions(string connectionString)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
