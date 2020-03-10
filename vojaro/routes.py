#coding=utf-8

from vojaro import app
from config import config
from flask import send_from_directory

@app.route('/')
@app.route('/index')
def index():
    return send_from_directory(config.STATIC_FOLDER, 'index.html')

@app.route('/ping')
def ping():
    return 'Pong!'
