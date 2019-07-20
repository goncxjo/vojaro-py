using System;
 
namespace vojaro.core.Entities
{
    public class BaseEntidad
    {
        public long Id { get; set; }
        public DateTime FechaCarga { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public long? ModificadoPor { get; set; }
        public int Version { get; set; }
    }
}
