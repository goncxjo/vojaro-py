# coding=utf-8

from src import db
from marshmallow import Schema, fields
from werkzeug.security import generate_password_hash, check_password_hash

from .entity import Entity

class Usuario(db.Model, Entity):
    __tablename__ = 'Usuario'
    
    nick = db.Column(db.String(64), index=True, unique=True)
    email = db.Column(db.String(120), index=True, unique=True)
    password_hash = db.Column(db.String(128))

    def __init__(self, codigo, nombre, creado_por):
        Entity.__init__(self, creado_por)
        self.codigo = codigo
        self.nombre = nombre
    
    def __repr__(self):
        return '<Usuario {}>'.format(self.nick)
    
    def set_password(self, password):
        self.password_hash = generate_password_hash(password)
    
    def check_password(self, password):
        return check_password_hash(self.password_hash, password)

class UsuarioSchema(Schema):
    id = fields.Number()
    nick = fields.Str()
    email = fields.Str()
    password_hash = fields.Str()
    creado = fields.DateTime()
    modificado = fields.DateTime()
    modificado_por = fields.Str()
