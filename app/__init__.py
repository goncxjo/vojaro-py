#!flask/bin/python
import os

from flask import Flask, send_file
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

from .config import Config

db = SQLAlchemy()
migrate = Migrate()


def create_app(settings={}):
    """ Initialize the core application """

    app = Flask(__name__, static_folder='../dist/static')
    app.config.from_object(Config)
    app.config.update(settings)

    # Initialize Plugins
    db.init_app(app)
    migrate.init_app(app, db)

    with app.app_context():
        from .api import blueprint as api
        app.register_blueprint(api)

        from .client import client_bp as client
        app.register_blueprint(client)

        return app


from .models import *
