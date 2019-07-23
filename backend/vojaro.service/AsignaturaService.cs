using System;
using System.Collections.Generic;
using System.Linq;
using vojaro.core.Entities;
using vojaro.core.Interfaces;

namespace vojaro.service
{
    public class AsignaturaService : IAsignaturaService
    {
        private readonly IRepository<Asignatura> repository;

        public AsignaturaService(IRepository<Asignatura> repository)
        {
            this.repository = repository;
        }

        public Asignatura ObtenerAsignatura(long id)
        {
            return repository.Obtener(id);
        }

        public IEnumerable<Asignatura> ObtenerCorrelativas(long idAsignatura)
        {
            IEnumerable<Asignatura> asignaturasCorrelativas = new List<Asignatura>();
            var correlativas = repository.ObtenerTodos().Select(x => x.CorrelativasPosteriores);

            if(correlativas.Any())
            {
                asignaturasCorrelativas = correlativas.SelectMany(ac => ac.Select(x => x.Correlativa)).Distinct();
            }

            return asignaturasCorrelativas;
        }
    }
}
