import os

basedir = os.path.join(os.path.dirname(os.path.realpath(__file__)))

db_url = 'localhost:5432'
db_name = 'vojaro'
db_user = 'postgres'
db_password = 'v0j4r0'

class Config:
    SECRET_KEY = os.environ.get('SECRET_KEY')
    STATIC_FOLDER = os.path.join(basedir, 'vojaro', 'static', 'dist', 'vojaro-angular')
    SQLALCHEMY_DATABASE_URI = os.environ.get('DATABASE_URL') or \
        'postgresql://' + db_user + ':' + db_password + '@' + db_url + '/' + db_name

class DevelopmentConfig(Config):
    DEBUG = True
    SECRET_KEY = os.environ.get('SECRET_KEY') or 'secret_key_here'
    SQLALCHEMY_TRACK_MODIFICATIONS = False

class TestingConfig(Config):
    TESTING = True
    SECRET_KEY = os.environ.get('SECRET_KEY') or 'secret_key_here'
    SQLALCHEMY_TRACK_MODIFICATIONS = False

class ProductionConfig(Config):
    SECRET_KEY = os.environ.get('SECRET_KEY') or 'secret_key_here'
    SQLALCHEMY_TRACK_MODIFICATIONS = True

dic_config = {
	'dev': DevelopmentConfig,
	'test':	TestingConfig,
	'prod': ProductionConfig,
	'default': DevelopmentConfig
}

config = dic_config[os.getenv('FLASK_CONFIG') or 'default']