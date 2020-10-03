using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSchoolApi.Models
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Logo { get; set; }
        public Profesor Profesor { get; set; }
        public int ProfesorId { get; set; }

    }
}
