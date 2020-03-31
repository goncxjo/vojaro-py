#!flask/bin/python
from app import db
from app.models.entidad import EntidadMixin


class Departamento(EntidadMixin, db.Model):
    __tablename__ = 'Departamentos'

    nombre = db.Column(db.String)
    universidad_id = db.Column(db.Integer, db.ForeignKey('Universidades.id'), nullable=False)

    def __init__(self, nombre=''):
        self.nombre = nombre

    def __repr__(self):
        return '<Departamento {}>'.format(self.nombre)
