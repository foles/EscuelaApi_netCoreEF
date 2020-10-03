using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSchoolApi.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Foto { get; set; }
        public DateTime Fechanac { get; set; }
        public Escuela Escuela { get; set; }
        public int EscuelaId { get; set; }




    }
}
