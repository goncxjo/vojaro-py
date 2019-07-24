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
                new Universidad { Codigo = "UNDAV", Nombre = "Universidad Nacional de Avellaneda" }
            };

            var ami = new Asignatura { Id = 1, Nombre = "Análisis Matemático I" };
            var inf = new Asignatura { Id = 2, Nombre = "Informática" };
            var fii = new Asignatura { Id = 3, Nombre = "Física I" };
            var aed = new Asignatura { Id = 4, Nombre = "Algoritmos y Estructura de Datos" };
            var aga = new Asignatura { Id = 5, Nombre = "Álgebra y Geometría Analítica" };
            var api = new Asignatura { Id = 6, Nombre = "Algoritmos y Programación I" };
            var asignaturas = new List<Asignatura>() { ami, inf, aed, aga };

            var correlativas = new List<AsignaturaCorrelativa>()
            {
                new AsignaturaCorrelativa { Asignatura = ami, Correlativa = aed, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = ami, Correlativa = aga, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = ami, Correlativa = fii, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = inf, Correlativa = aed, Aprobada = true },
                new AsignaturaCorrelativa { Asignatura = aed, Correlativa = api, Aprobada = true }
            };

            var planes = new List<PlanCarrera>()
            {
                new PlanCarrera { CarreraId = 1, Anio = 2012, Asignaturas = { ami, inf, aed, aga }  }
            };

            var carreras = new List<Carrera>()
            {
                new Carrera { Id = 1, Nombre = "Ingeniería Informática", Duracion = 5, TipoCarrera = tipoCarreras[1], Planes = planes }
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