using System.Collections.Generic;

namespace vojaro.core.Entities
{
    public partial class TipoCarrera
    {
        public TipoCarrera()
        {
            Carrera = new HashSet<Carrera>();
        }

        public byte Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Carrera> Carrera { get; set; }
    }
}
