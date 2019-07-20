using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using vojaro.core.Entities;
using vojaro.infrastructure.Data;

namespace vojaro.infrastructure.Repositories
{
    public abstract class BaseEntidadRepository<T> : IRepository<T> where T : BaseEntidad
    {
        private readonly VojaroDbContext Context;
        private DbSet<T> Entidades;
        private string MensajeError = string.Empty;

        public BaseEntidadRepository(VojaroDbContext context)
        {
            this.Context = context;
            this.Entidades = context.Set<T>();
        }

        public IQueryable<T> ObtenerTodos()
        {
            return Entidades;
        }

        public T Obtener(long id)
        {
            return Entidades.SingleOrDefault(x => x.Id == id);
        }

        public void Agregar(T entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("entidad");
            }
            Entidades.Add(entidad);
            GuardarCambios();
        }

        public void Actualizar(T entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("entidad");
            }
            GuardarCambios();
        }

        public void Borrar(T entidad)
        {
            if (entidad == null)
            {
                throw new ArgumentNullException("entidad");
            }
            Entidades.Remove(entidad);
            GuardarCambios();
        }

        public void GuardarCambios()
        {
            this.Context.SaveChanges();
        }
    }
}
