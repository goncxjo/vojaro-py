using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Universidad : BaseEntidad
    {
        public Universidad()
        {
            Asignatura = new HashSet<Asignatura>();
            Carrera = new HashSet<Carrera>();
            DepartamentoUniversidad = new HashSet<DepartamentoUniversidad>();
            SedeUniversidad = new HashSet<SedeUniversidad>();
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Asignatura> Asignatura { get; set; }
        public virtual ICollection<Carrera> Carrera { get; set; }
        public virtual ICollection<DepartamentoUniversidad> DepartamentoUniversidad { get; set; }
        public virtual ICollection<SedeUniversidad> SedeUniversidad { get; set; }
    }
}
