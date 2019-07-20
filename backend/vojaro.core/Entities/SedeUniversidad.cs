using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class SedeUniversidad : BaseEntidad
    {
        public long? UniversidadId { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }

        public virtual Universidad Universidad { get; set; }
    }
}
