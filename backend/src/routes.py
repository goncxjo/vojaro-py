#coding=utf-8

from src import app, db

from flask import jsonify, request
from src.entities.universidad import Universidad, UniversidadSchema

@app.route('/universidades')
def get_universidades():
    # fetching from the database
    universidades_objects = db.session.query(Universidad).all()

    # transforming into JSON-serializable objects
    schema = UniversidadSchema(many=True)
    universidades = schema.dump(universidades_objects)

    # serializing as JSON
    db.session.close()
    return jsonify(universidades)

@app.route('/universidades', methods=['POST'])
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