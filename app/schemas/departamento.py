#!flask/bin/python
from marshmallow import Schema, fields


class DepartamentoSchema(Schema):
    id = fields.Number(missing=0)
    nombre = fields.Str()
