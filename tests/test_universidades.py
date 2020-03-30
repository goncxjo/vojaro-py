#!flask/bin/python
import pytest
import json

from app.models.universidad import Universidad
from app.api.services.universidades import UniversidadService


def test_post_model(session):
    service = UniversidadService(session)
    request = {'codigo':'undav', 'nombre':'universidad nacional de avellaneda', 'departamentos':[]}
    data = json.loads(json.dumps(request))
    universidad = service.create(data)

    assert universidad.id > 0
