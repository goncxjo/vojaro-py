#!flask/bin/python
from marshmallow import Schema, fields

from app.api.schemas.departamento import DepartamentoSchema


class UniversidadSchema(Schema):
    id = fields.Number()
    codigo = fields.Str()
    nombre = fields.Str()
    departamentos = fields.List(fields.Nested(DepartamentoSchema))
