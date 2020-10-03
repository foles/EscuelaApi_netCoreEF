using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSchoolApi.Models
{
   
    public class SchoolDBContext : DbContext
    {
        
        public  DbSet<Escuela> Escuela { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Trabajo> Trabajo { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=SchoolDB;Integrated Security=True");
        }
    }
}
