using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPIREST.Models
{
    public class Libro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public int anio { get; set; }
        public decimal multapordia { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; } //es para hacer consultas inner join
    }
}
