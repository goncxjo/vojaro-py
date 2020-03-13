from datetime import datetime
from flask import request, jsonify
from flask_restx import Resource

from . import api_rest
from .security import require_auth

from app import db
from app.models import Universidad
from app.schemas import UniversidadSchema

@api_rest.route('/universidades')
class UniversidadesAll(Resource):
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
        # mount universidad object
        posted_universidad = UniversidadSchema(only=('codigo', 'nombre'))\
            .load(request.get_json())

        universidad = Universidad(**posted_universidad, creado_por="HTTP post request")
        # persist universidad
        db.session.add(universidad)
        db.session.commit()
        # return created universidad
        new_universidad = UniversidadSchema().dump(universidad)
        db.session.close()

        return jsonify(new_universidad), 201

@api_rest.route('/universidades/<int:id>')
class UniversidadOne(Resource):
    """ Unsecure Universidad Class: Inherit from Resource """

    def get(self, id):
        # fetching from the database
        universidades_object = Universidad.query.filter_by(id=id).first_or_404(description='No existe esa universidad')
        # transforming into JSON-serializable objects
        universidad = UniversidadSchema().dump(universidades_object)
        # serializing as JSON
        db.session.close()

        return jsonify(universidad)
