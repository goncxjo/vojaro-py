from flask import jsonify, g
from flask_restx import Namespace, Resource

from app import db
from app.api import api
from app.api.auth import basic_auth

ns = api.namespace('tokens')


@ns.route('/')
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
