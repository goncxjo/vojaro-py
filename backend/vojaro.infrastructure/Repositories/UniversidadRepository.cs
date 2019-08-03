using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Repositories
{
    public class UniversidadRepository : BaseEntidadRepository<Universidad>
    {
        public UniversidadRepository(VojaroDbContext context) : base(context)
        {
        }
    }
}
