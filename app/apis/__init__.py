#!flask/bin/python
from flask import Blueprint
from flask_restx import Api

blueprint = Blueprint('api', __name__, url_prefix='/api')
api = Api(blueprint)


@blueprint.after_request
def add_header(response):
    response.headers['Access-Control-Allow-Headers'] = 'Content-Type,Authorization'
    return response


from .auth import api as auth_namespace
from .usuarios import api as usuarios_namespace
from .universidades import api as universidades_namespace

api.add_namespace(auth_namespace)
api.add_namespace(usuarios_namespace)
api.add_namespace(universidades_namespace)
