from app import db
from app.models.universidad import Universidad
from app.schemas.universidad import UniversidadSchema
from app.models.departamento import Departamento


class UniversidadService:

    session = db.session

    def __init__(self, session=None):
        if session is not None:
            self.session = session


    def get_all(self, ):
        return Universidad.query.all()
    
    
    def get(self, id):
        universidad = Universidad.query.filter_by(id=id).one()
        return universidad
    

    def create(self, data):
        schema = UniversidadSchema().load(data)
        universidad = Universidad(schema['codigo'], schema['nombre'])
        self.add_relationships(universidad, schema)

        self.session.add(universidad)
        self.session.commit()

        return universidad


    def update(self, id, data):
        schema = UniversidadSchema().load(data)
        universidad = Universidad.query.filter_by(id=id).one()
        universidad.codigo = schema['codigo']
        universidad.nombre = schema['nombre']
        self.update_relationships(universidad, schema)

        self.session.commit()

        return universidad


    def delete(self, id):
        universidad = Universidad.query.filter_by(id=id).one()
        self.session.delete(universidad)
        self.session.commit()


    def add_relationships(self, entity, schema):
        self.add_departamentos(entity, schema)


    def add_departamentos(self, entity, schema):
        departamentos = schema['departamentos']
        for schema_agregar in departamentos:
            model = Departamento(schema_agregar['nombre'])
            entity.departamentos.append(model)


    def update_relationships(self, entity, schema):
        self.update_departamentos(entity, schema)


    def update_departamentos(self, entity, schema):
        departamentos = schema['departamentos']
        departamentos_model = Departamento.query.filter_by(universidad_id=entity.id).all()
        ids = list(map(lambda x: x.id, departamentos_model))

        departamentos_actualizar = list(filter(lambda x: x['id'] != 0, departamentos))
        for schema_actualizar in departamentos_actualizar:
            model = Departamento.query.filter_by(id=schema_actualizar['id']).first()
            if model is not None:
                model.nombre = schema_actualizar['nombre']

        departamtentos_eliminar = list(filter(lambda x: x['id'] not in ids and x['id'] != 0, departamentos))
        for schema_eliminar in departamtentos_eliminar:
            model = Departamento.query.filter_by(id=schema_eliminar['id']).first()
            if model is not None:
                self.session.delete(model)

        departamentos_agregar = list(filter(lambda x: x['id'] == 0, departamentos))
        for schema_agregar in departamentos_agregar:
            model = Departamento(schema_agregar['nombre'])
            model.universidad_id = entity.id
            self.session.add(model)
