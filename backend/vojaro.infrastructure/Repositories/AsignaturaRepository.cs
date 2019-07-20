using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Repositories
{
    public class AsignaturaRepository : BaseEntidadRepository<Asignatura>
    {
        public AsignaturaRepository(VojaroDbContext context) : base(context)
        {

        }
    }
}
