from api import app, db
from api.models import Universidad

@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad }