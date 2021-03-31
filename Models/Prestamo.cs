using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPIREST.Models
{
    public class Prestamo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id_prestamo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime fecha_entrega { get; set; }
        [Column(TypeName = "Date")]
        public DateTime fecha_a_devolver { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? fecha_devolucion { get; set; }
        public string? observaciones { get; set; }

        public virtual Alumno Alumnos { get; set; } //opcional, para hacer los inner join
        [ForeignKey("Alumnos")]
        public int alumno_cuenta { get; set; }

        public virtual Libro Libros { get; set; } //opcional, para hacer los inner join

        [ForeignKey("Libros")]
        public int libro_id { get; set; }
    }
}
