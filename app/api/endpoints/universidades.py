#!flask/bin/python
from flask import request
from flask_restx import Resource

from app.api import api
from app.api.auth import token_auth
from app.api.serializers import universidad_model
from app.api.business import universidades

ns = api.namespace('universidades', description='Operaciones relacionadas a universidades')


class SecureResource(Resource):
    method_decorators = [token_auth.verify_token]


@ns.route('/')
class UniversidadCollection(SecureResource):
    
    @api.marshal_list_with(universidad_model)
    def get(self):
        """
        Devuelve una lista de universidades
        """
        return universidades.get_all()

    @api.expect(universidad_model)
    @api.response(201, 'Universidad creada satisfactoriamente')
    def post(self):
        """
        Crea una nueva universidad
        """
        data = request.json
        universidades.create(data)
        return None, 201


@ns.route('/<int:id>')
class UniversidadItem(SecureResource):

    @api.marshal_with(universidad_model)
    def get(self, id):
        """
        Devuelve una universidad en base a su ID
        """
        return universidades.get(id)

    @api.expect(universidad_model)
    @api.response(204, 'Universidad actualizada satisfactoriamente')
    def put(self, id):
        """
        Actualiza una universidad
        """
        data = request.json
        universidades.update(id, data)
        return None, 204

    @api.response(204, 'Universidad borrada satisfactoriamente.')
    def delete(self, id):
        """
        Borra una universidad
        """
        universidades.delete(id)
        return None, 204
