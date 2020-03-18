from datetime import datetime
from flask import request, jsonify, Response
from flask_restx import Resource

from . import api_rest
from .security import require_auth

from app import db
from app.models import Universidad
from app.schemas import UniversidadSchema

class SecureResource(Resource):
    """ Calls require_auth decorator on all requests """
    method_decorators = [require_auth]

@api_rest.route('/universidades')
class UniversidadesRoot(SecureResource):
    """ Unsecure Universidades Class: Inherit from Resource """

    def get(self):
        # fetching from the database
        universidades_objects = Universidad.query.all()
        # transforming into JSON-serializable objects
        schema = UniversidadSchema(many=True)
        universidades = schema.dump(universidades_objects)
        # serializing as JSON
        db.session.close()

        return jsonify(universidades)

    def post(self):
        model_json = request.get_json()
        # mount universidad object
        posted_universidad = UniversidadSchema(only=('codigo', 'nombre'))\
            .load(model_json)
        universidad = Universidad(**posted_universidad, creado_por="HTTP post request")
        # persist universidad
        db.session.add(universidad)
        db.session.commit()
        # return created universidad
        new_universidad = UniversidadSchema().dump(universidad)
        db.session.close()

        response = Response(new_universidad, status=201, mimetype='application/json')
        return response
        
@api_rest.route('/universidades/<int:id>')
class UniversidadId(SecureResource):
    """ Unsecure Universidad Class: Inherit from Resource """

    def get(self, id):
        # fetching from the database
        universidad_object = Universidad.query.filter_by(id=id).first_or_404()
        # transforming into JSON-serializable objects
        universidad = UniversidadSchema().dump(universidad_object)
        # serializing as JSON
        db.session.close()

        return jsonify(universidad)

    def put(self, id):
        model_json = request.get_json()
        # mount universidad object
        target_universidad = UniversidadSchema(only=('codigo', 'nombre'))\
            .load(model_json)
        universidad_object = Universidad.query.filter_by(id=id).first_or_404()
        universidad_object.codigo = target_universidad['codigo']
        universidad_object.nombre = target_universidad['nombre']
        # persist universidad
        db.session.commit()
        # transforming into JSON-serializable objects
        updated_universidad = UniversidadSchema().dump(universidad_object)
        # serializing as JSON
        db.session.close()

        response = Response(updated_universidad, status=200, mimetype='application/json')
        return response