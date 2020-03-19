#!flask/bin/python
import os

from app import app, db
from app.models import Universidad

@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad, 'Usuarios': Usuarios }

if __name__ == '__main__':
    app.run(port=5000)


# To Run:
# python run.py
# or
# python -m flask run
