from marshmallow import Schema, fields, validate

class UsuarioSchema(Schema):
    id = fields.Number()
    nick = fields.Str(required=True)
    email = fields.Str(required=True)
    password_hash = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()

class UniversidadSchema(Schema):
    id = fields.Number()
    codigo = fields.Str(required=True)
    nombre = fields.Str(required=True)
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()