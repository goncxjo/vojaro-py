#coding=utf-8

from vojaro import app, db
from vojaro.models import Universidad
from vojaro.schemas import UniversidadSchema

from flask import render_template, jsonify, request, Blueprint

api = Blueprint('api', __name__)

@api.route('/universidad/<int:id>')
def get_universidad(id):
    # fetching from the database
    universidades_object = Universidad.query.filter_by(id=id).first_or_404(description='No existe esa universidad')

    # transforming into JSON-serializable objects
    universidad = UniversidadSchema().dump(universidades_object)

    # serializing as JSON
    db.session.close()
    return jsonify(universidad)

@api.route('/universidades')
def get_universidades():
    # fetching from the database
    universidades_objects = Universidad.query.all()

    # transforming into JSON-serializable objects
    schema = UniversidadSchema(many=True)
    universidades = schema.dump(universidades_objects)

    # serializing as JSON
    db.session.close()
    return jsonify(universidades)

@api.route('/universidades', methods=['POST'])
def add_universidad():
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
