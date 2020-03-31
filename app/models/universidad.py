#!flask/bin/python
from app import db
from app.models.entidad import EntidadAuditadaMixin


class Universidad(EntidadAuditadaMixin, db.Model):
    __tablename__ = 'Universidades'

    codigo = db.Column(db.String, unique=True, nullable=False)
    nombre = db.Column(db.String, nullable=False)
    departamentos = db.relationship('Departamento', backref='Universidades', lazy='subquery')

    def __init__(self, codigo, nombre):
        self.codigo = codigo
        self.nombre = nombre

    def __repr__(self):
        return '<Universidad {}>'.format(self.codigo)
