using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Asignatura : BaseEntidad
    {
        public Asignatura()
        {
            AsignaturaCorrelativaAsignatura = new HashSet<AsignaturaCorrelativa>();
            AsignaturaCorrelativaCorrelativa = new HashSet<AsignaturaCorrelativa>();
        }

        public long? UniversidadId { get; set; }
        public long? CarreraId { get; set; }
        public string Nombre { get; set; }
        public int Cuatrimestre { get; set; }
        public byte CargaHoraria { get; set; }
        public bool EsAsignaturaComun { get; set; }
        public string Codigo { get; set; }

        public virtual Carrera Carrera { get; set; }
        public virtual Universidad Universidad { get; set; }
        public virtual ICollection<AsignaturaCorrelativa> AsignaturaCorrelativaAsignatura { get; set; }
        public virtual ICollection<AsignaturaCorrelativa> AsignaturaCorrelativaCorrelativa { get; set; }
    }
}
