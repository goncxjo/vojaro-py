using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.test.Services
{
    public abstract class BaseServiceTest
    {
        protected static VojaroDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<VojaroDbContext>()
                .UseInMemoryDatabase(databaseName: "vojaro_db")
                .Options;
            var context = new VojaroDbContext(options);
            GenerateData(context);
            return context;
        }

        private static void GenerateData(VojaroDbContext context)
        {
            var tipoCarreras = new List<TipoCarrera>()
            {
                new TipoCarrera { Id = 1, Nombre = "Pregrado" },
                new TipoCarrera { Id = 2, Nombre = "Grado" },
                new TipoCarrera { Id = 3, Nombre = "Posgrado" }
            };

            var universidades = new List<Universidad>()
            {
                new Universidad { Id = 1, Nombre = "Universidad Nacional de Avellaneda", Codigo = "UNDAV" }
            };

            var ami = new Asignatura { Id = 1, Nombre = "Análisis Matemático I" };
            var inf = new Asignatura { Id = 3, Nombre = "Informática" };
            var aed = new Asignatura { Id = 4, Nombre = "Algoritmos y Estructura de Datos" };
            var aga = new Asignatura { Id = 5, Nombre = "Álgebra y Geometría Analítica" };
            var asignaturas = new List<Asignatura>() { ami, inf, aed, aga };

            var correlativas = new List<AsignaturaCorrelativa>()
            {
                new AsignaturaCorrelativa { Asignatura = ami, Correlativa = aed, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = ami, Correlativa = aga, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = inf, Correlativa = aed, Aprobada = true }
            };

            var carreras = new List<Carrera>()
            {
                new Carrera { Id = 1, Nombre = "Ingeniería Informática", Duracion = 5, TipoCarrera = tipoCarreras[1], Asignatura = { ami, inf, aed, aga } }
            };

            context.Set<TipoCarrera>().AddRange(tipoCarreras);
            context.Set<Universidad>().AddRange(universidades);
            context.Set<Asignatura>().AddRange(asignaturas);
            context.Set<AsignaturaCorrelativa>().AddRange(correlativas);
            context.Set<Carrera>().AddRange(carreras);

            context.SaveChanges();
        }
    }
}