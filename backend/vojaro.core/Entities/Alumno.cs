using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Alumno : IBaseEntidad
    {
        public Alumno()
        {
            AlumnoAsignatura = new HashSet<AlumnoAsignatura>();
        }

        public long DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public virtual ICollection<AlumnoAsignatura> AlumnoAsignatura { get; set; }

        public long Id => this.DNI;
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? ModificadoPor { get; set; }
        public int Version { get; set; }
    }
}
