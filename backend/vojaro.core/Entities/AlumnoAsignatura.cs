using System;

namespace vojaro.core.Entities
{
    public partial class AlumnoAsignatura
    {
        public long? AlumnoId { get; set; }
        public long? CarreraId { get; set; }
        public string EstadoAsignatura { get; set; }
        public DateTime FechaCarga { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual PlanCarrera PlanCarrera { get; set; }
    }
}
