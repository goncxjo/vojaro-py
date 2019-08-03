﻿using System;
using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class SedeUniversidad
    {
        public long Id { get; set; }
        public long UniversidadId { get; set; }
        public string Nombre { get; set; }

        public virtual Universidad Universidad { get; set; }
    }
}
