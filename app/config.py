"""
Global Flask Application Setting

See `.flaskenv` for default settings.
 """

import os

db_uri = 'postgresql://postgres:root@localhost:5432/vojaro'

class Config(object):
    # If not set fall back to production for safety
    FLASK_ENV =  os.getenv('FLASK_ENV', 'production')
    # Set FLASK_SECRET on your production Environment
    SECRET_KEY = os.getenv('FLASK_SECRET', 'Secret')

    APP_DIR = os.path.dirname(__file__)
    ROOT_DIR = os.path.dirname(APP_DIR)
    DIST_DIR = os.path.join(ROOT_DIR, 'dist')

    SQLALCHEMY_DATABASE_URI = os.getenv('DATABASE_URL') or db_uri
    SQLALCHEMY_TRACK_MODIFICATIONS = False

    if FLASK_ENV == 'production' and not os.path.exists(DIST_DIR):
        raise Exception(
            'DIST_DIR not found: {}'.format(DIST_DIR))
