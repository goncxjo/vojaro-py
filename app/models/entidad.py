#!flask/bin/python
from datetime import datetime

from app import db


class EntidadMixin(object):
    id = db.Column(db.Integer, primary_key=True)


class EntidadAuditadaMixin(object):
    id = db.Column(db.Integer, primary_key=True)
    creado = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    modificado = db.Column(db.DateTime, onupdate=datetime.utcnow)
