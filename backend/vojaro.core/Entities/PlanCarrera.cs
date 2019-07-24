using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public class PlanCarrera
    {
        public PlanCarrera()
        {
            Asignaturas = new HashSet<Asignatura>();
            AlumnosAsignaturas = new HashSet<AlumnoAsignatura>();
        }

        public long Id { get; set; }
        public long CarreraId { get; set; }
        public int Anio { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual ICollection<Asignatura> Asignaturas { get; set; }
        public virtual ICollection<AlumnoAsignatura> AlumnosAsignaturas { get; set; }
    }
}
