#!flask/bin/python

import traceback

from flask import Blueprint, current_app
from flask_restx import Api
from flask_cors import CORS
from sqlalchemy.orm.exc import NoResultFound

from app.config import Config

blueprint = Blueprint('api', __name__, url_prefix='/api')
CORS(blueprint
     , allow_headers=['Content-Type', 'Authorization', 'Access-Control-Allow-Headers']
     , supports_credentials=True)

api = Api(blueprint)


@api.errorhandler
def default_error_handler(e):
    message = 'Ha ocurrido una excepción no manejada.'

    if not Config.FLASK_ENV == 'production':
        return {'message': message}, 500


@api.errorhandler(NoResultFound)
def database_not_found_error_handler(e):
    current_app.logger.warning('>>> {}'.format(traceback.format_exc()))
    return {'message': 'Es necesaria una base de datos para continuar.'}, 404


from .endpoints.tokens import ns as tokens_namespace
from .endpoints.usuarios import ns as usuarios_namespace
from .endpoints.universidades import ns as universidades_namespace

api.add_namespace(tokens_namespace)
api.add_namespace(usuarios_namespace)
api.add_namespace(universidades_namespace)
