using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class CarreraOrientacion : BaseEntidad
    {
        public long? CarreraId { get; set; }
        public string Nombre { get; set; }

        public virtual Carrera Carrera { get; set; }
    }
}
