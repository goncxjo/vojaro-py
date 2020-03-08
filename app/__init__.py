#coding=utf-8
import os
from config import Config

from flask import Flask
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

# creating the Flask application
app = Flask(__name__)
app.config.from_object(Config)

db = SQLAlchemy(app)
migrate = Migrate(app, db)

from app import routes
from app.models import Entity, Universidad

if __name__ == "__main__":
    app.run()
