from app import db
from app.models.universidad import Universidad
from app.schemas.universidad import UniversidadSchema
from app.models.departamento import Departamento


def get_all():
    return Universidad.query.all()


def get(id):
    universidad = Universidad.query.filter_by(id=id).one()
    db.session.close()
    return universidad


def create(data):
    schema = UniversidadSchema().load(data)
    universidad = Universidad(schema['codigo'], schema['nombre'])
    add_relationships(universidad, schema)

    db.session.add(universidad)
    db.session.commit()
    db.session.close()


def update(id, data):
    schema = UniversidadSchema().load(data)
    universidad = Universidad.query.filter_by(id=id).one()
    universidad.codigo = schema['codigo']
    universidad.nombre = schema['nombre']
    update_relationships(universidad, schema)

    db.session.commit()
    db.session.close()


def delete(id):
    universidad = Universidad.query.filter_by(id=id).one()
    db.session.delete(universidad)
    db.session.commit()
    db.session.close()


def add_relationships(entity, schema):
    add_departamentos(entity, schema)


def add_departamentos(entity, schema):
    departamentos = schema['departamentos']
    for schema_agregar in departamentos:
        model = Departamento(schema_agregar['nombre'])
        entity.departamentos.append(model)


def update_relationships(entity, schema):
    update_departamentos(entity, schema)


def update_departamentos(entity, schema):
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
            db.session.delete(model)

    departamentos_agregar = list(filter(lambda x: x['id'] == 0, departamentos))
    for schema_agregar in departamentos_agregar:
        model = Departamento(schema_agregar['nombre'])
        model.universidad_id = entity.id
        db.session.add(model)
