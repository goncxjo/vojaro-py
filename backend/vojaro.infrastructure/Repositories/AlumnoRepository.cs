using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Repositories
{
    public class AlumnoRepository : BaseEntidadRepository<Alumno>
    {
        public AlumnoRepository(VojaroDbContext context) : base(context)
        {
        }
    }
}
