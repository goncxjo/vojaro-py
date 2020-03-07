import os

db_url = 'localhost:5432'
db_name = 'vojaro'
db_user = 'postgres'
db_password = 'v0j4r0'

class Config(object):
    SQLALCHEMY_DATABASE_URI = os.environ.get('DATABASE_URL') or \
        'postgresql://' + db_user + ':' + db_password + '@' + db_url + '/' + db_name
    SQLALCHEMY_TRACK_MODIFICATIONS = False