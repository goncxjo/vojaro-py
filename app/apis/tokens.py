from flask import jsonify, g
from flask_restx import Namespace, Resource

from app import db
from .auth import basic_auth

api = Namespace('tokens')


class TokenAPI(Resource):
    method_decorators = [basic_auth.login_required]

    def post(self):
        token = g.current_user.get_token()
        db.session.commit()
        return jsonify({'token': token})

    def delete(self):
        g.current_user.revoke_token()
        db.session.commit()
        return '', 204


api.add_resource(TokenAPI, '/')
