""" Security Related things """
from functools import wraps
from flask import request, g
from flask_restx import abort
from app.models import Usuario

def verify_password(username, password):
    user = Usuario.query.filter_by(nombre_usuario=username).first()
    if user is None:
        return False
    g.current_user = user
    return user.check_password(password)

def require_auth(func):
    """ Secure method decorator """
    @wraps(func)
    def wrapper(*args, **kwargs):
        # Verify if User is Authenticated
        # Authentication logic goes here
        user = request.authorization
        if request.headers.get('authorization') and verify_password(user.username, user.password):
            return func(*args, **kwargs)
        else:
            return abort(401)
    return wrapper

# def verify_token(func):
#     """ Secure method decorator """
#     @wraps(func)
#     def wrapper(*args, **kwargs):
#         g.current_user = Usuario.check_token(token) if token else None
#         if g.current_user is not None:
#             return func(*args, **kwargs)
#         else:
#             return abort(401)
#     return wrapper
