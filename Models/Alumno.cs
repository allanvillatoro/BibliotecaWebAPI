using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaAPIREST.Models
{
    public class Alumno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int cuenta { get; set; }
        public string nombres { get; set; }
        public string carrera { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; } //es para hacer consultas inner join
    }
}
