using NUnit.Framework;
using System.Collections.Generic;
using vojaro.core.Entities;
using vojaro.service;

namespace vojaro.test.Services
{
    public class AsignaturaServiceTest
    {
        private IAsignaturaService asignaturaService;

        [SetUp]
        public void Setup()
        {
            asignaturaService = new AsignaturaService();
        }

        [Test]
        public void ObtenerCorrelativas()
        {
            long idAsignatura = 1;
            IEnumerable<Asignatura> correlativas = asignaturaService.ObtenerCorrelativas(idAsignatura);
            Assert.IsNotEmpty(correlativas);
        }
    }
}
