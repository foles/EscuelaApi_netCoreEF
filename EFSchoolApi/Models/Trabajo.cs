using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFSchoolApi.Models
{
    public class Trabajo
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public int Nota { get; set; }
        public string Fechaent { get; set; }
        public Estudiante Estudiante { get; set; }
        public int EstudianteId { get; set; }
    }
}
