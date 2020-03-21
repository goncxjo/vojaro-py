from flask_restx import fields
from . import api

universidad_model = api.model('Universidad', {
    'id': fields.Integer(readOnly=True),
    'codigo': fields.String(readOnly=True),
    'nombre': fields.String(required=True),
})
