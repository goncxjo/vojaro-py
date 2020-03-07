from src import app, db
from src.entities.universidad import Universidad

@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad }