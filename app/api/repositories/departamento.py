from .base import BaseEntityRepository
from app.models.departamento import Departamento


class DepartamentoRepository(BaseEntityRepository):

    Entity = Departamento

    def apply_filters(self, query, filters):
        # TODO: aplicar filtros para esta entidad
        return query
