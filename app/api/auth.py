from flask import jsonify, g
from flask_restx import Resource

from . import api_rest
from .security import require_auth

from app import db

class SecureResource(Resource):
    """ Calls require_auth decorator on all requests """
    method_decorators = [require_auth]

@api_rest.route('/auth/token')
class AuthToken(SecureResource):
    """ Unsecure Resource Class: Inherit from Resource """

    def post(self):
        token = g.current_user.get_token()
        db.session.commit()
        return jsonify({ 'token': token })

@api_rest.route('/auth/logout')
class AuthLogout(Resource):
    """ Unsecure Resource Class: Inherit from Resource """

    def post(self):
        pass
