using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Alumno : BaseEntidad
    {
        public Alumno()
        {
            AlumnoAsignatura = new HashSet<AlumnoAsignatura>();
        }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        public virtual ICollection<AlumnoAsignatura> AlumnoAsignatura { get; set; }
    }
}
