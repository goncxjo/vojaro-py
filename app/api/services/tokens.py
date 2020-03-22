from flask import g

from app import db


def get_user_token():
    token = g.current_user.get_token()
    db.session.commit()
    return token


def revoke_user_token():
    g.current_user.revoke_token()
    db.session.commit()

