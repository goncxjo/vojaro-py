#coding=utf-8

from app import app, db
from app.models import Universidad
from app.schemas import UniversidadSchema

from flask import render_template, jsonify, request

@app.route('/')
@app.route('/index')
def index():
    return render_template('index.html')

@app.route('/ping')
def ping():
    return 'Pong!'

@app.route('/api/universidades')
def get_universidades():
    # fetching from the database
    universidades_objects = Universidad.query.all()

    # transforming into JSON-serializable objects
    schema = UniversidadSchema(many=True)
    universidades = schema.dump(universidades_objects)

    # serializing as JSON
    db.session.close()
    return jsonify(universidades)

@app.route('/api/universidades', methods=['POST'])
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
