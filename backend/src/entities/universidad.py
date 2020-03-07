# coding=utf-8

from src import db
from datetime import datetime
from marshmallow import Schema, fields

from .entity import Entity

class Universidad(db.Model, Entity):
    codigo = db.Column(db.String)
    nombre = db.Column(db.String)

    def __init__(self, codigo, nombre, creado_por):
        Entity.__init__(self, creado_por)
        self.codigo = codigo
        self.nombre = nombre
    
    def __repr__(self):
        return '<Universidad {}>'.format(self.codigo)

class UniversidadSchema(Schema):
    id = fields.Number()
    codigo = fields.Str()
    nombre = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()