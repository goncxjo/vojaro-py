from app import db
from app.models.universidad import Universidad
from app.schemas.universidad import UniversidadSchema


def get_all():
    return Universidad.query.all()


def get(id):
    universidad = Universidad.query.filter_by(id=id).one()
    db.session.close()
    return universidad


def create(data):
    schema = UniversidadSchema(only=('codigo', 'nombre')).load(data)
    universidad = Universidad(**schema, creado_por='HTTP POST REQUEST')

    db.session.add(universidad)
    db.session.commit()
    db.session.close()


def update(id, data):
    schema = UniversidadSchema().load(data)
    universidad = Universidad.query.filter_by(id=id).one()
    universidad.codigo = schema['codigo']
    universidad.nombre = schema['nombre']
    universidad.departamentos = schema['departamentos']

    db.session.commit()
    db.session.close()


def delete(id):
    universidad = Universidad.query.filter_by(id=id).one()
    db.session.delete(universidad)
    db.session.commit()
    db.session.close()
