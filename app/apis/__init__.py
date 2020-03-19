#!flask/bin/python
from flask import Blueprint
from flask_restx import Api
from flask_cors import CORS

blueprint = Blueprint('api', __name__, url_prefix='/api')
CORS(blueprint
    , allow_headers=['Content-Type', 'Authorization', 'Access-Control-Allow-Headers']
    , supports_credentials=True)

api = Api(blueprint)

from .auth import api as auth_namespace
from .usuarios import api as usuarios_namespace
from .universidades import api as universidades_namespace

api.add_namespace(auth_namespace)
api.add_namespace(usuarios_namespace)
api.add_namespace(universidades_namespace)
