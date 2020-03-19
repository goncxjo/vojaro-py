#!flask/bin/python
from marshmallow import Schema, fields


class UniversidadSchema(Schema):
    id = fields.Number()
    codigo = fields.Str()
    nombre = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()
