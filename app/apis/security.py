# decorators
from functools import wraps
from flask import request, g
from flask_restx import abort

from app.models import Usuario


def require_authorization(func):
    """ Secure method decorator """
    @wraps(func)
    def wrapper(*args, **kwargs):
        if request.headers.get('authorization'):
            return func(*args, **kwargs)
        else:
            return abort(401)
    return wrapper


def verify_password(func):
    """ Secure method decorator """
    @wraps(func)
    def wrapper(*args, **kwargs):
        credentials = request.authorization
        if credentials is not None:
            user = Usuario.query.filter_by(nombre_usuario=credentials.username).first()
            if user is not None:
                g.current_user = user
                if user.check_password(credentials.password):
                    return func(*args, **kwargs)
        else:
            return abort(401)
    return wrapper
