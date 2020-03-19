#!flask/bin/python
from flask import jsonify, g
from flask_restx import Resource, Namespace

from .security import require_authorization, verify_password
from app import db

api = Namespace('auth')


class SecureResource(Resource):
    """ Calls require_auth decorator on all requests """
    method_decorators = [require_authorization, verify_password]


@api.route('/token')
class AuthToken(SecureResource):
    def post(self):
        token = g.current_user.get_token()
        db.session.commit()
        return jsonify({ 'token': token })


@api.route('/logout')
class AuthLogout(Resource):
    def post(self):
        pass
