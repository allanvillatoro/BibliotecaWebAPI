using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace BibliotecaAPIREST.Models
{
    public class BibliotecaDBContext: DbContext
    {
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        //Es necesario para configurar Connection String
        public BibliotecaDBContext(DbContextOptions<BibliotecaDBContext> options)
            : base(options)
        {
        }

        //Es necesario para el CodeFirst
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>().ToTable("Libros");
            modelBuilder.Entity<Alumno>().ToTable("Alumnos");
            modelBuilder.Entity<Prestamo>().ToTable("Prestamos");
        }
    }
}
