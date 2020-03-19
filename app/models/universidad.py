#!flask/bin/python
from app import db
from app.models import Entity


class Universidad(db.Model, Entity):
    __tablename__ = 'Universidades'

    codigo = db.Column(db.String, unique=True)
    nombre = db.Column(db.String)

    def __init__(self, codigo, nombre, creado_por):
        Entity.__init__(self, creado_por)
        self.codigo = codigo
        self.nombre = nombre

    def __repr__(self):
        return '<Universidad {}>'.format(self.codigo)
