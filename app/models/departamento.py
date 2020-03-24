#!flask/bin/python
from app import db
from app.models.entidad import Entidad


class Departamento(db.Model, Entidad):
    __tablename__ = 'Departamentos'

    nombre = db.Column(db.String)
    universidad_id = db.Column(db.Integer, db.ForeignKey('Universidades.id'), nullable=False)

    def __repr__(self):
        return '<Departamento {}>'.format(self.nombre)
