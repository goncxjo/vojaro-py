#!flask/bin/python
import os

from flask import current_app, send_file, Blueprint
from flask_cors import CORS

client_bp = Blueprint('client_app', __name__,
                      url_prefix='',
                      static_url_path='',
                      static_folder='./dist/static/',
                      template_folder='./dist/',
                      )
CORS(client_bp)


@client_bp.route('/', methods=['GET'])
def index_client():
    dist_dir = current_app.config['DIST_DIR']
    entry = os.path.join(dist_dir, 'index.html')
    return send_file(entry)
