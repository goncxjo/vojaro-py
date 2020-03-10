from vojaro import create_app, db
from vojaro.models import Universidad

app = create_app()

@app.shell_context_processor
def make_shell_context():
    return { 'db': db, 'Universidad': Universidad }

if __name__ == '__main__':
    app.run()
