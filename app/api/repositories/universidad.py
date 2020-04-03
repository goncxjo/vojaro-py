from .base import BaseEntityRepository
from app.models.universidad import Universidad


class UniversidadRepository(BaseEntityRepository):

    Entity = Universidad
    sortable_columns = {
        'codigo': 'codigo',
        'nombre': 'nombre'
    }

    def apply_filters(self, query, filters):
        if filters is not None:
            # TODO: refactorizar esto
            if 'codigo' in filters:
                search = "%{}%".format(filters['codigo'])
                query = query.filter(Universidad.codigo.ilike(search))
            if 'nombre' in filters:
                search = "%{}%".format(filters['nombre'])
                query = query.filter(Universidad.nombre.ilike(search))

        return query
