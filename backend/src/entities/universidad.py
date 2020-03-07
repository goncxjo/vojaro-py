# coding=utf-8

from sqlalchemy import Column, String

from .entity import Entity, Base

class Universidad(Entity, Base):
    __tablename__ = 'Universidades'

    codigo = Column(String)
    nombre = Column(String)

    def __init__(self, codigo, nombre, created_by):
        Entity.__init__(self, created_by)
        self.codigo = codigo
        self.nombre = nombre
    