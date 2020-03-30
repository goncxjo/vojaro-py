#!flask/bin/python
import os
import pytest

from app import create_app, db as _db
from app.config import basedir

TEST_DB_NAME = 'test.db'
TEST_DB_PATH = os.path.join(basedir, 'test.db')
TEST_DB_URI = 'sqlite:///' + TEST_DB_PATH

# SETUP

@pytest.fixture(scope='session')
def app(request):
    """Session-wide test `Flask` application."""

    settings_override = {
        'TESTING': True,
        'SQLALCHEMY_DATABASE_URI': TEST_DB_URI
    }

    app = create_app(settings_override)

    # Establish an application context before running the tests.
    ctx = app.app_context()
    ctx.push()

    def teardown():
        ctx.pop()

    request.addfinalizer(teardown)
    return app


@pytest.fixture(scope='session')
def db(app, request):
    """Session-wide test database."""
    if os.path.exists(TEST_DB_PATH):
        os.unlink(TEST_DB_PATH)

    def teardown():
        _db.drop_all()
        os.unlink(TEST_DB_PATH)

    _db.app = app
    _db.create_all()

    request.addfinalizer(teardown)
    return _db


@pytest.fixture(scope='function')
def session(db, request):
    """Creates a new database session for a test."""
    connection = db.engine.connect()
    transaction = connection.begin()

    options = dict(bind=connection, binds={})
    session = db.create_scoped_session(options=options)

    db.session = session

    def teardown():
        transaction.rollback()
        connection.close()
        session.remove()

    request.addfinalizer(teardown)
    return session
