from .base import BaseEntityService

from app.api.repositories.departamento import DepartamentoRepository
from app.api.repositories import universidad_repository, departamento_repository
from app.api.schemas.universidad import UniversidadSchema
from app.models.universidad import Universidad
from app.models.departamento import Departamento


class UniversidadService(BaseEntityService):

    departamento_repository: DepartamentoRepository

    def __init__(self):
        self.repository = universidad_repository
        self.departamento_repository = departamento_repository

    # ADD
    def add_entity(self, data):
        schema = UniversidadSchema().load(data)
        universidad = Universidad(schema['codigo'], schema['nombre'])
        self.add_relationships(universidad, schema)

        return universidad

    def add_relationships(self, entity, schema):
        self.add_departamentos(entity, schema)

    def add_departamentos(self, entity, schema):
        if 'departamentos' in schema:
            departamentos = schema['departamentos']
            for schema_agregar in departamentos:
                model = Departamento(schema_agregar['nombre'])
                entity.departamentos.append(model)

    # UPDATE
    def update_entity(self, id, data):
        universidad = self.get(id)
        schema = UniversidadSchema().load(data)
        universidad.codigo = schema['codigo']
        universidad.nombre = schema['nombre']
        self.update_relationships(universidad, schema)

        return universidad

    def update_relationships(self, entity, schema):
        self.update_departamentos(entity, schema)

    def update_departamentos(self, entity, schema):
        if 'departamentos' in schema:
            # TODO: refactorizar
            departamentos = schema['departamentos']
            departamentos_model = Departamento.query.filter_by(universidad_id=entity.id).all()
            ids = list(map(lambda x: x.id, departamentos_model))

            departamentos_actualizar = list(filter(lambda x: x['id'] != 0, departamentos))
            for schema_actualizar in departamentos_actualizar:
                model = departamento_repository.get(schema_actualizar['id'])
                if model is not None:
                    model.nombre = schema_actualizar['nombre']

            departamtentos_eliminar = list(filter(lambda x: x['id'] not in ids and x['id'] != 0, departamentos))
            for schema_eliminar in departamtentos_eliminar:
                model = Departamento.query.filter_by(id=schema_eliminar['id']).first()
                if model is not None:
                    self.departamento_repository.delete(model)

            departamentos_agregar = list(filter(lambda x: x['id'] == 0, departamentos))
            for schema_agregar in departamentos_agregar:
                model = Departamento(schema_agregar['nombre'])
                model.universidad_id = entity.id
                self.departamento_repository.add(model)

