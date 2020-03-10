#coding=utf-8

from flask import send_from_directory

from vojaro import db
from vojaro.errors import bp

@bp.app_errorhandler(404)
def not_found_error():
    return render_template('errors/404.html'), 404

@bp.app_errorhandler(500)
def internal_error(error):
    db.session.rollback()
    return render_template('errors/500.html'), 500
