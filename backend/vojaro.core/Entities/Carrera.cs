using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class Carrera : IBaseEntidad
    {
        public Carrera()
        {
            Planes = new HashSet<PlanCarrera>();
            Orientaciones = new HashSet<CarreraOrientacion>();
        }

        public byte? TipoCarreraId { get; set; }
        public long? DepartamentoUniversidadId { get; set; }
        public string Nombre { get; set; }
        public byte Duracion { get; set; }

        public virtual DepartamentoUniversidad DepartamentoUniversidad { get; set; }
        public virtual TipoCarrera TipoCarrera { get; set; }
        public virtual ICollection<PlanCarrera> Planes { get; set; }
        public virtual ICollection<CarreraOrientacion> Orientaciones { get; set; }

        public long Id { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? ModificadoPor { get; set; }
        public int Version { get; set; }
    }
}
