#coding=utf-8

from flask import send_from_directory

from config import config
from vojaro.main import bp

@bp.route('/')
@bp.route('/index')
def index():
    return send_from_directory(config.STATIC_FOLDER, 'index.html')

@bp.route('/ping')
def ping():
    return 'Pong!'
