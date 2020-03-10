#coding=utf-8

from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

from config import config

db = SQLAlchemy()
migrate = Migrate()

def create_app():
    # creating the Flask application
    app = Flask(__name__, static_folder=config.STATIC_FOLDER, static_url_path='')
    app.config.from_object(config)

    # initialize any extensions we are using
    db.init_app(app)
    migrate.init_app(app, db)

    # register blueprints
    from vojaro.api import bp as api_bp
    app.register_blueprint(api_bp, url_prefix='/api')

    from vojaro.api import bp as main_bp
    app.register_blueprint(main_bp)

    return app

from vojaro import models
