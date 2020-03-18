from datetime import datetime
from flask import request, jsonify, Response
from flask_restx import Resource

from . import api_rest
from .security import require_auth

from app import db
from app.models import Usuario
from app.schemas import UsuarioSchema

class SecureResource(Resource):
    """ Calls require_auth decorator on all requests """
    method_decorators = [require_auth]

@api_rest.route('/usuarios')
class UsuariosRoot(SecureResource):
    """ Unsecure Usuarioes Class: Inherit from Resource """

    def get(self):
        # fetching from the database
        usuarios_objects = Usuario.query.all()
        # transforming into JSON-serializable objects
        schema = UsuarioSchema(many=True)
        usuarios = schema.dump(usuarios_objects)
        # serializing as JSON
        db.session.close()

        return jsonify(usuarios)

    def post(self):
        model_json = request.get_json()
        # mount usuario object
        posted_usuario = UsuarioSchema(only=('nombre_usuario', 'password'))\
            .load(model_json)
        usuario = Usuario(**posted_usuario, creado_por="HTTP post request")
        # persist usuario
        db.session.add(usuario)
        db.session.commit()
        # return created usuario
        new_usuario = UsuarioSchema().dump(usuario)
        db.session.close()

        response = Response(new_usuario, status=201, mimetype='application/json')
        return response
