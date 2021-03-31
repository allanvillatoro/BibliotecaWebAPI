using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaAPIREST.Models;

namespace BibliotecaAPIREST.Controllers
{
    //Para habilitar el CORS
    [EnableCors("bibliotecaPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private BibliotecaDBContext db;

        public LibrosController(BibliotecaDBContext dbContext)
        {
            this.db = dbContext;
        }
        //GET /api/libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            /*var consultalambda = db.Libros.Where(x => x.titulo.Contains("Progra"))
                                   .OrderBy(x => x.anio);*/
            var consulta = from s in db.Libros
                           select new Book
                           {
                               id_libro = s.id_libro,
                               titulo = s.titulo,
                               autor = s.autor,
                               anio = s.anio,
                               multapordia = s.multapordia
                           };
            return await consulta.ToListAsync();
        }

        //GET /api/libros/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            Libro libroEF = await db.Libros.FindAsync(id);
            if (libroEF != null)
            {
                Book book = new Book
                {
                    id_libro = libroEF.id_libro,
                    titulo = libroEF.titulo,
                    autor = libroEF.autor,
                    anio = libroEF.anio,
                    multapordia = libroEF.multapordia
                };
                return book;
            }
            else
                return NotFound();
        }

        //GET /api/libros/poranio?anio1=2015&anio2=2021
        [HttpGet("poranio")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByYear(int anio1, int anio2)
        {
            if (anio1 >= 0 && anio2 >= anio1)
            {
                var consulta = from s in db.Libros
                               where s.anio >= anio1 && s.anio <= anio2
                               orderby s.anio descending
                               select new Book
                               {
                                   id_libro = s.id_libro,
                                   titulo = s.titulo,
                                   autor = s.autor,
                                   anio = s.anio,
                                   multapordia = s.multapordia
                               };
                return await consulta.ToListAsync();
            }
            else
            {
                return BadRequest();
            }
        }

        //POST /api/libros
        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(Book book)
        {
            try
            {
                Libro libro = new Libro
                {
                    id_libro = book.id_libro,
                    titulo = book.titulo,
                    autor = book.autor,
                    anio = book.anio,
                    multapordia = book.multapordia
                };

                db.Libros.Add(libro);
                int filas = await db.SaveChangesAsync();
                if (filas > 0)
                {
                    return CreatedAtAction("CreateBook", new { status = "Agregado exitosamente" });
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception ex)
            {
                return Conflict();
            }
        }

        //PUT /api/libros/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> EditBook(int id, Book book)
        {
            try
            {
                Libro libroEF = db.Libros.Find(id);
                if (libroEF != null)
                {
                    libroEF.id_libro = book.id_libro;
                    libroEF.titulo = book.titulo;
                    libroEF.autor = book.autor;
                    libroEF.anio = book.anio;
                    libroEF.multapordia = book.multapordia;
                    int filas = await db.SaveChangesAsync();
                    if (filas > 0)
                    {
                        return Ok(new { status = "Modificado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }            
        }

        //DELETE /api/libros/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            try
            {
                Libro libroEF = await db.Libros.FindAsync(id);
                if (libroEF != null)
                {
                    db.Libros.Remove(libroEF);
                    int filas = db.SaveChanges();
                    if (filas > 0)
                    {
                        return Ok(new { status = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(500);
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }                
        }
    }
}
