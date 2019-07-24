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
            var asignatura = repository.Obtener(idAsignatura);

            var asignaturasCorrelativas = new List<Asignatura>();
            if(asignatura.Dependencias.Any())
            {
                asignaturasCorrelativas.AddRange(
                    asignatura.Dependencias.Select(ac => ac.Asignatura).Distinct()
                );
            }
            if (asignatura.Correlativas.Any())
            {
                asignaturasCorrelativas.AddRange(
                    asignatura.Correlativas.Select(ac => ac.Correlativa).Distinct()
                );
            }

            return asignaturasCorrelativas.AsEnumerable();
        }
    }
}
