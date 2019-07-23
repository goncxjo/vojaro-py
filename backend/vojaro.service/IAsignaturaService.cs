using System;
using System.Collections.Generic;
using System.Text;
using vojaro.core;
using vojaro.core.Entities;

namespace vojaro.service
{
    public interface IAsignaturaService
    {
        IEnumerable<Asignatura> ObtenerCorrelativas(long id);
        Asignatura ObtenerAsignatura(long idAsignatura);
    }
}
