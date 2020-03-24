#!flask/bin/python
from flask import request
from flask_restx import Resource, abort
from sqlalchemy.orm.exc import NoResultFound

from app.api import api
from app.api.auth import token_auth
from app.api.serializers import universidad_list_model, universidad_model
from app.api.services import universidades as service

ns = api.namespace('universidades', description='Operaciones relacionadas a universidades')


class SecureResource(Resource):
    method_decorators = [token_auth.verify_token]


@ns.route('/')
class UniversidadCollection(SecureResource):
    
    @api.marshal_list_with(universidad_list_model)
    def get(self):
        """
        Devuelve una lista de universidades
        """
        return service.get_all()

    @api.expect(universidad_model)
    @api.response(201, 'Universidad creada.')
    def post(self):
        """
        Crea una nueva universidad
        """
        data = request.json
        service.create(data)
        return None, 201


@ns.route('/<int:id>')
class UniversidadItem(SecureResource):

    @api.marshal_with(universidad_model)
    def get(self, id):
        """
        Devuelve una universidad en base a su ID
        """
        try:
            universidades = service.get(id)
            return universidades
        except NoResultFound:
            abort(404, 'No existe una universidad con ese identificador')

    @api.expect(universidad_model)
    @api.response(204, 'Universidad actualizada.')
    def put(self, id):
        """
        Actualiza una universidad
        """
        try:
            data = request.json
            service.update(id, data)
            return None, 204
        except NoResultFound:
            abort(404, 'No existe una universidad con ese identificador')

    @api.response(204, 'Universidad borrada.')
    def delete(self, id):
        """
        Borra una universidad
        """
        try:
            service.delete(id)
            return None, 204
        except NoResultFound:
            abort(404, 'No existe una universidad con ese identificador')
