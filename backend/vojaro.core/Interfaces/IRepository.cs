using System.Linq;
using vojaro.core.Entities;

namespace vojaro.core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObtenerTodos();
        T Obtener(long id);
        void Agregar(T entity);
        void Borrar(T entity);
        void Actualizar(T entity);
        void GuardarCambios();
    }
}
