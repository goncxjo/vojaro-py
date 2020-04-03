from flask import jsonify, g
from flask_restx import Resource

from app.api import api
from app.api.auth import basic_auth
from app.api.services import token as service

ns = api.namespace('tokens')


@ns.route('/')
class TokenAPI(Resource):
    method_decorators = [basic_auth.login_required]

    def post(self):
        token = service.get_user_token()
        return jsonify({'token': token, 'avatar': g.current_user.avatar()})

    @api.response(204, 'Token revocado.')
    def delete(self):
        service.revoke_user_token()
        return None, 204
