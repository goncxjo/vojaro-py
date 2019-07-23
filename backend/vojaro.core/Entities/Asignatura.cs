using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Asignatura : BaseEntidad
    {
        public Asignatura()
        {
            CorrelativasAnteriores = new HashSet<AsignaturaCorrelativa>();
            CorrelativasPosteriores = new HashSet<AsignaturaCorrelativa>();
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
        public virtual ICollection<AsignaturaCorrelativa> CorrelativasAnteriores { get; set; }
        public virtual ICollection<AsignaturaCorrelativa> CorrelativasPosteriores { get; set; }
    }
}
