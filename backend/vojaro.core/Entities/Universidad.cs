using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Universidad : IBaseEntidad
    {
        public Universidad()
        {
            Departamentos = new HashSet<DepartamentoUniversidad>();
            Sedes = new HashSet<SedeUniversidad>();
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<DepartamentoUniversidad> Departamentos { get; set; }
        public virtual ICollection<SedeUniversidad> Sedes { get; set; }

        public long Id => 0;
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? ModificadoPor { get; set; }
        public int Version { get; set; }
    }
}
