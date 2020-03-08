from marshmallow import Schema, fields

class UsuarioSchema(Schema):
    id = fields.Number()
    nick = fields.Str()
    email = fields.Str()
    password_hash = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()

class UniversidadSchema(Schema):
    id = fields.Number()
    codigo = fields.Str()
    nombre = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()