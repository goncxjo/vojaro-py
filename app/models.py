# coding=utf-8

from datetime import datetime

from werkzeug.security import generate_password_hash, check_password_hash

from app import db

class Entity():
    id = db.Column(db.Integer, primary_key=True)
    creado = db.Column(db.DateTime)
    modificado = db.Column(db.DateTime, default=datetime.utcnow)
    modificado_por = db.Column(db.String)

    def __init__(self, creado_por):
        self.creado = datetime.now()
        self.modificado = datetime.now()
        self.modificado_por = creado_por

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

class Usuario(db.Model, Entity):
    __tablename__ = 'Usuarios'
    
    nombre_usuario = db.Column(db.String(64), index=True, unique=True)
    email = db.Column(db.String(120), index=True, unique=True)
    password_hash = db.Column(db.String(128))

    def __init__(self, codigo, nombre, creado_por):
        Entity.__init__(self, creado_por)
        self.codigo = codigo
        self.nombre = nombre
    
    def __repr__(self):
        return '<Usuario {}>'.format(self.nombre_usuario)
    
    def set_password(self, password):
        self.password_hash = generate_password_hash(password)
    
    def check_password(self, password):
        return check_password_hash(self.password_hash, password)

