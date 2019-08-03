using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Repositories
{
    public class CarreraRepository : BaseEntidadRepository<Carrera>
    {
        public CarreraRepository(VojaroDbContext context) : base(context)
        {
        }
    }
}
