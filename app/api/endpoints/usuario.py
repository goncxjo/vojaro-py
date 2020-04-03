#!flask/bin/python
from flask import request, jsonify, Response
from flask_restx import Resource

from app import db
from app.models.usuario import Usuario
from app.api import api
from app.api.auth import token_auth
from app.api.schemas.usuario import UsuarioSchema

ns = api.namespace('usuarios')


class SecureResource(Resource):
    """ Calls require_auth decorator on all requests """
    method_decorators = [token_auth.verify_token]


@ns.route('/')
class UsuarioCollection(SecureResource):
    def get(self):
        usuarios_objects = Usuario.query.all()
        usuarios = UsuarioSchema(many=True).dump(usuarios_objects)
        db.session.close()
        return jsonify(usuarios)

    def post(self):
        user = request.authorization
        posted_usuario = UsuarioSchema(only=('nombre_usuario', 'password'))\
            .load(request.get_json())
        usuario = Usuario(**posted_usuario)
        db.session.add(usuario)
        db.session.commit()
        new_usuario = UsuarioSchema().dump(usuario)
        db.session.close()
        response = Response(new_usuario, status=201, mimetype='application/json')
        return response

