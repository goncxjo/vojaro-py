#coding=utf-8

from flask import Flask
from config import Config
from flask_sqlalchemy import SQLAlchemy
from flask_migrate import Migrate

# creating the Flask application
app = Flask(__name__)
app.config.from_object(Config)
db = SQLAlchemy(app)
migrate = Migrate(app, db)

from src import routes
from .entities.entity import Entity
from .entities.universidad import Universidad
