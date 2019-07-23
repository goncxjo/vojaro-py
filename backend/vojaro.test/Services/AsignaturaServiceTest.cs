using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using vojaro.core.Entities;
using vojaro.core.Interfaces;
using vojaro.infrastructure.Data;
using vojaro.infrastructure.Repositories;
using vojaro.service;

namespace vojaro.test.Services
{
    public class AsignaturaServiceTest : BaseServiceTest
    {
        private IAsignaturaService asignaturaService;
        private IRepository<Asignatura> asignaturaRepository;

        [SetUp]
        public void Setup()
        {
            VojaroDbContext context = GetDbContext();
            asignaturaRepository = new AsignaturaRepository(context);
            asignaturaService = new AsignaturaService(asignaturaRepository);
        }

        [Test]
        public void ObtenerCorrelativas_Asignatura_Tiene_Dos_Correlativas()
        {
            long idAsignatura = 1; // Análisis Matemático I (UNDAV)
            IEnumerable<Asignatura> correlativas = asignaturaService.ObtenerCorrelativas(idAsignatura);
            Assert.That(correlativas.Count() == 2);
        }
    }
}
