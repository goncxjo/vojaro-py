using System;
 
namespace vojaro.core.Entities
{
    public interface IBaseEntidad
    {
        long Id { get; }
        DateTime FechaCarga { get; set; }
        DateTime? FechaModificacion { get; set; }
        long? ModificadoPor { get; set; }
        int Version { get; set; }
    }
}
