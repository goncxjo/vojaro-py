using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Carrera : BaseEntidad
    {
        public Carrera()
        {
            AlumnoAsignatura = new HashSet<AlumnoAsignatura>();
            Asignatura = new HashSet<Asignatura>();
            CarreraOrientacion = new HashSet<CarreraOrientacion>();
        }

        public byte? TipoCarreraId { get; set; }
        public long? DepartamentoUniversidadId { get; set; }
        public long? UniversidadId { get; set; }
        public string Nombre { get; set; }
        public byte Duracion { get; set; }

        public virtual DepartamentoUniversidad DepartamentoUniversidad { get; set; }
        public virtual TipoCarrera TipoCarrera { get; set; }
        public virtual Universidad Universidad { get; set; }
        public virtual ICollection<AlumnoAsignatura> AlumnoAsignatura { get; set; }
        public virtual ICollection<Asignatura> Asignatura { get; set; }
        public virtual ICollection<CarreraOrientacion> CarreraOrientacion { get; set; }
    }
}
