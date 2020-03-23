#!flask/bin/python
from datetime import datetime

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

from .universidad import Universidad
from .usuario import Usuario