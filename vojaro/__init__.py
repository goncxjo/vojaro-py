#coding=utf-8

import os
from config import config

from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

db = SQLAlchemy()

# creating the Flask application
app = Flask(__name__
            , static_folder=config.STATIC_FOLDER
            , static_url_path=''
            )
app.config.from_object(config)

# register blueprints
from vojaro.api import api
app.register_blueprint(api, url_prefix='/api')

# initialize any extensions we are using
db.init_app(app)
migrate = Migrate(app, db)

from vojaro import routes
from vojaro.models import Entity, Universidad
