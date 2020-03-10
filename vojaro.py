import os
from vojaro import db, app
from vojaro.models import Universidad

@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad }

if __name__ == '__main__':
    app.run()
