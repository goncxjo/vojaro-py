#!flask/bin/python
import os

from app import create_app, db
from app.models.universidad import Universidad
from app.models.departamento import Departamento
from app.models.usuario import Usuario

app = create_app()


@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad, 'Departamento': Departamento, 'Usuario': Usuario }

if __name__ == '__main__':
    app.run(port=5000)
