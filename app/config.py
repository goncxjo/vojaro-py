#!flask/bin/python

"""
Global Flask Application Setting

See `.flaskenv` for default settings.
 """

import os

basedir = os.path.abspath(os.path.dirname(__file__))

DB_NAME = 'vojaro'
DB_PATH = 'postgres:root@localhost:5432/{}'.format(DB_NAME)
DB_URI = 'postgresql://' + DB_PATH


class Config(object):
    # If not set fall back to production for safety
    FLASK_ENV =  os.getenv('FLASK_ENV', 'production')
    # Set FLASK_SECRET on your production Environment
    SECRET_KEY = os.getenv('FLASK_SECRET', 'Secret')

    APP_DIR = os.path.dirname(__file__)
    ROOT_DIR = os.path.dirname(APP_DIR)
    DIST_DIR = os.path.join(ROOT_DIR, 'dist')

    SQLALCHEMY_DATABASE_URI = os.getenv('DATABASE_URL') or DB_URI
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    
    if FLASK_ENV == 'production':
        DEBUG = False
        TESTING = False

        if not os.path.exists(DIST_DIR):
            raise Exception('DIST_DIR not found: {}'.format(DIST_DIR))

    if FLASK_ENV == 'development':
        DEBUG = True
        TESTING = False
