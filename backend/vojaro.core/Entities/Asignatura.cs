using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Asignatura : IBaseEntidad
    {
        public Asignatura()
        {
            Dependencias = new HashSet<AsignaturaCorrelativa>();
            Correlativas = new HashSet<AsignaturaCorrelativa>();
            AlumnosAsignaturas = new HashSet<AlumnoAsignatura>();
        }

        public long? PlanCarreraId { get; set; }
        public string Nombre { get; set; }
        public int Cuatrimestre { get; set; }
        public byte CargaHoraria { get; set; }
        public string Codigo { get; set; }

        public virtual ICollection<AsignaturaCorrelativa> Dependencias { get; set; }
        public virtual ICollection<AsignaturaCorrelativa> Correlativas { get; set; }
        public virtual ICollection<AlumnoAsignatura> AlumnosAsignaturas { get; set; }

        public long Id { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? ModificadoPor { get; set; }
        public int Version { get; set; }
    }
}
