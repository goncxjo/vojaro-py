#!flask/bin/python
from flask import request, jsonify, Response
from flask_restx import Resource, Namespace

from .security import require_authorization, verify_password
from app import db
from app.models.universidad import Universidad
from app.schemas.universidad import UniversidadSchema

api = Namespace('universidades')


class SecureResource(Resource):
    """ Calls require_authorization decorator on all requests """
    method_decorators = [require_authorization, verify_password]


@api.route('/')
class UniversidadesList(SecureResource):
    def get(self):
        query = Universidad.query.all()
        universidades = UniversidadSchema(many=True).dump(query)
        db.session.close()
        return jsonify(universidades)

    def post(self):
        user = request.authorization
        posted_universidad = UniversidadSchema(only=('codigo', 'nombre')) \
            .load(request.get_json())
        universidad = Universidad(**posted_universidad, creado_por=user.username)
        db.session.add(universidad)
        db.session.commit()
        new_universidad = UniversidadSchema().dump(universidad)
        db.session.close()

        response = Response(new_universidad, status=201, mimetype='application/json')
        return response


@api.route('/<int:id>')
class UniversidadEntity(SecureResource):
    def get(self, id):
        universidad_object = Universidad.query.filter_by(id=id).first_or_404()
        universidad = UniversidadSchema().dump(universidad_object)
        db.session.close()
        return jsonify(universidad)

    def put(self, id):
        model_json = request.get_json()
        target_universidad = UniversidadSchema(only=('codigo', 'nombre')) \
            .load(model_json)
        universidad_object = Universidad.query.filter_by(id=id).first_or_404()
        universidad_object.codigo = target_universidad['codigo']
        universidad_object.nombre = target_universidad['nombre']
        db.session.commit()
        updated_universidad = UniversidadSchema().dump(universidad_object)
        db.session.close()
        response = Response(updated_universidad, status=200, mimetype='application/json')
        return response
