#!flask/bin/python
from datetime import datetime

from sqlalchemy import text

from app import db


class EntidadMixin(object):
    id = db.Column(db.Integer, primary_key=True)


class EntidadAuditadaMixin(object):
    id = db.Column(db.Integer, primary_key=True)
    creado = db.Column(db.DateTime, nullable=False, default=datetime.utcnow)
    modificado = db.Column(db.DateTime, onupdate=datetime.utcnow)

    @classmethod
    def sort(cls, **kwargs):
        columns_order = kwargs.pop('columns_order', '')
        if columns_order:
            return cls.query.order_by(text(columns_order))
        else:
            return cls.query
