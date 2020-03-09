#coding=utf-8

import os
from config import Config

from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

# creating the Flask application
app = Flask(__name__, static_url_path='', static_folder='../vojaro-angular/dist/vojaro-angular', template_folder='../vojaro-angular/dist/vojaro-angular')
app.config.from_object(Config)
db = SQLAlchemy(app)
migrate = Migrate(app, db)

from app.api import api
app.register_blueprint(api, url_prefix='/api')

from app import routes
from app.models import Entity, Universidad

if __name__ == '__main__':
    app.run(debug=True)
