#!flask/bin/python
from flask import g
from flask_restx import abort
from flask_httpauth import HTTPBasicAuth, HTTPTokenAuth
from sqlalchemy.orm.exc import NoResultFound
from app.models.usuario import Usuario

basic_auth = HTTPBasicAuth()
token_auth = HTTPTokenAuth()


@basic_auth.verify_password
def verify_password(username, password):
    try:
        user = Usuario.query.filter_by(nombre_usuario=username).one()
        g.current_user = user
        return user.check_password(password)
    except NoResultFound:
        return False


@basic_auth.error_handler
def basic_auth_error():
    return abort(401, message="Credenciales no válidas")


@token_auth.verify_token
def verify_token(token):
    g.current_user = Usuario.check_token(token) if token else None
    return g.current_user is not None


@token_auth.error_handler
def token_auth_error():
    return abort(401, message="Token expirado")
