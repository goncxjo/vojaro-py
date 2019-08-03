using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class DepartamentoUniversidad
    {
        public DepartamentoUniversidad()
        {
            Carrera = new HashSet<Carrera>();
        }

        public long Id { get; set; }
        public long UniversidadId { get; set; }
        public string Nombre { get; set; }

        public virtual Universidad Universidad { get; set; }
        public virtual ICollection<Carrera> Carrera { get; set; }
    }
}
