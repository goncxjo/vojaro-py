import os

from flask import Flask, send_file
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

from .config import Config

db = SQLAlchemy()
migrate = Migrate()

#def create_app():
app = Flask(__name__, static_folder='../dist/static')
app.config.from_object('app.config.Config')
app.logger.info('>>> {}'.format(Config.FLASK_ENV))

db.init_app(app)
migrate.init_app(app, db)

from .api import api_bp
app.register_blueprint(api_bp)

@app.route('/')
def index():
    return "Ready!"

#return app

from app import models