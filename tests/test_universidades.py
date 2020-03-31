#!flask/bin/python
import pytest
import json

from app.models.universidad import Universidad
from app.api.services.universidades import UniversidadService


def test_get_all(session):
    service = UniversidadService(session)

    undav = {'codigo': 'undav', 'nombre': 'universidad nacional de avellaneda'}
    data_undav = json.loads(json.dumps(undav))
    service.create(data_undav)

    unaj = {'codigo': 'unaj', 'nombre': 'universidad nacional arturo jauretche'}
    data_unaj = json.loads(json.dumps(unaj))
    service.create(data_unaj)

    universidades = service.get_all()
    for u in universidades:
        assert u.id > 0


def test_post_model(session):
    service = UniversidadService(session)
    request = {'codigo': 'undav', 'nombre': 'universidad nacional de avellaneda', 'departamentos': []}
    data = json.loads(json.dumps(request))
    universidad = service.create(data)

    assert universidad.id > 0


def test_get_paginated_without_filtering_and_sorting(session):
    service = UniversidadService(session)

    undav = {'codigo': 'undav', 'nombre': 'universidad nacional de avellaneda'}
    data_undav = json.loads(json.dumps(undav))
    service.create(data_undav)

    unaj = {'codigo': 'unaj', 'nombre': 'universidad nacional arturo jauretche'}
    data_unaj = json.loads(json.dumps(unaj))
    service.create(data_unaj)

    unq = {'codigo': 'unq', 'nombre': 'universidad nacional de quilmes'}
    data_unq = json.loads(json.dumps(unq))
    service.create(data_unq)

    unla = {'codigo': 'unla', 'nombre': 'universidad nacional de lanus'}
    data_unla = json.loads(json.dumps(unla))
    service.create(data_unla)

    universidades = service.get_paginated(page=2, per_page=1)

    print('__')
    for u in universidades['items']:
        print(u)

    for u in universidades['items']:
        assert u.codigo == 'unaj'
