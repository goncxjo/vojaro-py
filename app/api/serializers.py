from flask_restx import fields
from . import api

universidad_list_model = api.model('UniversidadList', {
    'id': fields.Integer(readOnly=True),
    'codigo': fields.String(readOnly=True),
    'nombre': fields.String(required=True),
})

departamento_model = api.model('Departamento', {
    'id': fields.Integer(readOnly=True),
    'nombre': fields.String(readOnly=True),
})

universidad_model = api.inherit('Universidad', universidad_list_model, {
    'departamentos': fields.List(fields.Nested(departamento_model), required=True),
})
