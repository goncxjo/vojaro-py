using System.Linq;
using vojaro.core;
using vojaro.core.Entities;

namespace vojaro.infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntidad
    {
        IQueryable<T> ObtenerTodos();
        T Obtener(long id);
        void Agregar(T entity);
        void Borrar(T entity);
        void Actualizar(T entity);
        void GuardarCambios();
    }
}
