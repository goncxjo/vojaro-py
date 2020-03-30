""" pytests for Flask """

import pytest
from app import create_app

@pytest.fixture(scope="module")
def client():
    settings_override = {
        'TESTING': True,
    }

    app = create_app(settings_override)
    return app.test_client()

def test_backend(client):
    resp = client.get('/api/')
    assert resp.status_code == 200

def test_frontend(client):
    resp = client.get('/')
    assert resp.status_code == 200
