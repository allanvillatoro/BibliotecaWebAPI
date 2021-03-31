using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaAPIREST.Models;

namespace BibliotecaAPIREST.Data
{
    public class DbInitializer
    {
        public static void Initialize(BibliotecaDBContext context)
        {
            context.Database.EnsureCreated();

            if (context.Libros.Any())
            {
                return;   // DB has been seeded
            }

            Libro nuevoLibro = new Libro
            {
                id_libro = 235,
                titulo = "Code First",
                autor = "Allan Villatoro",
                anio = 2021,
                multapordia = 20,
            };
            context.Libros.Add(nuevoLibro);
            context.SaveChanges();
        }
    }
}
