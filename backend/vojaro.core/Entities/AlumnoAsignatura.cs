using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class AlumnoAsignatura : BaseEntidad
    {
        public long? AlumnoId { get; set; }
        public long? CarreraId { get; set; }
        public string EstadoAsignatura { get; set; }

        public virtual Alumno Alumno { get; set; }
        public virtual Carrera Carrera { get; set; }
    }
}
